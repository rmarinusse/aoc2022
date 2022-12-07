using System.Threading.Tasks.Sources;
var input = File.ReadAllLines(@"input.txt");

void Part1(string[] input)
{
    var totalScore = 0;
    foreach (var line in input)
    {
        var move = line.Split(' ');
        var left = move[0];
        var right = move[1];
        // A,X = Rock=1
        // B,Y=Paper=2
        // C,Z=Scissors=3

        var score = getScore(left, right);
        totalScore += score;
    }
    Console.WriteLine($"Total score: {totalScore}");
}

void Part2(string[] input)
{
    var totalScore = 0;
    foreach (var line in input)
    {
        var move = line.Split(' ');
        var left = move[0];
        var right = move[1];
        // A = Rock=1
        // B = Paper=2
        // C = Scissors=3
        // X = lose
        // Y = draw
        // Z = win
        var play = getPlay(left, right);
        var score = getScore(left, play);
        totalScore += score;
    }
    Console.WriteLine($"Total score: {totalScore}");

}

int getScore(string left, string right)
{
    if (left == "A" && right == "X")
    {
        return 4;
    }
    else if (left == "A" && right == "Y")
    {
        return 8;
    }
    else if (left == "A" && right == "Z")
    {
        return 3;
    }
    else if (left == "B" && right == "X")
    {
        return 1;
    }
    else if (left == "B" && right == "Y")
    {
        return 5;
    }
    else if (left == "B" && right == "Z")
    {
        return 9;
    }
    else if (left == "C" && right == "X")
    {
        return 7;
    }
    else if (left == "C" && right == "Y")
    {
        return 2;
    }
    //else if (left == "C" && right == "Z")
    //{
    return 6;
    //}
}

string getPlay(string left, string outcome)
{
    if (left == "A" && outcome == "X")
        return "Z";
    else if (left == "A" && outcome == "Y")
        return "X";
    else if (left == "A" && outcome == "Z")
        return "Y";
    else if (left == "B" && outcome == "X")
        return "X";
    else if (left == "B" && outcome == "Y")
        return "Y";
    else if (left == "B" && outcome == "Z")
        return "Z";
    else if (left == "C" && outcome == "X")
        return "Y";
    else if (left == "C" && outcome == "Y")
        return "Z";
    return "X";
}

Part1(input);
Part2(input);