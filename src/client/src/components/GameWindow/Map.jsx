import React, { useState, useEffect } from 'react';
import PropTypes from "prop-types";

import Canvas from "./Canvas";
import InputService from "./InputService";
import MapService from "./MapService";
import styles from "./styles";

const DisplayOptions = {
    tileSize: 20,
    tilePadding: 5,

    backgroundColor: '#000000', //Black
    foregroundColor: '#ffffff', //White
    clickedTileColor: "lightgrey",
    tileColor: "grey",
    actorColor: "red"
}

const Map = (props) => {
    const canvasRef = React.useRef(null);
    const [canvas, setCanvas] = useState(null);
    const [screenCenter, setScreenCenter] = useState({ x: 0, y: 0 });
    const [selectedTile, setSelectedTile] = useState(null);
    const [actor, setActor] = useState({ x: 0, y: 0 });
    const [oldActor, setOldActor] = useState({ x: 0, y: 0 });

    useEffect(() => {
        setCanvas(new Canvas(canvasRef, DisplayOptions));
    }, []);

    useEffect(() => {
        if (canvas) {
            canvas.drawCanvas();
            canvas.drawMap(props.map, screenCenter);
            canvas.drawActor(actor, screenCenter);
        }
    }, [canvas, screenCenter]);

    useEffect(() => {
        if (canvas) {
            canvas.drawFloorRelativeToScreenCenter(oldActor, screenCenter);
            canvas.drawActor(actor, screenCenter);
        }
    }, [actor]);

    function handler(event) {
        var offset = InputService.getScreenCenterOffset(event.key);
        if (!MapService.isZero(offset)) {
            setScreenCenter(MapService.offset(screenCenter, offset))
            setSelectedTile(null)
        }

        var offset = InputService.getActorOffset(event.key);
        if (!MapService.isZero(offset)) {
            setOldActor(actor)
            var newActor = MapService.offset(actor, offset);
            if (MapService.contains(props.map.tiles, newActor)) {
                setActor(newActor)
            }
        }
    }

    function mouseClick(clickEvent) {
        const newLocation = canvas.mousePosition(clickEvent)
        var tileCoords = canvas.tileCoordinates(newLocation);

        var relative = MapService.relativeToScreenCenter(tileCoords, screenCenter)

        if (MapService.contains(props.map.tiles, relative)) {
            if (selectedTile) {
                canvas.drawFloor(selectedTile);
            }
            canvas.clickTile(clickEvent);
            setSelectedTile(tileCoords)
        }
    }

    function handleCanvasClick(e) {
        if (canvas) {
            var mouseOnCanvas = canvas.mousePosition(e)
            props.handleCanvasClick(canvas.tileCoordinates(mouseOnCanvas))
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
    handleCanvasClick: PropTypes.func.isRequired,
    map: PropTypes.any.isRequired
};

export default Map;