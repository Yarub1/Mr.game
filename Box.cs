using System;
using System.Threading;
using System.Collections.Generic;

public class Box
{
    /// <summary>
    /// This block of code defines the Box class and its properties. The Box class has the following properties:
    /// 
    /// Left, Top: The coordinates of the top-left corner of the box.
    /// Width, Height: The dimensions of the box.
    /// BackgroundColor, ForegroundColor: The background and foreground colors of the box.
    /// Title: The title of the box.
    /// ScrollOffset: The offset used for scrolling the content of the box.
    /// 
    /// </summary>
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
        ///<summary>
        /// This is the constructor of the Box class. It takes the parameters necessary to initialize the properties of the Box object.
        /// The constructor assigns the parameter values to the corresponding properties and sets the ScrollOffset to 0.
        /// <summary>
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
    {//This method, DisplayContent, is responsible for rendering the box and its content on the console.
     //It takes an array of strings (content) as input, which represents the lines of content to be displayed inside the box.
     // 
     // The method starts by calculating the contentHeight, which is the maximum number of lines that can fit inside the box.
     // 
     // Next, it sets the console cursor position to the top-left corner of the box and sets the background and foreground colors to the specified values.
     // 
     // The method then writes the title of the box, padded to fit the width, followed by a decorative character. It also sets the background color back to black.
     // 
     // A loop is used to draw the vertical lines on the left and right sides of the box.
     // 
     // After that, it draws the bottom line of the box using a combination of characters.
     // 
     // Another loop is used to display the content inside the box. It takes into account the ScrollOffset to determine which lines of content to display. The content is written starting from the second row of the box.
     // 
     // If the content exceeds the height of the box, it adds scroll indicators (▲ and ▼) to indicate that scrolling is possible.
     // 
     // Finally, it adds icons for minimizing, maximizing, and closing the box on the right side.

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
    {//These methods, ScrollUp and ScrollDown, are used to scroll the content of the box.
     //ScrollUp decreases the ScrollOffset if it's greater than 0, allowing the content to move up.
     //ScrollDown increases the ScrollOffset if it's less than the difference between the content length and the height of the box,
     //allowing the content to move down.
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