namespace LawnmowerApp;

public class Mower(
    int x,
    int y,
    int maxX,
    int maxY,
    int orientation
)
{
    private (int, int) velocity = (velocities[orientation].Item1, velocities[orientation].Item2);

    private static List<(int, int)> velocities = new List<(int, int)>()
    {
        { (0, 1) },
        { (1, 0) },
        { (0, -1) },
        { (-1, 0) },
    };

    public (int finalX, int finalY, int orientation) ProcessCommands(char[] commands)
    {
        foreach(var command in commands)
        {
            if(command == 'F')
            {
                Move();
            }
            else if(command == 'L') {
                orientation = orientation > 0 ? orientation - 1 : 3;
                velocity = velocities[orientation];
            }
            else if (command == 'R')
            {
                orientation = orientation < 3 ? orientation + 1 : 0;
                velocity = velocities[orientation];
            }
            else
            {
                throw new ArgumentException("Invalid command.");
            }
        }

        return (x, y, orientation);
    }

    private void Move()
    {
        x += x == maxX ? 0 : velocity.Item1;
        y += y == maxY ? 0 : velocity.Item2;
    }
}
