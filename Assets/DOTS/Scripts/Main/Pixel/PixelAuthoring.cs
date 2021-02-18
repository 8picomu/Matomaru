using UnityEngine;
using Unity.Entities;

namespace Matomaru.ECS.Main {

    public class PixelAuthoring : MonoBehaviour, IConvertGameObjectToEntity {

        public MousePos pos;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
            dstManager.AddSharedComponentData(entity, new MousePos());
        }
    }
}
