import React from 'react';
import Container from "../Container/Container";

import styles from "../../styles/gameWindow";

const ContextMenu = (props) => {
  return (
    <Container className={styles.flex1} isDark withTitle title="Inventory">
      {props.mobs.map(mob => <p >{mob}</p>)}
    </Container>
  )
}

export default ContextMenu