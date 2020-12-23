using UnityEngine;

namespace Matomaru.Main {
    class ServiceLocatorProvider : SingletonMonoBehaviour<ServiceLocatorProvider> {

        [SerializeField]
        public ServiceLocator Current { get; private set; } = new ServiceLocator();

    }
}