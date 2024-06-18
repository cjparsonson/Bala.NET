using Bala.Shared; // JournalDbContext, JournalEntry, JournalEntryValidationExtensions

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
            WriteLine("Date: {0:dd-MM-yyyy}\nRating: {1}\nComment: {2}\n", date, rating, comment);
            WriteLine("Is this correct? (Y/N)");

        } while (ReadLine()?.ToUpper() != "Y");

        var newEntry = new JournalEntry
        {
            Date = date,
            Rating = rating,
            Comment = comment
        };

        if (!newEntry.IsValidDate())
        {
            WriteLine($"You cannot choose a future date: {newEntry.Date} . Please try again.");
            return;
        }

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
        // TODO - Add paging and a helper method to display entries
        WriteLine("Your Journal entries:");
        foreach (JournalEntry entry in entries)
        {
            WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
            WriteLine($"ID: {entry.Id}");
            WriteLine($"Date: {entry.Date:d}");
            WriteLine($"Rating: {entry.Rating}");
            WriteLine($"Comment: {entry.Comment}");
        }
        WriteLine(); // Add a blank line
    }

    public void EditEntry(int Id)
    {
        var entry = _db.JournalEntries.Find(Id);
        if (entry == null)
        {
            WriteLine("Entry not found.");
            return;
        }

        // Display the entry
        WriteLine("Current entry:");
        WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
        WriteLine($"ID: {entry.Id}");
        WriteLine($"Date: {entry.Date:d}");
        WriteLine($"Rating: {entry.Rating}");
        WriteLine($"Comment: {entry.Comment}");

        // Ask user if they want to edit
        WriteLine("Do you want to edit this entry? (Y/N)");
        if (ReadLine()?.ToUpper() != "Y")
        {
            return;
        }
        else
        {
            // New values
            DateTime newDate;
            int newRating;

            // Ask for new values one by one
            WriteLine("Enter the date for the entry (dd-mm-yyyy), or press enter for today: ");
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.Enter)
            {
                newDate = DateTime.Now;
            }
            else
            {
                while (!DateTime.TryParse(ReadLine(), out newDate))
                {
                    WriteLine("Invalid date. Please try again.");
                }
                entry.Date = newDate;
            }

            WriteLine("Enter the new rating for the day (1-5, with 1 being bad), or press enter to skip: ");
            string? inputRating = ReadLine();
            if (!string.IsNullOrEmpty(inputRating))
            {
                while (!int.TryParse(inputRating, out newRating) || newRating < 1 || newRating > 5)
                {
                    WriteLine("Invalid rating. Please try again.");
                }
                entry.Rating = newRating;
            }

            WriteLine("Enter the new comment for the day (200 characters or less), press enter to skip: ");
            string? newComment = ReadLine();
            if (!string.IsNullOrEmpty(newComment))
            {
                entry.Comment = newComment;
            }

            // Validate
            if (!entry.IsValidDate())
            {
                WriteLine($"You cannot choose a future date: {entry.Date:d} . Please try again.");
                return;
            }
            // Save changes
            _db.SaveChanges();

            WriteLine("Entry updated successfully.");
        }
    }

    public void DeleteEntry(int Id)
    {
        var entry = _db.JournalEntries.Find(Id);
        if (entry == null)
        {
            WriteLine("Entry not found.");
            return;
        }

        // Display the entry
        WriteLine("Current entry:");
        WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
        WriteLine($"ID: {entry.Id}");
        WriteLine($"Date: {entry.Date:d}");
        WriteLine($"Rating: {entry.Rating}");
        WriteLine($"Comment: {entry.Comment}");

        // Ask user if they want to delete
        WriteLine("Do you want to delete this entry? (Y/N)");
        if (ReadLine()?.ToUpper() != "Y")
        {
            return;
        }
        else
        {
            _db.JournalEntries.Remove(entry);
            _db.SaveChanges();

            WriteLine("Entry deleted successfully.");
        }
    }
}

