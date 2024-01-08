using minECS.Registry;
using Undine.Core;
using Undine.Core.Struct;

namespace Undine.MinEcs.Struct
{
    public class MinEntity : IUnifiedEntity
    {
        private EntityRegistry _registry;
        private ulong _entity;

        public MinEntity(EntityRegistry registry)
        {
            _registry = registry;
            _entity = registry.CreateEntity();
        }

        public void AddComponent<A>(in A component)
            where A : struct
        {
            _registry.AddComponent(_entity, component);
        }

        public ref A GetComponent<A>() where A : struct
        {
            return ref _registry.GetComponent<A>((int)_entity);
        }
    }
}