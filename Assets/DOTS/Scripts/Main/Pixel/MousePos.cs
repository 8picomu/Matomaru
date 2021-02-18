using UnityEngine;
using Unity.Entities;
using System;

namespace Matomaru.ECS.Main {

    public struct MousePos : ISharedComponentData, IEquatable<MousePos> {

        public Vector3 MousePosition;

        public bool Equals(MousePos other) {
            return MousePosition == other.MousePosition;
        }

        public override int GetHashCode() {
            return GetHashCode();
        }
    }
}