var input = File.ReadAllLines(@"input.txt");

void Part1(string[] input)
{
    var count = 0;
    foreach (var line in input)
    {
        var parts = line.Split(',');
        var one = parts[0].Split('-').Select(c => int.Parse(c));
        var two = parts[1].Split('-').Select(c => int.Parse(c));

        if ((one.ElementAt(0) >= two.ElementAt(0) && one.ElementAt(1) <= two.ElementAt(1)) ||
            (two.ElementAt(0) >= one.ElementAt(0) && two.ElementAt(1) <= one.ElementAt(1)))
        {
            count++;
        }
    }
    Console.WriteLine($"Pairs with contained overlap: {count}");
}

void Part2(string[] input)
{
    var count = 0;
    foreach (var line in input)
    {
        var parts = line.Split(',');
        var one = parts[0].Split('-').Select(c => int.Parse(c));
        var two = parts[1].Split('-').Select(c => int.Parse(c));

        if ((two.ElementAt(0) <= one.ElementAt(0) && one.ElementAt(0) <= two.ElementAt(1)) ||
            (two.ElementAt(0) <= one.ElementAt(1) && one.ElementAt(1) <= two.ElementAt(1)) ||
            (one.ElementAt(0) <= two.ElementAt(0) && two.ElementAt(0) <= one.ElementAt(1)) ||
            (one.ElementAt(0) <= two.ElementAt(1) && two.ElementAt(1) <= one.ElementAt(1)))
        {
            count++;
        }
    }
    Console.WriteLine($"Pairs with overlap: {count}");
}

Part1(input);
Part2(input);