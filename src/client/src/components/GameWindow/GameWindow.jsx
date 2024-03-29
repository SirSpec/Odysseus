import React, { useState, useEffect } from 'react';

import * as signalR from "@microsoft/signalr"

import Configuration from "../../constants/Configuration"

import GameMenu from "../GameMenu/GameMenu";
import ActivityLogContainer from "../ActivityLog/ActivityLogContainer";
import MapContainer from "../Map/MapContainer";
import RayCastingViewContainer from "../RayCasting/RayCastingViewContainer";

import styles from "../../styles/gameWindow.scss";

const PlayerConfiguration = {
    playerPosition: { x: 0.5, y: 0.5 },
    rotationSpeed: 0.1,
    moveSpeed: 0.2
}

const CanvasConfiguration = {
    width: Math.floor(window.innerWidth / 1.5),
    height: window.innerHeight
}

let GameWindow = (props) => {
    const [connection, setConnection] = useState(null);
    const [isRayCastingOpened, setIsRayCastingOpened] = useState(false);
    const [logs, setLogs] = useState([]);

    useEffect(() => {
        var connection = new signalR.HubConnectionBuilder()
            .withUrl(Configuration.BackendHubUrl)
            .build();

        connection.on("ReceiveMap", map => {
            props.setMap(map);
        })

        connection.on("ReceiveMobsPosition", mobsPosition => {
            props.setMobs(mobsPosition);
        })

        connection.on("ReceiveLog", log => {
            setLogs(logs => ([log, ...logs]));
        })

        connection.start().then(() => {
            console.log("GameWindow component connection started.")
            connection.invoke("SendMap").catch(err => {
                console.log(err.toString());
            });
        }).catch(err => {
            console.log(err.toString());
        });

        setConnection(connection)
    }, []);

    return (
        <div className={styles.full_height}>
            {isRayCastingOpened
                ? <RayCastingViewContainer
                    canvasConfiguration={CanvasConfiguration}
                    playerConfiguration={PlayerConfiguration} />
                : <MapContainer canvasConfiguration={CanvasConfiguration} />
            }
            <div className={styles.column}>
                <div className={styles.row}>
                    <GameMenu handleChangeView={() => setIsRayCastingOpened(!isRayCastingOpened)} />
                </div>
                <div className={`${styles.row} ${styles.flex1}`}>
                    <div className={`${styles.column} ${styles.flex1}`}>
                        <ActivityLogContainer />
                    </div>
                </div>
            </div>
        </div>
    );
};

export default GameWindow;