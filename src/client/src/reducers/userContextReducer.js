import UserContextActions from '../actions/userContextActions';

const initialState = {
    mobs: [],
    selectedTile: null,
    hoveredTile: null,
}

function userContext(state = initialState, action) {
    switch (action.type) {
        case UserContextActions.SET_MOBS:
            return { ...state, mobs: action.mobs }
        case UserContextActions.SELECT_TILE:
            return { ...state, selectedTile: action.tile }
        case UserContextActions.SET_HOVERED_TILE:
            return { ...state, hoveredTile: action.tile }
        default:
            return state;
    }
}

export default userContext