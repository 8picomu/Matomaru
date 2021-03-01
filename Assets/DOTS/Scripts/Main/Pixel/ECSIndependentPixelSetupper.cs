using UnityEngine;
using Unity.Entities;

using eightpicomu.Extensions.Editor;
using Matomaru.Main;

namespace Matomaru.ECS.Main {

    class ECSIndependentPixelSetupper : MonoBehaviour, IIndependentPixel {

        public bool IsIndependent { get; private set; } = false;

        [SerializeField, ReadOnly]
        private Rigidbody2D m_Rigid;

        [SerializeField]
        private PixelAdjuster m_PixelAdjuster;

        [SerializeField]
        private PixelDiffusioner m_PixelDiffusioner;

        private void Start() {
            m_PixelAdjuster = GetComponent<PixelAdjuster>();
            m_PixelAdjuster.enabled = false;
        }

        public void Setup(Vector2 hitPoint) {
            m_Rigid = gameObject.AddComponent<Rigidbody2D>();
            m_Rigid.mass = 0;
            m_Rigid.gravityScale = 0;
            m_Rigid.freezeRotation = true;

            m_PixelAdjuster.enabled = true;

            m_PixelDiffusioner?.AddForceWithHitPoint(m_Rigid, hitPoint);

            IsIndependent = true;

            //gameObject.AddComponent<ConvertToEntity>();
        }

        public void FollowTarget(Transform target) {
            GetComponent<IPixelAdjuster>().PixelAdjust();
            Destroy(m_Rigid);
            transform.parent = target;
            IsIndependent = false;
        }
    }
}