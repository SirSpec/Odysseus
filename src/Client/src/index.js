import React from "react";
import ReactDOM from "react-dom";

import App from "./js/App.jsx";

const mainAppEntryPoint = document.getElementById("app");

if (mainAppEntryPoint) {
    ReactDOM.render(
        <App />,
        mainAppEntryPoint
    );
}