using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        WaitingInput,
        Started,
        GameOver
    }

    public static GameManager Instance;
    public GameState CurrentGameState;
    private void Awake()
    {
        Instance = this;
    }
}
