using System.ComponentModel;

namespace LeClassic.Domain.Enums
{
    public enum UserRole
    {
        [Description("Покупатель")]
        Consumer,

        [Description("Редактор")]
        Editor,

        [Description("Администратор системы")]
        Administrator
    }
}
