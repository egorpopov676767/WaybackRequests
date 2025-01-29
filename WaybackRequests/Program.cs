
namespace WaybackRequests;

using static GetSnapshotsData;

public class Program
{
    public static async Task Main(string[] args)
    {
        var snapshotsData = await GetAllSnapshotsDataFor(
            "dotnet.microsoft.com/en-us/download");
        var first = await snapshotsData[0].GetSnapshotContent();
        var saveTo = @"..\..\..\example.html";
        await File.WriteAllTextAsync(saveTo, first);
        Console.WriteLine();
    }
}