import React from "react";
import Button from "./Button";
import "../../styles/global.scss";

export default { title: "Components/Button" };

export const Primary = () =>
  <Button type={Button.types.PRIMARY} onClick={() => alert("Primary Button")}>
    Primary Button
  </Button>;

export const Success = () =>
  <Button type={Button.types.SUCCESS} onClick={() => alert("Success Button")}>
    Success Button
  </Button>;

export const Warning = () =>
  <Button type={Button.types.WARNING} onClick={() => alert("Warning Button")}>
    Warning Button
  </Button>;

export const Error = () =>
  <Button type={Button.types.ERROR} onClick={() => alert("Error Button")}>
    Error Button
</Button>;

export const Disabled = () =>
  <Button type={Button.types.DISABLED} onClick={() => alert("Disabled Button")}>
    Disabled Button
  </Button>;