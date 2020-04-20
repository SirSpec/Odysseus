import React from "react";
import PropTypes from "prop-types";

const Span = (props) => (
    <span className={props.type ? "nes-text " + props.type : "nes-text"} onClick={props.onClick}>
        {props.children}
    </span>
);

Span.types = {
    PRIMARY: "is-primary",
    SUCCESS: "is-success",
    WARNING: "is-warning",
    ERROR: "is-error",
    DISABLED: "is-disabled"
}

Span.propTypes = {
    children: PropTypes.any,
    type: PropTypes.oneOf(Object.values(Span.types)),
    onClick: PropTypes.func
};

export default Span;