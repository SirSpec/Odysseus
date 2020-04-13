export default class Canvas {
  constructor(context, options) {
    this.context = context;
    this.options = options;
  }

  drawCanvas() {
    this.context.fillStyle = this.options.backgroundColor;
    this.context.fillRect(0, 0, this.context.canvas.width, this.context.canvas.height);
  }

  draw(map, root) {
    this.drawCanvas()
    this.context.textBaseline = 'top';
    this.context.font = this.options.tileSize + 'px monospace';

    map.tiles.forEach(tile => {
      this.context.fillStyle = "grey";
      this.drawTile(tile, root)
      
      //testing
      this.context.fillStyle = "red";
      this.context.fillText("A", (root.x + tile.x) * this.options.tileSize, (root.y + tile.y) * this.options.tileSize);
    });
  }

  drawTile(tile, root) {
    var contentSize = this.options.tileSize - this.options.tileSpacing;
    this.context.fillRect((tile.x + root.x) * this.options.tileSize, (tile.y + root.y) * this.options.tileSize, contentSize, contentSize);
  }

  mousePosition(mousePosition) {
    this.context.fillStyle = "green";

    let x = Math.floor(mousePosition.x / this.options.tileSize);
    let y = Math.floor(mousePosition.y / this.options.tileSize);

    var contentSize = this.options.tileSize - this.options.tileSpacing;
    this.context.fillRect(x * this.options.tileSize, y * this.options.tileSize, contentSize, contentSize);
  }
}