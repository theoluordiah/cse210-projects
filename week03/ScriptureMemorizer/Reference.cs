using System;

class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public Reference(string reference)
    {
        string[] parts = reference.Split(' ');
        string versePart = parts[parts.Length - 1];
        _book = string.Join(" ", parts, 0, parts.Length - 1);

        string[] chapterAndVerse = versePart.Split(':');
        _chapter = int.Parse(chapterAndVerse[0]);

        string[] verseRange = chapterAndVerse[1].Split('-');
        _startVerse = int.Parse(verseRange[0]);
        _endVerse = verseRange.Length > 1 ? int.Parse(verseRange[1]) : _startVerse;
    }

    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}