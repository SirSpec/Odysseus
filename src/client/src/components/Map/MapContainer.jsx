import { connect } from 'react-redux'
import { selectTile, setHoveredTile } from "../../actionCreators/gameWindowActionCreators"
import { setPlayerPosition } from "../../actionCreators/playerActionCreators"

import Map from './Map'

const mapStateToProps = state => {
    return {
        map: state.map,
        mobs: state.gameWindow.mobs,
        playerPosition: state.player.position,
    }
}

const mapDispatchToProps = dispatch => {
    return {
        selectTile: tile => dispatch(selectTile(tile)),
        setHoveredTile: tile => dispatch(setHoveredTile(tile)),
        setPlayerPosition: position => dispatch(setPlayerPosition(position)),
    }
}

const MapContainer = connect(mapStateToProps, mapDispatchToProps)(Map)

export default MapContainer