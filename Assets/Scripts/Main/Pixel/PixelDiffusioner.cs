using UnityEngine;
using eightpicomu.Extensions.Editor;

namespace Matomaru.Main {
    public class PixelDiffusioner : MonoBehaviour {

        [SerializeField]
        private float m_ForceGain;


        public void AddForceWithHitPoint(Rigidbody2D rigid, Vector2 point) {

            var position = transform.position;
            var force = (new Vector3(position.x - point.x, position.y - point.y, 0).normalized) * m_ForceGain;

            rigid.AddForce(force);
        }
    }
}