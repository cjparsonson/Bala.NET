using Microsoft.EntityFrameworkCore; // DbContext, DbSet<T>
using Bala.Shared; // JournalEntry
using Bala.Console; // JournalEntryManager


using (JournalDbContext db = new()) // Ensure the database is created
{
    bool deleted = await db.Database.EnsureDeletedAsync();
    WriteLine($"Database deleted: {deleted}");

    bool created = await db.Database.EnsureCreatedAsync();
    WriteLine($"Database created: {created}");

    WriteLine("SQL script used to create the database:");
    WriteLine(db.Database.GenerateCreateScript());

    // Initiate a new JournalEntryManager 
    JournalEntryManager manager = new(db);

    // Menu
    bool menuLoop = true;
    while (menuLoop)
    {
        WriteLine("Choose an option:");
        WriteLine("A - Add a journal entry");
        WriteLine("L - List journal entries");
        WriteLine("E - Edit a journal entry");
        WriteLine("D - Delete a journal entry");
        WriteLine("Q - Quit");

        string choice = ReadLine()?.ToUpper() ?? string.Empty; // Read user input

        switch (choice)
        {
            case "A":
                manager.AddEntry();
                break;
            // Add more cases here
            case "Q":
                menuLoop = false;
                break;
            case "L":
                manager.ListEntries();
                break;
            case "E":
                WriteLine("Enter the ID of the entry you want to edit: ");
                int id = int.TryParse(ReadLine(), out id) ? id : -1;
                manager.EditEntry(id);
                break;
            case "D":
                WriteLine("Enter the ID of the entry you want to delete: ");
                id = int.TryParse(ReadLine(), out id) ? id : -1;
                manager.DeleteEntry(id);
                break;
            default:
                WriteLine("Invalid choice. Please try again.");
                break;
        }

    }
}


