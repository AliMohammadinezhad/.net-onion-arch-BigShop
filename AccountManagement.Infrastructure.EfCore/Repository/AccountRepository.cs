﻿using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using Framework.Infrastructure;

namespace AccountManagement.Infrastructure.EfCore.Repository;

public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
{
    private readonly AccountContext _context;
    public AccountRepository(AccountContext context) : base(context)
    {
        _context = context;
    }

    public EditAccount GetDetails(long id)
    {
        return _context.Accounts.Select(x => new EditAccount()
        {
            Id = x.Id,
            FullName = x.FullName,
            Mobile = x.Mobile,
            Password = x.Password,
            RoleId = x.RoleId,
            Username = x.Username
        }).FirstOrDefault(x => x.Id == id);
    }

    public List<AccountViewModel> Search(AccountSearchModel searchModel)
    {
        var query = _context.Accounts.Select(x => new AccountViewModel()
        {
            Id = x.Id,
            Username = x.Username,
            FullName = x.FullName,
            Mobile = x.Mobile,
            ProfilePhoto = x.ProfilePhoto,
            Role = "مدیر سیستم",
            RoleId = 2
        });

        if (!string.IsNullOrWhiteSpace(searchModel.Username))
            query = query.Where(x => x.Username.Contains(searchModel.Username));

        if (!string.IsNullOrWhiteSpace(searchModel.FullName))
            query = query.Where(x => x.FullName.Contains(searchModel.FullName));

        if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
            query = query.Where(x => x.Mobile.Contains(searchModel.Mobile));

        if (searchModel.RoleId > 0 )
            query = query.Where(x => x.RoleId.Equals(searchModel.RoleId));

        return query.OrderByDescending(x => x.Id).ToList();
    }
}