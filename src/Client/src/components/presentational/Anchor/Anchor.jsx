import React from "react";
import PropTypes from "prop-types";

const Anchor = (props) => {
    return (
        <a className="nes-btn" href={props.href}>
            {props.children}
        </a>
    );
};

Anchor.propTypes = {
    children: PropTypes.any,
    href: PropTypes.string.isRequired
};

export default Anchor;