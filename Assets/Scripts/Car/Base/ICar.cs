using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CarGame.Car
{
    public interface ICar
    {
        Collider ExitCollider { get; }
        Transform FirstPos { get;}
        bool isActive();
    }
}
