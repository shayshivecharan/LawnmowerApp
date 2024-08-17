using LawnmowerApp;

var lines = File.ReadAllLines("input.txt");

try
{
    var max = lines[0].Split(" ").Select(x => int.Parse(x)).ToArray();

    for(var x = 1; x < lines.Length; x += 2)
    {
        string[] mowerInit = lines[x].Split(" ");
        char[] mowerCommands = lines[x + 1].ToCharArray();

        (int finalX, int finalY, int orientation) = new Mower(
            int.Parse(mowerInit[0]),
            int.Parse(mowerInit[1]),
            max[0],
            max[1],
            (int) Enum.Parse<Orientations>(mowerInit[2])).ProcessCommands(mowerCommands);

        Console.WriteLine($"{finalX} {finalY} {(Orientations)orientation}");
    }

    Console.WriteLine("Press any key to end...");
    Console.ReadKey();
}
catch(Exception ex)
{
    throw new ArgumentException("Invalid file format.", ex);
}


enum Orientations
{
    N = 0,
    E = 1,
    S = 2,
    W = 4
}