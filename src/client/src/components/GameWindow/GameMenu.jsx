import React from 'react';

import Container from "../Container/Container";
import Button from "../Button/Button";

import styles from "./styles";

const GameMenu = () => {
  return (
    <Container className={styles.flex1} isCentered>
      <p><Button type={Button.types.PRIMARY}>Keys</Button></p>
      <p><Button type={Button.types.PRIMARY}>Save</Button> <Button type={Button.types.PRIMARY}>Load</Button></p>
      <p><Button type={Button.types.PRIMARY}>Statistics</Button></p>
      <p><Button type={Button.types.PRIMARY}>Inventory</Button></p>
      <p><Button type={Button.types.PRIMARY}>Spell Book</Button></p>
      <p><Button type={Button.types.PRIMARY}>Journal</Button></p>
    </Container>
  );
};

export default GameMenu;