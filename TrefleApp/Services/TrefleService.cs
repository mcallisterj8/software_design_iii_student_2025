using System.Text.Json;
using AutoMapper;
using TrefleApp.Models.Trefle.Dtos;
using TrefleApp.Models.Trefle.Responses;

namespace TrefleApp.Services;

/**
    Responsible for calling the service which interacts with the API, and will
    transform the responses into what our app needs.
*/
public class TrefleService {
    private readonly TrefleApiService _trefleApiService;
    private readonly IMapper _mapper;

    public TrefleService(
        TrefleApiService trefleApiService,
        IMapper mapper
    ) {
        _trefleApiService = trefleApiService;
        _mapper = mapper;
    }

    public async Task<PlantDto?> GetPlantById(int plantId) {
        // TODO: Complete.
        return null;
    }

    public async Task<ICollection<PlantDto>?> GetPlants() {
        // TODO: Complete.
        return null;
    }
}