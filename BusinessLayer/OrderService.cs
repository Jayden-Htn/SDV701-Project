using AutoMapper;
using Models;
using DataAccessLayer.Models;

namespace BusinessLayer;

public class OrderService : ServiceBase, IOrderService
{
    public OrderService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public OrderModel Get(int id)
    {
        var order = UnitOfWork.OrderRepository.Get(id);

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Order, OrderModel>();
            cfg.CreateMap<PushLawnmower, PushLawnmowerModel>();
            cfg.CreateMap<RideOnLawnmower, RideOnLawnmowerModel>();
            cfg.CreateMap<PushLawnmower, ILawnmowerModel>().As<PushLawnmowerModel>();
            cfg.CreateMap<RideOnLawnmower, ILawnmowerModel>().As<RideOnLawnmowerModel>();
        });
        IMapper mapper = new Mapper(config);

        var model = new OrderModel();

        mapper.Map(order, model);

        return model;
    }

    public int Add(OrderModel model)
    {
        Validate(model);

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<OrderModel, Order>();
            cfg.CreateMap<PushLawnmowerModel, PushLawnmower>();
            cfg.CreateMap<RideOnLawnmowerModel, RideOnLawnmower>();
            cfg.CreateMap<ILawnmowerModel, Lawnmower>()
                    .Include<PushLawnmowerModel, PushLawnmower>()
                    .Include<RideOnLawnmowerModel, RideOnLawnmower>();
        });

        IMapper mapper = new Mapper(config);
        var data = new Order();
        mapper.Map(model, data);

        UnitOfWork.OrderRepository.Add(data);

        // Remove items from stock
        var orderedProduct = UnitOfWork.LawnmowerRepository.Get(data.ProductId);
        if (orderedProduct == null)
        {
            throw new Exception("Product doesn't exist");
        }
        orderedProduct.QuantityInStock -= data.Quantity;
        UnitOfWork.LawnmowerRepository.Update(orderedProduct);

        UnitOfWork.Save();
        return data.Id;
    }

    public int Update(OrderModel model)
    {
        Validate(model);

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<OrderModel, Order>()
                .ForMember(x => x.Product, opt => opt.Ignore());
        });

        IMapper mapper = new Mapper(config);

        var data = UnitOfWork.OrderRepository.Get(model.Id);

        mapper.Map(model, data);

        UnitOfWork.OrderRepository.Update(data);
        UnitOfWork.Save();

        return data.Id;
    }

    public Task Delete(int id)
    {
        UnitOfWork.OrderRepository.Delete(id);
        UnitOfWork.Save();
        return Task.CompletedTask;
    }

    public IList<OrderModel> List()
    {
        var orders = UnitOfWork.OrderRepository.List().OrderByDescending(x => x.TimeCreated).ThenBy(x => x.Completed == true);

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Brand, BrandModel>()
                .ForMember(dest => dest.Lawnmowers, opt => opt.Ignore());
            cfg.CreateMap<Order, OrderModel>();
            cfg.CreateMap<PushLawnmower, PushLawnmowerModel>()
                .ForMember(dest => dest.Orders, opt => opt.Ignore());
            cfg.CreateMap<RideOnLawnmower, RideOnLawnmowerModel>()
                .ForMember(dest => dest.Orders, opt => opt.Ignore());
            cfg.CreateMap<PushLawnmower, ILawnmowerModel>().As<PushLawnmowerModel>();
            cfg.CreateMap<RideOnLawnmower, ILawnmowerModel>().As<RideOnLawnmowerModel>();
        });

        IMapper mapper = new Mapper(config);
        var models = new List<OrderModel>();

        mapper.Map(orders, models);

        return models;
    }
}
