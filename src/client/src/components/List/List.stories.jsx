import React from "react";
import List from "./List";
import "../../styles/global.scss";

export default { title: "Components/List" };

const items = ["Item 1", "Item 2", "Item 3", "Item 4"];

export const Disc = () =>
  <List type={List.types.DISC} items={items} />

export const Circle = () =>
  <List type={List.types.CIRCLE} items={items} />