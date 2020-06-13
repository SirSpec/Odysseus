import PlayerActions from "../actions/playerActions"

export function setPlayerPosition(position) {
    return {
        type: PlayerActions.SET_POSITION,
        position
    }
}