import { connect } from 'react-redux'
import ContextMenu from './ContextMenu'

const mapStateToProps = state => {
    return {
        mobs: state.userContext.targets,
    }
}

const ContextMenuContainer = connect(mapStateToProps)(ContextMenu)

export default ContextMenuContainer