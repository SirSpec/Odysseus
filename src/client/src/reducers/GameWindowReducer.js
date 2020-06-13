import GameWindowActions from '../actions/GameWindowActions';

const initialState = {
    mobs: [],
    map: {}
}

function gameWindow(state = initialState, action) {
    switch (action.type) {
        case GameWindowActions.SET_MAP:
            return { ...state, map: action.map }
        case GameWindowActions.SET_MOBS:
            return { ...state, mobs: action.mobs }
        default:
            return state;
    }
}

export default gameWindow