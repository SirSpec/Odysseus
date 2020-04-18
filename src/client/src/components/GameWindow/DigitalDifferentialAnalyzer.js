export default class DigitalDifferentialAnalyzer {
    static analyze(start, end, stopCondition) {
        var tile = { x: Math.floor(start.x), y: Math.floor(start.y) }
        var sideDistance = { x: 0, y: 0 }
        var deltaSideDistance = { x: Math.abs(1 / end.x), y: Math.abs(1 / end.y) }
        var step = { x: 0, y: 0 }

        if (end.x < 0) {
            step.x = -1;
            sideDistance.x = (start.x - tile.x) * deltaSideDistance.x;
        }
        else {
            step.x = 1;
            sideDistance.x = (tile.x + 1.0 - start.x) * deltaSideDistance.x;
        }
        if (end.y < 0) {
            step.y = -1;
            sideDistance.y = (start.y - tile.y) * deltaSideDistance.y;
        }
        else {
            step.y = 1;
            sideDistance.y = (tile.y + 1.0 - start.y) * deltaSideDistance.y;
        }

        var wallSide
        while (stopCondition(tile) == 0) {
            if (sideDistance.x < sideDistance.y) {
                sideDistance.x += deltaSideDistance.x;
                tile.x += step.x;
                wallSide = 0;
            }
            else {
                sideDistance.y += deltaSideDistance.y;
                tile.y += step.y;
                wallSide = 1;
            }
        }

        return { tile, wallSide, step }
    }
}