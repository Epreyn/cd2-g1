namespace RogueLike_CD2_2022;

public enum TileType {
    Ground,
    Wall
}

public class Tile {
    public Position Position;
    public char Sprite;
    public bool IsPassable;
    public ConsoleColor Color;

    public Tile(Position position, char sprite, bool isPassable,
        ConsoleColor color) {
        Position = position;
        Sprite = sprite;
        IsPassable = isPassable;
        Color = color;
    }

    public Tile(Position position, TileType type) {
        Position = position;

        switch (type) {
            case TileType.Ground:
                Sprite = '·';
                IsPassable = true;
                Color = ConsoleColor.DarkGray;
                break;
            
            case TileType.Wall:
                Sprite = '¶';
                IsPassable = false;
                Color = ConsoleColor.DarkGreen;
                break;
        }
    }
}