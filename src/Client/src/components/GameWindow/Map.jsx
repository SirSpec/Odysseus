import React from 'react';
import PropTypes from "prop-types";

const Map = (props) => {
  return (
    <canvas
      id="map"
      ref={props.canvasRef}
      width={props.canvasConfiguration.width}
      height={props.canvasConfiguration.height}
      onClick={props.handleCanvasClick}
    />
  );
};

Map.propTypes = {
  canvasRef: PropTypes.any.isRequired,
  canvasConfiguration: PropTypes.any.isRequired,
  handleCanvasClick: PropTypes.any.isRequired,
};

export default Map;