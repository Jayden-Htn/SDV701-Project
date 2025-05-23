using AutoMapper;
using Models;
using DataAccessLayer.Models;

namespace BusinessLayer;

public class LawnmowerService : ServiceBase, ILawnmowerService
{
    public LawnmowerService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public LawnmowerModel Get(int id)
    {
        var lawnmower = UnitOfWork.LawnmowerRepository.Get(id);

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Order, OrderModel>();
            cfg.CreateMap<PushLawnmower, PushLawnmowerModel>();
            cfg.CreateMap<RideOnLawnmower, RideOnLawnmowerModel>();
            cfg.CreateMap<PushLawnmower, ILawnmowerModel>().As<PushLawnmowerModel>();
            cfg.CreateMap<RideOnLawnmower, ILawnmowerModel>().As<RideOnLawnmowerModel>();
        });
        IMapper mapper = new Mapper(config);

        var model = new LawnmowerModel();

        mapper.Map(lawnmower, model);

        return model;
    }

    public int Add(LawnmowerModel model)
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

        var data = new Lawnmower();

        mapper.Map(model, data);

        UnitOfWork.LawnmowerRepository.Add(data);
        UnitOfWork.Save();

        return data.Id;
    }

    public int Update(LawnmowerModel model)
    {
        Validate(model);

        var config = new MapperConfiguration(cfg => cfg.CreateMap<LawnmowerModel, Lawnmower>()
        .ForMember(x => x.Brand, opt => opt.Ignore()));

        IMapper mapper = new Mapper(config);

        var data = UnitOfWork.LawnmowerRepository.Get(model.Id);

        mapper.Map(model, data);

        UnitOfWork.LawnmowerRepository.Update(data);
        UnitOfWork.Save();

        return data.Id;
    }

    public Task Delete(int id)
    {
        UnitOfWork.LawnmowerRepository.Delete(id);
        UnitOfWork.Save();
        return Task.CompletedTask;
    }

    public IList<LawnmowerModel> List(int brandId)
    {
        var lawnmowers = UnitOfWork.LawnmowerRepository.List();

        if (brandId != 0)
        {
            lawnmowers = lawnmowers.Where(l => l.BrandId == brandId);
        }

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Brand, BrandModel>()
                .ForMember(dest => dest.Lawnmowers, opt => opt.Ignore());
            cfg.CreateMap<Order, OrderModel>();
            cfg.CreateMap<PushLawnmower, PushLawnmowerModel>();
            cfg.CreateMap<RideOnLawnmower, RideOnLawnmowerModel>();
            cfg.CreateMap<PushLawnmower, ILawnmowerModel>().As<PushLawnmowerModel>();
            cfg.CreateMap<RideOnLawnmower, ILawnmowerModel>().As<RideOnLawnmowerModel>();
        });

        IMapper mapper = new Mapper(config);

        var models = new List<LawnmowerModel>();
        mapper.Map(lawnmowers, models);

        return models;
    }

    public IList<BrandModel> Brands()
    {
        var brands = UnitOfWork.LawnmowerRepository.Brands();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Brand, BrandModel>()
                .ForMember(dest => dest.Lawnmowers, opt => opt.Ignore());
        });

        IMapper mapper = new Mapper(config);

        var models = new List<BrandModel>();
        mapper.Map(brands, models);

        return models;
    }
}
