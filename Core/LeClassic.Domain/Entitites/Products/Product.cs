using LeClassic.Domain.Entitites.Base;
using LeClassic.Domain.Exceptions;

namespace LeClassic.Domain.Entitites.Products
{
    public class Product : BaseEntity
    {
        private string _name;
        private string _linkToPhoto;

        private int _price;
        private int _size;
        private int _modelNumber;

        /* Недобавленные свойства
         * Бренд
         * Категория
         * Подкатегория
         * Описание
         * Состав
         * Страна 
         */

        /// <summary>
        /// Конструткор
        /// </summary>
        /// <param name="fullName">Полное имя</param>
        /// <param name="_email">Логин</param>
        /// <param name="passwordHash">Хеш пароля</param>
        /// <param name="role">Роль</param>
        public Product(
            string name,
            string linktoPhoto,
            int price,
            int size,
            int modelNumber
            )
        {
            Name = name;
            LinkToPhoto = linktoPhoto;
            Price = price;
            Size = size;
            ModelNumber = modelNumber;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        protected Product()
        {
        }

        public string Name
        {
            get => _name;
            private set
                => _name = string.IsNullOrEmpty(value)
                ? throw new RequiredFieldNotSpecifiedException("UserFullName")
                : value;
        }
        
        public string LinkToPhoto
        {
            get => _linkToPhoto;
            private set
                => _linkToPhoto = string.IsNullOrEmpty(value)
                ? throw new RequiredFieldNotSpecifiedException("LinkToPhoto")
                : value;
        }
        
        public int Price
        {
            get => _price;
            private set
            {
                if (value < 1 || value > 100)
                    throw new BadDataException();
                _size = value;
            }
        }

        public int Size 
        { 
            get => _size;
            private set
            {
                if (value < 1 || value > 100)
                    throw new BadDataException();
                _size = value;
            }
        }

        public int ModelNumber
        { 
            get => _modelNumber;
            private set
            {
                if (value < 1 || value > 100)
                    throw new BadDataException();
                _modelNumber = value;
            }
        }

    }
}
