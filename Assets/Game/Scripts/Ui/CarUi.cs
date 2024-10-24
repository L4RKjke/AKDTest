using System;
using TMPro;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Ui
{
    public class CarUi : MonoBehaviour
    {
        [SerializeField] Car _car;
        [SerializeField] TextMeshProUGUI _carCapacity;

        public void Start()
        {
            _car.Stash
                .Subscribe( c => _carCapacity.text = $"{c} items" )
                .AddTo(this);
            
            _car.Selected
                .Subscribe( v => gameObject.SetActive( v ) )
                .AddTo(this);
        }
    }
}