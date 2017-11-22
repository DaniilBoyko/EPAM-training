namespace DAL.Interfaces.DTO
{
    /// <summary>
    /// Data access layer account.
    /// </summary>
    public class DalAccount : IEntity
    {
        /// <summary>
        /// Id of the account.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the account.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Surname of the account.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Amount of the account.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Points of the account.
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Type of the account.
        /// </summary>
        public string Type { get; set; }
    }
}
