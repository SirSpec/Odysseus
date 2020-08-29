import React, { useState, useEffect } from 'react';
import PropTypes from "prop-types";

import RayCasting from "./RayCasting";
import styles from "../../styles/gameWindow.scss";

const RayCastingView = (props) => {
    const canvasRef = React.useRef(null);
    const [rayCasting, setRayCasting] = useState(null);

    useEffect(() => {
        setRayCasting(new RayCasting(
            canvasRef,
            props.map,
            {
                screen: props.canvasConfiguration,
                playerConfiguration: props.playerConfiguration
            }))
    }, []);

    useEffect(() => {
        if (rayCasting) rayCasting.drawView()
    }, [rayCasting]);

    function handleKeyDown(event) {
        switch (event.key) {
            case "w":
                rayCasting.forward()
                break;
            case "s":
                rayCasting.backwards()
                break;
            case "d":
                rayCasting.rotateRight()
                break;
            case "a":
                rayCasting.rotateLeft()
                break;
            default:
                break;
        }

        rayCasting.drawView()
    }

    return (
        <canvas
            id="rayCasting"
            tabIndex="0"
            className={styles.floatLeft}
            ref={canvasRef}
            width={props.canvasConfiguration.width}
            height={props.canvasConfiguration.height}
            onKeyDown={handleKeyDown}
        />
    );
};

RayCastingView.propTypes = {
    canvasConfiguration: PropTypes.shape({
        width: PropTypes.number.isRequired,
        height: PropTypes.number.isRequired
    }).isRequired,
    playerConfiguration: PropTypes.any.isRequired,
    map: PropTypes.array.isRequired
};

export default RayCastingView;