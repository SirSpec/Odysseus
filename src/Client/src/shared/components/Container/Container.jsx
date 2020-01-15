import React from "react";
import PropTypes from "prop-types";

const Container = (props) => (
    <div className={
        "nes-container" +
        (props.isCentered ? " is-centered" : "") +
        (props.isDark ? " is-dark" : "") +
        (props.isRounded ? " is-rounded" : "") +
        (props.withTitle ? " with-title" : "")}>
        {props.withTitle ? <p className="title">{props.title}</p> : null}
        {props.children}
    </div>
);

Container.propTypes = {
    children: PropTypes.any,
    isCentered: PropTypes.bool,
    isDark: PropTypes.bool,
    isRounded: PropTypes.bool,
    withTitle: PropTypes.bool,
    title: PropTypes.string,
};

export default Container;