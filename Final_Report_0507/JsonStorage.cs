using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public static class JsonStorage<T>
{
    private static readonly string BaseUrl = "http://litghostserver.ddns.net:5000/";
    private static readonly string FileName = typeof(T).Name.ToLower() + "s.json";
    private static string FullUrl => BaseUrl + FileName;

    public static async Task<List<T>> LoadAsync()
    {
        using HttpClient client = new HttpClient();
        string json = await client.GetStringAsync(FullUrl);
        return JsonSerializer.Deserialize<List<T>>(json);
    }

    public static async Task SaveAsync(List<T> data)
    {
        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        using HttpClient client = new HttpClient();
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // 嘗試 PUT，若失敗改 POST
        var response = await client.PutAsync(FullUrl, content);

        if (!response.IsSuccessStatusCode)
        {
            // 如果是 MethodNotAllowed，嘗試 POST
            if (response.StatusCode == System.Net.HttpStatusCode.MethodNotAllowed)
            {
                response = await client.PostAsync(FullUrl, content);
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to upload (tried PUT and POST): {response.StatusCode}");
            }
        }
    }
}
