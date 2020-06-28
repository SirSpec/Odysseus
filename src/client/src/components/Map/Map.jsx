import React, { useState, useEffect } from 'react';
import PropTypes from "prop-types";
import * as signalR from "@microsoft/signalr"
import Canvas from "./Canvas";
import InputService from "./InputService";
import MapService from "./MapService";

import styles from "../../styles/gameWindow";

const DisplayOptions = {
    tileSize: 20,
    tilePadding: 5,

    backgroundColor: '#000000', //Black
    foregroundColor: '#ffffff', //White
    clickedTileColor: "lightgrey",
    tileColor: "grey",
    actorColor: "red",
    mobsColor: "green"
}

const Map = (props) => {
    const [isLoading, setIsLoading] = useState(true);
    const canvasRef = React.useRef(null);
    const [canvas, setCanvas] = useState(null);
    const [screenCenter, setScreenCenter] = useState({ x: 0, y: 0 });
    const [connection, setConnection] = useState(null);

    useEffect(() => {
        var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44301/hub").build()

        connection.start().then(() => {
            console.log("Map component connection started.")
        }).catch(err => {
            console.log(err.toString())
        });

        setConnection(connection);
        setCanvas(new Canvas(canvasRef, DisplayOptions));
    }, []);

    useEffect(() => {
        if (canvas && props.map.tiles && props.mobs) {
            canvas.drawCanvas();
            canvas.drawMap(props.map, screenCenter);
            canvas.drawActor(props.playerPosition, screenCenter);
            canvas.drawMobs(props.mobs, screenCenter);
            setIsLoading(false);
        }
    }, [canvas, screenCenter, props.map, props.playerPosition, props.mobs]);

    function handler(event) {
        var offset = InputService.getScreenCenterOffset(event.key);
        if (!MapService.isZero(offset)) {
            setScreenCenter(MapService.offset(screenCenter, offset))
            props.selectTile(null)
        }

        var offset = InputService.getActorOffset(event.key);
        if (!MapService.isZero(offset)) {
            var newActor = MapService.offset(props.playerPosition, offset);
            if (MapService.contains(props.map.tiles, newActor)) {
                props.setPlayerPosition(newActor)
                
                connection.invoke("Search", props.playerPosition.x, props.playerPosition.y).catch(err => {
                    console.log(err)
                });
            }
        }
    }

    function mouseClick(clickEvent) {
        const newLocation = canvas.mousePosition(clickEvent)
        var tileCoords = canvas.tileCoordinates(newLocation);

        var relative = MapService.relativeToScreenCenter(tileCoords, screenCenter)

        if (MapService.contains(props.map.tiles, relative)) {
            if (props.selectedTile) {
                canvas.drawFloor(props.selectedTile);
            }
            canvas.clickTile(clickEvent);
            props.selectTile(tileCoords)
        }
    }

    function handleCanvasClick(e) {
        if (canvas) {
            var mouseOnCanvas = canvas.mousePosition(e)
            props.setHoveredTile(canvas.tileCoordinates(mouseOnCanvas))
        }
    }

    return (
        <canvas
            id="map"
            tabIndex="0"
            className={styles.floatLeft}
            ref={canvasRef}
            width={props.canvasConfiguration.width}
            height={props.canvasConfiguration.height}
            onMouseMove={handleCanvasClick}
            onClick={mouseClick}
            onKeyDown={handler}
        />
    );
};

Map.propTypes = {
    canvasConfiguration: PropTypes.shape({
        width: PropTypes.number.isRequired,
        height: PropTypes.number.isRequired
    }).isRequired,
    setHoveredTile: PropTypes.func.isRequired,
    map: PropTypes.any.isRequired,
    mobs: PropTypes.any.isRequired,
};

export default Map;