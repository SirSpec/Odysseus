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
  canvasConfiguration: PropTypes.shape(
    {
      width: PropTypes.number.isRequired,
      height: PropTypes.number.isRequired
    }).isRequired,
  handleCanvasClick: PropTypes.func.isRequired,
};

export default Map;