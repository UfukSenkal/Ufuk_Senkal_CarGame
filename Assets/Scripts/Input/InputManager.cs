using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarGame.InputSystem
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] InputData _inputData;


        private void LateUpdate()
        {
            if (GameManager.Instance.CurrentGameState == GameManager.GameState.WaitingInput)
            {
                CarManager.Instance.GetActiveCar().IsActive = true;
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