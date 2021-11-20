using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarGame.Car
{
    public abstract class AbstractCarBase : MonoBehaviour, ICar
    {
        
       
        private bool _isActive = false;
        /// <summary>
        /// Set car is moving by itself
        /// </summary>
        public bool IsActive { set => _isActive = value; }

        public abstract Transform FirstPos { get; }

        public abstract Collider ExitCollider { get; }
        public abstract Rigidbody CarRigidbody { get; }

        public abstract void Move();
        public abstract void Rotate();
        public abstract void RecordPlay();
        public abstract void ResetPos();
        public abstract void ResetRecord();

        /// <summary>
        /// Is moving by itself
        /// </summary>
        public bool isActive()
        {
            return _isActive;
        }
    }
}
