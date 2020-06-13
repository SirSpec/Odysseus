import GameWindowActions from '../actions/gameWindowActions';

const initialState = {
    mobs: [],
    selectedTile: null,
    hoveredTile: null,
}

function gameWindow(state = initialState, action) {
    switch (action.type) {
        case GameWindowActions.SET_MOBS:
            return { ...state, mobs: action.mobs }
        case GameWindowActions.SELECT_TILE:
            return { ...state, selectedTile: action.tile }
        case GameWindowActions.SET_HOVERED_TILE:
            return { ...state, hoveredTile: action.tile }
        default:
            return state;
    }
}

export default gameWindow