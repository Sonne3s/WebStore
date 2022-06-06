namespace WebStore.Areas.Admin.Fillers.IFillers
{
    public interface IProductFillerProvider
    {
        IProductComponentsTabFiller ProductComponentsTabFiller { get; set; }
    }
}
