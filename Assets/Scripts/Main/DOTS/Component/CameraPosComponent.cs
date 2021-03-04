using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Matomaru.ECS.Main {

    [Serializable]
    public struct CameraPosComponent : ISharedComponentData {
        public float3 position;
    }
}