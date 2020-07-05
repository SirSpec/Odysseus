import React, { useState, useEffect, useRef } from 'react';
import PropTypes from "prop-types";
import * as signalR from "@microsoft/signalr"
import * as PIXI from 'pixi.js'
import MapViewRenderer from "./MapViewRenderer";
import InputService from "./InputService";
import MapService from "./MapService";

import styles from "../../styles/gameWindow";

const Map = (props) => {
    const mapViewRef = useRef(null);
    const [mapViewRenderer, setMapViewRenderer] = useState(null);
    const [connection, setConnection] = useState(null);
    const [screenCenter, setScreenCenter] = useState({ x: 0, y: 0 });

    useEffect(() => {
        var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:5001/hub").build()

        connection.start().then(() => {
            console.log("Map component connection started.")
        }).catch(err => {
            console.log(err)
        });

        setConnection(connection);

        const app = new PIXI.Application({
            width: props.canvasConfiguration.width,
            height: props.canvasConfiguration.height,
        });

        mapViewRef.current.appendChild(app.view)
        setMapViewRenderer(new MapViewRenderer(mapViewRef, app, props.setHoveredTile));
    }, []);

    useEffect(() => {
        if (mapViewRenderer && props.map.tiles && props.mobs) {
            mapViewRenderer.drawMap(props.map, screenCenter);
            mapViewRenderer.drawActor(props.playerPosition, screenCenter);
            mapViewRenderer.drawMobs(props.mobs, screenCenter);
        }
    }, [screenCenter, props.map, props.playerPosition, props.mobs]);


    function onKeyDownHandler(event) {
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

    // function mouseClick(clickEvent) {
    //     const newLocation = canvas.mousePosition(clickEvent, mapViewRef.current)
    //     var tileCoords = canvas.tileCoordinates(newLocation);

    //     var relative = MapService.relativeToScreenCenter(tileCoords, screenCenter)

    //     if (MapService.contains(props.map.tiles, relative)) {
    //         // if (props.selectedTile) {
    //         //     canvas.drawFloor(props.selectedTile);
    //         // }
    //         canvas.clickTile(clickEvent);
    //         props.selectTile(tileCoords)
    //     }
    // }

    // function handleCanvasClick(e) {
    //     if (canvas) {
    //         var mouseOnCanvas = canvas.mousePosition(e)
    //         props.setHoveredTile(canvas.tileCoordinates(mouseOnCanvas))
    //     }
    // }

    return (<div id="mapView" tabIndex="0" ref={mapViewRef} className={styles.floatLeft} onKeyDown={onKeyDownHandler} />);
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