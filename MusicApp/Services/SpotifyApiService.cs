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
    private readonly string? _authToken;

    private SpotifyTokenResponse? _accessToken;

    public SpotifyApiService(IConfiguration config) {

        _clientId = config["ClientId"];
        _clientSecret = config["ClientSecret"];

    }



}