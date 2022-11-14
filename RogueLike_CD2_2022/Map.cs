namespace RogueLike_CD2_2022; 

public class Map {
    public int Width = 40;
    public int Height = 8;
    public Tile[,] Tiles;

    public Map() {
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