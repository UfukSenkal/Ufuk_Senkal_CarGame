using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CarGame.UIData {
    public class InputTextController : MonoBehaviour
    {
        [Tooltip("Text for user to get input")]
        [SerializeField] private TextMeshProUGUI _inputText;


        private void Update()
        {
            if (GameManager.Instance.CurrentGameState == GameManager.GameState.WaitingInput)
            {
                _inputText.gameObject.SetActive(true);
            }
            else
            {
                _inputText.gameObject.SetActive(false);
            }
        }
    } 
}
