import PlayerActions from '../actions/playerActions';

const initialState = {
    position: { x: 0, y: 0 },
}

function player(state = initialState, action) {
    switch (action.type) {
        case PlayerActions.SET_POSITION:
            return { ...state, position: action.position }
        default:
            return state;
    }
}

export default player