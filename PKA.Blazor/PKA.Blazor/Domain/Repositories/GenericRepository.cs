using Microsoft.EntityFrameworkCore;
using PKA.Blazor.Domain.Interfaces;
using System.Linq.Expressions;

namespace PKA.Blazor.Domain.Repositories
{
    public class GenericRepository<T>(BlazorDbContext context) : IGenericRepository<T> where T : class
    {
        /// <inheritdoc />
        public async Task<List<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, bool ignoreQueryFilters)
        {
            var query = context.Set<T>()
                .AsNoTracking();

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters(); // Ignore query filters if specified
            }

            if (orderBy != null)
            {
                query = orderBy(query); // Apply the ordering
            }

            return await query.ToListAsync();
        }

        public async Task<T?> FindByIdAsync(Guid id, bool ignoreQueryFilters = false)
        {
            if (ignoreQueryFilters)
            {
                var entityType = context.Model.FindEntityType(typeof(T));
                var key = entityType!.FindPrimaryKey();
                var param = Expression.Parameter(typeof(T), "e");

                // Only supports single-key for now
                var property = Expression.Property(param, key!.Properties[0].Name);
                var equals = Expression.Equal(property, Expression.Constant(id));
                var lambda = Expression.Lambda<Func<T, bool>>(equals, param);

                return await context.Set<T>()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(lambda);
            }

            return await context.Set<T>().FindAsync(id);
        }

        /// <inheritdoc />
        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        /// <inheritdoc />
        public async Task RemoveAsync(T entity)
        {
            if (entity != null)
            {
                await Task.FromResult(context.Set<T>().Remove(entity));
            }
        }

        /// <inheritdoc />
        public Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task SoftRemoveAsync(T entity)
        {
            entity?.GetType().GetProperty("IsDeleted")?.SetValue(entity, true);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public BlazorDbContext GetDbContext()
        {
            return context;
        }
    }
}
