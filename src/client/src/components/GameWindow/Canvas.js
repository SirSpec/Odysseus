export default class Canvas {
    constructor(canvasRef, options) {
        this.canvasRef = canvasRef;
        this.context = canvasRef.current.getContext('2d');
        this.options = options;

        this.contentSize = this.options.tileSize - this.options.tilePadding
    }

    drawCanvas() {
        this.context.fillStyle = this.options.backgroundColor;
        this.context.fillRect(0, 0, this.context.canvas.width, this.context.canvas.height);
    }

    drawMap(map, screenCenter) {
        this.drawCanvas()

        map.tiles.forEach(tile => {
            this.drawFloorRelativeToScreenCenter(tile, screenCenter)
        });
    }

    drawActor(actor, screenCenter) {
        this.context.fillStyle = this.options.actorColor;
        this.drawTileRelativeToScreenCenter(actor, screenCenter)
    }

    clickTile(mouseEvent) {
        var mousePosition = this.mousePosition(mouseEvent)
        var tile = this.tileCoordinates(mousePosition)

        this.context.fillStyle = this.options.clickedTileColor
        this.drawTile(tile)
    }

    drawFloorRelativeToScreenCenter(tileCoordinates, screenCenter) {
        this.context.fillStyle = this.options.tileColor
        this.drawTileRelativeToScreenCenter(tileCoordinates, screenCenter)
    }

    drawFloor(tileCoordinates) {
        this.context.fillStyle = this.options.tileColor
        this.drawTile(tileCoordinates)
    }

    drawTileRelativeToScreenCenter(tileCoordinates, screenCenter) {
        this.context.fillRect(
            (tileCoordinates.x + screenCenter.x) * this.options.tileSize,
            (tileCoordinates.y + screenCenter.y) * this.options.tileSize,
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

    mousePosition(mouseEvent) {
        var canvasElement = this.canvasRef.current.getBoundingClientRect();
        var x = mouseEvent.pageX - canvasElement.x - window.scrollX
        var y = mouseEvent.pageY - canvasElement.y - window.scrollY

        return { x, y }
    }
}