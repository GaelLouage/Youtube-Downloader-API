using Infrastructuur.Enums;
using Infrastructuur.Extensions;
using Infrastructuur.Libraries;
using Infrastructuur.Models.Dtos;
using Infrastructuur.Models.Entities;
using Infrastructuur.Services.Interfaces;
using VideoLibrary;

namespace Infrastructuur.Services.Classes
{
    public class YoutubeService : IYoutubeService
    {
        private readonly YoutubeLibrary _youtubeLibrary;

        public YoutubeService(YoutubeLibrary youtubeLibrary)
        {
            _youtubeLibrary = youtubeLibrary;
        }
        // youtube movie in mp3 format
        public async Task<ResultDto> GetYoutubeMP3FormatAsync(YoutubeEntity youtube) => 
            await youtube.VideoFormatAsync(_youtubeLibrary,FileFormat.MP3);
        // youtube movie in mp4 format
        public async Task<ResultDto> GetYoutubeMP4FormatAsync(YoutubeEntity youtube) => 
            await youtube.VideoFormatAsync(_youtubeLibrary, FileFormat.MP4);
    }
}
