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
                //Time.fixedDeltaTime = 0;
                _inputData.ProccessInput();
                if (_inputData.IsTouching != 0)
                {
                    GameManager.Instance.CurrentGameState = GameManager.GameState.Started;
                    
                    CarManager.Instance.GetActiveCar().IsActive = true;
                }
            }
            else
            {
                Time.fixedDeltaTime = 1;
                _inputData.ProccessInput();
            }
        }
    }
}