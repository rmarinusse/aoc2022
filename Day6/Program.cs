void Part1(string input)
{
    var i = 0;
    var marker = input.Substring(i, 4);
    while (marker.Distinct().Count() != marker.Length)
    {
        i++;
        marker = input.Substring(i, 4);
    }
    Console.WriteLine($"Start of packet marker {marker} location: {i + 4}");
}

void Part2(string input)
{
    var i = 0;
    var marker = input.Substring(i, 14);
    while (marker.Distinct().Count() != marker.Length)
    {
        i++;
        marker = input.Substring(i, 14);
    }
    Console.WriteLine($"Start of message marker {marker} location: {i + 14}");
}

void Run()
{
    var input = File.ReadAllText(@"input.txt");
    Part1(input);
    Part2(input);
}

Run();