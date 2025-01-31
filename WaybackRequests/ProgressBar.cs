namespace WaybackRequests;

public class ProgressBar
{
    private int _total;
    private int _current;
    private int _barSize;
    private const char Empty = '\u2591';
    private const char Filled = '\u2593';

    public ProgressBar(int total, int barSize = 40)
    {
        _total = total;
        _current = 0;
        _barSize = barSize;
    }

    public void Add(int value = 1)
    {
        _current += value;
        DrawBar();
        if(_current == _total)
            Console.WriteLine("\nГотово.");
    }

    private void DrawBar()
    {
        double progress = (double)_current / _total;
        int filledLength = (int)(progress * _barSize);

        string filledPart = new string(Filled, filledLength);
        string emptyPart = new string(Empty, _barSize - filledLength);
        string percentage = progress.ToString("P0"); 
        
        Console.CursorLeft = 0;
        Console.Write($"\u2590{filledPart}{emptyPart}\u258c  {_current}/{_total} ({percentage})");
    }
}