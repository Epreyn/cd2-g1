namespace RogueLike_CD2_2022; 

public class Map {
    private Random rng = new Random();
    public int Width;
    public int Height;
    public Tile[,] Tiles;

    private int minPercent = 10;
    private int maxPercent = 20;

    public Map() {
        Width = rng.Next(20, 41);
        Height = rng.Next(5, 9);
        
        Tiles = new Tile[Width, Height];
    }

    public Map(int width, int height) {
        Width = width;
        Height = height;
        Tiles = new Tile[Width, Height];
    }

    private bool isBorder(int x, int y) {
        return x == 0 
               || y == 0 
               || x == Width - 1
               || y == Height - 1;
    }

    public void CreateMap() {
        for (int y = 0; y < Height; y++) {
            for (int x = 0; x < Width; x++) {
                Tiles[x, y] = isBorder(x, y) ?
                    new Tile(
                    position: new Position(x, y),
                    type: TileType.Wall) 
                    : 
                    new Tile(
                    position: new Position(x, y),
                    type: TileType.Ground);
            }
        }
    }

    public int wallsNumber() {
        var emptyPlaceNumber = (Width - 2) * (Height - 2);
        var min = emptyPlaceNumber * minPercent / 100;
        var max = emptyPlaceNumber * maxPercent / 100;
        return rng.Next(min, max + 1);
    }

    public void CreateWalls(int number) {
        while (number > 0) {
            var randomX = rng.Next(1,Width);
            var randomY = rng.Next(1,Height);

            if (Tiles[randomX, randomY].IsPassable) {
                Tiles[randomX, randomY] = new Tile(
                    position: new Position(randomX,randomY),
                    type: TileType.Wall);
                number--;
            }
        }
    }

    public void DisplayMap() {
        for (int y = 0; y < Height; y++) {
            for (int x = 0; x < Width; x++) {
                Console.ForegroundColor = Tiles[x, y].Color;
                Console.Write(Tiles[x, y].Sprite);
            }
            Console.WriteLine();
        }
    }
}