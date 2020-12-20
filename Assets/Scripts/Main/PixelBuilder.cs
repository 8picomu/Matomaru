using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Matomaru.Main {
    public class PixelBuilder : MonoBehaviour {

        [SerializeField]
        private GameObject textureObject;

        private void OnEnable() {
            if(textureObject == null) {

            }
        }

        private void OnValidate() {
            
        }
    }
}