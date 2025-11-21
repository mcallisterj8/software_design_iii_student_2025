using System.Text.Json;
using System.Text;
using RestSharp;
using MusicApp.Models.Spotify;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.ObjectPool;

namespace MusicApp.Services;

public class SpotifyApiService {
    private readonly RestClient _authClient;
    private readonly RestClient _apiClient;

    private readonly string? _authBaseUrl;
    private readonly string? _apiBaseUrl;

    private readonly string? _clientId;
    private readonly string? _clientSecret;
    private readonly string? _encodedClientInfo;

    private SpotifyTokenResponse? _accessTokenResponse;

    public SpotifyApiService(IConfiguration config) {
        _authBaseUrl = config["Spotify:AuthBaseUrl"] ?? "";
        _apiBaseUrl = config["Spotify:BaseUrl"] ?? "";

        _clientId = config["ClientId"];
        _clientSecret = config["ClientSecret"];

        _encodedClientInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}"));

        _authClient = new RestClient(_authBaseUrl);
        _apiClient = new RestClient(_apiBaseUrl);

    }

    private async Task<SpotifyTokenResponse> GetAccessTokenAsync() {
        if(null == _accessTokenResponse || _accessTokenResponse.IsExpired()){
            _accessTokenResponse = await this.RequestNewAccessToken();
        }

        return _accessTokenResponse;
    }

    private async Task<SpotifyTokenResponse> RequestNewAccessToken(){
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
            _accessTokenResponse = res;
            _accessTokenResponse.AcquiredAt = DateTime.UtcNow;
        }

        return res;
    }


    public async Task<AlbumResponse> GetNewReleaseAlbums() {
        SpotifyTokenResponse tokenResponse = await this.GetAccessTokenAsync();

        var request = new RestRequest($"/browse/new-releases")
            .AddHeader("Authorization", $"Bearer {_accessTokenResponse.AccessToken}")
            .AddHeader("accept", "application/json");

        var response = await _apiClient.GetAsync(request);

        if (!response.IsSuccessStatusCode) {
            Console.WriteLine($"\n\nRESPONSE STATUS:\n\n{response.StatusCode}");
            Console.WriteLine($"\n\nErrorMessage:\n{response.ErrorMessage}\n\n");
            Console.WriteLine($"\n\nError in Content:\n{response.Content}\n\n");
        }

        return JsonSerializer.Deserialize<AlbumResponse>(response.Content);

    }



}