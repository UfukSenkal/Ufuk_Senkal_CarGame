using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CarGame.Car
{
    public interface ICar
    {
        Transform FirstPos { get;}
        bool isActive();
    }
}
