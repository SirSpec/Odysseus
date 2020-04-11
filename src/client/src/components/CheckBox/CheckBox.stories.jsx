import React from "react";
import CheckBox from "./CheckBox";
import "../../styles/global.scss";

export default { title: "Components/CheckBox" };

export const Default = () =>
  <CheckBox label="Default" />

export const Dark = () =>
  <CheckBox label="Dark" isDark />

export const Checked = () =>
  <CheckBox label="Checked" checked />

export const DarkChecked = () =>
  <CheckBox label="DarkChecked" checked isDark />