# Sticky Rooms
## Description
Inspired by: https://www.gamasutra.com/blogs/AAdonaac/20150903/252889/Procedural_Dungeon_Generation_Algorithm.php

## Configuration
1. Map size
2. Circle radius
3. List of created rooms
    - The list contains information about the rooms that already have been and need to be processed
4. Room constraints
    - Minimum and maximum size
5. Number of tries of rooms placements per Wall - NumberOfTries
6. Width/Height room threshold
7. Width/Height threshold

## Step by step

### Rooms generation
1. Create random room in the center of the map
    - Add room to the list and mark it as Unprocessed
2. Create a random room and try to attach it to each wall of the current room. Repeat NumberOfTries times.
    - Omit a new room if it intersects with existing room
        - Loop throught rooms list and check if the room is intersecting
    - Wall position choosen randomly
    - Add each new room to the list and mark it as Unprocessed
3. Select next room and go to step 2 until rooms are not intersecting with circle radius
4. Select main rooms
    - Pick rooms that are above width/height threshold.
5. Take all the midpoints of the selected rooms and feed that into the Delaunay procedure.
    - https://en.wikipedia.org/wiki/Delaunay_triangulation
6. Generate a minimum spanning tree from the graph
    - https://en.wikipedia.org/wiki/Minimum_spanning_tree
    - The minimum spanning tree will ensure that all main rooms in the dungeon are reachable but also will make it so that they're not all connected as before. This is useful because by default we usually don't want a super connected dungeon but we also don't want unreachable islands. However, we also usually don't want a dungeon that only has one linear path, so what we do now is add a few edges back from the Delaunay graph.

### Hallways
1. Go through each node in the graph and then for each other node that connects to it we create lines between them.
    - If the nodes are horizontally close enough (their y position is similar) then we create a horizontal line. If the nodes are vertically close enough then we create a vertical line.
    - If the nodes are not close together either horizontally or vertically then we create 2 lines forming an L shape. 
    - ~close enough~ means calculates the midpoint between both nodes' positions and checks to see if that midpoint's x or y attributes are inside the node's boundaries. If they are then create the line from that midpoint's position. If they aren't then create two lines, both going from the source's midpoint to the target's midpoint but only in one axis.
2. Check to see which rooms that aren't main rooms that collide with each of the lines. Colliding rooms are then added to structure that is being used to hold all this by now and they will serve as the skeleton for the hallways.