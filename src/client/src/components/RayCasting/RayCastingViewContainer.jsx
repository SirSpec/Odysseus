import { connect } from 'react-redux'

import RayCastingView from './RayCastingView'

const mapStateToProps = state => {
    return {
        map: state.gameWindow.map,
    }
}

const RayCastingViewContainer = connect(mapStateToProps)(RayCastingView)

export default RayCastingViewContainer