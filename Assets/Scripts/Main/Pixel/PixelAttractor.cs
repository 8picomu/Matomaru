using UnityEngine;

namespace Matomaru.Main {
    public class PixelAttractor : MonoBehaviour {

        [SerializeField]
        private GameObject Pixels;

        private void OnCollisionEnter2D(Collision2D collision) {
            var independentPixel = collision.gameObject.GetComponent<IIndependentPixel>();

            if(independentPixel?.IsIndependent == true) {
                independentPixel.FollowTarget(Pixels.transform);
            }
        }
    }
}
