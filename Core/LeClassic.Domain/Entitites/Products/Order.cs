using LeClassic.Domain.Entitites.Base;
using LeClassic.Domain.Entitites.Users;

namespace LeClassic.Domain.Entitites.Products
{
    public class Order : BaseEntity
    {
        /// <summary>
        /// Поле для <see cref="_consumer"/>
        /// </summary>
        public const string ConsumerField = nameof(_consumer);

        /// <summary>
        /// Поле для <see cref="_users"/>
        /// </summary>
        public const string ProductsField = nameof(_products);

        private Consumer? _consumer;
        private List<ProductInCart> _products;

        public Order(Consumer consumer, List<ProductInCart> products)
        {
            Consumer = consumer;
            _products = products;
        }

        protected Order()
        {

        }

        #region Navigation properties

        /// <summary>
        /// Покупатель
        /// </summary>
        public Consumer? Consumer
        {
            get => _consumer;
            private set
            {
                ArgumentNullException.ThrowIfNull(value);
                _consumer = value;
            }
        }

        /// <summary>
        /// Товары в заказе
        /// </summary>
        public IReadOnlyList<ProductInCart> Products => _products;
        #endregion
    }
}
