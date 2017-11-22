namespace BLL.Interfaces.Entities.Account
{
    /// <summary>
    /// Account with gold privileges.
    /// </summary>
    public class GoldAccount : Account
    {
        #region public Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="GoldAccount"/> class.
        /// </summary>
        /// <param name="id">id of the account</param>
        /// <param name="name">name of the owner</param>
        /// <param name="surname">surname of the owner</param>
        public GoldAccount(string id, string name, string surname) : base(id, name, surname)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoldAccount"/> class.
        /// </summary>
        /// <param name="id">id of the account</param>
        /// <param name="name">name of the owner</param>
        /// <param name="surname">surname of the owner</param>
        /// <param name="amount">start money on the account</param>
        /// <param name="points">start points on the account</param>
        public GoldAccount(string id, string name, string surname, double amount, int points) : base(id, name, surname, amount, points)
        {
        }
        #endregion // !public Constructors

        #region public Methods
        /// <summary>
        /// Get type of account.
        /// </summary>
        /// <returns>Name of type.</returns>
        public override string GetAccountType()
        {
            return "Gold";
        }
        #endregion // !public Methods

        #region protected override Methods
        /// <summary>
        /// Calculate add points according to amount of money.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>Calculating points.</returns>
        protected override int AddPoints(double amount)
        {
            return (int)(amount / 10 * 2);
        }

        /// <summary>
        /// Calculate subtract points according to amount of money.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>Calculating points.</returns>
        protected override int SubtractPoints(double amount)
        {
            return (int)(amount / 10 / 3);
        }
        #endregion // !protected override Methods
    }
}
