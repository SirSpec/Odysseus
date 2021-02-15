import { connect } from 'react-redux'
import { setMap } from "../../actionCreators/mapActionCreators"
import { setMobs } from "../../actionCreators/userContextActionCreators"

import GameWindow from './GameWindow'

const mapDispatchToProps = dispatch => {
    return {
        setMap: map => dispatch(setMap(map)),
        setMobs: mobs => dispatch(setMobs(mobs)),
    }
}

const GameWindowContainer = connect(undefined, mapDispatchToProps)(GameWindow)

export default GameWindowContainer