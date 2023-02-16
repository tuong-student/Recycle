using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NOOD
{
    public abstract class AbstractMonoBehaviour : MonoBehaviour, IDisposable
    {
        internal List<AbstractMonoBehaviour> objects = new List<AbstractMonoBehaviour>();

        public AbstractMonoBehaviour AddTo(AbstractMonoBehaviour parent)
        {
            parent.objects.Add(this);
            return this;
        }

        private void OnDestroy()
        {
            Clear();
        }

        public void Clear()
        {
            foreach (var obj in objects)
            {
                if (obj)
                {
                    Destroy(obj.gameObject);
                }
            }
        }

        public void DisposeAll()
        {
            foreach (var obj in objects)
            {
                if (obj)
                {
                    obj.Dispose();
                }
            }
        }

        public abstract void Dispose();
    }
}
