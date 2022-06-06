using WebStore.Models;

namespace WebStore.Repositories.Fillers
{
    public static class FakeRepositoriesFiller
    {
        private static List<PropertyGroupModel> propertyGroups;
        private static List<PropertyGroupModel> basePropertyGroups;
        private static List<PropertyUnitModel> units;
        private static List<PropertyValueModel> producers;
        private static List<ImageModel> images;
        private static List<PropertyModel> properties;
        private static List<PropertyValueModel> propertyValues;
        private static List<OrderingModel> orderings;
        private static List<ProductModel> products;
        private static List<UserModel> users;
        private static List<AnonimousUserModel> anonimousUsers;
        private static List<UserRoleModel> roles;

        static FakeRepositoriesFiller()
        {
            roles = FakeUserRoleFiller.Get();
            users = FakeUserFiller.Get();
            anonimousUsers = new List<AnonimousUserModel>();
            orderings = FakeOrderFiller.Get();
            FakeRepositoriesFiller.EmptyInitialProducts();
            //FakeRepositoriesFiller.FakeDatasInitialProducts();
        }

        private static void EmptyInitialProducts()
        {
            units = new List<PropertyUnitModel>();
            producers = new List<PropertyValueModel>();
            images = new List<ImageModel>();
            propertyGroups = new List<PropertyGroupModel>();
            propertyGroups.AddRange(FakePropertyGroupFiller.GetBase());
            basePropertyGroups = FakePropertyGroupFiller.GetBase();
            properties = new List<PropertyModel>();
            propertyValues = new List<PropertyValueModel>();
            products = new List<ProductModel>();
        }

        private static void FakeDatasInitialProducts()
        {
            //units = FakePropertyValueUnitFiller.Get();
            //producers = FakeProducerFiller.Get();
            //images = FakeProductImageFiller.Get();
            //productTypes = FakeProductTypeFiller.Get();
            //productSubTypes = FakeProductSubTypeFiller.Get();
            //propertyGroups = FakePropertyGroupFiller.Get();
            //properties = new List<PropertyModel>();
            //propertyValues = FakePropertyValueFiller.Get();
            //products = new List<ProductModel>
            //{
            //    FakeProductModelRepository.GetProductModel1(),
            //    FakeProductModelRepository.GetProductModel2(),
            //};
        }

        public static List<UserRoleModel> GetUserRoles() => roles;

        public static List<PropertyUnitModel> GetPropertyValueUnits() => units;

        public static List<UserModel> GetUsers() => users;

        public static List<AnonimousUserModel> GetAnonimousUsers() => anonimousUsers;

        public static List<PropertyGroupModel> GetBasePropertyGroupModels() => basePropertyGroups;

        public static List<PropertyGroupModel> GetPropertyGroupModels() => propertyGroups;

        public static List<ImageModel> GetImages() => images;

        public static List<PropertyValueModel> GetPropertyValue() => propertyValues;

        public static List<PropertyModel> GetProperties() => properties;

        public static List<PropertyValueModel> GetProducers() => producers;

        public static List<OrderingModel> GetOrders() => orderings;

        public static List<ProductModel> GetProducts()
        {
            return products;
        }
    }
}
