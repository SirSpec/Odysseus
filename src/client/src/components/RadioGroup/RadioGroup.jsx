import React from "react";
import PropTypes from "prop-types";

const RadioGroup = (props) => (
    props.options.map((option, index) => (
        <label key={index}>
            <input
                type="radio"
                className={"nes-radio" + (props.isDark ? " is-dark" : "")}
                value={option.value}
                name={props.name}
                defaultChecked={index == 0} />
            <span>{option.label}</span>
        </label>
    ))
);

RadioGroup.propTypes = {
    isDark: PropTypes.bool,
    name: PropTypes.string.isRequired,
    options: PropTypes.arrayOf(
        PropTypes.shape({
            label: PropTypes.string.isRequired,
            value: PropTypes.string.isRequired,
        })
    ).isRequired
};

export default RadioGroup;