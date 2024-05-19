namespace LikeCommentFeedbackMicroservice.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        //Task<int> SaveChangesAsync();
    }
}
