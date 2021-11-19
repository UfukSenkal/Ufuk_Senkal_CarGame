using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace CarGame.Level
{

    [CreateAssetMenu(menuName = "CarGame/Scene/Level Settings")]
    public class LevelSettings_SO : ScriptableObject
    {
        [SerializeField] private int _levelCount;
        [SerializeField] private int _carCount;
        [SerializeField] private int _obstacleCount;

        public int LevelCount { get { return _levelCount; } }
        public int CarCount { get { return _carCount; } }
        public int ObstacleCount { get { return _obstacleCount; } }


    }
}
