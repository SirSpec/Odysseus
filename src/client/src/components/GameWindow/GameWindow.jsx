import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux'

import PlayerStatus from "./PlayerStatus";
import GameMenu from "../GameMenu/GameMenu";
import InteractionMenu from "./InteractionMenu";
import ActivityLog from "./ActivityLog";
import ContextMenu from "./ContextMenu";
import Map from "./Map";

import styles from "./styles";

const CanvasConfiguration = {
  width: Math.floor(window.innerWidth / 2.5),
  height: window.innerHeight
}

let GameWindow = () => {
  const [hoveredTile, setHoveredTile] = useState(null);

  function handleCanvasClick(e) {
    setHoveredTile(`${e.x}, ${e.y}`);
  }

  return (
    <div className={styles.full_height}>
      <Map
        canvasConfiguration={CanvasConfiguration}
        handleCanvasClick={handleCanvasClick} />
      <div className={styles.column}>
        <div className={styles.row}>
          <PlayerStatus hoveredTile={hoveredTile} />
          <GameMenu />
        </div>
        <div className={`${styles.row} ${styles.flex1}`}>
          <div className={`${styles.column} ${styles.flex1}`}>
            <InteractionMenu />
            <ActivityLog />
          </div>
          <ContextMenu />
        </div>
      </div>
    </div>
  );
};

const mapStateToProps = state => {
  return {
    // todos: getVisibleTodos(state.todos, state.visibilityFilter)
  }
}

const mapDispatchToProps = dispatch => {
  return {
    // onTodoClick: id => dispatch(toggleTodo(id))
  }
}

GameWindow = connect(mapStateToProps, mapDispatchToProps)(GameWindow)

export default GameWindow;