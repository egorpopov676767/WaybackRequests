
namespace WaybackRequests;

using static GetSnapshotsData;

public class Program
{
    static string saveTo = @"..\..\..\snapshots";

    static Program()
    {
        Directory.CreateDirectory(saveTo);
    }
    
    public static async Task Main(string[] args)
    {
        var url = "dotnet.microsoft.com/en-us/download";
        var (from, to) = ("20240610", "20240611");
        
        var snapshotsData = await GetAllSnapshotsDataFor(url, from, to);
        
        foreach (var snapshotData in snapshotsData)
        {
            var content = await snapshotData.GetSnapshotContent();
            await File.WriteAllTextAsync(
                $@"{saveTo}\{snapshotData.ToValidFileName()}.html", 
                content);
        }
    }
}