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
        DateTime date;
        int rating;
        string comment;

        do
        {
            WriteLine("Enter the date for the entry (dd-mm-yyyy), or press enter for today: ");
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
            while (!int.TryParse(ReadLine(), out rating) || rating < 1 || rating > 5)
            {
                WriteLine("Invalid rating. Please try again.");
            }

            WriteLine("Enter your comment for the day (200 characters or less), press enter to leave blank: ");
            comment = ReadLine() ?? string.Empty;

            WriteLine("You entered the following information:");
            WriteLine("Date: {0}\nRating: {1}\nComment: {2}\n", date, rating, comment);
            WriteLine("Is this correct? (Y/N)");

        } while (ReadLine()?.ToUpper() != "Y");

        var newEntry = new JournalEntry
        {
            Date = date,
            Rating = rating,
            Comment = comment
        };



        _db.JournalEntries.Add(newEntry);
        _db.SaveChanges();

        WriteLine("Entry added successfully.");

    }

    public void ListEntries()
    {
        var entries = _db.JournalEntries;

        // Hand empty case
        if (!entries.Any())
        {
            WriteLine("No entries found.");
            return;
        }

        // Display all entries
        WriteLine("Your Journal entries:");
        foreach (JournalEntry entry in entries)
        {
            WriteLine("----------------------------------");
            WriteLine($"Date: {entry.Date:d}");
            WriteLine($"Rating: {entry.Rating}");
            WriteLine($"Comment: {entry.Comment}");
        }
    }
}