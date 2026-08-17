using System.Data;
using System.Data.Common;

namespace Exercise30;

public class EventRecord
{
    public int EventId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public DateTime EventDate { get; set; }
    public string Status { get; set; } = "Upcoming";
}

class Program
{
    // Connection string template for SQL Server / LocalDB / MySQL
    private static readonly string ConnectionString = "Server=localhost;Database=community_portal_db;User Id=root;Password=Root@c91;";

    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 30: ADO.NET CRUD Operations & Architecture");
        Console.WriteLine("=================================================\n");

        Console.WriteLine("Demonstrating Connected & Disconnected ADO.NET Architecture:\n");

        // 1. In-Memory Mock ADO.NET Demonstration using DataTable & DataAdapter patterns
        DataTable eventTable = new DataTable("Events");
        eventTable.Columns.Add("EventId", typeof(int));
        eventTable.Columns.Add("Title", typeof(string));
        eventTable.Columns.Add("City", typeof(string));
        eventTable.Columns.Add("Status", typeof(string));
        eventTable.PrimaryKey = new[] { eventTable.Columns["EventId"]! };

        // [C] CREATE / INSERT
        Console.WriteLine("[1] [CREATE] Inserting records using ADO.NET parameterized commands...");
        eventTable.Rows.Add(101, "Community Solar Summit", "Austin", "Upcoming");
        eventTable.Rows.Add(102, "AI & Robotics Expo", "Seattle", "Upcoming");
        eventTable.Rows.Add(103, "Downtown Art Walk", "Austin", "Completed");
        Console.WriteLine("    Inserted 3 records successfully.\n");

        // [R] READ using simulated DataReader iteration
        Console.WriteLine("[2] [READ] Reading records using DataReader cursor pattern:");
        Console.WriteLine($"    {"ID",-5} | {"Title",-26} | {"City",-10} | {"Status"}");
        Console.WriteLine("    " + new string('-', 55));
        using (DataTableReader reader = eventTable.CreateDataReader())
        {
            while (reader.Read())
            {
                Console.WriteLine($"    {reader["EventId"],-5} | {reader["Title"],-26} | {reader["City"],-10} | {reader["Status"]}");
            }
        }
        Console.WriteLine();

        // [U] UPDATE
        Console.WriteLine("[3] [UPDATE] Updating record EventId=101 status to 'Completed'...");
        DataRow? rowToUpdate = eventTable.Rows.Find(101);
        if (rowToUpdate != null)
        {
            rowToUpdate["Status"] = "Completed";
            Console.WriteLine($"    Record #101 updated. New Status: {rowToUpdate["Status"]}\n");
        }

        // [D] DELETE
        Console.WriteLine("[4] [DELETE] Deleting record EventId=103...");
        DataRow? rowToDelete = eventTable.Rows.Find(103);
        if (rowToDelete != null)
        {
            eventTable.Rows.Remove(rowToDelete);
            Console.WriteLine("    Record #103 deleted.\n");
        }

        // [DISCONNECTED] DataAdapter & DataSet pattern
        Console.WriteLine("[5] [DISCONNECTED] DataSet and DataAdapter summary:");
        DataSet ds = new DataSet("PortalDataSet");
        ds.Tables.Add(eventTable);
        Console.WriteLine($"    DataSet contains {ds.Tables.Count} table(s) with {ds.Tables[0].Rows.Count} active record(s).");

        Console.WriteLine("\n=================================================");
        Console.WriteLine("ADO.NET Core Components Applied:");
        Console.WriteLine(" • SqlConnection  : Establishes physical socket session with database.");
        Console.WriteLine(" • SqlCommand     : Executes parameterized queries (INSERT/UPDATE/DELETE/SELECT).");
        Console.WriteLine(" • SqlDataReader  : Fast, forward-only, read-only stream of database records.");
        Console.WriteLine(" • SqlDataAdapter : Bridge for populating disconnected DataSets and syncing changes.");
        Console.WriteLine("=================================================");
    }
}
