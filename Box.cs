using System;
using System.Threading;
using System.Collections.Generic;

public class Box
{
    public int Left { get; }
    public int Top { get; }
    public int Width { get; set; }
    public int Height { get; set; }
    public ConsoleColor BackgroundColor { get; set; }
    public ConsoleColor ForegroundColor { get; set; }
    public string Title { get; }

    private int ScrollOffset { get; set; }

    public Box(int left, int top, int width, int height, ConsoleColor backgroundColor, ConsoleColor foregroundColor, string title)
    {
        Left = left;
        Top = top;
        Width = width;
        Height = height;
        BackgroundColor = backgroundColor;
        ForegroundColor = foregroundColor;
        Title = title;
        ScrollOffset = 0;
    }
    
    public void DisplayContent(string[] content)
    {
        int contentHeight = Math.Min(content.Length, Height - 2);

        Console.SetCursorPosition(Left, Top);
        Console.BackgroundColor = BackgroundColor;
        Console.ForegroundColor = ForegroundColor;

        Console.Write(" " + Title.PadRight(Width - 4));
        Console.Write(" ▐█");
        Console.BackgroundColor = ConsoleColor.Black;

        for (int i = Top + 1; i < Top + Height; i++)
        {
            Console.SetCursorPosition(Left, i);
            Console.Write("║");
            Console.SetCursorPosition(Left + Width, i);
            Console.Write("║");
        }

        Console.SetCursorPosition(Left, Top + Height);
        Console.Write("╚" + new string('═', Width - 1) + "╝");

        for (int i = 0; i < contentHeight; i++)
        {
            int contentIndex = i + ScrollOffset;
            if (contentIndex >= 0 && contentIndex < content.Length)
            {
                Console.SetCursorPosition(Left + 1, Top + i + 1);
                Console.Write(content[contentIndex]);
            }
        }

        if (content.Length > Height - 2)
        {
            if (ScrollOffset > 0)
            {
                Console.SetCursorPosition(Left + Width - 1, Top + 1);
                Console.Write("▲");
            }

            if (ScrollOffset < content.Length - (Height - 2))
            {
                Console.SetCursorPosition(Left + Width - 1, Top + Height - 2);
                Console.Write("▼");
            }
        }

        // Add icons for Minimize, Maximize, and Close on the right side
        Console.SetCursorPosition(Left + Width - 3, Top);
        Console.Write("□");
        Console.SetCursorPosition(Left + Width - 2, Top);
        Console.Write("■");
        Console.SetCursorPosition(Left + Width - 1, Top);
        Console.Write("✕");

        Console.ResetColor();
    }

    public void ScrollUp()
    {
        if (ScrollOffset > 0)
        {
            ScrollOffset--;
        }
    }

    public void ScrollDown(string[] content)
    {
        if (ScrollOffset < content.Length - (Height - 2))
        {
            ScrollOffset++;
        }
    }

    public void Clear()
    {
        for (int i = Top + 1; i < Top + Height - 1; i++)
        {
            Console.SetCursorPosition(Left + 1, i);
            Console.Write(new string(' ', Width - 2));
        }
    }

    public void ResetColors()
    {
        Console.ResetColor();
    }

    public void DisplayContent(string content)
    {
        // Convert the string content to an array of lines
        string[] contentArray = content.Split('\n');

        // Call the existing DisplayContent method with the array of lines
        DisplayContent(contentArray);
    }

    internal void DisplayContent(object v)
    {
        throw new NotImplementedException();
    }
}