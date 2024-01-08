using minECS.Registry;
using System;
using System.Collections.Generic;
using System.Text;
using Undine.Core;
using Undine.Core.Class;

namespace Undine.MinEcs.Class
{
    public class MinSystem<T> : ISystem
        where T : class
    {
        private IUnifiedSystem<T> _system;
        private EntityRegistry.ProcessComponent<MinComponentWrapper<T>> _processComponent;

        public EntityRegistry Registry { get; set; }

        public IUnifiedSystem<T> System
        {
            get => _system;
            set
            {
                _system = value;
                _processComponent = new EntityRegistry.ProcessComponent<T>(ProcessComponent);
            }
        }
        void ProcessComponent(int entity, MinComponentWrapper<T> component)
        {
            System.ProcessSingleEntity(entity, ref component.Component);
        }


        public void ProcessAll()
        {
            _system.PreProcess();
            Registry.Loop(_processComponent);
            _system.PostProcess();
        }
    }

    public class MinSystem<A, B> : ISystem
        where A : class
        where B : class
    {
        private IUnifiedSystem<A, B> _system;
        public EntityRegistry Registry { get; set; }

        public IUnifiedSystem<A, B> System
        {
            get => _system;
            set
            {
                _system = value;
                _processComponent = new EntityRegistry.ProcessComponent<A, B>(System.ProcessSingleEntity);
            }
        }

        private EntityRegistry.ProcessComponent<A, B> _processComponent;

        public void ProcessAll()
        {
            _system.PreProcess();
            Registry.Loop(_processComponent);
            _system.PostProcess();
        }
    }

    public class MinSystem<A, B, C> : ISystem
        where A : class
        where B : class
        where C : class
    {
        private IUnifiedSystem<A, B, C> _system;
        public EntityRegistry Registry { get; set; }

        public IUnifiedSystem<A, B, C> System
        {
            get => _system;
            set
            {
                _system = value;
                _processComponent = new EntityRegistry.ProcessComponent<A, B, C>(System.ProcessSingleEntity);
            }
        }

        private EntityRegistry.ProcessComponent<A, B, C> _processComponent;

        public void ProcessAll()
        {
            _system.PreProcess();
            Registry.Loop(_processComponent);
            _system.PostProcess();
        }
    }

    public class MinSystem<A, B, C, D> : ISystem
        where A : class
        where B : class
        where C : class
        where D : class
    {
        private IUnifiedSystem<A, B, C, D> _system;
        public EntityRegistry Registry { get; set; }

        public IUnifiedSystem<A, B, C, D> System
        {
            get => _system;
            set
            {
                _system = value;
                _processComponent = new EntityRegistry.ProcessComponent<A, B, C, D>(System.ProcessSingleEntity);
            }
        }

        private EntityRegistry.ProcessComponent<A, B, C, D> _processComponent;

        public void ProcessAll()
        {
            _system.PreProcess();
            Registry.Loop(_processComponent);
            _system.PostProcess();
        }
    }
}
