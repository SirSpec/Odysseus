import React from 'react';
import Container from "../Container/Container";
import Span from "../Span/Span";

import styles from "../../styles/gameWindow";

const InteractionMenu = () => {
  return (
    <Container className={styles.flex1} isDark withTitle title="Interaction">
      <Span>Informacje po kliknieciu + mozliwe opcje interakcji</Span>
    </Container>
  );
};

export default InteractionMenu;