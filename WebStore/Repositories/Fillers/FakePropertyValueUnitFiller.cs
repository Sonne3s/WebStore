using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Repositories.Fillers
{
    public class FakePropertyValueUnitFiller
    {
        private static List<PropertyUnitModel> values;

        static FakePropertyValueUnitFiller() => values = Initial();

        public static List<PropertyUnitModel> Get() => values;

        private static List<PropertyUnitModel> Initial()
        {
            return new List<PropertyUnitModel>()
            {
                    new PropertyUnitModel
                    {
                        Id = (int)PropertyValueUnitEnumeration.М2,
                        Value = "М2"
                    },

                    new PropertyUnitModel
                    {
                        Id = (int)PropertyValueUnitEnumeration.BTU,
                        Value = "BTU"
                    },

                    new PropertyUnitModel
                    {
                        Id = (int)PropertyValueUnitEnumeration.Вт,
                        Value = "Вт"
                    },

                    new PropertyUnitModel
                    {
                        Id = (int)PropertyValueUnitEnumeration.мм,
                        Value = "мм"
                    },

                     new PropertyUnitModel
                    {
                        Id = (int)PropertyValueUnitEnumeration.кВт,
                        Value = "кВт"
                    },
            };
        }
    }
}
