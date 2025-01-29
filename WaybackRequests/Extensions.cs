namespace WaybackRequests;

public static class Extensions
{
    public static string ToValidFileName(this string name) =>
        string.Join('_', name.Split(Path.GetInvalidFileNameChars()));
    
    public static string ToValidFileName(this SnapshotData snapshotData) =>
        snapshotData.ToString().ToValidFileName();
}