using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using Bank.Models;
using BLL.Interfaces.Entities.Account;
using BLL.Interfaces.Entities.Exceptions;
using BLL.Interfaces.Services;
using DependencyResolver;
using Ninject;


namespace Bank.Controllers
{
    public class AccountController : Controller
    {
        private static readonly IKernel Resolver;

        static AccountController()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolverConsole();
        }

        // GET: Account
        public ActionResult Index()
        {
            return RedirectToAction("Register");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                var service = Resolver.Get<IAccountService>();
                service.CreateNewAccount(account.Type, account.Name, account.Surname, account.Amount);
                ModelState.Clear();
                ViewBag.Message = "Account successfully registered.";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount userAccount)
        {
            var service = Resolver.Get<IAccountService>();
            List<Account> accounts = service.SelectAll(userAccount.Name, userAccount.Surname);
            if (accounts.Count != 0)
            {
                Session["Username"] = userAccount.Name;
                Session["Usersurname"] = userAccount.Surname;
                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "User is not found.");
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["Username"] != null)
            {
                var service = Resolver.Get<IAccountService>();
                List<Account> accounts = service.SelectAll(Session["Username"].ToString(), Session["Usersurname"].ToString());
                return View(accounts);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Withdraw()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Withdraw(Transfer transfer)
        {
            var service = Resolver.Get<IAccountService>();
            string message;
            try
            {
                service.SelectAccount(transfer.Id);
                if (!service.WithdrawFromAccount(transfer.Amount))
                {
                    message = "Falil to withdraw " + transfer.Amount + " money.";
                }
                else
                {
                    message = "Operation complete successfully!";
                }
            }
            catch (AccountNotFoundException)
            {
                message = "Account not found!";
            }
            catch (NotEnoughMoneyException)
            {
                message = "Not enough money on the Account!";
            }

            ViewBag.Message = message;
            return View();
        }

        public ActionResult Deposit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Deposit(Transfer transfer)
        {
            var service = Resolver.Get<IAccountService>();
            string message = string.Empty;
            try
            {
                service.SelectAccount(transfer.Id);
                if (!service.DepositToAccount(transfer.Amount))
                {
                    message = "Falil to deposit " + transfer.Amount + " money.";
                }
                else
                {
                    message = "Operation complete successfully!";
                }
            }
            catch (AccountNotFoundException)
            {
                message = "Account not found!";
            }

            ViewBag.Message = message;
            return View();
        }

        public ActionResult CloseAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CloseAccount(Transfer transfer)
        {
            var service = Resolver.Get<IAccountService>();
            string message = string.Empty;
            try
            {
                service.SelectAccount(transfer.Id);
                service.DeleteAccount();
            }
            catch (AccountNotFoundException)
            {
                message = "Account not found!";
            }
            catch (AccountHasMoneyException)
            {
                message = "Account has money. Withdraw before delete.";
            }

            ViewBag.Message = message;
            return View();
        }
    }
}