using UnityEngine;

namespace Matomaru.Main {
    class ServiceLocatorProvider : SingletonMonoBehaviour<ServiceLocatorProvider> {
        public ServiceLocator Current { get; private set; }

        private void Awake() {
            Current = new ServiceLocator();
        }
    }
}