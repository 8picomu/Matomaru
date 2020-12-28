using UnityEngine;

namespace Matomaru.Main {
    [RequireComponent(typeof(PixelAdjuster))]
    public class IndependentPixelSetupper : MonoBehaviour, ISetup {

        [SerializeField]
        private PixelAdjuster m_PixelAdjuster;

        [SerializeField]
        private PixelDiffusioner m_PixelDiffusioner;

        private void Start() {
            m_PixelAdjuster = GetComponent<PixelAdjuster>();
            m_PixelAdjuster.enabled = false;
        }

        public void Setup(Vector2 hitPoint) {
            var rigid = gameObject.AddComponent<Rigidbody2D>();
            rigid.mass = 0;
            rigid.gravityScale = 0;
            rigid.freezeRotation = true;

            m_PixelAdjuster.enabled = true;

            m_PixelDiffusioner?.AddForceWithHitPoint(rigid, hitPoint);
        }
    }
}