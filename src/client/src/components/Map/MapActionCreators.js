import MapActions from "./MapActions"

export function setSelectedTile(tile) {
    return {
        type: MapActions.SET_SELECTED_TILE,
        tile
    }
}

export function setHoveredTile(tile) {
    return {
        type: MapActions.SET_HOVERED_TILE,
        tile
    }
}
export function setPlayerPosition(position) {
    return {
        type: MapActions.SET_PLAYER_POSITION,
        position
    }
}