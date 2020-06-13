import LogsActions from '../actions/logsActions';

function logs(state = [], action) {
    switch (action.type) {
        case LogsActions.ADD_LOG:
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