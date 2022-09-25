using Infrastructuur.Enums;
using Infrastructuur.Libraries;
using Infrastructuur.Models.Dtos;
using Infrastructuur.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace Infrastructuur.Extensions
{
    public static class VideoFormatter
    {
        public static async Task<ResultDto> VideoFormatAsync(this YoutubeEntity youtube, YoutubeLibrary lib, FileFormat fileFormat)
        {
            var result = new ResultDto();
            if (string.IsNullOrEmpty(youtube.Link) || string.IsNullOrEmpty(youtube.Path))
            {
                result.Errors.Add("Link or link type is empty!");
                return result;
            }
            //TODO: change static path use youtube.Path property
            //string path = youtube.Path.Replace("\\", "/");
            var video = await lib.DlVideoAsync(youtube.Link);
            switch(fileFormat)
            {
                case FileFormat.MP3:
                    File.WriteAllBytes(
                        youtube.Path + 
                        video.FullName.Replace("mp4", "mp3"),
                        await video.GetBytesAsync());
                    break;
                case FileFormat.MP4:
                    File.WriteAllBytes(
                        youtube.Path + 
                        video.FullName,
                        await video.GetBytesAsync());
                    break;
                default:
                    result.Errors.Add("Invalid format!");
                    break;
            }
            // testing
            result.Link = youtube.Link;
            result.Path = youtube.Path;
            result.Video = video.ConvertToByteArray<YouTubeVideo>();
            return result;
        }
    }
}
