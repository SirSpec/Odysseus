import LogsActions from "../actions/logsActions"

export function addLog(text) {
    return {
        type: LogsActions.ADD_LOG,
        text
    }
}