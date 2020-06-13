import { combineReducers } from 'redux'

import gameWindow from "./reducers/GameWindowReducer"
import logs from "./reducers/LogsReducer"
import map from "./reducers/MapReducer"
import player from "./reducers/playerReducer"

const rootReducer = combineReducers({
    gameWindow,
    logs,
    map,
    player
})

export default rootReducer;