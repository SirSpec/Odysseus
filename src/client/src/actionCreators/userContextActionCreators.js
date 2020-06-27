import UserContextActions from "../actions/userContextActions"

export function setMobs(mobs) {
    return {
        type: UserContextActions.SET_MOBS,
        mobs
    }
}

export function setTargets(targets) {
    return {
        type: UserContextActions.SET_TARGETS,
        targets
    }
}

export function selectTile(tile) {
    return {
        type: UserContextActions.SELECT_TILE,
        tile
    }
}

export function setHoveredTile(tile) {
    return {
        type: UserContextActions.SET_HOVERED_TILE,
        tile
    }
}