# Top Down Game

This is a game created for practicing different subjects:
* Mainly development via the component pattern (although there is minimal inheritance where it deemed fit).
* XML code documentation, in order to generate a doc, available on /Top Down Game 1/Docs/html/index.html.
* General GitHub version control practices.

## Game Features
* The goal of the game is to collect every item on each map, avoiding the enemies.
* Controls: WASD to move.
* Menu
* Map Generation

## Map Generation
There are 3 different ways of creating the match maps:
1. From scratch, using a simple algorithm that places random walls on the map.
2. From a .txt file.
3. From prefabs.

The composition pattern allows to quickly change between each map loading approach on two steps:

1. On the Hierarchy, on the "Map Loader" GameObject enable only the GameObject of the desired loading approach.

2. On the "Game Comm Hub" GameObject, drag the chosen Map Loader GameObject to the "MapLoader" field, on the GameCommHub script.

## Character Movement

The characters' movement is also easily changed through composition. The enemies or items can be controlled like the hero and the hero could move like the NPCs.

Their collision logic is also easily interchangeable.

## Docs

The code documentation is avaiable on the Docs folder (/Top Down Game 1/Docs/html/index.html)
