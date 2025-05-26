using Models;

namespace WinFormsApp.Models;

public class ProductDataModel
{
    public ILawnmowerModel Lawnmower { get; set; }
    public IList<BrandModel> Brands { get; set; }
}
