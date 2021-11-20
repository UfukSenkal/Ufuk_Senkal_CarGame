using CarGame;
using CarGame.Car.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarGame.Colliders
{
    public class CrashController : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            var car = other.gameObject.GetComponent<CarMovementController>();
            var obstacle = other.gameObject.GetComponent<ObstacleBase>();

            if (car != null || obstacle != null)
            {



                if (this.GetComponent<CarMovementController>().IsActive)
                {
                    GameManager.Instance.CurrentGameState = GameManager.GameState.WaitingInput;
                    CarManager.Instance.carState = CarManager.CarState.Waiting;
                    CarManager.Instance.SetAllFirstPos();

                    this.GetComponent<CarMovementController>().ResetRecord();
                }
            }
        }
    }
}
