using System;
using UnityEngine;
using UniRx;
using pf35301.Extensions.Editor;

namespace Matomaru.Main {
    
    class PlayerMover : MonoBehaviour {

        private IInputObservables m_InputObservables;

        [SerializeField, ReadOnly]
        private Rigidbody2D m_RigidBody;

        [Header("Move")]

        [SerializeField]
        private float m_MoveGain = 1.0f;

        private void Start() {
            if(m_RigidBody == null) {
                m_RigidBody = GetComponent<Rigidbody2D>();
            }

            if(m_InputObservables == null) {
                m_InputObservables = ServiceLocatorProvider.Instance.Current.Resolve<IInputObservables>();
            }

            m_InputObservables.LStickObservable.Subscribe(
                vec => {
                    m_RigidBody.AddForce(vec * m_MoveGain);
                }).AddTo(this);
        }
    }
}