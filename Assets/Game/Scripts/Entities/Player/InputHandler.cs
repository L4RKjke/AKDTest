using System;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Entities
{
    public class InputHandler : MonoBehaviour
    {
        public readonly ReactiveCommand OnInteractiveClick = new ();
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnInteractiveClick.Execute();
            }
        }
    }
}