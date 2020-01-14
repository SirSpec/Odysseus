import React from "react";
import PropTypes from "prop-types";

const Select = (props) => (
    <div>
        <label htmlFor={props.id}>{props.label}</label>
        <div className={"nes-select" + (props.type ? " " + props.type : "")}>
            <select id={props.id} required>
                {props.options.map((option, index) => (
                    <option key={index} value={option.value}>{option.label}</option>
                ))}
            </select>
        </div>
    </div>
);

Select.types = {
    SUCCESS: "is-success",
    WARNING: "is-warning",
    ERROR: "is-error",
    DARK: "is-dark"
}

Select.propTypes = {
    type: PropTypes.oneOf(Object.values(Select.types)),
    id: PropTypes.string.isRequired,
    label: PropTypes.string.isRequired,
    options: PropTypes.arrayOf(
        PropTypes.shape({
            label: PropTypes.string.isRequired,
            value: PropTypes.string.isRequired,
        })
    ).isRequired
};

export default Select;