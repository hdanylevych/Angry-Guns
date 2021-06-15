using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

using UnityEngine;

public class UnitDatabase : IUnitDatabase
{
    private const string UnitConfigLocation = "Databases/UnitConfigurations";

    private UnitConfiguration[] unitConfigurations;

    public IReadOnlyList<UnitConfiguration> Configs => unitConfigurations.ToList();

    private UnitConfiguration[] UnitConfigurations
    {
        get
        {
            if (unitConfigurations == null)
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

            return unitConfigurations;
        }
    }

    public UnitConfiguration Get(int id)
    {
        foreach (var config in UnitConfigurations)
        {
            if (config.Id == id)
            {
                return config;
            }
        }

        return UnitConfiguration.Null;
    }
}
