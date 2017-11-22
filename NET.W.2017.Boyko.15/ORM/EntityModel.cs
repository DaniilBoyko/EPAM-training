namespace ORM
{
    using System.Data.Entity;

    /// <summary>
    /// Module of entity.
    /// </summary>
    public class EntityModel : DbContext
    {
        /// <summary>
        /// Constructor initialize the instance of <see cref="EntityModel"/> class.
        /// </summary>
        public EntityModel()
            : base("name=EntityModel")
        {
        }

        /// <summary>
        /// Gets or sets database set of accounts.
        /// </summary>
        public virtual DbSet<OrmAccount> Accounts { get; set; }
    }
}