using System;

public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    private void CurrentState() 
        => Console.WriteLine($"{nameof(database)} has an internal state of {nameof(Database.State)}.{database.DbState}");

    public void Begin()
    {
        database.BeginTransaction();
        CurrentState();
    }

    public void Write(string data)
    {
        try
        {
            database.Write(data);
        }
        catch (InvalidOperationException error)
        {
            database.Dispose();
        }
        CurrentState();
    }

    public void Commit()
    {
        using (database)
        {
            try
            {
                database.EndTransaction();
            }
            catch (InvalidOperationException error) {}
        }
        CurrentState();
    }
    
    public void Dispose() => database.Dispose();
}
