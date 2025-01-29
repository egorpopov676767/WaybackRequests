
namespace WaybackRequests;

using static WebPages;

public class GetSnapshotsData
{
    public static async Task<SnapshotData[]> GetAllSnapshotsDataFor(
        string url, string? from = null, string? to = null)
    {
        var cdxUrl = $"http://web.archive.org/cdx/search/cdx?url={url}";
        if (from != null)
            cdxUrl += $"&from={from}";
        if (to != null)
            cdxUrl += $"&to={to}";
        var cdxSearchResult = await GetPage(cdxUrl);
        return cdxSearchResult
            .Split('\n')
            .Where(line => line != "")
            .Select(line => new SnapshotData(line))
            .ToArray();
    }

    public static async Task<SnapshotData[]> GetAllValidSnapshotsDataFor(
        string url, string? from = null, string? to = null)
    {
        return (await GetAllSnapshotsDataFor(url, from, to))
            .Where(s => s.IsSnapshotValid)
            .ToArray();
    }
}