import { connect } from 'react-redux'
import InteractionMenu from './InteractionMenu'

const mapStateToProps = state => {
    return {
        mobs: state.userContext.targets,
    }
}

const InteractionMenuContainer = connect(mapStateToProps)(InteractionMenu)

export default InteractionMenuContainer