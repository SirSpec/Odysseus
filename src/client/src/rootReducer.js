import { combineReducers } from 'redux'

import gameWindow from "./reducers/gameWindowReducer"
import logs from "./reducers/logsReducer"
import map from "./reducers/mapReducer"
import player from "./reducers/playerReducer"

const rootReducer = combineReducers({
    gameWindow,
    logs,
    map,
    player
})

export default rootReducer;