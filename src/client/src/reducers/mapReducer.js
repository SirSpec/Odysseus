import MapActions from '../actions/mapActions';

function map(state = {}, action) {
    switch (action.type) {
        case MapActions.SET_MAP:
            return action.map
        default:
            return state;
    }
}

export default map