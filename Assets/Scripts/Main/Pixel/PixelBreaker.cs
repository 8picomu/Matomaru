using System;
using System.Collections.Generic;
using UnityEngine;

namespace Matomaru.Main {
    public class PixelBreaker : MonoBehaviour, IPixelBreaker {

        [SerializeField]
        private List<GameObject> IClickableGameObjectChildren;

        public List<IIndependentPixel> ISetupChildren { get; set; } = new List<IIndependentPixel>();

        public void ClickWithHitPoint(Vector2 hitPoint) {

            if(IClickableGameObjectChildren.Count != 0) {
                foreach(var child in IClickableGameObjectChildren) {
                    foreach(var value in child.GetComponents<IClickable>()) {
                        value.ClickWithHitPoint(hitPoint);
                    }
                }
            }

            foreach(var child in ISetupChildren) {
                child.Setup(hitPoint);
            }

            transform.DetachChildren();
            Destroy(this);
        }
    }
}
