namespace BusinessLayer;

public abstract class ServiceBase
{
    protected IUnitOfWork UnitOfWork { get; private set; }

    public ServiceBase(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    protected virtual bool Validate(object model)
    {
        var modelValidator = new ModelValidator();
        if (!modelValidator.Validate(model))
        {
            throw new ModelValidationException($"{nameof(model)} is invalid", modelValidator.Errors);
        }
        return true;
    }
}