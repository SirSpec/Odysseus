import React, { useState, useEffect } from 'react';

import * as signalR from "@microsoft/signalr"

import PlayerStatusContainer from "../PlayerStatus/PlayerStatusContainer";
import GameMenu from "../GameMenu/GameMenu";
import InteractionMenuContainer from "../InteractionMenu/InteractionMenuContainer";
import ActivityLogContainer from "../ActivityLog/ActivityLogContainer";
import ContextMenuContainer from "../ContextMenu/ContextMenuContainer";
import MapContainer from "../Map/MapContainer";
import RayCastingViewContainer from "../RayCasting/RayCastingViewContainer";

import styles from "../../styles/gameWindow.scss";

const PlayerConfiguration = {
    playerPosition: { x: 0.5, y: 0.5 },
    rotationSpeed: 0.1,
    moveSpeed: 0.2
}

const CanvasConfiguration = {
    width: Math.floor(window.innerWidth / 2.5),
    height: window.innerHeight
}

let GameWindow = (props) => {
    const [connection, setConnection] = useState(null);
    const [isRayCastingOpened, setIsRayCastingOpened] = useState(false);
    const [logs, setLogs] = useState([]);

    useEffect(() => {
        var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:5001/hub").build()
        connection.on("ReceiveMap", map => {
            props.setMap(map);
        })

        connection.on("ReceiveMobsPosition", mobsPosition => {
            props.setMobs(mobsPosition);
        })

        connection.on("GetScaned", targets => {
            props.setTargets(targets);
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
                    <PlayerStatusContainer />
                    <GameMenu handleChangeView={() => setIsRayCastingOpened(!isRayCastingOpened)} />
                </div>
                <div className={`${styles.row} ${styles.flex1}`}>
                    <div className={`${styles.column} ${styles.flex1}`}>
                        <InteractionMenuContainer />
                        <ActivityLogContainer />
                    </div>
                    <ContextMenuContainer />
                </div>
            </div>
        </div>
    );
};

export default GameWindow;