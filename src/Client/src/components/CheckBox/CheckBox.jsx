import React from "react";
import PropTypes from "prop-types";

const CheckBox = (props) => (
    <label>
        <input
            type="checkbox"
            className={"nes-checkbox" + (props.isDark ? " is-dark" : "")}
            defaultChecked={props.checked} />
        <span>{props.label}</span>
    </label>
);

CheckBox.propTypes = {
    isDark: PropTypes.bool,
    checked: PropTypes.bool,
    label: PropTypes.string.isRequired,
};

export default CheckBox;