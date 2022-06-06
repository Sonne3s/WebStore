using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Repositories.Fillers
{
    public class FakePropertyGroupFiller
    {
        private static List<PropertyGroupModel> baseValues = new List<PropertyGroupModel>()
        {
                new PropertyGroupModel //base property
                {
                    Id = (int)BasePropertyGroupIdEnumeration.ProductType,
                    Name = "Тип устройства",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Text,
                },

                new PropertyGroupModel
                {
                    Id = (int)BasePropertyGroupIdEnumeration.Producer,
                    Name = "Производитель",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Text,
                },
        };

        private static List<PropertyGroupModel> values;

        static FakePropertyGroupFiller() => values = Initial();

        public static List<PropertyGroupModel> Get() => values;

        public static List<PropertyGroupModel> GetBase() => baseValues;

        private static List<PropertyGroupModel> Initial()
        {
            var result = new List<PropertyGroupModel>(baseValues);
            result.AddRange(new List<PropertyGroupModel>
            {
                //Id = 1,2,3 - reserved from base properties

                new PropertyGroupModel
                {
                    Id = 4,
                    Name = "Линейка",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Text,
                },

                new PropertyGroupModel
                {
                    Id = 5,
                    Name = "Мощность кондиционера",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Integer,
                },

                new PropertyGroupModel
                {
                    Id = 6,
                    Name = "Инверторный",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Text,
                },

                new PropertyGroupModel
                {
                    Id = 7,
                    Name = "Класс энергопотребления",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Text,
                },

                new PropertyGroupModel
                {
                    Id = 8,
                    Name = "Мощность в режиме охлаждения",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Decimal,
                },

                new PropertyGroupModel
                {
                    Id = 9,
                    Name = "Инверторный",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Text,
                    Description = "В обычных кондиционерах компрессор работает в режиме «включение — выключение». В кондиционерах с инвертором компрессор работает постоянно, плавно меняя мощность охлаждения или обогрева при изменении внешней температуры. Благодаря этому такие кондиционеры долговечнее традиционных моделей, они точнее поддерживают температуру, быстрее охлаждают воздух, меньше шумят, потребляют на 30–35% меньше электроэнергии.",
                },

                new PropertyGroupModel
                {
                    Id = 10,
                    Name = "Расход воздуха, м3/ч",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Text,
                },

                new PropertyGroupModel
                {
                    Id = 11,
                    Name = "Ширина",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Integer,
                },

                new PropertyGroupModel
                {
                    Id = 12,
                    Name = "Длинна",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Integer,
                },

                new PropertyGroupModel
                {
                    Id = 13,
                    Name = "Высота",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Integer,
                },

                new PropertyGroupModel
                {
                    Id = 14,
                    Name = "Электропитание, В/Гц/Ф",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Text,
                },

                new PropertyGroupModel
                {
                    Id = 15,
                    Name = "Холодопроизводительность",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Decimal,
                },

                new PropertyGroupModel
                {
                    Id = 16,
                    Name = "Площадь помещения",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Decimal,
                },
            });

            return result;
        }
    }
}
