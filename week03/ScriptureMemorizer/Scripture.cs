using System;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
        _random = new Random();
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();
        int count = Math.Min(numberToHide, visibleWords.Count);

        foreach (Word word in visibleWords.OrderBy(word => _random.Next()).Take(count))
        {
            word.Hide();
        }
    }

    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()}: {text}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}