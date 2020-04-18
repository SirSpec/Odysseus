import Player from "./Player";
import DigitalDifferentialAnalyzer from "./DigitalDifferentialAnalyzer";

export default class RayCasting {
    constructor(canvasRef, map, options) {
        this.canvasRef = canvasRef;
        this.context = canvasRef.current.getContext('2d');
        this.screen = options.screen
        this.map = map
        this.moveSpeed = options.playerConfiguration.moveSpeed
        this.rotationSpeed = options.playerConfiguration.rotationSpeed
        this.player = new Player(options.playerConfiguration.playerPosition)
    }

    forward() {
        this.move(this.moveSpeed)
    }

    backwards() {
        this.move(-this.moveSpeed)
    }

    rotateRight() {
        this.player.rotate(-this.rotationSpeed)
    }

    rotateLeft() {
        this.player.rotate(this.rotationSpeed)
    }

    isWall(x, y) {
        return !this.map.tiles.some(tile => tile.x === x && tile.y === y);
    }

    move(moveSpeed) {
        if (this.isWall(Math.floor(this.player.nextStepX(moveSpeed)), Math.floor(this.player.position.y)) == false)
            this.player.moveX(moveSpeed)

        if (this.isWall(Math.floor(this.player.position.x), Math.floor(this.player.nextStepY(moveSpeed))) == false)
            this.player.moveY(moveSpeed)
    }

    drawView() {
        this.drawBackground()

        for (var verticalScreenStripe = 0; verticalScreenStripe < this.screen.width; verticalScreenStripe++) {
            var rayDirection = this.rayDirection(verticalScreenStripe)

            var dda = DigitalDifferentialAnalyzer.analyze(this.player.position, rayDirection, (tile) => this.isWall(tile.x, tile.y))
            var perpenducilarWallDistance = this.perpenducilarWallDistance(dda, rayDirection)

            var lineToDraw = this.lineToDraw(perpenducilarWallDistance)
            this.drawLine(verticalScreenStripe, lineToDraw, dda.wallSide)
        }
    }

    drawBackground() {
        this.context.fillStyle = "black";
        this.context.fillRect(0, 0, this.screen.width, this.screen.height);
    }

    rayDirection(verticalScreenStripe) {
        var cameraPlaneX = 2 * verticalScreenStripe / this.screen.width - 1;
        return {
            x: this.player.direction.x + this.player.cameraPlane.x * cameraPlaneX,
            y: this.player.direction.y + this.player.cameraPlane.y * cameraPlaneX
        }
    }

    perpenducilarWallDistance(dda, rayDir) {
        return dda.wallSide == 0
            ? (dda.tile.x - this.player.position.x + (1 - dda.step.x) / 2) / rayDir.x
            : (dda.tile.y - this.player.position.y + (1 - dda.step.y) / 2) / rayDir.y
    }

    lineToDraw(perpenducilarWallDistance) {
        var lineHeight = Math.floor(this.screen.height / perpenducilarWallDistance);

        var start = -lineHeight / 2 + this.screen.height / 2;
        if (start < 0) start = 0;

        var end = lineHeight / 2 + this.screen.height / 2;
        if (end >= this.screen.height) end = this.screen.height - 1;

        return { start, end }
    }

    drawLine(verticalScreenStripe, lineToDraw, side) {
        var color = side == 1 ? "darkgrey" : "grey"
        this.context.beginPath();
        this.context.moveTo(verticalScreenStripe, lineToDraw.start);
        this.context.lineTo(verticalScreenStripe, lineToDraw.end);
        this.context.strokeStyle = color;
        this.context.stroke();
    }
}