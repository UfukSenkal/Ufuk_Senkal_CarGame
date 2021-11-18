using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarGame
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public enum GameState
        {
            WaitingInput,
            Started,
            GameOver
        }

        public GameState CurrentGameState;


        private void Awake()
        {
            Instance = this;
        }
    }
}
