import React from "react";
import RadioGroup from "./RadioGroup";
import "../../styles/global.scss";

export default { title: "Components/RadioGroup" };

const options = [
  { label: "Label 1", value: "Value 1" },
  { label: "Label 2", value: "Value 2" },
  { label: "Label 3", value: "Value 3" },
  { label: "Label 4", value: "Value 4" }
];

export const Default = () =>
  <RadioGroup
    name="Default"
    options={options} />

export const Dark = () =>
  <RadioGroup
    name="Dark"
    isDark
    options={options} />