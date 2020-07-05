import * as PIXI from 'pixi.js'

import MapViewConfiguration from './MapViewConfiguration'

export default class MapViewRenderer {
    constructor(mapViewRef, app, onTileHover) {
        this.mapViewRef = mapViewRef;
        this.app = app;
        this.onTileHover = onTileHover;

        this.contentSize = MapViewConfiguration.tileSize - MapViewConfiguration.tilePadding
    }

    drawMap(map, screenCenter) {
        this.app.stage.removeChildren(0, this.app.stage.children.length);
        map.tiles.forEach(tile => {
            this.drawTileRelativeToScreenCenter(tile, screenCenter, MapViewConfiguration.colors.tileColor)
        });
    }

    drawActor(actor, screenCenter) {
        this.drawTileRelativeToScreenCenter(actor, screenCenter, MapViewConfiguration.colors.actorColor)
    }

    drawMobs(mobs, screenCenter) {
        // mobs.forEach(mob => {
            this.drawTileRelativeToScreenCenter(mobs, screenCenter, MapViewConfiguration.colors.mobsColor)
        // });
    }

    clickTile(mouseEvent) {
        var mousePosition = this.mousePosition(mouseEvent)
        var tile = this.tileCoordinates(mousePosition)
    }

    drawFloor(tileCoordinates) {
        this.drawTile(tileCoordinates, MapViewConfiguration.colors.tileColor)
    }

    drawTileRelativeToScreenCenter(tileCoordinates, screenCenter, color) {
        const graphics = new PIXI.Graphics();
        graphics.interactive = true;
        graphics.on('mouseover', (event) => {
            const color = new PIXI.filters.ColorMatrixFilter();
            color.lsd(true);
            graphics.filters = [color];
            this.onTileHover(tileCoordinates)
        });

        graphics.on('mouseout', (event) => {
            graphics.filters = [];
            this.onTileHover(null)
        });

        graphics.beginFill(color);
        graphics.drawRect(
            (tileCoordinates.x + screenCenter.x) * MapViewConfiguration.tileSize,
            (tileCoordinates.y + screenCenter.y) * MapViewConfiguration.tileSize,
            this.contentSize,
            this.contentSize);
        graphics.endFill();
        this.app.stage.addChild(graphics);
    }

    drawTile(tileCoordinates, color) {
        const graphics = new PIXI.Graphics();
        graphics.beginFill(color);
        graphics.drawRect(
            tileCoordinates.x * MapViewConfiguration.tileSize,
            tileCoordinates.y * MapViewConfiguration.tileSize,
            this.contentSize,
            this.contentSize);
        graphics.endFill();
        this.app.stage.addChild(graphics);
    }

    tileCoordinates(mousePosition) {
        let x = Math.floor(mousePosition.x / MapViewConfiguration.tileSize)
        let y = Math.floor(mousePosition.y / MapViewConfiguration.tileSize)

        return { x, y }
    }

    mousePosition(mouseEvent) {
        var canvasElement = this.mapViewRef.current.getBoundingClientRect();
        var x = mouseEvent.pageX - canvasElement.x - window.scrollX
        var y = mouseEvent.pageY - canvasElement.y - window.scrollY

        return { x, y }
    }
}