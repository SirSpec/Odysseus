import React from 'react';
import Container from "../Container/Container";
import Span from "../Span/Span";

import styles from "./styles";

const History = () => {
  return (
    <Container className={styles.flex1} isDark withTitle title="Log">
      <Span>Informacje po kliknieciu + mozliwe opcje interakcji</Span><br />
      <Span>Informacje po kliknieciu + mozliwe opcje interakcji</Span><br />
      <Span>Informacje po kliknieciu + mozliwe opcje interakcji</Span><br />
      <Span>Informacje po kliknieciu + mozliwe opcje interakcji</Span><br />
    </Container>
  );
};

export default History;