using System.Collections.Generic;

public interface IUnitDatabase
{
    IReadOnlyList<UnitConfiguration> Configs { get; }
    UnitConfiguration Get(int id);
}
