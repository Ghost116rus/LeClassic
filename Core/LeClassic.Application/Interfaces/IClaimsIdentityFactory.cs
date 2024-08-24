using System.Security.Claims;

namespace LeClassic.Application.Interfaces
{
    /// <summary>
    /// Фабрика ClaimsPrincipal для пользователей.
    /// </summary>
    public interface IClaimsIdentityFactory
    {
        /// <summary>
        /// Создать ClaimsIdentity по данным пользователя.
        /// </summary>
        /// <param name="user">Данные пользователя.</param>
        /// <returns>ClaimsIdentity.</returns>
        ClaimsIdentity CreateClaimsIdentity(User user);
    }
}
