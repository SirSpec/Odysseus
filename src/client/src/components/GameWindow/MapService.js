export default class Map {
    static contains(tiles, otherTile) {
        return tiles.some(tile => tile.x == otherTile.x && tile.y == otherTile.y);
    }

    static offset(tile, offset) {
        return { x: tile.x + offset.x, y: tile.y + offset.y };
    }
}