class PromptGenerator
{
    public List<string> _prompts;
    private List<string> _unusedPrompts;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What made me smile today?",
            "What did I learn today that I want to remember?",
            "Who am I grateful for today and why?",
            "What challenge did I face today and how did I handle it?",
            "What is one goal I want to work toward tomorrow?"
        };

        _unusedPrompts = new List<string>(_prompts);
        Shuffle();
    }

    public string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
            Shuffle();
        }

        string prompt = _unusedPrompts[0];
        _unusedPrompts.RemoveAt(0);
        return prompt;
    }

    private void Shuffle()
    {
        Random random = new Random();
        for (int i = _unusedPrompts.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            string temp = _unusedPrompts[i];
            _unusedPrompts[i] = _unusedPrompts[j];
            _unusedPrompts[j] = temp;
        }
    }
}