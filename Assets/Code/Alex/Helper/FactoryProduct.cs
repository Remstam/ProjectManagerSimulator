using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Alex.Helper
{
    public class FactoryProduct : IDisposable
    {
        private readonly GameObject _product;

        public FactoryProduct(GameObject product)
        {
            _product = product;
        }
        
        public T Get<T>() where T : Component
        {
            return _product.GetComponent<T>();
        }
        
        public T Add<T>() where T : Component
        {
            return _product.AddComponent<T>();
        }

        public T GetInChild<T>() where T : Component
        {
            return _product.GetComponentInChildren<T>();
        }

        public void Dispose()
        {
            Object.Destroy(_product);
        }
    }
}