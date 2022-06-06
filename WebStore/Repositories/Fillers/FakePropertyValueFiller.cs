//using WebStore.Models;
//using WebStore.Models.Enumerations;

//namespace WebStore.Repositories.Fillers
//{
//    public static class FakePropertyValueFiller
//    {
//        private static List<PropertyValueModel> values;
//        private static int _counter = 0;

//        static FakePropertyValueFiller() => values = Initial();

//        public static List<PropertyValueModel> Get() => values;

//        private static List<PropertyValueModel> Initial()
//        {
//            return (new List<List<PropertyValueModel>>
//            {
//                FakePropertyValueFiller.GetPropertiesForGroup1(),
//                FakePropertyValueFiller.GetPropertiesForGroup2(),
//                //FakePropertyValueFiller.GetPropertiesForGroup3(), productTypes
//                FakePropertyValueFiller.GetPropertiesForGroup4(),
//                FakePropertyValueFiller.GetPropertiesForGroup5(),
//                FakePropertyValueFiller.GetPropertiesForGroup6(),
//                FakePropertyValueFiller.GetPropertiesForGroup7(),
//                FakePropertyValueFiller.GetPropertiesForGroup8(),
//                FakePropertyValueFiller.GetPropertiesForGroup9(),
//                FakePropertyValueFiller.GetPropertiesForGroup10(),
//                FakePropertyValueFiller.GetPropertiesForGroup11(),
//                FakePropertyValueFiller.GetPropertiesForGroup12(),
//                FakePropertyValueFiller.GetPropertiesForGroup13(),
//                FakePropertyValueFiller.GetPropertiesForGroup14(),
//                FakePropertyValueFiller.GetPropertiesForGroup15(),
//            })
//            .SelectMany(l => l)
//            .ToList();
//        }

//        private static List<PropertyValueModel> GetPropertiesForGroup1()
//        {
//            var group = FakeRepositoriesFiller.GetPropertyGroupModels().Find(p => p.Id == 1);

//            return new List<PropertyValueModel>()
//            {
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "Lagoon DC inverter",
//                },
//            };
//        }

//        private static List<PropertyValueModel> GetPropertiesForGroup2()
//        {
//            var group = FakeRepositoriesFiller.GetPropertyGroupModels().Find(p => p.Id == 2);

//            return new List<PropertyValueModel>()
//            {
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "настенная сплит-система",
//                },
//            };
//        }


//        private static List<PropertyValueModel> GetPropertiesForGroup4()
//        {
//            var group = FakeRepositoriesFiller.GetPropertyGroupModels().Find(p => p.Id == 4);

//            return new List<PropertyValueModel>()
//            {
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "32M",
//                },
//            };
//        }

//        private static List<PropertyValueModel> GetPropertiesForGroup5()
//        {
//            var group = FakeRepositoriesFiller.GetPropertyGroupModels().Find(p => p.Id == 5);

//            return new List<PropertyValueModel>()
//            {
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "9",
//                },
//            };
//        }

//        private static List<PropertyValueModel> GetPropertiesForGroup6()
//        {
//            var group = FakeRepositoriesFiller.GetPropertyGroupModels().Find(p => p.Id == 6);

//            return new List<PropertyValueModel>()
//            {
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "true",
//                },
//            };
//        }

//        private static List<PropertyValueModel> GetPropertiesForGroup7()
//        {
//            var group = FakeRepositoriesFiller.GetPropertyGroupModels().Find(p => p.Id == 7);

//            return new List<PropertyValueModel>()
//            {
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "А",
//                },
//            };
//        }

//        private static List<PropertyValueModel> GetPropertiesForGroup8()
//        {
//            var group = FakeRepositoriesFiller.GetPropertyGroupModels().Find(p => p.Id == 8);

//            return new List<PropertyValueModel>()
//            {
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "2600M",
//                },
//            };
//        }

//        private static List<PropertyValueModel> GetPropertiesForGroup9()
//        {
//            var group = FakeRepositoriesFiller.GetPropertyGroupModels().Find(p => p.Id == 9);

//            return new List<PropertyValueModel>()
//            {
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "true",
//                },
//            };
//        }

//        private static List<PropertyValueModel> GetPropertiesForGroup10()
//        {
//            var group = FakeRepositoriesFiller.GetPropertyGroupModels().Find(p => p.Id == 10);

//            return new List<PropertyValueModel>()
//            {
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "300/338/390/430/475",
//                },
//            };
//        }

//        private static List<PropertyValueModel> GetPropertiesForGroup11()
//        {
//            var group = FakeRepositoriesFiller.GetPropertyGroupModels().Find(p => p.Id == 11);

//            return new List<PropertyValueModel>()
//            {
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "698",
//                },
                
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "712",
//                },
//            };
//        }

//        private static List<PropertyValueModel> GetPropertiesForGroup12()
//        {
//            var group = FakeRepositoriesFiller.GetPropertyGroupModels().Find(p => p.Id == 12);

//            return new List<PropertyValueModel>()
//            {
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "255",
//                },
                
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "459",
//                },
//            };
//        }

//        private static List<PropertyValueModel> GetPropertiesForGroup13()
//        {
//            var group = FakeRepositoriesFiller.GetPropertyGroupModels().Find(p => p.Id == 13);

//            return new List<PropertyValueModel>()
//            {
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "190",
//                },
                
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "276",
//                },
//            };
//        }

//        private static List<PropertyValueModel> GetPropertiesForGroup14()
//        {
//            var group = FakeRepositoriesFiller.GetPropertyGroupModels().Find(p => p.Id == 14);

//            return new List<PropertyValueModel>()
//            {
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "220-240/50/1",

//                },
//            };
//        }

//        private static List<PropertyValueModel> GetPropertiesForGroup15()
//        {
//            var group = FakeRepositoriesFiller.GetPropertyGroupModels().Find(p => p.Id == 15);

//            return new List<PropertyValueModel>()
//            {
//                new PropertyValueModel
//                {
//                    Id = ++_counter,
//                    Group = group,
//                    GroupId = group.Id,
//                    Value = "2.05",
//                },
//            };
//        }
//    }
//}
