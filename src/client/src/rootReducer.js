import { combineReducers } from 'redux'

import userContext from "./reducers/userContextReducer"
import logs from "./reducers/logsReducer"
import map from "./reducers/mapReducer"
import player from "./reducers/playerReducer"

const rootReducer = combineReducers({
    userContext,
    logs,
    map,
    player
})

export default rootReducer;