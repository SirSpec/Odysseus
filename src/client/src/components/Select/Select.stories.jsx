import React from "react";
import Select from "./Select";
import "../../styles/global.scss";

export default { title: "Components/Select" };

const options = [
  { label: "Label 1", value: "Value 1" },
  { label: "Label 2", value: "Value 2" },
  { label: "Label 3", value: "Value 3" },
  { label: "Label 4", value: "Value 4" }
];

export const Default = () =>
  <Select
    id="default"
    label="Default"
    options={options} />

export const Success = () =>
  <Select
    id="success"
    label="Success"
    type={Select.types.SUCCESS}
    options={options} />

export const Warning = () =>
  <Select
    id="warning"
    label="Warning"
    type={Select.types.WARNING}
    options={options} />

export const Error = () =>
  <Select
    id="error"
    label="Error"
    type={Select.types.ERROR}
    options={options} />

export const Dark = () =>
  <Select
    id="dark"
    label="Dark"
    type={Select.types.DARK}
    options={options} />