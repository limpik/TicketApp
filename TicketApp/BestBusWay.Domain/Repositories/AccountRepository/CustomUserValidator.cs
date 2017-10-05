﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BestBusWay.Domain.Concrete;
using BestBusWay.Domain.Entities;

namespace BestBusWay.Domain.Repositories.AccountRepository
{
    public class CustomUserValidator : IIdentityValidator<AppUser>
    {
        public async Task<IdentityResult> ValidateAsync(AppUser item)
        {
            List<string> errors = new List<string>();

            if (String.IsNullOrEmpty(item.UserName.Trim()))
                errors.Add("Вы указали пустое имя.");

            string userNamePattern = @"^[a-zA-Z0-9а-яА-Я]+$";

            if (!Regex.IsMatch(item.UserName, userNamePattern))
                errors.Add("В имени разрешается указывать буквы английского или русского языков, и цифры");

            if (errors.Count > 0)
                return IdentityResult.Failed(errors.ToArray());

            return IdentityResult.Success;
        }
    }
}