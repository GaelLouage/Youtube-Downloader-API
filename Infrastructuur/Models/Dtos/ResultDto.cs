using Infrastructuur.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace Infrastructuur.Models.Dtos
{
    public sealed class ResultDto : YoutubeEntity
    {
        public List<string> Errors { get; set; } = new List<string>();
        public byte[] Video { get; set; } = new byte[] { };
    }
}
