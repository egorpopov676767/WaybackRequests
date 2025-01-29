namespace WaybackRequests;

public static class WebPages
{
    static readonly HttpClient HTTPClient = new();

    public static async Task<string> GetPage(string url)
    {
        return await HTTPClient.GetStringAsync(url);
    }
}