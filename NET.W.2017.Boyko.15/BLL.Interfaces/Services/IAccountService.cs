namespace BLL.Interfaces.Services
{
    /// <summary>
    /// Interface of account service.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Deposit money to account.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>True if success, false otherwise.</returns>
        bool DepositToAccount(double amount);

        /// <summary>
        /// Withdraw money from account.
        /// </summary>
        /// <param name="amount">amount of money</param>
        /// <returns>Thru if success, false otherwise.</returns>
        bool WithdrawFromAccount(double amount);

        /// <summary>
        /// Create new account.
        /// </summary>
        /// <param name="accountType">account type</param>
        /// <param name="name">name of the owner of the account</param>
        /// <param name="surname">surname of the owner of the account</param>
        /// <param name="amount">start amount of money</param>
        void CreateNewAccount(string accountType, string name, string surname, double amount = 0);

        /// <summary>
        /// Delete account.
        /// </summary>
        void DeleteAccount();

        /// <summary>
        /// Select account
        /// </summary>
        /// <param name="id">id of the account</param>
        void SelectAccount(string id);

        /// <summary>
        /// Show account info.
        /// </summary>
        void ShowAccountInfo();
    }
}
