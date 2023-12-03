namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Day2b();
        }

        static void Day2b()
        {
            var txt = File.ReadAllText("input.txt");

            int pows = 0;
            txt = txt.Replace("\r", "");
            foreach (var lin in txt.Split("\n"))
            {
                try
                {
                    var lineParts = lin.Split(":");
                    int gameId = int.Parse(lineParts[0].Split(" ")[1]);

                    var gameParts = lineParts[1].Split(";");
                    var maxColors = new Dictionary<string, int>();
                    maxColors.Add("blue", 0);
                    maxColors.Add("green", 0);
                    maxColors.Add("red", 0);
                    foreach (var gamePart in gameParts)
                    {
                        var grabParts = gamePart.Split(",");                        
                        foreach (var gp in grabParts)
                        {
                            var cubes = gp.Trim().Split(" ");
                            var nrc = int.Parse(cubes[0]);
                            var col = cubes[1];

                            if (nrc > maxColors[col])
                            {
                                maxColors[col] = nrc;
                            }
                        }                            
                    }
                    pows += maxColors["red"] * maxColors["green"] * maxColors["blue"];
                }
                catch { }
            }

            Console.WriteLine("Sum Powers : " + pows);
            Console.ReadLine();
        }

        static void Day2a()
        {
            var txt = File.ReadAllText("input.txt");

            Dictionary<string, int> maxColors = new Dictionary<string, int>();
            maxColors.Add("blue", 14);
            maxColors.Add("green", 13);
            maxColors.Add("red", 12);

            int sumIDs = 0;
            txt = txt.Replace("\r", "");
            foreach (var lin in txt.Split("\n"))
            {
                try
                {
                    var lineParts = lin.Split(":");
                    int gameId = int.Parse(lineParts[0].Split(" ")[1]);

                    var gameParts = lineParts[1].Split(";");
                    bool isValid = true;
                    foreach (var gamePart in gameParts)
                    {
                        var grabParts = gamePart.Split(",");

                        foreach (var gp in grabParts)
                        {
                            var cubes = gp.Trim().Split(" ");
                            var nrc = int.Parse(cubes[0]);
                            var col = cubes[1];

                            if (nrc > maxColors[col])
                            {
                                isValid = false;
                                break;
                            }
                        }
                        if (!isValid)
                        {
                            break;
                        }
                    }
                    if (isValid)
                    {
                        sumIDs += gameId;
                    }
                }
                catch { }
            }

            Console.WriteLine("Sum Game IDs : " + sumIDs);
            Console.ReadLine();
        }
    }
}