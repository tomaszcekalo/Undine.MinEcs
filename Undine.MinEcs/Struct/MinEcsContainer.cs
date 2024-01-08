using minECS.Components;
using minECS.Registry;
using System;
using System.Collections.Generic;
using Undine.Core;
using Undine.Core.Struct;

namespace Undine.MinEcs.Struct
{
    public class MinEcsContainer : EcsContainer
    {
        private readonly List<ISystem> _systems = new List<ISystem>();
        private readonly EntityRegistry _registry;
        private readonly List<Type> _registeredTypes = new List<Type>();
        private readonly int _preallocShift;
        public readonly BufferType _bufferType;

        public MinEcsContainer(int preallocShift = 14, BufferType bufferType = BufferType.Sparse)
        {
            _preallocShift = preallocShift;
            _bufferType = bufferType;
            _registry = new EntityRegistry(1 << _preallocShift);
        }

        public override void RegisterComponentType<A>(Action<object, IUnifiedEntity> action = null)
            where A : struct
        {
            var type = typeof(A);
            if (!_registeredTypes.Contains(type))
            {
                _registry.RegisterComponent<A>(_bufferType, _preallocShift);
                base.RegisterComponentType<A>(action);
            }
        }

        public override void AddSystem<A>(UnifiedSystem<A> system)
        {
            RegisterComponentType<A>();

            _systems.Add(new MinSystem<A>
            {
                System = system,
                Registry = _registry
            });
        }

        public override void AddSystem<A, B>(UnifiedSystem<A, B> system)
        {
            RegisterComponentType<A>();
            RegisterComponentType<B>();

            _systems.Add(new MinSystem<A, B>
            {
                System = system,
                Registry = _registry
            });
        }

        public override void AddSystem<A, B, C>(UnifiedSystem<A, B, C> system)
        {
            RegisterComponentType<A>();
            RegisterComponentType<B>();
            RegisterComponentType<C>();

            _systems.Add(new MinSystem<A, B, C>
            {
                System = system,
                Registry = _registry
            });
        }

        public override void AddSystem<A, B, C, D>(UnifiedSystem<A, B, C, D> system)
        {
            RegisterComponentType<A>();
            RegisterComponentType<B>();
            RegisterComponentType<C>();
            RegisterComponentType<D>();

            _systems.Add(new MinSystem<A, B, C, D>
            {
                System = system,
                Registry = _registry
            });
        }

        public override void Run()
        {
            foreach (var system in _systems)
                system.ProcessAll();
        }

        public override IUnifiedEntity CreateNewEntity()
        {
            return new MinEntity(_registry);
        }

        public override ISystem GetSystem<A>(UnifiedSystem<A> system)
        {
            RegisterComponentType<A>();
            return new MinSystem<A>
            {
                System = system,
                Registry = _registry
            };
        }

        public override ISystem GetSystem<A, B>(UnifiedSystem<A, B> system)
        {
            RegisterComponentType<A>();
            RegisterComponentType<B>();
            return new MinSystem<A, B>
            {
                System = system,
                Registry = _registry
            };
        }

        public override ISystem GetSystem<A, B, C>(UnifiedSystem<A, B, C> system)
        {
            RegisterComponentType<A>();
            RegisterComponentType<B>();
            RegisterComponentType<C>();

            return new MinSystem<A, B, C>
            {
                System = system,
                Registry = _registry
            };
        }

        public override ISystem GetSystem<A, B, C, D>(UnifiedSystem<A, B, C, D> system)
        {
            RegisterComponentType<A>();
            RegisterComponentType<B>();
            RegisterComponentType<C>();
            RegisterComponentType<D>();

            return new MinSystem<A, B, C, D>
            {
                System = system,
                Registry = _registry
            };
        }
    }
}