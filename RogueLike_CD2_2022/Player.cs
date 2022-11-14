namespace RogueLike_CD2_2022; 

public class Player {
    public char Sprite = '@';
    public Position CurrentPosition = new Position(1, 1);
    public Position OldPosition = new Position(1, 1);

    public void MovePlayer() {
        var keyPressed = Console.ReadKey();
        OldPosition.X = CurrentPosition.X;
        OldPosition.Y = CurrentPosition.Y;

        switch (keyPressed.Key) {
            case ConsoleKey.LeftArrow:
                CurrentPosition.X -= 1;
                break;
            
            case ConsoleKey.RightArrow:
                CurrentPosition.X += 1;
                break;
            
            case ConsoleKey.UpArrow:
                CurrentPosition.Y -= 1;
                break;
            
            case ConsoleKey.DownArrow:
                CurrentPosition.Y += 1;
                break;
        }
    }

    public void DisplayPlayer(Tile[,] array) {
        array[OldPosition.X, OldPosition.Y].Sprite = '.';
        array[CurrentPosition.X, CurrentPosition.Y].Sprite = Sprite;
    }
}