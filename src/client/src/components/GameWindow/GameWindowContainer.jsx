import { connect } from 'react-redux'
import { setMap } from "../../actionCreators/mapActionCreators"
import { setMobs, setTargets } from "../../actionCreators/userContextActionCreators"

import GameWindow from './GameWindow'

const mapDispatchToProps = dispatch => {
    return {
        setMap: map => dispatch(setMap(map)),
        setMobs: mobs => dispatch(setMobs(mobs)),
        setMobs: mobs => dispatch(setMobs(mobs)),
        setTargets: targets => dispatch(setTargets(targets)),
    }
}

const GameWindowContainer = connect(undefined, mapDispatchToProps)(GameWindow)

export default GameWindowContainer