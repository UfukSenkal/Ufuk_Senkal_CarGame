using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarGame.Car
{
    [CreateAssetMenu(menuName = "CarGame/Car/Car Settings")]
    public class CarSettings_SO : MonoBehaviour
    {
        [SerializeField] private Material _playerMaterial;
        [SerializeField] private Material _replayMaterial;


        public Material PlayerMaterial { get { return _playerMaterial; } }
        public Material ReplayMaterial { get { return _replayMaterial; } }
    }
}
