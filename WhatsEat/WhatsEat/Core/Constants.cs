namespace WhatsEat.Core;

public static class Constants
{
    public static class Roles
    {
        public const string Administrator = "Администратор";
        public const string Manager = "Менеджер";
        public const string User = "Пользователь";
    }

    public static class Policies
    {
        public const string RequireAdmin = "RequireAdmin";
        public const string RequireManager = "RequireManager";
    }
}
