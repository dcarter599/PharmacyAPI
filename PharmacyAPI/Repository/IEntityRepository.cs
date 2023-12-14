namespace PharmacyAPI.Repository
{
    public interface IEntityRepository<T>
    {
        Task<T?> GetAsync(int id);
        List<T> GetAll();
        Task UpdateAsync(T oldEntity, T entity);
    }
}
