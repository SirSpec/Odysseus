import React, { useState, useEffect } from 'react';
import PropTypes from "prop-types";

import Canvas from "./Canvas";
import styles from "./styles";

const DisplayOptions = {
  tileSize: 20,
  tilePadding: 5,

  backgroundColor: '#000000', //Black
  foregroundColor: '#ffffff', //White
  clickedTileColor: "lightgrey",
  tileColor: "grey",
}

const Map = (props) => {
  const canvasRef = React.useRef(null);
  const [canvas, setCanvas] = useState(null);
  const [map, setMap] = useState(null);
  const [root, setRoot] = useState({ x: 0, y: 0 });

  useEffect(() => {
    setCanvas(new Canvas(canvasRef.current.getContext('2d'), DisplayOptions));

    async function fetchMyAPI() {
      const url = "https://localhost:44319/weatherforecast"
      var response = await fetch(url);
      var data = await response.json();
      setMap(data);
    }

    fetchMyAPI();
  }, []);

  useEffect(() => {
    if (canvas) {
      canvas.drawCanvas();
    }
  }, [canvas]);

  useEffect(() => {
    if (canvas) {
      canvas.drawMap(map, root);
    }
  }, [map, root]);

  function handler(event) {
    switch (event.key) {
      case "s":
        setRoot({ x: root.x, y: root.y - 1 })
        break;
      case "w":
        setRoot({ x: root.x, y: root.y + 1 })
        break;
      case "a":
        setRoot({ x: root.x + 1, y: root.y })
        break;
      case "d":
        setRoot({ x: root.x - 1, y: root.y })
        break;
      default:
        break;
    }
  }

  function mouseClick(e) {
    var canvasElement = canvasRef.current.getBoundingClientRect();
    const newLocation = canvas.mousePosition(e, canvasElement)
    canvas.clickTile(newLocation);
  }

  function handleCanvasClick(e) {
    var rect = canvasRef.current.getBoundingClientRect();
    var mouseOnCanvas = canvas.mousePosition(e, rect)
    props.handleCanvasClick(canvas.tileCoordinates(mouseOnCanvas))
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
      onKeyPress={handler}
    />
  );
};

Map.propTypes = {
  canvasConfiguration: PropTypes.shape({
    width: PropTypes.number.isRequired,
    height: PropTypes.number.isRequired
  }).isRequired,
  handleCanvasClick: PropTypes.func.isRequired,
};

export default Map;