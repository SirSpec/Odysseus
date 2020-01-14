import React from "react";
import PropTypes from "prop-types";

const Input = (props) => (
    <div className={"nes-field" + (props.inline ? " is-inline" : "")}>
        <label htmlFor={props.id}>{props.label}</label>
        <input 
            type="text"
            id={props.id}
            className={"nes-input" + (props.type ? " " + props.type : "")}
            placeholder={props.placeholder} />
    </div>
);

Input.types = {
    SUCCESS: "is-success",
    WARNING: "is-warning",
    ERROR: "is-error",
    DARK: "is-dark"
}

Input.propTypes = {
    type: PropTypes.oneOf(Object.values(Input.types)),
    inline: PropTypes.bool,
    placeholder: PropTypes.string,
    id: PropTypes.string.isRequired,
    label: PropTypes.string.isRequired,
};

export default Input;