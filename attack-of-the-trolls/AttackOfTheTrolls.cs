using System;

[Flags]
public enum AccountType
{
    Guest     = Permission.Read,
    User      = Permission.Write | Permission.Read,
    Moderator = Permission.All
}

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
        => Enum.IsDefined(typeof(AccountType), accountType) ? (Permission) accountType : Permission.None;

    public static Permission Grant(Permission current, Permission grant) => current | grant;

    public static Permission Revoke(Permission current, Permission revoke) => current ^ (current & revoke);

    public static bool Check(Permission current, Permission check) => (current & check) == check;
}
