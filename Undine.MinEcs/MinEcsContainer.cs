using minECS.Components;
using minECS.Registry;
using System;
using System.Collections.Generic;
using Undine.Core;

namespace Undine.MinEcs
{
    public class MinEcsContainer : EcsContainer
    {
        private readonly List<ISystem> _systems = new List<ISystem>();
        private readonly EntityRegistry _registry;
        private readonly List<Type> _registeredTypes = new List<Type>();
        private readonly int _preallocShift;
        public readonly int _bufferType;

        public MinEcsContainer(int preallocShift = 14, int bufferType = 1)
        {
            _preallocShift = preallocShift;
            _bufferType = bufferType;
            _registry = new EntityRegistry(1 << _preallocShift);
        }

        protected void RegisterTypeIfNotRegistered<T>()
            where T : struct
        {
            var type = typeof(T);
            if (!_registeredTypes.Contains(type))
            {
                _registry.RegisterComponent<T>((BufferType)_bufferType, _preallocShift);
            }
        }

        public override void AddSystem<A>(UnifiedSystem<A> system)
        {
            RegisterTypeIfNotRegistered<A>();

            _systems.Add(new MinSystem<A>
            {
                System = system,
                Registry = _registry
            });
        }

        public override void AddSystem<A, B>(UnifiedSystem<A, B> system)
        {
            RegisterTypeIfNotRegistered<A>();
            RegisterTypeIfNotRegistered<B>();

            _systems.Add(new MinSystem<A, B>
            {
                System = system,
                Registry = _registry
            });
        }

        public override void AddSystem<A, B, C>(UnifiedSystem<A, B, C> system)
        {
            RegisterTypeIfNotRegistered<A>();
            RegisterTypeIfNotRegistered<B>();
            RegisterTypeIfNotRegistered<C>();

            _systems.Add(new MinSystem<A, B, C>
            {
                System = system,
                Registry = _registry
            });
        }

        public override void AddSystem<A, B, C, D>(UnifiedSystem<A, B, C, D> system)
        {
            RegisterTypeIfNotRegistered<A>();
            RegisterTypeIfNotRegistered<B>();
            RegisterTypeIfNotRegistered<C>();
            RegisterTypeIfNotRegistered<D>();

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
            RegisterTypeIfNotRegistered<A>();
            return new MinSystem<A>
            {
                System = system,
                Registry = _registry
            };
        }

        public override ISystem GetSystem<A, B>(UnifiedSystem<A, B> system)
        {
            RegisterTypeIfNotRegistered<A>();
            RegisterTypeIfNotRegistered<B>();
            return new MinSystem<A, B>
            {
                System = system,
                Registry = _registry
            };
        }

        public override ISystem GetSystem<A, B, C>(UnifiedSystem<A, B, C> system)
        {
            RegisterTypeIfNotRegistered<A>();
            RegisterTypeIfNotRegistered<B>();
            RegisterTypeIfNotRegistered<C>();

            return new MinSystem<A, B, C>
            {
                System = system,
                Registry = _registry
            };
        }

        public override ISystem GetSystem<A, B, C, D>(UnifiedSystem<A, B, C, D> system)
        {
            RegisterTypeIfNotRegistered<A>();
            RegisterTypeIfNotRegistered<B>();
            RegisterTypeIfNotRegistered<C>();
            RegisterTypeIfNotRegistered<D>();

            return new MinSystem<A, B, C, D>
            {
                System = system,
                Registry = _registry
            };
        }

        //public override void AddSystem(IMinSystem system)
        //{
        //    _systems.Add(system);
        //}
    }
}