import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux'

import PlayerStatus from "./PlayerStatus";
import GameMenu from "../GameMenu/GameMenu";
import InteractionMenu from "./InteractionMenu";
import ActivityLog from "./ActivityLog";
import ContextMenu from "./ContextMenu";
import Map from "./Map";
import RayCastingView from "./RayCastingView";

import styles from "./styles";

const testRayCastingMap =
    [
        [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
        [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
        [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
        [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
        [1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1],
        [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
        [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1],
        [1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
        [1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1],
        [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
        [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
        [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
        [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
        [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
        [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1],
        [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
        [1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1],
        [1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
        [1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1],
        [1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
        [1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
        [1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
        [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
    ];

const PlayerConfiguration = {
    playerPosition: { x: 17, y: 14 },
    rotationSpeed: 0.1,
    moveSpeed: 0.2
}

const CanvasConfiguration = {
    width: Math.floor(window.innerWidth / 2.5),
    height: window.innerHeight
}

let GameWindow = () => {
    const [hoveredTile, setHoveredTile] = useState(null);
    const [isLoading, setIsLoading] = useState(true);
    const [isRayCastingOpened, setIsRayCastingOpened] = useState(false);
    const [map, setMap] = useState(null);

    useEffect(() => {
        async function fetchMyAPI() {
            const url = "https://localhost:44301/"
            var response = await fetch(url);
            var data = await response.json();
            setMap(data);
        }

        fetchMyAPI();
    }, []);

    useEffect(() => {
        if (map) setIsLoading(false)
    }, [map]);

    function handleCanvasClick(e) {
        setHoveredTile(`${e.x}, ${e.y}`);
    }

    function handleChangeView(e) {
        setIsRayCastingOpened(!isRayCastingOpened)
    }

    return (
        <div className={styles.full_height}>
            {!isLoading ?
                isRayCastingOpened
                    ? <RayCastingView
                        canvasConfiguration={CanvasConfiguration}
                        playerConfiguration={PlayerConfiguration}
                        map={testRayCastingMap} />
                    : <Map
                        map={map}
                        canvasConfiguration={CanvasConfiguration}
                        handleCanvasClick={handleCanvasClick} />
                : null
            }
            <div className={styles.column}>
                <div className={styles.row}>
                    <PlayerStatus hoveredTile={hoveredTile} />
                    <GameMenu handleChangeView={handleChangeView} />
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