using minECS.Registry;
using Undine.Core;

namespace Undine.MinEcs
{
    public class MinEntity : IUnifiedEntity
    {
        private EntityRegistry _registry;
        public ulong EntityId { get; set; }

        public MinEntity(EntityRegistry registry)
        {
            _registry = registry;
            EntityId = registry.CreateEntity();
        }

        public void AddComponent<A>(in A component)
            where A : struct
        {
            _registry.AddComponent(EntityId, component);
        }

        public ref A GetComponent<A>() where A : struct
        {
            return ref _registry.GetComponent<A>((int)EntityId);
        }

        public void RemoveComponent<A>() where A : struct
        {
            _registry.RemoveComponent<A>(EntityId);
        }
    }
}