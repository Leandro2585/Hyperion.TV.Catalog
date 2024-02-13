namespace Hyperion.TV.Catalog.Domain.SeedWork;

public abstract class Entity
{
    #region Properties
    
    public Guid Id { get; protected set; }

    #endregion

    #region Constructor
    
    protected Entity() => Id = Guid.NewGuid();
    
    #endregion
}
