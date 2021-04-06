using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitDatabase : IUnitDatabase
{
    private const string UnitConfigLocation = "Databases/UnitConfigurations";

    private UnitConfiguration[] unitConfigurations;

    public IReadOnlyList<UnitConfiguration> Configs => unitConfigurations.ToList();

    [PostConstruct]
    private void Initialize()
    {
        var unitConfigObject = Resources.Load<UnitConfigurations>(UnitConfigLocation);

        if (unitConfigObject)
        {
            unitConfigurations = unitConfigObject.unitConfigurations;
        }
        else
        {
            Debug.LogError($"Error: failed loading UnitConfiguration with path {UnitConfigLocation}");
        }
    }

    public UnitConfiguration Get(int id)
    {
        foreach (var config in unitConfigurations)
        {
            if (config.Id == id)
            {
                return config;
            }
        }

        return UnitConfiguration.Null;
    }
}
