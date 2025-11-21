using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Services;
using MusicApp.Models.Spotify;

namespace MusicApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase {
        private readonly SpotifyApiService _spotifyApiService;

        public AlbumsController(SpotifyApiService spotifyApiService) {
            _spotifyApiService = spotifyApiService;
        }

        // [HttpGet("access-token")]
        // public async Task<ActionResult> GetAccessToken() {
        //     // return Ok(await _spotifyApiService.GetAccessTokenAsync());
        //     return Ok(await _spotifyApiService.RequestNewAccessToken());
        // }

        [HttpGet("new-releases")]
        public async Task<ActionResult<AlbumResponse>> GetNewReleaseAlbums() {
            return Ok(await _spotifyApiService.GetNewReleaseAlbums());
        }
    }
}
