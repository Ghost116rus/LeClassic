using LeClassic.Domain.Entitites.Base;
using LeClassic.Domain.Entitites.Products;
using LeClassic.Domain.Enums;
using LeClassic.Domain.Exceptions;
using LeClassic.Domain.Extensions;

namespace LeClassic.Domain.Entitites.Users
{
    public class Consumer : BaseEntity
    {
        /// <summary>
        /// Поле для <see cref="_characteristics"/>
        /// </summary>
        public const string OrdersField = nameof(_orders);

        /// <summary>
        /// Поле для <see cref="_surveysProgress"/>
        /// </summary>
        public const string ProductsInCartField = nameof(_productsInCart);

        /// <summary>
        /// Поле для <see cref="_users"/>
        /// </summary>
        public const string UserField = nameof(_user);

        private User _user;

        private List<Product> _favourites = new();
        private List<ProductInCart> _productsInCart = new();
        private List<Order> _orders = new();

        private string _phoneNumber;

        public Consumer(User user, string phone)
        {
            User = user;
            _phoneNumber = phone;
        }

        /// <summary>
        /// Конструктор для EF
        /// </summary>
        protected Consumer()
        {
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            private set
                => _phoneNumber = string.IsNullOrEmpty(value)
                ? throw new RequiredFieldNotSpecifiedException("PhoneNumber")
                : value;
        }

        #region Navigation properties

        /// <summary>
        /// Пользователь
        /// </summary>
        public User User
        {
            get => _user;
            private set
            {
                ArgumentNullException.ThrowIfNull(value);

                if (Id != default && Id != value.Id)
                    throw new BadDataException("Id назначаемого пользователя не соответсвует Id покупателя");

                if (value.Role != UserRole.Consumer.GetDecription())
                    throw new BadDataException("Неправильная роль у покупателя");

                _user = value;
                Id = value.Id;
            }
        }


        /// <summary>
        /// Избранные товары покупателя
        /// </summary>
        public IReadOnlyList<Product> Favourites => _favourites;

        /// <summary>
        /// Товары в корзине покупателя
        /// </summary>
        public IReadOnlyList<ProductInCart> ProductsInCart => _productsInCart;

        /// <summary>
        /// Заказы покупателя
        /// </summary>
        public IReadOnlyList<Order> Orders => _orders;

        #endregion


    }
}
