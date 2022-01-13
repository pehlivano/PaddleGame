using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    
    static ConfigurationData configurationData;

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    public static float BallLifeSecond
    {
        get { return configurationData.BallLifeSeconds; }
    }

    public static float MinSpawnSecond
    {
        get { return configurationData.MinSpawnSeconds; }
    }

    public static float MaxSpawnSecond
    {
        get { return configurationData.MaxSpawnSeconds; }
    }

    public static float StandartBlockPoints
    {
        get { return configurationData.StandartBlockPoints; }
    }

    public static float BonusBlockPoints
    {
        get { return configurationData.BonusBlockPoints; }
    }

    public static float PickupBlockPoints
    {
        get { return configurationData.PickupBlockPoints; }
    }

    public static float StandartBlockProbability
    {
        get { return configurationData.StandartBlockProb; }
    }

    public static float BonusBlockProbability
    {
        get { return configurationData.BonusBlockProb; }
    }

    public static float FreezerBlockProbability
    {
        get { return configurationData.FreezerBlockProb; }
    }

    public static float SpeedupBlockProbability
    {
        get { return configurationData.SpeedupBlockProb; }
    }

    public static float BallsPerGame
    {
        get { return configurationData.BallsPerGame; }
    }

    public static float FreezerEffectDuration
    {
        get { return configurationData.FreezerEffectDuration; }
    }

    public static float SpeedupEffectDuration
    {
        get { return configurationData.SpeedupEffectDuration; }
    }

    public static float SpeedupFactor
    {
        get { return configurationData.SpeedupFactor; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
