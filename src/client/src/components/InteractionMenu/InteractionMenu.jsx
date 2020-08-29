import React from 'react';
import Container from "../Container/Container";

import styles from "../../styles/gameWindow.scss";

const InteractionMenu = (props) => {
    return (
        <Container className={styles.flex1} isDark withTitle title="Interaction">
            {props.children}
        </Container>
    );
};

export default InteractionMenu;