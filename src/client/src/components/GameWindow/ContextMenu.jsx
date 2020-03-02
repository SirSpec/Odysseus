import React from 'react';
import Container from "../Container/Container";
import Span from "../Span/Span";

import styles from "./styles";

const ContextMenu = () => {
  return (
    <Container className={styles.flex1} isDark withTitle title="Inventory">
      <Span>Context Menu</Span>
    </Container>
  );
};

export default ContextMenu;