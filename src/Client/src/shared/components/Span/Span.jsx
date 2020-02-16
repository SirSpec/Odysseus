import React from "react";
import PropTypes from "prop-types";

const Span = (props) => (
    <span className={props.type ? "nes-text " + props.type : "nes-text"}>
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
    type: PropTypes.oneOf(Object.values(Span.types))
};

export default Span;