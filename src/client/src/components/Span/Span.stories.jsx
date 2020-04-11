import React from "react";
import Span from "./Span";
import "../../styles/global.scss";

export default { title: "Components/Span" };

export const Primary = () =>
  <Span type={Span.types.PRIMARY}>
    Primary Span
  </Span>;

export const Success = () =>
  <Span type={Span.types.SUCCESS}>
    Success Span
  </Span>;

export const Warning = () =>
  <Span type={Span.types.WARNING}>
    Warning Span
  </Span>;

export const Error = () =>
  <Span type={Span.types.ERROR}>
    Error Span
</Span>;

export const Disabled = () =>
  <Span type={Span.types.DISABLED}>
    Disabled Span
  </Span>;