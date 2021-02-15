import { connect } from 'react-redux'
import ActivityLog from './ActivityLog'

const LogsNumberPerPage = 5

const mapStateToProps = state => {
    return {
        logs: state.logs,
        pageSize: LogsNumberPerPage,
        hoveredTile: state.userContext.hoveredTile,
        selectedTile: state.userContext.selectedTile, 
    }
}

const ActivityLogContainer = connect(mapStateToProps)(ActivityLog)

export default ActivityLogContainer