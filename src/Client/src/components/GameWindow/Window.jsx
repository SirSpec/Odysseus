import React, { useState, useEffect } from 'react';
import Canvas from "../../Canvas";

import Statistics from "./Statistics";
import Menu from "./Menu";
import Interaction from "./Interaction";
import History from "./History";
import ContextMenu from "./ContextMenu";

import styles from "./styles";

let map = [
  ['#', '#', ' ', '#'],
  ['#', '#', ' ', '#'],
  ['#', '.', '|', '#'],
  ['#', ' ', '@', '#'],
  ['#', '#', '#', '#'],
]

const DisplayOptions = {
  fontSize: 30,
  backgroundColor: '#000000', //Black
  foregroundColor: '#ffffff' //White
}

const CanvasConfiguration = {
  width: Math.floor(window.innerWidth / 2),
  height: Math.floor(window.innerHeight / (2 * DisplayOptions.fontSize)) * DisplayOptions.fontSize
}

const Window = () => {
  const canvasRef = React.useRef(null);
  const [canvas, setCanvas] = useState(null);

  useEffect(() => {
    setCanvas(new Canvas(canvasRef.current.getContext('2d'), DisplayOptions));
  }, []);

  useEffect(() => {
    if (canvas) {
      canvas.drawCanvas();
      canvas.draw(map);
    };
  }, [canvas]);

  function handleCanvasClick(e) {
    const newLocation = { x: e.clientX, y: e.clientY }
    canvas.mousePosition(newLocation);
  }

  return (
    <div className={styles.column}>
      <div className={styles.row}>
        <canvas
          ref={canvasRef}
          id="map"
          width={CanvasConfiguration.width}
          height={CanvasConfiguration.height}
          onClick={handleCanvasClick}
        />
        <Statistics />
        <Menu />
      </div>
      <div className={styles.row + " " + styles.flex1}>
        <div className={styles.column + " " + styles.flex1}>
          <Interaction />
          <History />
        </div>
        <ContextMenu />
      </div>
    </div>
  );
};

export default Window;