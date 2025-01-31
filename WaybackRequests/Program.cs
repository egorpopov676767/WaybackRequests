
namespace WaybackRequests;

using static GetSnapshotsData;

public class Program
{
    public static string SaveTo = @"..\..\..\snapshots";

    static Program()
    {
        Directory.CreateDirectory(SaveTo);
    }
    
    public static async Task Main(string[] args)
    {
        // пример команды:
        // save_for dotnet.microsoft.com/en-us/download 20240610 20240611

        while (true)
        {
            var command = Console.ReadLine();
            var parts = command!.Split();
            if (parts.Length == 0)
                continue;
            if (parts[0] == "save_for")
            {
                var (url, from, to) = (parts[1], parts[2], parts[3]);
                await SaveAllValidSnapshotsFor(url, from, to);
            }
            else if (parts[0] == "quit")
                return;
        }
    }
}