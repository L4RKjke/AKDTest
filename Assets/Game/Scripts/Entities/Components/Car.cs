using System.Collections.Generic;
using Game.Scripts.Entities;
using UniRx;
using UnityEngine;

namespace Game.Scripts
{
    public class Car : MonoBehaviour, ISelectable
    {
        [SerializeField] Taker _taker;

        readonly ReactiveProperty<int> _stash = new ();
        readonly BoolReactiveProperty _isSelected = new ();

        public IReadOnlyReactiveProperty<bool> Selected => _isSelected;
        public IReadOnlyReactiveProperty<int> Stash => _stash;
        
        public void Take(Item item)
        {
            _taker.Take( item );
            _stash.Value++;
        }

        public void Select(bool isSelected)
        {
            _isSelected.Value = isSelected;
        }
    }
}