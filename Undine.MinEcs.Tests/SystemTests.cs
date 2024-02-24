using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Undine.Core;
using Undine.MinEcs.Tests.Components;

namespace Undine.MinEcs.Tests
{
    [TestClass]
    public class SystemTests
    {


        [TestMethod]
        public void OneTypeSystem_FromAdd_GetsProcessed()
        {
            var mock = Substitute.For<UnifiedSystem<AComponent>>();
            var container = new MinEcsContainer();
            container.AddSystem(mock);
            container.Init();
            var entity = container.CreateNewEntity();
            entity.AddComponent(new AComponent());
            container.Run();
            mock.Received().ProcessSingleEntity(
                Arg.Any<int>(),
                ref Arg.Any<AComponent>()
                );
        }
        [TestMethod]
        public void TwoTypeSystem_FromAdd_GetsProcessed()
        {
            var mock = Substitute.For<UnifiedSystem<AComponent, BComponent>>();
            var container = new MinEcsContainer();
            container.AddSystem(mock);
            container.Init();
            var entity = container.CreateNewEntity();
            entity.AddComponent(new AComponent());
            entity.AddComponent(new BComponent());
            container.Run();
            mock.Received().ProcessSingleEntity(
                Arg.Any<int>(),
                ref Arg.Any<AComponent>(),
                ref Arg.Any<BComponent>()
                );
        }
        [TestMethod]
        public void ThreeTypeSystem_FromAdd_GetsProcessed()
        {
            var mock = Substitute.For<UnifiedSystem<AComponent, BComponent, CComponent>>();
            var container = new MinEcsContainer();
            container.AddSystem(mock);
            container.Init();
            var entity = container.CreateNewEntity();
            entity.AddComponent(new AComponent());
            entity.AddComponent(new BComponent());
            entity.AddComponent(new CComponent());
            container.Run();
            mock.Received().ProcessSingleEntity(
                Arg.Any<int>(),
                ref Arg.Any<AComponent>(),
                ref Arg.Any<BComponent>(),
                ref Arg.Any<CComponent>()
                );
        }
        [TestMethod]
        public void FourTypeSystem_FromAdd_GetsProcessed()
        {
            var mock = Substitute.For<UnifiedSystem<AComponent, BComponent, CComponent, DComponent>>();
            var container = new MinEcsContainer();
            container.AddSystem(mock);
            container.Init();
            var entity = container.CreateNewEntity();
            entity.AddComponent(new AComponent());
            entity.AddComponent(new BComponent());
            entity.AddComponent(new CComponent());
            entity.AddComponent(new DComponent());
            container.Run();
            mock.Received().ProcessSingleEntity(
                Arg.Any<int>(),
                ref Arg.Any<AComponent>(),
                ref Arg.Any<BComponent>(),
                ref Arg.Any<CComponent>(),
                ref Arg.Any<DComponent>()
                );
        }
        public void AddDummySystem(EcsContainer container)
        {
            container.AddSystem(Substitute.For<UnifiedSystem<DComponent>>());
        }
        [TestMethod]
        public void OneTypeSystem_FromGet_GetsProcessed()
        {
            var mock = Substitute.For<UnifiedSystem<AComponent>>();
            var container = new MinEcsContainer();
            var system = container.GetSystem(mock);
            AddDummySystem(container);
            container.Init();
            var entity = container.CreateNewEntity();
            entity.AddComponent(new AComponent());
            system.ProcessAll();
            mock.Received().ProcessSingleEntity(
                Arg.Any<int>(),
                ref Arg.Any<AComponent>()
                );
        }
        [TestMethod]
        public void TwoTypeSystem_FromGet_GetsProcessed()
        {
            var mock = Substitute.For<UnifiedSystem<AComponent, BComponent>>();
            var container = new MinEcsContainer();
            var system = container.GetSystem(mock);
            AddDummySystem(container);
            container.Init();
            var entity = container.CreateNewEntity();
            entity.AddComponent(new AComponent());
            entity.AddComponent(new BComponent());
            system.ProcessAll();
            mock.Received().ProcessSingleEntity(
                Arg.Any<int>(),
                ref Arg.Any<AComponent>(),
                ref Arg.Any<BComponent>()
                );
        }
        [TestMethod]
        public void ThreeTypeSystem_FromGet_GetsProcessed()
        {
            var mock = Substitute.For<UnifiedSystem<AComponent, BComponent, CComponent>>();
            var container = new MinEcsContainer();
            var system = container.GetSystem(mock);
            AddDummySystem(container);
            container.Init();
            var entity = container.CreateNewEntity();
            entity.AddComponent(new AComponent());
            entity.AddComponent(new BComponent());
            entity.AddComponent(new CComponent());
            system.ProcessAll();
            mock.Received().ProcessSingleEntity(
                Arg.Any<int>(),
                ref Arg.Any<AComponent>(),
                ref Arg.Any<BComponent>(),
                ref Arg.Any<CComponent>()
                );
        }
        [TestMethod]
        public void FourTypeSystem_FromGet_GetsProcessed()
        {
            var mock = Substitute.For<UnifiedSystem<AComponent, BComponent, CComponent, DComponent>>();
            var container = new MinEcsContainer();
            var system = container.GetSystem(mock);
            AddDummySystem(container);
            container.Init();
            var entity = container.CreateNewEntity();
            entity.AddComponent(new AComponent());
            entity.AddComponent(new BComponent());
            entity.AddComponent(new CComponent());
            entity.AddComponent(new DComponent());
            system.ProcessAll();
            mock.Received().ProcessSingleEntity(
                Arg.Any<int>(),
                ref Arg.Any<AComponent>(),
                ref Arg.Any<BComponent>(),
                ref Arg.Any<CComponent>(),
                ref Arg.Any<DComponent>()
                );
        }
    }
}
