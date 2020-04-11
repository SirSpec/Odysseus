import React from "react";
import Input from "./Input";
import "../../styles/global.scss";

export default { title: "Components/Input" };

export const Default = () =>
  <Input id="default" label="Default" />

export const Success = () =>
  <Input id="success" label="Success" type={Input.types.SUCCESS} />

export const Warning = () =>
  <Input id="warning" label="Warning" type={Input.types.WARNING} />

export const Error = () =>
  <Input id="error" label="Error" type={Input.types.ERROR} />

export const Dark = () =>
  <Input id="dark" label="Dark" type={Input.types.DARK} />

export const Inline = () =>
  <Input id="inline" label="Inline" inline />

export const Placeholder = () =>
  <Input id="placeholder" label="Placeholder" placeholder="Placeholder" />