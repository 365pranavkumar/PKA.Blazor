namespace PKA.Blazor.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Retrieves all entities of type <typeparamref name="T"/> asynchronously.
        /// </summary>
        /// <param name="ignoreQueryFilters">A boolean value indicating whether to ignore query filters.</param>
        /// <param name="orderBy"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of entities.</returns>
        Task<List<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool ignoreQueryFilters = false);

        /// <summary>
        /// Finds an entity of type <typeparamref name="T"/> by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to find.</param>
        /// <param name="ignoreQueryFilters">A boolean value indicating whether to ignore query filters.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the entity if found; otherwise, <c>null</c>.
        /// </returns>
        Task<T?> FindByIdAsync(Guid id, bool ignoreQueryFilters = false);

        /// <summary>
        /// Adds a new entity of type <typeparamref name="T"/> to the repository asynchronously.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Removes an existing entity of type <typeparamref name="T"/> from the repository asynchronously.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task RemoveAsync(T entity);

        /// <summary>
        /// Removes a range of entities of type <typeparamref name="T"/> from the repository asynchronously.
        /// </summary>
        /// <param name="entities">The list of entities to remove.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task RemoveRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// Marks an existing entity of type <typeparamref name="T"/> as soft deleted in the repository asynchronously.
        /// </summary>
        /// <param name="entity">The entity to mark as soft deleted.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task SoftRemoveAsync(T entity);

        /// <summary>
        /// Saves all changes made in the repository asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> SaveChangesAsync();

        BlazorDbContext GetDbContext();
    }
}
