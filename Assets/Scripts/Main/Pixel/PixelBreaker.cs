﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Matomaru.Main {
    public class PixelBreaker : MonoBehaviour, IPixelBreaker {

        [SerializeField]
        private List<GameObject> IClickableGameObjectChildren;

        public List<ISetup> ISetupChildren { get; set; } = new List<ISetup>();

        public void ClickWithHitPoint(Vector2 hitPoint) {

            if(IClickableGameObjectChildren.Count != 0) {
                foreach(var child in IClickableGameObjectChildren) {
                    child.GetComponent<IClickable>()?.ClickWithHitPoint(hitPoint);
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
