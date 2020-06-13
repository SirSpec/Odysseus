import MapActions from "../actions/mapActions"

export function setMap(map) {
    return {
        type: MapActions.SET_MAP,
        map
    }
}