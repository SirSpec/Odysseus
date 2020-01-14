import React from "react";
import PropTypes from "prop-types";

const Span = (props) => (
    <span className={"nes-text " + props.type}>
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
    type: PropTypes.oneOf(Object.values(Span.types)).isRequired
};

export default Span;