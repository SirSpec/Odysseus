import GameWindowActions from "../actions/GameWindowActions"

export function setMap(map) {
    return {
        type: GameWindowActions.SET_MAP,
        map
    }
}

export function setMobs(mobs) {
    return {
        type: GameWindowActions.SET_MOBS,
        mobs
    }
}