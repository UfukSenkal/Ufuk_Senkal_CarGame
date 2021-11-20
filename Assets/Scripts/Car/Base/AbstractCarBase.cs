using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarGame.Car
{
    public abstract class AbstractCarBase : MonoBehaviour, ICar
    {
        
       
        private bool _isActive = false;
        /// <summary>
        /// Set car is moving by itself, Get is car moving by itself
        /// </summary>
        public bool IsActive { get => _isActive; set => _isActive = value; }

        public abstract Transform FirstPos { get; }

        public abstract Collider ExitCollider { get; }
        public abstract Rigidbody CarRigidbody { get; }

        public abstract void Move();
        public abstract void Rotate();
        public abstract void RecordPlay();
        public abstract void ResetPos();
        public abstract void ResetRecord();

    
    }
}
