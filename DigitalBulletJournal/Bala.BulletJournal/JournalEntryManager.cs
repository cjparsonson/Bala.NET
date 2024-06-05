using System;
using Bala.Shared; // JournalDbContext, JournalEntry

namespace Bala.Console;

public class JournalEntryManager
{
    private readonly JournalDbContext _db;

    // Constructor
    public JournalEntryManager(JournalDbContext db)
    {
        _db = db;
    }

    // Methods
    public void AddEntry()
    {
        WriteLine("Enter the date for the entry (dd-mm-yyyy), or press enter for today: ");
        DateTime date;
        ConsoleKey key = ReadKey().Key;
        if (key == ConsoleKey.Enter)
        {
            date = DateTime.Now;
        }
        else
        {
            while (!DateTime.TryParse(ReadLine(), out date))
            {
                WriteLine("Invalid date. Please try again.");
            }
        }
        
        WriteLine("Enter your rating for the day (1-5, with 1 being bad), or press enter for 3: ");
        int rating;
        while (!int.TryParse(ReadLine(), out rating) || rating < 1 || rating > 5)
        {
            WriteLine("Invalid rating. Please try again.");
        }

        WriteLine("Enter your comment for the day (200 characters or less), press enter to leave blank: ");
        string comment = ReadLine() ?? string.Empty;

        
    }
}