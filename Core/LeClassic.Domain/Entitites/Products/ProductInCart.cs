using LeClassic.Domain.Entitites.Base;
using LeClassic.Domain.Exceptions;

namespace LeClassic.Domain.Entitites.Products
{
    public class ProductInCart : BaseEntity
    {
        /// <summary>
        /// Поле для <see cref="_product"/>
        /// </summary>
        public const string ProductField = nameof(_product);

        private Product _product;
        private int _count;


        public ProductInCart(Product product, int count)
        {
            Product = product;
            Count = count;
        }

        public int Count
        {
            get => _count;
            set
            {
                if (value < 1 || value > 100)
                    throw new BadDataException();
                _count = value;
            }
        }

        #region Navigation properties

        /// <summary>
        /// Покупатель
        /// </summary>
        public Product Product
        {
            get => _product;
            private set
            {
                ArgumentNullException.ThrowIfNull(value);
                _product = value;
            }
        }
        #endregion
    }
}
