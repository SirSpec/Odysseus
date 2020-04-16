import React from "react";
import Dialog from "./Dialog";
import "../../styles/global.scss";

export default { title: "Components/Dialog" };

export const Default = () =>
    <Dialog
        id="default"
        isOpened={true}
        title="Default Dialog"
        confirmButtonText="Confirm"
        onConfirm={() => { }}>
        <span>Default Dialog Content</span>
    </Dialog>

export const Rounded = () =>
    <Dialog
        id="rounded"
        isOpened={true}
        title="Rounded Dialog"
        confirmButtonText="Confirm"
        onConfirm={() => { }}
        isRounded>
        <span>Rounded Dialog Content</span>
    </Dialog>

export const Dark = () =>
    <Dialog
        id="dark"
        isOpened={true}
        title="Dark Dialog"
        confirmButtonText="Confirm"
        onConfirm={() => { }}
        isDark>
        <span>Dark Dialog Content</span>
    </Dialog>

export const RoundedDark = () =>
    <Dialog
        id="roundedDark"
        isOpened={true}
        title="RoundedDark Dialog"
        confirmButtonText="Confirm"
        onConfirm={() => { }}
        isRounded
        isDark>
        <span>RoundedDark Dialog Content</span>
    </Dialog>