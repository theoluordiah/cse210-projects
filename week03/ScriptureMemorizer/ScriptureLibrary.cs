class ScriptureLibrary
{
    private List<Scripture> _scriptures;

    public ScriptureLibrary()
    {
        _scriptures = LoadFromFile(FindFilePath("scriptures.txt"));
    }

    public List<Scripture> GetScriptures()
    {
        return _scriptures;
    }

    public Scripture GetRandomScripture()
    {
        return _scriptures[new System.Random().Next(_scriptures.Count)];
    }

    private List<Scripture> LoadFromFile(string file)
    {
        List<Scripture> scriptures = new List<Scripture>();
        string[] lines = System.IO.File.ReadAllLines(file);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split('|');
            if (parts.Length >= 2)
            {
                scriptures.Add(new Scripture(new Reference(parts[0]), parts[1]));
            }
        }

        return scriptures;
    }

    private string FindFilePath(string fileName)
    {
        string[] candidates = new string[]
        {
            System.IO.Path.Combine(AppContext.BaseDirectory, fileName),
            fileName,
        };

        foreach (string candidate in candidates)
        {
            if (System.IO.File.Exists(candidate))
            {
                return candidate;
            }
        }

        System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(System.IO.Directory.GetCurrentDirectory());
        for (int i = 0; i < 5 && directory != null; i++)
        {
            string candidate = System.IO.Path.Combine(directory.FullName, fileName);
            if (System.IO.File.Exists(candidate))
            {
                return candidate;
            }
            directory = directory.Parent;
        }

        return fileName;
    }
}