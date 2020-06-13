import { connect } from 'react-redux'
import { setSelectedTile, setHoveredTile, setPlayerPosition } from "../../actionCreators/MapActionCreators"

import Map from './Map'

const mapStateToProps = state => {
    return {
        map: state.gameWindow.map,
        mobs: state.gameWindow.mobs,
        playerPosition: state.map.playerPosition,
    }
}

const mapDispatchToProps = dispatch => {
    return {
        setSelectedTile: tile => dispatch(setSelectedTile(tile)),
        setHoveredTile: tile => dispatch(setHoveredTile(tile)),
        setPlayerPosition: position => dispatch(setPlayerPosition(position)),
    }
}

const MapContainer = connect(mapStateToProps, mapDispatchToProps)(Map)

export default MapContainer