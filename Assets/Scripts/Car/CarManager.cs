using CarGame.Car;
using CarGame.Car.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public enum CarState
    {
        Waiting,
        Moving,
        MovingByRecord,
        Parked
    }

    public static CarManager Instance;

    [SerializeField] Transform _carParent;
    private List<CarMovementController> carList = new List<CarMovementController>();

    public CarState carState = CarState.Waiting;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < _carParent.childCount; i++)
        {
            carList.Add(_carParent.GetChild(i).GetChild(0).GetComponent<CarMovementController>());
        }

    }

    public CarMovementController GetActiveCar()
    {
        CarMovementController activeCar = new CarMovementController();

        for (int i = 0; i < carList.Count; i++)
        {
            if (carList[i].isActive())
            {
                activeCar = carList[i];
                break;

            }
        }

        if (activeCar == null)
        {
            activeCar = carList[0];
            activeCar.IsActive = true;
        }
        return activeCar;
    }

    public void ChangeActiveCar()
    {
        CarMovementController activeCar = new CarMovementController();

        for (int i = 0; i < carList.Count - 1; i++)
        {
            if (carList[i].isActive())
            {
                carList[i].IsActive = false;
                activeCar = carList[i + 1];
                activeCar.IsActive = true;
                break;

            }
        }

        SetAllFirstPos();


    }

    private void SetAllFirstPos()
    {
        for (int i = 0; i < carList.Count - 1; i++)
        {
            carList[i].ResetPos();
        }
    }
}
