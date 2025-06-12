public interface IUnitOfWork
{
    ILawnmowerRepository LawnmowerRepository { get; }
    IOrderRepository OrderRepository { get; }

    void Dispose();
    void Save();
}