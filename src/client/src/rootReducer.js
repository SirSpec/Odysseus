import { combineReducers } from 'redux'

import gameWindow from "./components/GameWindow/GameWindowReducer"
import logs from "./components/ActivityLog/LogsReducer"
import map from "./components/Map/MapReducer"

const rootReducer = combineReducers({
    gameWindow,
    logs,
    map
})

export default rootReducer;