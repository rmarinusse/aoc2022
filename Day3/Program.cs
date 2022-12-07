using System.Text;

var input = File.ReadAllLines(@"input.txt");

void Part1(string[] input)
{
    var sum = 0;
    foreach (var line in input)
    {
        var compartment1 = new String(line.Take(line.Length / 2).ToArray());
        var compartment2 = new String(line.Skip(line.Length / 2).ToArray());
        var common = compartment1.Intersect(compartment2).First();

        if (Char.IsLower(common))
        {
            sum += (int)common - 96;
        }
        else
        {
            sum += (int)common - 38;
        }
    }
    Console.WriteLine($"Sum of priorities: {sum}");
}

void Part2(string[] input)
{
    int i = 0;
    var eof = false;
    var sum = 0;
    while (!eof)
    {
        var elf1 = input[i];
        var elf2 = input[i + 1];
        var elf3 = input[i + 2];
        var common12 = new String(elf1.Intersect(elf2).ToArray());
        var common123 = common12.Intersect(elf3).First();
        if (Char.IsLower(common123))
        {
            sum += (int)common123 - 96;
        }
        else
        {
            sum += (int)common123 - 38;
        }
        i += 3;
        if (i >= input.Length)
            eof = true;
    }
    Console.WriteLine($"Sum of priorities: {sum}");
}

Part1(input);
Part2(input);