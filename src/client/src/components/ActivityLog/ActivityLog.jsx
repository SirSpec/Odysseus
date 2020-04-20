import React, { useState, useEffect } from 'react';
import PropTypes from "prop-types";

import Container from "../Container/Container";
import Span from "../Span/Span";

import styles from "../GameWindow/styles.scss";

const ActivityLog = (props) => {
    const [pageNumber, setPageNumber] = useState(1);

    function logs() {
        return props.logs
            ? props.logs.slice((pageNumber - 1) * props.pageSize, pageNumber * props.pageSize)
            : []
    }

    function pagesCount() {
        return props.logs && props.pageSize
            ? Math.ceil(props.logs.length / props.pageSize)
            : 0;
    }

    function handleIncrementPage() {
        if (pageNumber < pagesCount())
            setPageNumber(pageNumber => ++pageNumber)
    }

    function handleDecrementPage() {
        if (pageNumber > 1)
            setPageNumber(pageNumber => --pageNumber)
    }

    return (
        <Container className={styles.flex1} isDark withTitle title="Log">
            {logs().map((log, index) => <p key={index}>{log}</p>)}
            <Span onClick={handleDecrementPage}>{'<'}</Span>
            <Span> {pageNumber} </Span>
            <Span onClick={handleIncrementPage}>{'>'}</Span>
        </Container>
    );
};

ActivityLog.propTypes = {
    logs: PropTypes.arrayOf(PropTypes.string),
    pageSize: PropTypes.number.isRequired
};

export default ActivityLog;