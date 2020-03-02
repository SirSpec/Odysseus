import React from "react";
import PropTypes from "prop-types";

const ProgressBar = (props) => (
    <progress
        className={"nes-progress" + (props.type ? " " + props.type : "")}
        value={props.value}
        max={props.max}></progress>
);

ProgressBar.types = {
    PRIMARY: "is-primary",
    SUCCESS: "is-success",
    WARNING: "is-warning",
    ERROR: "is-error",
    PATTERN: "is-pattern"
}

ProgressBar.propTypes = {
    max: PropTypes.number.isRequired,
    value: PropTypes.number.isRequired,
    type: PropTypes.oneOf(Object.values(ProgressBar.types))
};

export default ProgressBar;