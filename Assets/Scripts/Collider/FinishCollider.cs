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
            if (car.isActive())
            {

                car.ResetPos();
                GameManager.Instance.CurrentGameState = GameManager.GameState.WaitingInput;
                CarManager.Instance.carState = CarManager.CarState.Waiting;
                CarManager.Instance.ChangeActiveCar();
            }
            else
            {
                car.Park();
            }
        }

    }
}
