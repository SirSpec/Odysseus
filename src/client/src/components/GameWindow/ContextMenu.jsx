import React from 'react';
import Container from "../Container/Container";

import styles from "./styles";

const ContextMenu = (props) => {
  function handleClick(clickEvent) {
    var mobName = clickEvent.target.id;

    props.handleMobAttack(mobName)
  }

  return (
    <Container className={styles.flex1} isDark withTitle title="Inventory">
      {props.mobs.map(mob =>
        <p id={mob} onClick={handleClick}>{mob}</p>
      )}
    </Container>
  );
};

export default ContextMenu;