using Models;

namespace WinFormsApp.Models;

public class OrdersDataModel
{
    public IList<OrderModel> Orders { get; set; }

    public decimal TotalValue { get; set; }
}
