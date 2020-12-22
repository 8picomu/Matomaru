using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;
using pf35301.Extensions.Editor;

namespace Matomaru.Main {

    public class InputProvider : MonoBehaviour, IInputObservables, MainInputAction.IPlayerActions {
        
        public IObservable<Vector2> LStickObservable { get => m_LStickSubject; }
        private ISubject<Vector2> m_LStickSubject;
        [SerializeField, ReadOnly]
        private Vector2 m_LStickValue = new Vector2();

        private void Awake() {
            m_LStickSubject = new LStick();
        }

        private void OnEnable() {
            ServiceLocatorProvider.Instance.Current.Register<IInputObservables>(this);
        }

        private void FixedUpdate() {
            m_LStickSubject.OnNext(m_LStickValue.normalized);
        }

        private void OnDestroy() {
            m_LStickSubject.OnCompleted();
        }

        public void OnXAxis(InputAction.CallbackContext context) {
            if(context.performed) {
                m_LStickValue.x = context.ReadValue<float>();
            }
        }

        public void OnYAxis(InputAction.CallbackContext context) {
            if(context.performed) {
                m_LStickValue.y = context.ReadValue<float>();
            }
        }
    }

    internal class LStick : Subject<Vector2> { }
}