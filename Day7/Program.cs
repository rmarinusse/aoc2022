Directory Part1(string[] input)
{
    var i = 0;
    var root = new Directory { Name = "/" };
    var currentDirectory = root;
    while (i < input.Length)
    {
        var parts = input[i].Split(' ');
        if (parts[0].Equals("$"))
        {
            if (parts[1].Equals("cd"))
            {
                switch (parts[2])
                {
                    case "/":
                        currentDirectory = root;
                        break;
                    case "..":
                        currentDirectory = currentDirectory.ParentDirectory;
                        break;
                    default:
                        {
                            if (!currentDirectory.SubDirectories.Any(d => d.Name.Equals(parts[2])))
                            {
                                currentDirectory.SubDirectories.Add(new Directory
                                { Name = parts[2], ParentDirectory = currentDirectory });
                            }

                            currentDirectory = currentDirectory.SubDirectories.Single(d => d.Name.Equals(parts[2]));
                            break;
                        }
                }

                i++;
            }
            else if (parts[1].Equals("ls"))
            {
                i++;
            }
        }
        else
        {
            if (parts[0].Equals("dir"))
            {
                if (!currentDirectory.SubDirectories.Any(d => d.Name.Equals(parts[1])))
                {
                    currentDirectory.SubDirectories.Add(new Directory
                    { Name = parts[1], ParentDirectory = currentDirectory });
                }

                i++;
            }
            else
            {
                if (!currentDirectory.Files.Any(f => f.Name.Equals(parts[1])))
                {
                    currentDirectory.Files.Add(new File { Name = parts[1], Size = int.Parse(parts[0]) });
                }

                i++;
            }
        }
    }

    var size = SumSizeUnder100K(root);
    Console.WriteLine($"Total size of directories under 100K {size}");
    return root;
}

long SumSizeUnder100K(Directory directory)
{
    var sum = directory.Size <= 100000 ? directory.Size : 0;
    sum += directory.SubDirectories.Sum(SumSizeUnder100K);
    return sum;
}

void Part2(Directory root)
{
    var minimumSize = 30000000 - (70000000 - root.Size);
    var candidates = GetCandidatesForDeletion(minimumSize, root);
    var smallestDirectory = candidates.OrderBy(d => d.Size).First();
    Console.WriteLine($"Smallest directory size for deletion {smallestDirectory.Size}");
}

List<Directory> GetCandidatesForDeletion(long minimumSize, Directory directory)
{
    var candidates = new List<Directory>();
    if (directory.Size >= minimumSize) candidates.Add(directory);
    directory.SubDirectories.ForEach(d => candidates.AddRange(GetCandidatesForDeletion(minimumSize, d)));
    return candidates;
}

void Run()
{
    var input = System.IO.File.ReadAllLines(@"input.txt");

    var root = Part1(input);
    Part2(root);
}

Run();

class File
{
    public string Name { get; set; }
    public long Size { get; set; }
}

class Directory
{
    public string Name { get; set; }
    public long Size => Files.Sum(f => f.Size) + SubDirectories.Sum(d => d.Size);
    public List<File> Files = new();
    public List<Directory> SubDirectories = new();
    public Directory ParentDirectory { get; set; }
}