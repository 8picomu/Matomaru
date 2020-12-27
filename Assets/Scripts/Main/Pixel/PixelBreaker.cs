using System;
using System.Collections.Generic;
using UnityEngine;

namespace Matomaru.Main {
    public class PixelBreaker : MonoBehaviour, IPixelBreaker {

        [SerializeField]
        private List<GameObject> IClickableGameObjectChildren;

        public List<IClickable> IClickableChildren { get; set; } = new List<IClickable>();

        public void Click() {

            if(IClickableGameObjectChildren.Count != 0) {
                foreach(var child in IClickableGameObjectChildren) {
                    child.GetComponent<IClickable>()?.Click();
                }
            }

            foreach(var child in IClickableChildren) {
                child.Click();
            }

            transform.DetachChildren();
            Destroy(this);
        }
    }
}
