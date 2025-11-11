using AutoMapper;
using ChinookAutomapperExample.Models.Entities;
using ChinookAutomapperExample.Models.Dtos;
using NuGet.DependencyResolver;

namespace ChinookAutomapperExample.Services.Mapping;

public class AlbumMappingService {
    private readonly IMapper _mapper;

    public AlbumMappingService(IMapper mapper) {
        _mapper = mapper;
    }

    /*
        Mappings to DTO.
    */
    public AlbumDto MapToAlbumDto(Album artist) {
        return _mapper.Map<AlbumDto>(artist);
    }

    /*
        Mappings back to Entity.
    */

    public Album MapToAlbum(AlbumDto albumDto) {
        return _mapper.Map<Album>(albumDto);
    }

}