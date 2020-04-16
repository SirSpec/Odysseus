export default class InputService {
    static getScreenCenterOffset(keyCode) {
        switch (keyCode) {
            case "a": return { x: 1, y: 0 }
            case "w": return { x: 0, y: 1 }
            case "s": return { x: 0, y: -1 }
            case "d": return { x: -1, y: 0 }
            default: return { x: 0, y: 0 }
        }
    }

    static getActorOffset(keyCode) {
        switch (keyCode) {
            case "ArrowLeft": return { x: -1, y: 0 }
            case "ArrowUp": return { x: 0, y: -1 }
            case "ArrowDown": return { x: 0, y: 1 }
            case "ArrowRight": return { x: 1, y: 0 }
            default: return { x: 0, y: 0 }
        }
    }
}