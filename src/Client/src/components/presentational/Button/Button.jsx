import React from "react";
import PropTypes from "prop-types";

const Button = (props) => {
    return (
        <button
            type="button"
            className={"nes-btn " + props.type}
            onClick={() => props.onClick()}>
            {props.children}
        </button>
    );
};

Button.types = {
    PRIMARY: "is-primary",
    SUCCESS: "is-success",
    WARNING: "is-warning",
    ERROR: "is-error",
    DISABLED: "is-disabled"
}

Button.propTypes = {
    children: PropTypes.any,
    type: PropTypes.oneOf(Object.values(Button.types)).isRequired,
    onClick: PropTypes.func.isRequired
};

export default Button;