using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace Infrastructuur.Libraries
{
    public class YoutubeLibrary
    {
        private readonly YouTube _youTube;

        public YoutubeLibrary(YouTube youTube)
        {
            _youTube = youTube;
        }
        public async Task<YouTubeVideo> DlVideoAsync(string link) => await _youTube.GetVideoAsync(link);
    }
}
