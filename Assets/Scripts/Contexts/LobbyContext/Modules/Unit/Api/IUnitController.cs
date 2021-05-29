using System;
using System.Collections.Generic;

public interface IUnitController
{
    event Action<UnitModel> NewModelReceived;

    IReadOnlyList<UnitModel> Models { get; }
    void AddModel(UnitModel model);
}
