using System.Text.Json;
using RestSharp;
using TrefleApp.Models.Trefle.Responses;

namespace TrefleApp.Services;

/**
    Responsible strictly for talking with the Trefle API.
*/
public class TrefleApiService {
    private readonly RestClient _restClient;

    private readonly string? _apiKey;
    private readonly string? _baseUrl;

    public TrefleApiService(IConfiguration config) {
        // TODO: Complete.
    }

    public async Task<PlantResponse?> GetPlantById(int plantId) {
        // TODO: Complete.
        return null;
    }

    public async Task<PlantListResponse?> GetPlants() {
        // TODO: Complete.
        return null;
    }

}