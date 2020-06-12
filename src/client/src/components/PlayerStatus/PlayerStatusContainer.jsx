import { connect } from 'react-redux'
import PlayerStatus from './PlayerStatus'

const mapStateToProps = state => {
    return {
        hoveredTile: state.map.hoveredTile,
    }
}

const PlayerStatusContainer = connect(mapStateToProps)(PlayerStatus)

export default PlayerStatusContainer