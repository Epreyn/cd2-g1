using RogueLike_CD2_2022;

Player player = new Player();
Map map = new Map();

map.CreateMap();

while (true) {
    Console.Clear();
    player.DisplayPlayer(map.Tiles);
    map.DisplayMap();
    player.MovePlayer();
    
    
}





