namespace BLL.Interfaces.Entities.Account
{
    /// <summary>
    /// Account with platinum privileges.
    /// </summary>
    public class PlatinumAccount : Account
    {
        #region public Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PlatinumAccount"/> class.
        /// </summary>
        /// <param name="id">id of the account</param>
        /// <param name="name">name of the owner</param>
        /// <param name="surname">surname of the owner</param>
        public PlatinumAccount(string id, string name, string surname) : base(id, name, surname)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatinumAccount"/> class.
        /// </summary>
        /// <param name="id">id of the account</param>
        /// <param name="name">name of the owner</param>
        /// <param name="surname">surname of the owner</param>
        /// <param name="amount">start money on the account</param>
        /// <param name="points">start points on the account</param>
        public PlatinumAccount(string id, string name, string surname, double amount, int points) : base(id, name, surname, amount, points)
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
            return "Platinum";
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
            return (int)(amount / 10);
        }

        /// <summary>
        /// Calculate subtract points according to amount of money.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>Calculating points.</returns>
        protected override int SubtractPoints(double amount)
        {
            return (int)(amount / 10 / 2);
        }
        #endregion // !protected override Methods
    }
}
