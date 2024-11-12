using System;

// TODO: define the 'AccountType' enum
enum AccountType {
    Guest,
    User,
    Moderator,
};

// TODO: define the 'Permission' enum
[Flags]
enum Permission : byte {
    Read = 0b00000001,
    Write = 0b00000010,
    Delete = 0b00000100,

    All = Read | Write | Delete,

    None = 0,
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        return accountType switch {
            AccountType.Guest => Permission.Read,
            AccountType.User => Permission.Read | Permission.Write,
            AccountType.Moderator => Permission.All,
            _ => Permission.None,
        };
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        return current | grant;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        return current & ~revoke;
    }

    public static bool Check(Permission current, Permission check)
    {
        return current.HasFlag(check);
    }
}
