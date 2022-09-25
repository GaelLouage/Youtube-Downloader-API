using Infrastructuur.Models.Dtos;
using Infrastructuur.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuur.Services.Interfaces
{
    public interface IYoutubeService
    {
        Task<ResultDto> GetYoutubeMP3FormatAsync(YoutubeEntity youtube);
        Task<ResultDto> GetYoutubeMP4FormatAsync(YoutubeEntity youtube);
    }
}
