using System;

namespace Task1.Solution
{
    /// <summary>
    /// Service of check password.
    /// </summary>
    public class PasswordCheckerService
    {
        /// <summary>
        /// Store repository.
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Constructor initialize the instance of the <see cref="PasswordCheckerService"/> class.
        /// </summary>
        /// <param name="repository">repository</param>
        public PasswordCheckerService(IRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Verify password, if OK write to repository.
        /// </summary>
        /// <param name="conditions">conditions for check password</param>
        /// <param name="password">password for check</param>
        /// <returns>Tuple whick contains if password valid and information message.</returns>
        public Tuple<bool, string> VerifyPassword(Func<string, Tuple<bool, string>> conditions, string password)
        {
            if (conditions == null)
            {
                throw new ArgumentNullException(nameof(conditions));
            }

            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            foreach (Delegate condition in conditions.GetInvocationList())
            {
                Tuple<bool, string> tuple = (Tuple<bool, string>)condition.DynamicInvoke(password);
                if (!tuple.Item1)
                {
                    return tuple;
                }
            }

            _repository.Create(password);

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}
