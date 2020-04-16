import React from "react";
import PropTypes from "prop-types";

import styles from "./styles.scss"

const Dialog = (props) => (
    <dialog
        id={props.id}
        open={props.isOpened}
        className={
            (props.isDark ? "is-dark " : "") +
            (props.isRounded ? "is-rounded " : "") +
            `nes-dialog ${styles.modal}`
        }>
        <form method="dialog">
            <p className="title">{props.title}</p>
            {props.children}
            <menu className="dialog-menu">
                <button className="nes-btn is-primary" onClick={props.onConfirm}>
                    {props.confirmButtonText}
                </button>
            </menu>
        </form>
    </dialog>
);

Dialog.propTypes = {
    id: PropTypes.string.isRequired,
    isOpened: PropTypes.bool,
    isDark: PropTypes.bool,
    isRounded: PropTypes.bool,
    title: PropTypes.string,
    confirmButtonText: PropTypes.string.isRequired,
    onConfirm: PropTypes.func.isRequired,
};

export default Dialog;