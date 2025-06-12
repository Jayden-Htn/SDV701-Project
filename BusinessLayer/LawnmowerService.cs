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
            cfg.CreateMap<Brand, BrandModel>()
                .ForMember(dest => dest.Lawnmowers, opt => opt.Ignore());
            cfg.CreateMap<Order, OrderModel>();
            cfg.CreateMap<Lawnmower, LawnmowerModel>();
            cfg.CreateMap<PushLawnmower, PushLawnmowerModel>();
            cfg.CreateMap<RideOnLawnmower, RideOnLawnmowerModel>();
        });
        IMapper mapper = new Mapper(config);

        if (lawnmower is PushLawnmower)
        {
            return mapper.Map(lawnmower, new PushLawnmowerModel());
        } 
        else if (lawnmower is RideOnLawnmower)
        {
            return mapper.Map(lawnmower, new RideOnLawnmowerModel());
        }
        else
        {
            return mapper.Map(lawnmower, new LawnmowerModel());
        }
    }

    public int Add(ILawnmowerModel model)
    {
        Validate(model);

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<PushLawnmowerModel, PushLawnmower>()
                .ForMember(l => l.Brand, t => t.Ignore())
                .ForMember(l => l.Orders, t => t.Ignore());
            cfg.CreateMap<RideOnLawnmowerModel, RideOnLawnmower>()
                .ForMember(l => l.Brand, t => t.Ignore())
                .ForMember(l => l.Orders, t => t.Ignore());
            cfg.CreateMap<LawnmowerModel, Lawnmower>();
            cfg.CreateMap<ILawnmowerModel, Lawnmower>()
                .Include<PushLawnmowerModel, PushLawnmower>()
                .Include<RideOnLawnmowerModel, RideOnLawnmower>();
        });
        IMapper mapper = new Mapper(config);

        ILawnmower data;
        if (model is PushLawnmowerModel)
        {
            data = new PushLawnmower();
        }
        else if (model is RideOnLawnmowerModel)
        {
            data = new RideOnLawnmower();
        }
        else
        {
            data = new Lawnmower();
        }

        mapper.Map(model, data);

        UnitOfWork.LawnmowerRepository.Add(data);
        UnitOfWork.Save();

        return data.Id;
    }

    public int Update(ILawnmowerModel model)
    {
        Validate(model);

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<PushLawnmowerModel, PushLawnmower>()
                .ForMember(l => l.Brand, t => t.Ignore())
                .ForMember(l => l.Orders, t => t.Ignore());
            cfg.CreateMap<RideOnLawnmowerModel, RideOnLawnmower>()
                .ForMember(l => l.Brand, t => t.Ignore())
                .ForMember(l => l.Orders, t => t.Ignore());
            cfg.CreateMap<LawnmowerModel, Lawnmower>();
            cfg.CreateMap<ILawnmowerModel, Lawnmower>()
                .Include<PushLawnmowerModel, PushLawnmower>()
                .Include<RideOnLawnmowerModel, RideOnLawnmower>();
        });
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
