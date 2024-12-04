﻿using AccountManagement.Domain.AccountAgg;
using Framework.Domain;

namespace AccountManagement.Domain.RoleAgg;

public class Role : EntityBase
{
    public string Name { get; private set; }
    public List<Account> Accounts { get; private set; }

    public Role(string name)
    {
        Name = name;
    }

    public void Edit(string name)
    {
        Name = name;
    }
}