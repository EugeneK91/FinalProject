using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using DAL.DTO;
using Entity;

namespace BLL.Mappers
{
    public static class BllAudioFileMapper
    {
        public static AudioFileEntity ToBllAudioFile(this AudioFile dalAudioFile)
        {
            return new AudioFileEntity()
            {
                Id = dalAudioFile.Id,
                Genre = dalAudioFile.Genre,
                SongName = dalAudioFile.SongName,
                Artist = dalAudioFile.Artist,
                Rating = dalAudioFile.Rating,
                Body = dalAudioFile.Body
            };
        }
        public static AudioFile ToDalAudioFile(this AudioFileEntity dalAudioFile)
        {
            return new AudioFile()
            {
                Id = dalAudioFile.Id,
                Genre = dalAudioFile.Genre,
                SongName = dalAudioFile.SongName,
                Artist = dalAudioFile.Artist,
                Rating = dalAudioFile.Rating,
                Body = dalAudioFile.Body
            };
        }
    }
}
