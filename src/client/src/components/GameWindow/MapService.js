export default class MapService {
    static contains(tiles, otherTile) {
        return tiles.some(tile => tile.x === otherTile.x && tile.y === otherTile.y);
    }

    static offset(tile, offset) {
        return { x: tile.x + offset.x, y: tile.y + offset.y };
    }

    static isZero(offset) {
        return offset.x === 0 && offset.y === 0;
    }

    static relativeToScreenCenter(tile, screenCenter) {
        return { x: tile.x - screenCenter.x, y: tile.y - screenCenter.y }
    }
}