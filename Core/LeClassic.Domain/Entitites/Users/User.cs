using LeClassic.Domain.Entitites.Base;
using LeClassic.Domain.Enums;
using LeClassic.Domain.Exceptions;
using LeClassic.Domain.Extensions;

namespace LeClassic.Domain.Entitites.Users
{
    public class User : BaseEntity
    {
        /// <summary>
        /// Поле для <see cref="_consumer"/>
        /// </summary>
        public const string ConsumerField = nameof(_consumer);

        private string _email = default!;
        private string _passwordHash = default!;
        private Consumer _consumer;
        private string _fullName = default!;
        private string _role = default!;

        /// <summary>
        /// Конструткор
        /// </summary>
        /// <param name="fullName">Полное имя</param>
        /// <param name="_email">Логин</param>
        /// <param name="passwordHash">Хеш пароля</param>
        /// <param name="role">Роль</param>
        public User(
            string fullName,
            string _email,
            string passwordHash,
            string role = "Consumer")
        {
            FullName = fullName;
            Email = _email;
            PasswordHash = passwordHash;
            Role = role;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        protected User()
        {
        }

        /// <summary>
        /// Хеш пароля
        /// </summary>
        public string PasswordHash
        {
            get => _passwordHash;
            set => _passwordHash = value
                    ?? throw new RequiredFieldNotSpecifiedException("Хеш пароля");
        }

        public string Email
        {
            get => _email;
            private set
                => _email = string.IsNullOrEmpty(value)
                ? throw new RequiredFieldNotSpecifiedException("Email")
                : value;
        }

        public string FullName
        {
            get => _fullName;
            private set
                => _fullName = string.IsNullOrEmpty(value)
                ? throw new RequiredFieldNotSpecifiedException("UserFullName")
                : value;
        }

        public string Role 
        {
            get => _role; 
            private set
            {
                // бизнес на проверку соответствия значению
                _role = value;
            }
        }



        #region Navigation properties

        /// <summary>
        /// Ссылка на студента
        /// </summary>
        public Consumer? Consumer
        {
            get => _consumer;
            private set
            {
                ArgumentNullException.ThrowIfNull(value);
                if (Role != UserRole.Consumer.GetDecription())
                    throw new BadDataException($"Не совпадение роли и навигационного свойства ({UserRole.Consumer.GetDecription()})");
                _consumer = value;
            }
        }

        #endregion


        public void UpdatePassword()
        {
            throw new NotImplementedException();
        }
        
        public void UpdateEmail()
        {
            throw new NotImplementedException();
        }

    }
}
