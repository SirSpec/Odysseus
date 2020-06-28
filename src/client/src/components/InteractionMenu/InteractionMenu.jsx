import React from 'react';
import Container from "../Container/Container";

import styles from "../../styles/gameWindow";

const InteractionMenu = (props) => {
    return (
        <Container className={styles.flex1} isDark withTitle title="Interaction">
            {props.mobs.map(mob => <p >{mob}</p>)}
        </Container>
    );
};

export default InteractionMenu;