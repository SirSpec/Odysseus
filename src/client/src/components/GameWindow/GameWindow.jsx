import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux'

import PlayerStatus from "./PlayerStatus";
import GameMenu from "./GameMenu";
import InteractionMenu from "./InteractionMenu";
import ActivityLog from "./ActivityLog";
import ContextMenu from "./ContextMenu";
import Map from "./Map";

import styles from "./styles";

let GameWindow = () => {
  const [menuText, setMenuText] = useState("");

  function handleCanvasClick(e) {
    setMenuText(e);
  }

  return (
    <div className={styles.full_height}>
      <Map handleCanvasClick={handleCanvasClick} />
      <div className={styles.column}>
        <div className={styles.row}>
          <PlayerStatus />
          <GameMenu />
        </div>
        <div className={`${styles.row} ${styles.flex1}`}>
          <div className={`${styles.column} ${styles.flex1}`}>
            <InteractionMenu />
            <ActivityLog />
          </div>
          <ContextMenu text={menuText} />
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