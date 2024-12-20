﻿using AccountManagement.Application.Contract.Account;
using Framework.Domain;

namespace AccountManagement.Domain.AccountAgg;

public interface IAccountRepository : IRepository<long, Account>
{
    Account GetByUserName(string userName);
    EditAccount GetDetails(long id);
    List<AccountViewModel> GetAccounts();
    List<AccountViewModel> Search(AccountSearchModel searchModel);
}