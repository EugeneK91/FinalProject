using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.Interface;
using Entity;


namespace DAL.Concrete
{
    public class AudioRatingRepository:IAudioRatingRepository
    {
        private readonly DbContext _context;

        public AudioRatingRepository(DbContext context)
        {
            _context = context;
        }
        public IEnumerable<AudioRating> GetAll()
        {
            return _context.Set<AudioRating>().ToList();
        }

        public AudioRating GetById(int key)
        {
            return _context.Set<AudioRating>().Find(key);
        }

        public IEnumerable<AudioRating> GetByPredicate(Expression<Func<AudioRating, bool>> f)
        {
            return _context.Set<AudioRating>().Where(f);
        }

        public AudioRating GetFirstByPredicate(Expression<Func<AudioRating, bool>> f)
        {
            return _context.Set<AudioRating>().FirstOrDefault(f);
        }

        public void Create(AudioRating e)
        {
            _context.Set<AudioRating>().Add(e);
        }

        public void Delete(AudioRating e)
        {
            _context.Set<AudioRating>().Remove(e);
        }

        public void Update(AudioRating entity)
        {
            _context.Set<AudioRating>().AddOrUpdate(entity);
        }
    }
}
