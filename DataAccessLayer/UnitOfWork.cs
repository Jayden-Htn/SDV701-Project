using DataAccessLayer;

public class UnitOfWork : IDisposable, IUnitOfWork
{
    private readonly ModelContext _context;
    private ILawnmowerRepository _lawnmowerRepository;
    private IOrderRepository _orderRepository;
    private bool _disposed = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public UnitOfWork(ModelContext context)
    {
        _context = context;
    }

    public ILawnmowerRepository LawnmowerRepository
    {
        get
        {
            if (_lawnmowerRepository == null)
            {
                _lawnmowerRepository = new LawnmowerRepository(_context);
            }
            return _lawnmowerRepository;
        }
    }

    public IOrderRepository OrderRepository
    {
        get
        {
            if (_orderRepository == null)
            {
                _orderRepository = new OrderRepository(_context);
            }
            return _orderRepository;
        }
    }

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources.
    /// </summary>
    /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to 
    /// release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing) { _context.Dispose(); }
        }
        this._disposed = true;
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources 
    /// related to the context.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Saves all changes made in this context to the database.
    /// </summary>   
    public void Save()
    {
        _context.SaveChanges();
    }
}