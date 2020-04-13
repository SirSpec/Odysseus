import React from 'react';
import Container from "../Container/Container";
import Span from "../Span/Span";

import styles from "./styles";

const ContextMenu = (props) => {
  return (
    <Container className={styles.flex1} isDark withTitle title="Inventory">
      <Span>{props.text}</Span>
    </Container>
  );
};

export default ContextMenu;