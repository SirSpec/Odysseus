import LogActions from "./LogActions"

export function addLog(text) {
    return {
        type: LogActions.ADD_LOG,
        text
    }
}