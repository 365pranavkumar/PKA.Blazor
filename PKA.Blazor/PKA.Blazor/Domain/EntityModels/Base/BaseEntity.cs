namespace PKA.Blazor.Domain.EntityModels.Base
{
    public abstract class BaseEntity<TId> where TId : struct
    {
        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        public TId Id { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was created.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is marked as deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets the date and time when the entity record was deleted, if applicable.
        /// </summary>
        public DateTime? DeletedOn { get; set; }
    }
}
