using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    float paddleMoveUnitsPerSecond = 10;
    float ballImpulseForce = 200;
    float ballLifeSeconds = 10;
    float minSpawnSeconds = 5;
    float maxSpawnSeconds = 10;
    float standartBlockPoints = 10;
    float bonusBlockPoints = 20;
    float pickupBlockPoints = 15;
    float standartBlockProb = 0.7f;
    float bonusBlockProb = 0.2f;
    float freezerBlockProb = 0.05f;
    float speedupBlockProb = 0.05f;
    float ballsPerGame = 5;
    float freezerEffectDuration = 2;
    float speedupEffectDuration = 2;
    float speedupFactor = 2;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    public float BallLifeSeconds
    {
        get { return ballLifeSeconds;  }
    }

    public float MinSpawnSeconds
    {
        get { return minSpawnSeconds; }
    }

    public float MaxSpawnSeconds
    {
        get { return maxSpawnSeconds; }
    }

    public float StandartBlockPoints
    {
        get { return standartBlockPoints; }
    }

    public float BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }

    public float PickupBlockPoints
    {
        get { return pickupBlockPoints; }
    }

    public float StandartBlockProb
    {
        get { return standartBlockProb; }
    }

    public float BonusBlockProb
    {
        get { return bonusBlockProb; }
    }

    public float FreezerBlockProb
    {
        get { return freezerBlockProb; }
    }

    public float SpeedupBlockProb
    {
        get { return speedupBlockProb; }
    }

    public float BallsPerGame
    {
        get { return ballsPerGame; }
    }

    public float FreezerEffectDuration
    {
        get { return freezerEffectDuration; }
    }

    public float SpeedupEffectDuration
    {
        get { return speedupEffectDuration; }
    }

    public float SpeedupFactor
    {
        get { return speedupFactor; }
    }



    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            // read in names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            // set configuration data fields
            SetConfigurationDataFields(values);
        }
        catch (Exception e)
        {
        }
        finally
        {               
            // always close input file
            if (input != null)
            {
                input.Close();
            }
        }
    }


    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    void SetConfigurationDataFields(string csvValues)
    {
        // the code below assumes we know the order in which the
        // values appear in the string. We could do something more
        // complicated with the names and values, but that's not
        // necessary here
        string[] values = csvValues.Split(','); 
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifeSeconds = float.Parse(values[2]);
        minSpawnSeconds = float.Parse(values[3]);
        maxSpawnSeconds = float.Parse(values[4]);
        standartBlockPoints = float.Parse(values[5]);
        bonusBlockPoints = float.Parse(values[6]);
        pickupBlockPoints = float.Parse(values[7]);
        standartBlockProb = float.Parse(values[8]) / 100;
        bonusBlockProb = float.Parse(values[9]) / 100;
        freezerBlockProb = float.Parse(values[10]) / 100;
        speedupBlockProb = float.Parse(values[11]) / 100;
        ballsPerGame = float.Parse(values[12]);
        freezerEffectDuration = float.Parse(values[13]);
        speedupEffectDuration = float.Parse(values[14]);
        speedupFactor = float.Parse(values[15]);

    }

    #endregion
}
