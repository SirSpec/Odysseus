import React from "react";
import ProgressBar from "./ProgressBar";
import "../../styles/global.scss";

export default { title: "Components/ProgressBar" };

export const Default = () =>
  <ProgressBar value={75} max={100} />

export const Primary = () =>
  <ProgressBar value={75} max={100} type={ProgressBar.types.PRIMARY} />

export const Success = () =>
  <ProgressBar value={75} max={100} type={ProgressBar.types.SUCCESS} />

export const Warning = () =>
  <ProgressBar value={75} max={100} type={ProgressBar.types.WARNING} />

export const Error = () =>
  <ProgressBar value={75} max={100} type={ProgressBar.types.ERROR} />

export const Pattern = () =>
  <ProgressBar value={75} max={100} type={ProgressBar.types.PATTERN} />