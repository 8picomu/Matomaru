using Unity.Transforms;
using Unity.Entities;
using Unity.Physics;
using Unity.Jobs;
using Unity.Burst;
using Unity.Collections;

using Random = Unity.Mathematics.Random;

namespace Matomaru.ECS.Main {
    class MovePixelSystem : SystemBase {

        private EntityQuery query;

        protected override void OnCreate() {
            query = GetEntityQuery(typeof(Translation)) ;
        }

        protected override void OnUpdate() {

            var job2 = new moveJob2 {
                translationType = GetComponentTypeHandle<Translation>(),
            };

            Dependency = job2.Schedule(query, Dependency);
            
            var job = new moveJob {
                translationType = GetComponentTypeHandle<Translation>(),
            };

            Dependency = job.Schedule(query, Dependency);
        }

        [BurstCompile]
        private struct genRndNumbersJob : IJobChunk {
            public ComponentTypeHandle<RandomNumberComponent> randomNumberType;

            public uint seed;

            public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex) {
                NativeArray<RandomNumberComponent> randomNumbers = chunk.GetNativeArray(randomNumberType);

                var rnd = new Random(seed++);

                for(var i = 0; i < chunk.Count; i++) {
                    randomNumbers[i] = new RandomNumberComponent{ value = rnd.NextFloat(1.0f, 10.0f) };
                }
            }
        }

        [BurstCompile]
        private struct movePixelJob : IJobChunk {
            public ComponentTypeHandle<PhysicsVelocity> physicsVelocityType;
            [ReadOnly]
            public ComponentTypeHandle<Translation> translationType;
            public ComponentTypeHandle<RandomNumberComponent> randomNumberType;
            public ComponentTypeHandle<CameraPosComponent> cameraPosType;

            public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex) {
                var physicsVelociries = chunk.GetNativeArray(physicsVelocityType);
                var translations = chunk.GetNativeArray(translationType);
                var randomNumbers = chunk.GetNativeArray(randomNumberType);

                for(var i = 0; i < chunk.Count; i++) {
                    physicsVelociries[i] = new PhysicsVelocity { Linear = new Unity.Mathematics.float3(translations[i].Value.x , translations[i].Value.y + randomNumbers[i].value, 0) };

                }
            }
        }

        [BurstCompile]
        private struct moveJob : IJobChunk {
            public ComponentTypeHandle<Translation> translationType;

            public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
            {
                var translations = chunk.GetNativeArray(translationType);

                for(var i = 0; i < chunk.Count; i++) {
                    translations[i] = new Translation{ Value = new Unity.Mathematics.float3(0, 0, 0) };
                }
            }
        }

        [BurstCompile]
        private struct moveJob2 : IJobChunk {
            public ComponentTypeHandle<Translation> translationType;

            public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
            {
                var translations = chunk.GetNativeArray(translationType);

                for(var i = 0; i < chunk.Count; i++) {
                    translations[i] = new Translation{ Value = new Unity.Mathematics.float3(40, 40, 0) };
                }
            }
        }
    }  
}
