using System.Collections;
using System.Linq;

void Part1(Dictionary<int, Stack<char>> stacks, List<Move> moves)
{
    moves.ForEach(m =>
    {
        for (var i = 0; i < m.Amount; i++)
        {
            stacks[m.To].Push(stacks[m.From].Pop());
        }
    });
    var top = new string(stacks.Select(s => s.Value.Peek()).ToArray());
    Console.WriteLine($"Crates at top of stacks {top}");
}

void Part2(Dictionary<int, Stack<char>> stacks, List<Move> moves)
{
    moves.ForEach(m =>
    {
        var crates = new List<char>();
        for (var i = 0; i < m.Amount; i++)
        {
            crates.Add(stacks[m.From].Pop());
        }

        for (var c = crates.Count - 1; c >= 0; c--)
        {
            stacks[m.To].Push(crates[c]);
        }
    });
    var top = new string(stacks.Select(s => s.Value.Peek()).ToArray());
    Console.WriteLine($"Crates at top of stacks {top}");
}

(Dictionary<int, Stack<char>>, List<Move>) Parse()
{
    var input = File.ReadAllText(@"input.txt");
    var s = input.Split("\r\n\r\n")[0].Split("\r\n");

    var stacks = new Dictionary<int, Stack<char>>();

    // Last line has stack numbering
    foreach (var i in s.Last().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse))
    {
        var stack = new Stack<char>();
        for (var row = s.Length - 1; row >= 0; row--)
        {
            var crate = s[row].Skip(4 * (i - 1)).Take(3).ToArray();
            if (crate.ElementAt(0).Equals('['))
                stack.Push(crate.ElementAt(1));
        }
        stacks.Add(i, stack);
    }

    var moves = input.Split("\r\n\r\n")[1].Split("\r\n").Select(m =>
    {
        var move = new Move();
        var parts = m.Split(' ');
        move.Amount = int.Parse(parts[1]);
        move.From = int.Parse(parts[3]);
        move.To = int.Parse(parts[5]);
        return move;
    }).ToList();
    return (stacks, moves);
}

void Run()
{
    var (stacks1, moves1) = Parse();
    Part1(stacks1, moves1);
    var (stacks2, moves2) = Parse();
    Part2(stacks2, moves2);
}

Run();

class Move
{
    public int From;
    public int To;
    public int Amount;
}
