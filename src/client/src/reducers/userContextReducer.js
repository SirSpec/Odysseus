import UserContextActions from '../actions/userContextActions';

const initialState = {
    mobs: [],
    targets: [],
    selectedTile: null,
    hoveredTile: null,
}

function userContext(state = initialState, action) {
    switch (action.type) {
        case UserContextActions.SET_MOBS:
            return { ...state, mobs: action.mobs }
        case UserContextActions.SET_TARGETS:
            return { ...state, targets: action.targets }
        case UserContextActions.SELECT_TILE:
            return { ...state, selectedTile: action.tile }
        case UserContextActions.SET_HOVERED_TILE:
            return { ...state, hoveredTile: action.tile }
        default:
            return state;
    }
}

export default userContext