import React from 'react';
import Container from "../Container/Container";
import Span from "../Span/Span";

import styles from "./styles";

const PlayerStatus = () => {
  return (
    <Container isDark className={styles.flex2}>
      <div className={styles.row}>
        <div className={styles.flex1}>
          <Span type={Span.types.ERROR}>Health: 10/20<br /></Span>
          <Span type={Span.types.PRIMARY}>Mana: 10/20<br /></Span>
          <Span type={Span.types.SUCCESS}>Experience: 100/205<br /></Span>
        </div>
        <div className={styles.flex1}>
          <Span>Level: 4<br /></Span>
          <Span>Location: 5/76<br /></Span>
          <Span type={Span.types.WARNING}>Gold: 125<br /></Span>
        </div>
      </div>
      <br />
      <Span>Left Hand: Short Sword<br /></Span>
      <Span>Right Hand: Small Round Shield<br /></Span>
      <Span>Skill Points: 1<br /></Span>
      <Span>Stenght/Dexterity/Inteligence: 5/3/8<br /></Span>
      <Span>Status: Curse(Slow) Bleed|4 DUPA Blada Znowu<br /></Span>
      <br />
      <div className={styles.row}>
        <div className={styles.flex1}>
          <Span>Damage: 42<br /></Span>
          <Span>Armor: 12<br /></Span>
          <Span>Critical: 12%<br /></Span>
        </div>
        <div className={styles.flex1}>
          <Span>Weight: 56/123<br /></Span>
          <Span>Food: 56%<br /></Span>
          <Span>Water: 89%<br /></Span>
        </div>
      </div>
      <br />
      <Span>Resistance:<br /></Span>
      <div className={styles.row}>
        <div className={styles.flex1}>
          <Span>Fire: 100%<br /></Span>
          <Span>Cold: 10%<br /></Span>
          <Span>Electricity: 100%<br /></Span>
        </div>
        <div className={styles.flex1}>
          <Span>Magic: 100%<br /></Span>
          <Span>Curse: 10%<br /></Span>
          <Span>Acid: 100%<br /></Span>
        </div>
      </div>
      <br />
      <Span>Standing: Empty Tile<br /></Span>
    </Container>
  );
};

export default PlayerStatus;