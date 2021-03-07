using Unity.Transforms;
using Unity.Entities;
using Unity.Physics;
using Unity.Jobs;
using Unity.Burst;
using Unity.Collections;

using Random = Unity.Mathematics.Random;

namespace Matomaru.ECS.Main {
    class MoveTestPixelSystem : SystemBase {

        private EntityQuery query;

        protected override void OnCreate() {
            query = GetEntityQuery(typeof(Translation)) ;
        }

        protected override void OnUpdate() {
            
/*             var job = new moveJob {
                translationType = GetComponentTypeHandle<Translation>(),
            };

            Dependency = job.Schedule(query, Dependency); */
        }

        [BurstCompile]
        private struct moveJob : IJobChunk {
            public ComponentTypeHandle<Translation> translationType;

            public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
            {
                var translations = chunk.GetNativeArray(translationType);

                for(var i = 0; i < chunk.Count; i++) {
                    translations[i] = new Translation{ Value = translations[i].Value + 0.1f };
                }
            }
        }
    }  
}
