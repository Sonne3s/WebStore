using WebStore.Models;

namespace WebStore.Repositories.Fillers
{
    public class FakeProductImageFiller
    {
        private static List<ImageModel> values;

        static FakeProductImageFiller() => values = Initial();

        public static List<ImageModel> Get() => values;

        private static List<ImageModel> Initial()
        {
            return new List<ImageModel>
            {
                new ImageModel
                {
                    Id = 1,
                    Src = "img/1.webp"
                },
                new ImageModel
                {
                    Id = 2,
                    Src = "img/2.webp"
                },
                new ImageModel
                {
                    Id = 3,
                    Src = "img/3.webp"
                },
                new ImageModel
                {
                    Id = 4,
                    Src = "img/4.webp"
                },
                new ImageModel
                {
                    Id = 5,
                    Src = "img/5.webp"
                },
                new ImageModel
                {
                    Id = 6,
                    Src = "img/6.webp"
                },
                new ImageModel
                {
                    Id = 7,
                    Src = "img/7.webp"
                }
            };
        }
    }
}
