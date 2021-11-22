using System;

// TODO: define the 'AccountType' enum
[Flags]
public enum AccountType
{
    Guest     = Permission.Read,
    User      = Permission.Write | Permission.Read,
    Moderator = Permission.All
}

// TODO: define the 'Permission' enum
[Flags]
public enum Permission
{
    Read   = 1 << 0,
    Write  = 1 << 1,
    Delete = 1 << 2,
    All = Read | Write | Delete,
    None = 0
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        return Enum.IsDefined(typeof(AccountType), accountType) ? 
            Enum.Parse<Permission>( ((int)accountType).ToString() ) : Permission.None;
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        return current | grant;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        return current ^ (current & revoke);
    }

    public static bool Check(Permission current, Permission check)
    {
        return (current & check) == check;
    }
}
