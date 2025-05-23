using Models;

namespace WinFormsApp.Models;

public class ProductsDataModel
{
    public IList<LawnmowerModel> Lawnmowers { get; set; }
    public IList<BrandModel> Brands { get; set; }
}
