using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarGame.Car
{
    public abstract class AbstractCarBase : MonoBehaviour, ICar
    {
        private bool _isActive = false;

        public bool IsActive { set => _isActive = value; }

        public abstract void Move();
        public abstract void RecordPlay();
        public abstract void PlayMovement();

        public bool isActive()
        {
            return _isActive;
        }
    }
}
