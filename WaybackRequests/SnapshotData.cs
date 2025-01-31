namespace WaybackRequests;

using static WebPages;

public readonly struct SnapshotData
{
    public readonly string Timestamp;
    public readonly string SourceURL;
    public readonly string SnapURL;
    public readonly string MIMEType;
    public readonly string ResponseCode;
    public readonly bool IsSnapshotValid;
    public readonly int ContentSize;
    //public readonly string Content;

    public SnapshotData(string description)
    {
        var parts = description.Split(' ');
        Timestamp = parts[1];
        SourceURL = parts[2];
        SnapURL = $"http://web.archive.org/web/{Timestamp}id_/{SourceURL}";
        MIMEType = parts[3];
        ResponseCode = parts[4];
        IsSnapshotValid = ResponseCode[0] == '2';
        ContentSize = int.Parse(parts[6]);
    }

    public async Task<string> GetSnapshotContent()
    {
        return await GetPage(SnapURL);
    }

    public async Task GetAndSaveSnapshotContent()
    {
        await File.WriteAllTextAsync(
            $@"{Program.SaveTo}\{this.ToValidFileName()}.html", 
            await GetSnapshotContent());
    }

    public override string ToString() =>
        $"{SourceURL}_{Timestamp}";
}