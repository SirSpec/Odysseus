import React from "react";
import ActivityLog from "./ActivityLog";
import "../../styles/global.scss";

export default { title: "Components/ActivityLog" };

const logs = [
    "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
    "Proin ullamcorper dui quis metus euismod, vel sagittis erat mollis.",
    "Donec eget nulla vulputate, laoreet magna at, efficitur magna.",
    "Ut in felis at ipsum molestie laoreet.",
    "Nam congue ligula et nulla dictum, id porttitor odio suscipit."
]

export const Empty = () =>
    <ActivityLog pageSize={1} />

export const PageSize6 = () =>
    <ActivityLog logs={logs} pageSize={6} />

export const PageSize5 = () =>
    <ActivityLog logs={logs} pageSize={5} />

export const PageSize4 = () =>
    <ActivityLog logs={logs} pageSize={4} />

export const PageSize3 = () =>
    <ActivityLog logs={logs} pageSize={3} />

export const PageSize2 = () =>
    <ActivityLog logs={logs} pageSize={2} />

export const PageSize1 = () =>
    <ActivityLog logs={logs} pageSize={1} />

export const PageSize0 = () =>
    <ActivityLog logs={logs} pageSize={0} />