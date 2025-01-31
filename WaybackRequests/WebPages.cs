namespace WaybackRequests;

public static class WebPages
{
    static readonly HttpClient HTTPClient = new();

    public static async Task<string> GetPage(string url)
    {
        while (true)
        {
            try
            {
                return await HTTPClient.GetStringAsync(url);
            }
            catch (HttpRequestException e)
            {
                continue;
            }
        }
    }
}