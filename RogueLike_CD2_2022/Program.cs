using RogueLike_CD2_2022;

GameManager gameManager;
Player player;
Map map;

gameManager = new GameManager();

while (!gameManager.isTerminate) {
    gameManager = new GameManager();
    player = new Player();
    map = new Map();
    
    map.CreateMap();
    map.CreateWalls(map.wallsNumber());
    player.PlacePlayer(map);
    
    while (!gameManager.isReset) {
        Console.Clear();
        player.DisplayPlayer(map.Tiles);
        map.DisplayMap();
        player.MovePlayer(gameManager, map.Tiles);
    }
}










