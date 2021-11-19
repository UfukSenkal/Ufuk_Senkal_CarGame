using CarGame;
using CarGame.Car.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var car = other.gameObject.GetComponent<CarMovementController>();
        var obstacle = other.gameObject.GetComponent<ObstacleBase>();
        if (car != null || obstacle != null)
        {

           
            GameManager.Instance.CurrentGameState = GameManager.GameState.WaitingInput;
            CarManager.Instance.carState = CarManager.CarState.Waiting;
            CarManager.Instance.SetAllFirstPos();
            if (this.GetComponent<CarMovementController>().isActive())
            {

                this.GetComponent<CarMovementController>().ResetRecord();
            }
        }
    }
}
