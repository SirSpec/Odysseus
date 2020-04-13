import React, { useState, useEffect } from 'react';
import PropTypes from "prop-types";

import Canvas from "./Canvas";
import styles from "./styles";
const DisplayOptions = {
  fontSize: 20,
  backgroundColor: '#000000', //Black
  foregroundColor: '#ffffff' //White
}

const CanvasConfiguration = {
  width: Math.floor(window.innerWidth / 2.5),
  height: window.innerHeight //Math.floor(window.innerHeight / (2 * DisplayOptions.fontSize)) * DisplayOptions.fontSize
}

const Map = (props) => {
  const canvasRef = React.useRef(null);
  const [canvas, setCanvas] = useState(null);
  const [map, setMap] = useState(null);
  const [c, setC] = useState(null);
  const [root, setRoot] = useState({ x: 0, y: 0 });
  const [mouse, setMouse] = useState("");

  useEffect(() => {
    setCanvas(new Canvas(canvasRef.current.getContext('2d'), DisplayOptions));
    setC(canvasRef.current.getContext('2d'))

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
      // canvas.draw(map);
    };
  }, [canvas]);

  useEffect(() => {
    if (canvas) {
      canvas.draw(map, root);
      canvas.drawTest();
    };
  }, [map]);

  useEffect(() => {
    if (canvas) {
      canvas.draw(map, root);
    };
  }, [root]);

  function handler(event) {
    switch (event.key) {
      case "s":
        setRoot({ x: root.x, y: root.y + 1 })
        break;
      case "w":
        setRoot({ x: root.x, y: root.y - 1 })
        break;
      case "a":
        setRoot({ x: root.x - 1, y: root.y })
        break;
      case "d":
        setRoot({ x: root.x + 1, y: root.y })
        break;

      default:
        break;
    }
  }

  function handleCanvasClick(e) {
    const newLocation = { x: e.clientX, y: e.clientY }
    //canvas.mousePosition(newLocation);

    const mouseText = `Client: ${e.clientX}, ${e.clientY} => Page:${e.pageX}, ${e.pageY} => Screen:${e.screenX}, ${e.screenY}`
    const windowText = ` // Window Inner: ${window.innerWidth}, ${window.innerHeight} => Window outer: ${window.outerWidth}, ${window.outerHeight}`
    const canvasText = ` // Canvas : ${c.canvas.width}, ${c.canvas.height}`

    var rect = canvasRef.current.getBoundingClientRect();
    const rectText = ` // Rect : ${rect.x}, ${rect.y} => Rect Size: ${rect.width}, ${rect.height}`
    const mouseOnCanvas = ` // mouseOnCanvas : ${e.pageX - rect.x - window.scrollX}, ${e.pageY - rect.y - window.scrollY}`
    setMouse(mouseText + windowText + canvasText + rectText + mouseOnCanvas);

    props.handleCanvasClick(mouse)
  }

  return (
    <canvas
      id="map"
      tabIndex="0"
      className={styles.floatLeft}
      ref={canvasRef}
      width={CanvasConfiguration.width}
      height={CanvasConfiguration.height}
      onMouseMove={handleCanvasClick}
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