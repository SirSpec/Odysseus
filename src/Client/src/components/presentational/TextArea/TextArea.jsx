import React from "react";
import PropTypes from "prop-types";

const TextArea = (props) => (
    <div>
        <label htmlFor={props.id}>{props.label}</label>
        <textarea id={props.id} className="nes-textarea"></textarea>
    </div>
);

TextArea.propTypes = {
    id: PropTypes.string.isRequired,
    label: PropTypes.string.isRequired,
};

export default TextArea;