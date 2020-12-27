using UnityEngine;


namespace Matomaru.Main {
    [RequireComponent(typeof(PixelAdjuster))]
    public class IndependentPixelSetupper : MonoBehaviour, IClickable {

        [SerializeField]
        private PixelAdjuster m_PixelAdjuster;

        private void Start() {
            m_PixelAdjuster = GetComponent<PixelAdjuster>();
            m_PixelAdjuster.enabled = false;
        }

        public void Click() {
            var rigid = gameObject.AddComponent<Rigidbody2D>();
            rigid.mass = 0;
            rigid.freezeRotation = true;

            m_PixelAdjuster.enabled = true;
        }
    }
}