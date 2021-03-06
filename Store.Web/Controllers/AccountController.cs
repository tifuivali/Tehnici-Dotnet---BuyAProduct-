﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Store.Web.CustomerService;
using Store.Web.Models;
using Store.Web.Security;

namespace Store.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly CustomerServiceClient customerServiceClient;

        public AccountController(CustomerServiceClient customerServiceClient)
        {
            this.customerServiceClient = customerServiceClient;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginAccountViewModel userLoginAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                var userCreditalsAreValid = customerServiceClient.VerifyAccount(Mapper.Map<CustomerAccount>(userLoginAccountViewModel));
                if (!userCreditalsAreValid)
                {
                    ModelState.AddModelError("Password", "Invalid email or password.");
                    return View();
                }
                FormsAuthentication.SetAuthCookie(userLoginAccountViewModel.Email, false);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccountViewModel userAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                var alreadyCustomer = customerServiceClient.GetCustomerByEmail(userAccountViewModel.Email);
                if (alreadyCustomer != null)
                {
                    ModelState.AddModelError("Password", "An account with the same email already exists!");
                    return View();
                }
                var createdUser = customerServiceClient.AddCustomer(Mapper.Map<Customer>(userAccountViewModel));
                if (createdUser != null)
                {
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("Password", "An error ocurred!");
                return View();
            }

            return View();
        }

        [AuthorizeUsers]
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [AuthorizeUsers]
        [HttpGet]
        public ActionResult Edit(string email)
        {
            var customer = customerServiceClient.GetCustomerByEmail(email);
            if (customer == null)
            {
                RedirectToAction("GenericError", "Error");
            }
            var userAcountViewModel = Mapper.Map<UserAccountViewModel>(customer);
            return View(userAcountViewModel);
        }

        [AuthorizeUsers]
        [HttpPost]
        public ActionResult Edit(UserAccountViewModel userAccountViewModel)
        {
            var customer = Mapper.Map<Customer>(userAccountViewModel);
            var updatedUserMessage = customerServiceClient.UpdateCustomer(customer);
            if (updatedUserMessage != null)
            {
                var updatedUser = customerServiceClient.GetCustomerByEmail(userAccountViewModel.Email);
                return View(Mapper.Map<UserAccountViewModel>(updatedUser));
            }

            return RedirectToAction("GenericError", "Error");
        }

    }
}