using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarGame.InputSystem
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] InputData _inputData;


        private void Update()
        {
            if (GameManager.Instance == null)
                return;


            if (GameManager.Instance.CurrentGameState == GameManager.GameState.WaitingInput)
            {
                CarManager.Instance.CheckActiveCar();
                _inputData.ProccessInput();
                if (_inputData.IsTouching != 0)
                {
                    _inputData.ResetInput();
                    GameManager.Instance.CurrentGameState = GameManager.GameState.Started;

                }
            }
            else
            {
                _inputData.ProccessInput();
            }
        }
    }
}