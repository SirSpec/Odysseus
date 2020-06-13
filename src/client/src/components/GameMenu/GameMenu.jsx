import React, { useState } from 'react';
import PropTypes from "prop-types";

import Container from "../Container/Container";
import Button from "../Button/Button";
import Dialog from "../Dialog/Dialog";

import styles from "../../styles/gameWindow";

const GameMenu = (props) => {
  const [isOpened, setIsOpened] = useState(false);

  function handleOpenHotkeys(clickEvent) {
    setIsOpened(!isOpened)
  }

  return (
    <Container className={styles.flex1} isCentered>
      <p><Button type={Button.types.PRIMARY} onClick={handleOpenHotkeys}>Hotkeys</Button></p>
      <p><Button type={Button.types.PRIMARY} onClick={props.handleChangeView}>View</Button></p>
      <p><Button type={Button.types.PRIMARY}>Save</Button> <Button type={Button.types.PRIMARY}>Load</Button></p>
      <p><Button type={Button.types.PRIMARY}>Statistics</Button></p>
      <p><Button type={Button.types.PRIMARY}>Inventory</Button></p>
      <p><Button type={Button.types.PRIMARY}>Spell Book</Button></p>
      <p><Button type={Button.types.PRIMARY}>Journal</Button></p>
      <Dialog
        id="hotkeys"
        isOpened={isOpened}
        title="Hotkeys"
        confirmButtonText="Close"
        onConfirm={handleOpenHotkeys}>
        <p>AWSD to move screen</p>
        <p>Arrows to move actor</p>
        <p>Mouse to click tiles</p>
      </Dialog>
    </Container>
  );
};

GameMenu.propTypes = {
  handleChangeView: PropTypes.func.isRequired,
};

export default GameMenu;