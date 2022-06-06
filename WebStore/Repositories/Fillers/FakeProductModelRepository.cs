//using WebStore.Models;
//using WebStore.Models.Enumerations;

//namespace WebStore.Repositories.Fillers
//{
//    public static class FakeProductModelRepository
//    {
//        public static List<ProductModel> GetProductModel()
//        {
//            return new List<ProductModel>
//            {
//                GetProductModel1()
//            };
//        }

//        private static PropertyModel GetPropertyModel(ProductModel product, PropertyValueModel value, ComponentModel component = null)
//        {
//            return new PropertyModel
//            {
//                ValueId = value.PropertyId,//value.Id,
//                Value = value,
//                ComponentId = component?.Id ?? 0,
//            };
//        }

//        public static ProductModel GetProductModel1()
//        {
//            var product = new ProductModel
//            {
//                Id = 1,
//                Producer = FakeRepositoriesFiller.GetProducers().Find(p => p.Id == 1),
//                Name = "BSDI-09HN1",
//                Price = 32490.1232321M,
//                ProductType = FakeRepositoriesFiller.GetProductTypes().FirstOrDefault(t => t.Id == 1),
//                Images = FakeRepositoriesFiller.GetImages()
//            };

//            product.GeneralProperties = new ComponentModel
//            {
//                Properties = new List<PropertyModel>
//                {
//                    FakeProductModelRepository.GetPropertyModel(product, FakeRepositoriesFiller.GetPropertyValue().FirstOrDefault(p => p.Group.Id == 1 && p.Id == 1)),
//                    FakeProductModelRepository.GetPropertyModel(product, FakeRepositoriesFiller.GetPropertyValue().FirstOrDefault(p => p.Group.Id == 2 && p.Id == 2)),
//                    FakeProductModelRepository.GetPropertyModel(product, FakeRepositoriesFiller.GetPropertyValue().FirstOrDefault(p => p.Group.Id == 4 && p.Id == 3)),
//                    FakeProductModelRepository.GetPropertyModel(product, FakeRepositoriesFiller.GetPropertyValue().FirstOrDefault(p => p.Group.Id == 5 && p.Id == 4)),
//                    FakeProductModelRepository.GetPropertyModel(product, FakeRepositoriesFiller.GetPropertyValue().FirstOrDefault(p => p.Group.Id == 6 && p.Id == 5)),
//                    FakeProductModelRepository.GetPropertyModel(product, FakeRepositoriesFiller.GetPropertyValue().FirstOrDefault(p => p.Group.Id == 7 && p.Id == 6)),
//                    FakeProductModelRepository.GetPropertyModel(product, FakeRepositoriesFiller.GetPropertyValue().FirstOrDefault(p => p.Group.Id == 8 && p.Id == 7)),
//                    FakeProductModelRepository.GetPropertyModel(product, FakeRepositoriesFiller.GetPropertyValue().FirstOrDefault(p => p.Group.Id == 9 && p.Id == 8)),
//                }
//            };

//            return product;
//        }

//        public static ProductModel GetProductModel2()
//        {
//            var product = new ProductModel
//            {
//                Id = 2,
//                Producer = FakeRepositoriesFiller.GetProducers().Find(p => p.Id == 3),
//                Name = "XG-TX21RHA",
//                Price = 18750.123213M,
//                Description = "Сплит-системы Turbocool 2022 выполнены в строгом минималистичном дизайне, который придает блоку строгий и запоминающийся вид.",
//                ProductType = FakeRepositoriesFiller.GetProductTypes().FirstOrDefault(t => t.Id == 1),
//                Images = FakeRepositoriesFiller.GetImages()
//            };
//            //product.GeneralProperties = new ComponentModel
//            //{
//            //    Properties = new List<PropertyModel>
//            //    {
//            //    FakeProductModelRepository.GetPropertyModel(product, FakeRepositoriesFiller.GetPropertyValue().FirstOrDefault(p => p.Group.Id == 14 && p.Id == 16)),
//            //    FakeProductModelRepository.GetPropertyModel(product, FakeRepositoriesFiller.GetPropertyValue().FirstOrDefault(p => p.Group.Id == 15 && p.Id == 17)),
//            //    }
//            //};
//            product.Components = new List<ComponentModel>
//                {
//                    new ComponentModel
//                    {
//                        Id = 1,
//                        Name = "Внутренний блок",
//                    },
//                    new ComponentModel
//                    {
//                        Id = 2,
//                        Name = "Наружний блок",
//                    }
//                };

//            //product.Components[0].Properties = new List<PropertyModel>
//            //{
//            //    FakeProductModelRepository.GetPropertyModel(product, FakeRepositoriesFiller.GetPropertyValue().FirstOrDefault(p => p.Group.Id == 10 && p.Id == 9)),
//            //    FakeProductModelRepository.GetPropertyModel(product, FakeRepositoriesFiller.GetPropertyValue().FirstOrDefault(p => p.Group.Id == 11 && p.Id == 10)),
//            //    FakeProductModelRepository.GetPropertyModel(product, FakeRepositoriesFiller.GetPropertyValue().FirstOrDefault(p => p.Group.Id == 12 && p.Id == 12)),
//            //};

//            //product.Components[1].Properties = new List<PropertyModel>
//            //{
//            //    FakeProductModelRepository.GetPropertyModel(product, FakeRepositoriesFiller.GetPropertyValue().FirstOrDefault(p => p.Group.Id == 11 && p.Id == 11)),
//            //    FakeProductModelRepository.GetPropertyModel(product, FakeRepositoriesFiller.GetPropertyValue().FirstOrDefault(p => p.Group.Id == 12 && p.Id == 13)),
//            //    FakeProductModelRepository.GetPropertyModel(product, FakeRepositoriesFiller.GetPropertyValue().FirstOrDefault(p => p.Group.Id == 13 && p.Id == 15)),
//            //};

//            return product;
//        }
//    }
//}
