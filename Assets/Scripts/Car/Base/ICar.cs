using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CarGame.Car
{
    public interface ICar
    {
        Rigidbody CarRigidbody { get; }
        Collider ExitCollider { get; }
        Transform FirstPos { get;}
        bool IsActive { get; set; }
        void Move();
         void Rotate();
         void RecordPlay();
         void ResetPos();
         void ResetRecord();
    }
}
