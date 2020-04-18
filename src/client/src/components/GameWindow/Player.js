export default class Player {
    constructor(position, direction, cameraPlane) {
        this.position = position
        this.direction = direction
        this.cameraPlane = cameraPlane
    }

    nextStepX(step) {
        return this.position.x + this.direction.x * step
    }

    nextStepY(step) {
        return this.position.y + this.direction.y * step
    }

    moveX(step) {
        this.position.x += this.direction.x * step;
    }

    moveY(step) {
        this.position.y += this.direction.y * step;
    }

    rotate(rotation) {
        this.direction = this.rotateVector(this.direction, rotation)
        this.cameraPlane = this.rotateVector(this.cameraPlane, rotation)
    }

    rotateVector(vector, rotation) {
        return {
            x: vector.x * Math.cos(rotation) - vector.y * Math.sin(rotation),
            y: vector.x * Math.sin(rotation) + vector.y * Math.cos(rotation)
        }
    }
}