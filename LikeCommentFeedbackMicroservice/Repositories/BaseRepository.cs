using LikeCommentFeedbackMicroservice.Data;
using LikeCommentFeedbackMicroservice.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LikeCommentFeedbackMicroservice.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }


        public async Task RemoveAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        //public async Task<int> SaveChangesAsync()
        //{
        //    return await _context.SaveChangesAsync();
        //}
    }
}
