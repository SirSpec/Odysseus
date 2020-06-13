import MapActions from "../actions/MapActions"

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