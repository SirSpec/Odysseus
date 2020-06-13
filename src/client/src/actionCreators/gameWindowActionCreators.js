import GameWindowActions from "../actions/gameWindowActions"

export function setMobs(mobs) {
    return {
        type: GameWindowActions.SET_MOBS,
        mobs
    }
}

export function selectTile(tile) {
    return {
        type: GameWindowActions.SELECT_TILE,
        tile
    }
}

export function setHoveredTile(tile) {
    return {
        type: GameWindowActions.SET_HOVERED_TILE,
        tile
    }
}