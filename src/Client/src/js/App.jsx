import React, { Component } from "react";
import styles from "./App.scss"

class App extends Component {
  constructor() {
    super();
  }

  render() {
    return (
      <p className={styles.test}>Hello World</p>
    );
  }
}

export default App;