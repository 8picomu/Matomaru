using System;
using System.Collections.Generic;
using UnityEngine;

namespace Matomaru.Main {
    public class PixelBreaker : MonoBehaviour, IClickable {

        [SerializeField]
        public List<GameObject> m_IClickableChildren;

        public void Click() {
            foreach(var child in m_IClickableChildren) {
                child.GetComponent<IClickable>()?.Click();
            }

            transform.DetachChildren();
            Destroy(this);
        }
    }
}
