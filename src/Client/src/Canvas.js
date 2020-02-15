export default class Canvas {
  constructor(context, options) {
    this.context = context;
    this.options = options;
    
    this.context.textBaseline = 'top';
    this.context.font = this.options.fontSize + 'px monospace';
    
    this.cellWidth = Math.floor(this.context.measureText(" ").width);
    this.cellHeight = this.options.fontSize;
  }

  drawCanvas() {
    this.context.fillStyle = this.options.backgroundColor;
    this.context.fillRect(0, 0, this.context.canvas.width, this.context.canvas.height);
  }

  draw(map) {
    map.forEach((row, rowIndex) => {
      row.forEach((cellInRow, cellInRowIndex) => {
        this.context.fillStyle = "red";
        this.context.fillText(cellInRow, cellInRowIndex * this.cellWidth, rowIndex * this.cellHeight);
      });
    });
  }

  mousePosition(mousePosition) {
    this.context.fillStyle = "green";

    let x = Math.floor(mousePosition.x / this.cellWidth);
    let y = Math.floor(mousePosition.y / this.cellHeight);

    this.context.fillText("G", x * this.cellWidth, y * this.cellHeight);
  }
}