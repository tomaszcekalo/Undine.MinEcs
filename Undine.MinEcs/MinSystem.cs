using minECS.Registry;
using Undine.Core;

namespace Undine.MinEcs
{
    public class MinSystem<T> : ISystem
        where T : struct
    {
        private IUnifiedSystem<T> _system;
        public EntityRegistry Registry { get; set; }

        public IUnifiedSystem<T> System
        {
            get => _system;
            set
            {
                _system = value;
                _processComponent = new EntityRegistry.ProcessComponent<T>(System.ProcessSingleEntity);
            }
        }

        private EntityRegistry.ProcessComponent<T> _processComponent;

        public void ProcessAll()
        {
            _system.PreProcess();
            Registry.Loop(_processComponent);
            _system.PostProcess();
        }
    }

    public class MinSystem<A, B> : ISystem
        where A : struct
        where B : struct
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
        where A : struct
        where B : struct
        where C : struct
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
        where A : struct
        where B : struct
        where C : struct
        where D : struct
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