using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Entities
{
    public class Taker : MonoBehaviour
    {
        readonly List<Item> _items = new List<Item>();

        public IReadOnlyCollection<Item> Items => _items;
        
        public void Take( Item item )
        {
            item.transform.SetParent( transform );
            item.gameObject.SetActive( false );
            _items.Add( item );
        }

        public void Clear() =>  _items.Clear();
    }
}