using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace CarGame.Level
{

    [CreateAssetMenu(menuName = "CarGame/Scene/Level Settings")]
    public class LevelSettings_SO : ScriptableObject
    {
        [Tooltip("Which Level is this scene")]
        [SerializeField] private int _levelCount;
        [Tooltip("How many car you will spawn")]
        [SerializeField] private int _carCount;
        [Tooltip("How many obstacle you will spawn")]
        [SerializeField] private int _obstacleCount;

        public int LevelCount { get { return _levelCount; } }
        public int CarCount { get { return _carCount; } }
        public int ObstacleCount { get { return _obstacleCount; } }


    }
}
