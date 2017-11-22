namespace ORM
{
    /// <summary>
    /// Account for object relational mapping.
    /// </summary>
    public class OrmAccount
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
        /// Amount money on the account.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Bonus points on the account.
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Type of the account.
        /// </summary>
        public string Type { get; set; }
    }
}
