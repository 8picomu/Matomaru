using System;
using System.Collections.Generic;

namespace Matomaru.Main {
    public class ServiceLocator {
        private Dictionary<Type, object> container = new Dictionary<Type, object>();

        public T Resolve<T>() {
            return (T)container[typeof(T)];
        }

        public void Register<T>(T instance) {
            container.Add(typeof(T), instance);
        }
    }
}
