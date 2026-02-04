using System.Collections.Generic;
using UnityEngine;

public interface ILevelGenerator
{
    /// <summary>
    /// Generates a map of given tiles for next level
    /// </summary>
    /// <param name="tiles">Prefabs of available tiles to use</param>
    /// <param name="levelCount">Information of which level to generate,
    ///                          used for adjusting level difficulty</param>
    /// <param name="onDeath">Method to be subscribed to generated tiles' OnDeath event</param>
    /// <returns>Number of tiles generated</returns>
    public int GenerateLevel(List<GameObject> tiles, int levelCount, Health.Death onDeath);
}
