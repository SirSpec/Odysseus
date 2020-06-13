import { combineReducers } from 'redux'

import gameWindow from "./reducers/GameWindowReducer"
import logs from "./reducers/LogsReducer"
import map from "./reducers/MapReducer"

const rootReducer = combineReducers({
    gameWindow,
    logs,
    map
})

export default rootReducer;