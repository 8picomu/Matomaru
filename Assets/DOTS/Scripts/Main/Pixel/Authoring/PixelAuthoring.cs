using UnityEngine;

using Unity.Entities;

namespace Matomaru.ECS.Main {
    public class PixelAuthoring : MonoBehaviour, IConvertGameObjectToEntity {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
            
        }
    }
}