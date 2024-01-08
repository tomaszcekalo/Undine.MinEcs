using minECS.Registry;
using System;
using System.Collections.Generic;
using System.Text;
using Undine.Core.Class;

namespace Undine.MinEcs.Class
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
            where A : class
        {
            _registry.AddComponent(_entity, new MinComponentWrapper<A>()
            {
                Component=component
            });
        }

        public ref A GetComponent<A>() where A : class
        {
            return ref _registry.GetComponent<MinComponentWrapper<A>>((int)_entity).Component;
        }
    }
}
