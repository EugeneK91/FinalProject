using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using DAL.DTO;
using DAL.Interface;
using Entity;


namespace DAL.Concrete
{
    public class AudioFileRepository:IAudioFileRepository
    {
        private readonly DbContext _context;

        public AudioFileRepository(DbContext context)
        {
            _context = context;
        }
        public IEnumerable<AudioFile> GetAll()
        {
            return _context.Set<AudioFile>().ToList();
        }

        public AudioFile GetById(int key)
        {
            var audioFile  = _context.Set<AudioFile>().Find(key);
            if (audioFile == null) return null;
            return audioFile;
        }

        public IEnumerable<AudioFile> GetByPredicate(Expression<Func<AudioFile, bool>> f)
        {
            return _context.Set<AudioFile>().Where(f);
        }

        public AudioFile GetFirstByPredicate(Expression<Func<AudioFile, bool>> f)
        {
            return _context.Set<AudioFile>().FirstOrDefault(f);
        }

        public void Create(AudioFile e)
        {
            _context.Set<AudioFile>().Add(e);
        }

        public void Delete(AudioFile e)
        {
            var entity = _context.Set<AudioFile>().Find(e.Id);
            _context.Set<AudioFile>().Remove(entity);
        }

        public void Update(AudioFile entity)
        {
            var audioFile = _context.Set<AudioFile>().Find(entity.Id);

            audioFile.Artist = entity.Artist;
            audioFile.Genre = entity.Genre;
            audioFile.Rating = entity.Rating;
            audioFile.SongName = entity.SongName;

            _context.Set<AudioFile>().AddOrUpdate(audioFile);
        }

    }
}
