using System.ComponentModel;

namespace Blog.Common.Enums
{
    public enum RoleType
    {
        [Description("Администратор")]
        Administrator =1,
        [Description("Модератор")]
        Moderator =2,
        [Description("Пользователь")]
        User =3
    }
}
