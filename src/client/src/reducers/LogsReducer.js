import LogActions from '../actions/LogActions';

function logs(state = [], action) {
    switch (action.type) {
        case LogActions.ADD_LOG:
            return [
                ...state,
                {
                    text: action.text,
                }
            ]
        default:
            return state;
    }
}

export default logs