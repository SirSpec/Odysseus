export default class Canvas {
  constructor(context, options) {
    this.context = context;
    this.options = options;

    this.contentSize = this.options.tileSize - this.options.tilePadding
  }

  drawCanvas() {
    this.context.fillStyle = this.options.backgroundColor;
    this.context.fillRect(0, 0, this.context.canvas.width, this.context.canvas.height);
  }

  drawMap(map, root) {
    this.drawCanvas()

    map.tiles.forEach(tile => {
      this.context.fillStyle = this.options.tileColor;
      this.drawTileRelative(tile, root)
    });
  }

  clickTile(mousePosition) {
    this.context.fillStyle = this.options.clickedTileColor
    var tile = this.tileCoordinates(mousePosition)

    this.drawTile(tile)
  }

  drawTileRelative(tileCoordinates, root) {
    this.context.fillRect(
      (tileCoordinates.x + root.x) * this.options.tileSize,
      (tileCoordinates.y + root.y) * this.options.tileSize,
      this.contentSize,
      this.contentSize);
  }

  drawTile(tileCoordinates) {
    this.context.fillRect(
      tileCoordinates.x * this.options.tileSize,
      tileCoordinates.y * this.options.tileSize,
      this.contentSize,
      this.contentSize);
  }

  tileCoordinates(mousePosition) {
    let x = Math.floor(mousePosition.x / this.options.tileSize)
    let y = Math.floor(mousePosition.y / this.options.tileSize)

    return { x, y }
  }

  mousePosition(mouseEvent, canvasElement) {
    var x = mouseEvent.pageX - canvasElement.x - window.scrollX
    var y = mouseEvent.pageY - canvasElement.y - window.scrollY

    return { x, y }
  }
}