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
    public static class BllAudioRatingMapper
    {
        public static AudioRatingEntity ToBllAudioFileEntity(this AudioRating model)
        {
            return new AudioRatingEntity()
            {
                Id = model.Id,
                Rating = model.Rating,
                AudioFileId = model.AudioFileId,
                UserId = model.UserId
            };
        }

        public static AudioRating ToDalAudioFileEntity(this AudioRatingEntity model)
        {
            return new AudioRating()
            {
                Id = model.Id,
                Rating = model.Rating,
                AudioFileId = model.AudioFileId,
                UserId = model.UserId
            };
        }
    }
}
