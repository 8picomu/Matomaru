using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;
using UniRx.InternalUtil;

namespace Matomaru.Main {

    public class InputProvider : MonoBehaviour, IInputObservables, MainInputAction.IPlayerActions {
        
        public IObservable<Vector2> LStickObservable { private set; get; }
        private ISubject<Vector2> m_LStickSubject;

        private void Awake() {
            m_LStickSubject = new LStick();
            LStickObservable = m_LStickSubject;
        }

        public void OnMove(InputAction.CallbackContext context) {
            if(context.performed) {
                m_LStickSubject.OnNext(context.ReadValue<Vector2>());
            }
        }

        private void OnDestroy() {
            m_LStickSubject.OnCompleted();
        }
    }

    internal class LStick : Subject<Vector2> { }
}