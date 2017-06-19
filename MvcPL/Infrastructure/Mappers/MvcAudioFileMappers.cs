using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Entities;
using BLL.Mappers;
using MvcPL.Models.AccountModel;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcAudioFileMappers
    {
        public static AudioFileViewModel ToMvcAudioFile(this AudioFileEntity audioFile)
        {
            return new AudioFileViewModel()
            {
                Id = audioFile.Id,
                Genre = audioFile.Genre,
                SongName = audioFile.SongName,
                Artist = audioFile.Artist,
                Rating = audioFile.Rating,
                Body = (HttpPostedFileBase)new MemoryPostedFile(audioFile.Body) ,
            };
        }

        public static AudioFileEntity ToBllAudioFile(this AudioFileViewModel audioFile)
        {
            return new AudioFileEntity()
            {
                Id = audioFile.Id,
                Genre = audioFile.Genre,
                SongName = audioFile.SongName,
                Artist = audioFile.Artist,
                Rating = audioFile.Rating,
                Body = audioFile.Body.HttpPostedFileBaseMusicToByteArray(),
            };
        }
    }
}