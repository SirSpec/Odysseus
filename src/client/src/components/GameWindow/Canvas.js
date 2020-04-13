export default class Canvas {
  constructor(context, options) {
    this.context = context;
    this.options = options;
    
    this.context.textBaseline = 'top';
    this.context.font = this.options.fontSize + 'px monospace';
    
    this.cellWidth = this.options.fontSize;//Math.floor(this.context.measureText(" ").width);
    this.cellHeight = this.options.fontSize;
  }

  drawCanvas() {
    this.context.fillStyle = this.options.backgroundColor;
    this.context.fillRect(0, 0, this.context.canvas.width, this.context.canvas.height);
  }

  draw(map, root) {
    this.drawCanvas()

    map.tiles.forEach(tile => {
        this.context.fillStyle = "grey";
        this.context.fillText("A", (root.x + tile.x) * this.cellWidth, (root.y + tile.y) * this.cellHeight);
    });
  }

  drawTest() {
    this.context.fillStyle = "red";
    this.context.fillRect(10, 10, this.options.fontSize, this.options.fontSize);
  }

  mousePosition(mousePosition) {
    this.context.fillStyle = "green";

    let x = Math.floor(mousePosition.x / this.cellWidth);
    let y = Math.floor(mousePosition.y / this.cellHeight);

    this.context.fillText("G", x * this.cellWidth, y * this.cellHeight);
  }
}