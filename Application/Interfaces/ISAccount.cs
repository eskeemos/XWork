﻿using Application.Dtos;
using Application.Dtos.AccountDtos;
using Application.Dtos.UserDtos;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ISAccount
    {
        IEnumerable<AccountInfo> GetAccounts();
        AccountInfo GetAccountById(int id);
        int AddAccount(AccountCreate location);
        void UpdateAccount(AccountUpdate location);
        void RemoveAccount(int id);
        int PostUser(UserRegisterDto dto);
        string GenerateJwt(UserLoginDto dto);
    }
}
