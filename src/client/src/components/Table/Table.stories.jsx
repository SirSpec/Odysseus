import React from "react";
import Table from "./Table";
import "../../styles/global.scss";

export default { title: "Components/Table" };

const rows = [
  ["Row 1A", "Row 1B", "Row 1C", "Row 1D",],
  ["Row 2A", "Row 2B", "Row 2C", "Row 2D",],
  ["Row 3A", "Row 3B", "Row 3C", "Row 3D",]
];

export const WithHeaders = () =>
  <Table
    headers={["Header 1", "Header 2", "Header 3", "Header 4"]}
    rows={rows} />

export const WithoutHeaders = () =>
  <Table rows={rows} />