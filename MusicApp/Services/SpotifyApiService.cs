using System.Text.Json;
using System.Text;
using RestSharp;
using MusicApp.Models.Spotify;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MusicApp.Services;

public class SpotifyApiService {
    private readonly RestClient _authClient;
    private readonly RestClient _apiClient;

    private readonly string? _authBaseUrl;
    private readonly string? _apiBaseUrl;

    private readonly string? _clientId;
    private readonly string? _clientSecret;
    private readonly string? _encodedClientInfo;

    private SpotifyTokenResponse? _accessToken;

    public SpotifyApiService(IConfiguration config) {
        _authBaseUrl = config["Spotify:AuthBaseUrl"] ?? "";
        _apiBaseUrl = config["Spotify:BaseUrl"] ?? "";

        _clientId = config["ClientId"];
        _clientSecret = config["ClientSecret"];

        _encodedClientInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}"));

        _authClient = new RestClient(_authBaseUrl);
        _apiClient = new RestClient(_apiBaseUrl);

    }

    public async Task<SpotifyTokenResponse> RequestNewAccessToken(){
        var request = new RestRequest($"/token", Method.Post)
            .AddHeader("Authorization", $"Basic {_encodedClientInfo}")
            .AddHeader("Content-Type", "application/x-www-form-urlencoded")
            .AddParameter("grant_type", "client_credentials");

        var response = await _authClient.ExecuteAsync(request);
        
        if(!response.IsSuccessStatusCode) {
            Console.WriteLine($"\n\nRESPONSE STATUS:\n\n{response.StatusCode}");
            Console.WriteLine($"\n\nErrorMessage:\n{response.ErrorMessage}\n\n");
            Console.WriteLine($"\n\nError in Content:\n{response.Content}\n\n");
        }

        SpotifyTokenResponse? res = JsonSerializer.Deserialize<SpotifyTokenResponse>(response.Content);

        if(null != res) {
            _accessToken = res;
            _accessToken.AcquiredAt = DateTime.UtcNow;
        }

        return res;
    }



}