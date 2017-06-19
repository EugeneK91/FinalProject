using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interface;
using BLL.Mappers;
using DAL.Interface;
using Entity;

namespace BLL.Concrete
{
    public class AudioFileService: IAudioFileService
    {
        private readonly IAudioFileRepository _audioFileRepository;
        private readonly IUnitOfWork _uow;

        public AudioFileService(IAudioFileRepository audioFileRepository, IUnitOfWork uow)
        {
            _audioFileRepository = audioFileRepository;
            _uow = uow;
        }

        public IEnumerable<AudioFileEntity> GetAllFiles()
        {
            return _audioFileRepository.GetAll().Select(c => c.ToBllAudioFile());
        }

        public void SaveFile(AudioFileEntity audioFile)
        {
            if (audioFile.Id == 0) _audioFileRepository.Create(audioFile.ToDalAudioFile());
            else _audioFileRepository.Update(audioFile.ToDalAudioFile());
            _uow.Commit();
        }

        public AudioFileEntity GetById(int id)
        {
            return _audioFileRepository.GetById(id).ToBllAudioFile();
        }

        public void DeleteFile(int id)
        {
            var audioFile = _audioFileRepository.GetById(id);
            _audioFileRepository.Delete(audioFile);
            _uow.Commit();
        }

        public IEnumerable<AudioFileEntity> SerchAudioFiles(BllSearchModel model)
        {
            var predicate = PredicateBuilder.True<AudioFile>();

            if (!string.IsNullOrEmpty(model.Artist))
                predicate = predicate.And(c => c.Artist.ToLower().Contains(model.Artist.ToLower()));
            if (!string.IsNullOrEmpty(model.Genre))
                predicate = predicate.And(c => (c.Genre.ToLower()).Contains(model.Genre.ToLower()));
            if (!string.IsNullOrEmpty(model.SongName))
                predicate = predicate.And(c => (c.SongName.ToLower()).Contains(model.SongName.ToLower()));

            return _audioFileRepository.GetByPredicate(predicate).Select(c=>c.ToBllAudioFile());
        }
    }
}
