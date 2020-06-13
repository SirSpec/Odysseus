import LogActions from "../actions/LogActions"

export function addLog(text) {
    return {
        type: LogActions.ADD_LOG,
        text
    }
}