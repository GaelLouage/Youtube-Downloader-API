using Infrastructuur.Models.Dtos;
using Infrastructuur.Models.Entities;
using Infrastructuur.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace YoutubeDlApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YoutubeController : ControllerBase
    {
 
        private readonly IYoutubeService _youtubeService;
        public YoutubeController(IYoutubeService youtubeService)
        {
            _youtubeService = youtubeService;
        }

        [HttpGet("mp3/")]
        [ProducesResponseType(200, Type = typeof(ResultDto))] // ok
        [ProducesResponseType(400)] // bad request
        [ProducesResponseType(404)] // not found
        public async Task<IActionResult> GetVideoMp3Format([FromQuery] YoutubeEntity youtube)
        {
            var youtubeVideo = await _youtubeService.GetYoutubeMP3FormatAsync(youtube);
            if(youtubeVideo == null)
            {
                return NotFound("Video not found!");
            }
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("","Model is not valid!");
                return BadRequest($"{ModelState}");
            }
            return Ok(youtubeVideo);
        }

        [HttpGet("mp4/{link}")]
        [ProducesResponseType(200, Type = typeof(ResultDto))] // ok
        [ProducesResponseType(400)] // bad request
        [ProducesResponseType(404)] // not found
        public async Task<IActionResult> GetVideoMp4Format([FromQuery] string path,string link)
        {
            var youtube = new YoutubeEntity();
            youtube.Path = path;
            youtube.Link = link;
            var youtubeVideo = await _youtubeService.GetYoutubeMP4FormatAsync(youtube);
            if (youtubeVideo == null)
            {
                return NotFound("Video not found!");
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Model is not valid!");
                return BadRequest($"{ModelState}");
            }
            return Ok(youtubeVideo);
        }
    }
}
