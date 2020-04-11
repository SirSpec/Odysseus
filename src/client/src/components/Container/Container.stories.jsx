import React from "react";
import Container from "./Container";
import "../../styles/global.scss";

export default { title: "Components/Container" };

export const Default = () =>
  <Container />;

export const DefaultWithChildren = () =>
  <Container >
    <span>Default With Children</span>
  </Container>;

export const Rounded = () =>
  <Container isRounded>
    <span>Rounded</span>
  </Container>;

export const WithTitle = () =>
  <Container title="Title" withTitle>
    <span>With Title</span>
  </Container>;

export const Centered = () =>
  <Container isCentered>
    <span>Centered</span>
  </Container>;

export const Dark = () =>
  <Container isDark>
    <span>Dark</span>
  </Container>;