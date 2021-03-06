using CarGame.Car.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarGame.Colliders
{
    public class FinishCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            CarMovementController car = other.gameObject.GetComponent<CarMovementController>();

            //AI cant collide with active car's exit
            if (car != null && car.ExitCollider == this.GetComponent<Collider>())
            {

                if (car.IsActive)
                {

                    car.ResetPos();
                    GameManager.Instance.CurrentGameState = GameManager.GameState.WaitingInput;
                    CarManager.Instance.carState = CarManager.CarState.Waiting;
                    if (CarManager.Instance.CheckLastCar(car))
                    {
                        LevelManager.Instance.NextLevel();
                    }
                    CarManager.Instance.ChangeActiveCar();
                }
                else
                {
                    car.Park();
                }
            }
        }

    }
}
