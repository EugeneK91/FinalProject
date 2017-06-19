using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface;
using BLL.Mappers;
using DAL.DTO;
using DAL.Interface;
using Entity;

namespace BLL.Concrete
{
    public class AudioRatingService:IAudioRatingService
    {
        private readonly IAudioRatingRepository _audioRatingRepository;
        private readonly IUnitOfWork _uof;
        private readonly IUserService _userService;

        public AudioRatingService(IAudioRatingRepository audioRatingRepository, IUnitOfWork uof,IUserService userService)
        {
            _uof = uof;
            _audioRatingRepository = audioRatingRepository;
            _userService = userService;
        }

        public void SetRating(int songId, decimal rating,int userId)
        {
            Expression<Func<AudioRating, bool>> predicate = c => c.AudioFileId == songId && c.UserId == userId;
            var audioRating = _audioRatingRepository.GetFirstByPredicate(predicate);
            if (audioRating != null)
            {
                audioRating.Rating = rating;
                _audioRatingRepository.Update(audioRating);
            }
            else
            {
                _audioRatingRepository.Create(new AudioRating()
                { AudioFileId = songId,
                    Rating = rating,
                    UserId = userId});
            }
            _uof.Commit();
        }
        public decimal GetRating(int songId, int userId)
        {
           Expression<Func<AudioRating, bool>> predicate = c => c.UserId == userId && c.AudioFileId == songId;
           var rating = _audioRatingRepository.GetFirstByPredicate(predicate);
           return rating?.Rating ?? 0;
        }
    }
}
