using System.Collections.Generic;

public interface IHeroMediator
{
    void Initialize(IReadOnlyList<UnitModel> unitModels);
}
