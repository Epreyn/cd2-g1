namespace RogueLike_CD2_2022; 

public class Player {
    public char Sprite = '@';
    public ConsoleColor Color = ConsoleColor.Red;
    public Position CurrentPosition = new Position(1, 1);
    public Position OldPosition = new Position(1, 1);
    
    public void PlacePlayer(Map map) {
        var isPlaced = false;
        var rng = new Random();
        while (!isPlaced) {
            var randomX = rng.Next(1, map.Width);
            var randomY = rng.Next(1, map.Height);

            if (map.Tiles[randomX, randomY].IsPassable) {
                CurrentPosition.X = randomX;
                CurrentPosition.Y = randomY;
                OldPosition.X = randomX;
                OldPosition.Y = randomY;
                isPlaced = true;
            }
        }
    }

    public void MovePlayer(GameManager gameManager, Tile[,] tiles) {
        var keyPressed = Console.ReadKey();
        var futurePosition = new Position(CurrentPosition.X, CurrentPosition.Y);
        OldPosition.X = CurrentPosition.X;
        OldPosition.Y = CurrentPosition.Y;

        switch (keyPressed.Key) {
            case ConsoleKey.Q:
                gameManager.isReset = true;
                gameManager.isTerminate = true;
                break;
            
            case ConsoleKey.R:
                gameManager.isReset = true;
                break;
            
            case ConsoleKey.LeftArrow:
                futurePosition.X -= 1;
                if (tiles[futurePosition.X,futurePosition.Y].IsPassable)
                    CurrentPosition.X -= 1;
                break;
            
            case ConsoleKey.RightArrow:
                futurePosition.X += 1;
                if (tiles[futurePosition.X,futurePosition.Y].IsPassable)
                    CurrentPosition.X += 1;
                break;
            
            case ConsoleKey.UpArrow:
                futurePosition.Y -= 1;
                if (tiles[futurePosition.X,futurePosition.Y].IsPassable)
                    CurrentPosition.Y -= 1;
                break;
            
            case ConsoleKey.DownArrow:
                futurePosition.Y += 1;
                if (tiles[futurePosition.X,futurePosition.Y].IsPassable)
                    CurrentPosition.Y += 1;
                break;
        }
    }

    public void DisplayPlayer(Tile[,] tiles) {
        tiles[OldPosition.X, OldPosition.Y] = new Tile(
            position: OldPosition,
            TileType.Ground);
        
        tiles[CurrentPosition.X, CurrentPosition.Y].Color = Color;
        tiles[CurrentPosition.X, CurrentPosition.Y].Sprite = Sprite;
        
    }
}