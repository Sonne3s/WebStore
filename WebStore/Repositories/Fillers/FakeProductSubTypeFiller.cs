﻿//using WebStore.Models;

//namespace WebStore.Repositories.Fillers
//{
//    public class FakeProductSubTypeFiller
//    {
//        private static List<ProductSubTypeModel> values;

//        static FakeProductSubTypeFiller() => values = Initial();

//        public static List<ProductSubTypeModel> Get() => values;

//        private static List<ProductSubTypeModel> Initial()
//        {
//            return new List<ProductSubTypeModel>()
//            {
//                new ProductSubTypeModel()
//                {
//                    Id = 1,
//                    Value = "моноблок",
//                    ParentId = 1,
//                    Description = "Моноблоки состоят из одного корпуса, в котором расположен и компрессор и вся электроника. Простота конструкции обеспечивает легкий монтаж и невысокую стоимость. Моноблоки различаются по двум вариантам установки: оконные, настенные и мобильные.",
//                },

//                new ProductSubTypeModel()
//                {
//                    Id = 2,
//                    Value = "сплит-система",
//                    ParentId = 1,
//                    Description = "Сплит-системы состоят из наружного и внутреннего блоков, соединенных между собой трубами и электрокабелем. Плюсами этого типа являются низкий уровень шума внутреннего блока, возможность расположения внутреннего блока в любом удобном месте квартиры или офиса.",
//                },

//                new ProductSubTypeModel()
//                {
//                    Id = 3,
//                    Value = "мультисплит-система",
//                    ParentId = 1,
//                    Description = "Мультисплит-системы – те же сплит-системы, в которых с одним внешним блоком работают от 2 до 7 внутренних блоков. Они подходят для кондиционирования нескольких соседних помещений. Достоинства и недостатки у них такие же, что и у сплит-систем.",
//                },

//                new ProductSubTypeModel()
//                {
//                    Id = 4,
//                    Value = "мультизональная система",
//                    ParentId = 1,
//                    Description = "Мультизональные системы малой мощности предназначены для кондиционирования нескольких помещений – в каждом из них устанавливается отдельный внутренний блок, все блоки работают от одного внешнего. В обычных мультисплит-системах между внешним и каждым из внутренних блоков прокладывается отдельная трасса. В мультизональных системах все блоки подключаются к общей трассе. Максимальная длина коммуникаций может достигать 120 м.",
//                },
//            };
//        }
//    }
//}
