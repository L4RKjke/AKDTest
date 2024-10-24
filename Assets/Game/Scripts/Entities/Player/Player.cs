using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Entities
{
    public class Player : MonoBehaviour
    {
        [SerializeField] Taker _taker;
        
        public void Take( Item item )
        {
            _taker.Take( item );
        }

        public void Put( Car car )
        {
            foreach (var i in _taker.Items)
                car.Take(i);
            
            _taker.Clear();
        }
    }
}