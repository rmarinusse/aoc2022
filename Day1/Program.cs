
void Part1()
{
    var maxCalories = 0;
    var calories = 0;
    foreach (string line in File.ReadLines(@"input1.txt"))
    {
        if (string.IsNullOrEmpty(line))
        {
            if (calories > maxCalories) { maxCalories = calories; }
            calories = 0;
        }
        else
        {
            calories += int.Parse(line);
        }
    }

    Console.WriteLine($"Max calories: {maxCalories}");
}

void Part2()
{

    var lines = File.ReadAllText(@"input1.txt");
    var total = lines.Split("\r\n\r\n").Select(line => line.Split("\r\n").Select(int.Parse).Sum()).ToList().OrderByDescending(s => s).Take(3).Sum();

    Console.WriteLine($"Max calories top 3: {total}");
}

Part1();
Part2();
