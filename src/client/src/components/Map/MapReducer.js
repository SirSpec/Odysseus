import MapActions from './MapActions';

const initialState = {
    selectedTile: null,
    hoveredTile: null,
    playerPosition: { x: 0, y: 0 },
}

function map(state = initialState, action) {
    switch (action.type) {
        case MapActions.SET_SELECTED_TILE:
            return { ...state, selectedTile: action.tile }
        case MapActions.SET_HOVERED_TILE:
            return { ...state, hoveredTile: action.tile }
        case MapActions.SET_PLAYER_POSITION:
            return { ...state, playerPosition: action.position }
        default:
            return state;
    }
}

export default map