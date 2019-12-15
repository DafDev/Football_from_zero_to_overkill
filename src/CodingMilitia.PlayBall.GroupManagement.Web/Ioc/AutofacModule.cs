using System;
using System.Collections.Generic;
using Autofac;
using CodingMilitia.PlayBall.GroupManagement.Business.Impl.Services;
using CodingMilitia.PlayBall.GroupManagement.Business.Models;
using CodingMilitia.PlayBall.GroupManagement.Business.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<InMemoryGroupService>().Named<IGroupService>("groupService").SingleInstance();
            builder.RegisterDecorator<IGroupService>((context, service) => new GroupServiceDecorator(service),
                "groupService");
        }

        private class GroupServiceDecorator : IGroupService
        {
            private readonly IGroupService _inner;

            public GroupServiceDecorator(IGroupService inner)
            {
                _inner = inner;
            }

            public Group Add(Group group)
            {
                Console.WriteLine($"#################This is from {nameof(Add)}! We're adding a new pokémon to the pokédex!##############");
                return _inner.Add(group);
            }

            public IReadOnlyCollection<Group> GetAll()
            {
                Console.WriteLine($"#################This is from {nameof(GetAll)}! We got'em all!##############");
                return _inner.GetAll();
            }

            public Group GetById(int id)
            {
                Console.WriteLine($"#################This is from {nameof(GetById)}! We got one!##############");
                return _inner.GetById(id);
            }

            public Group Update(Group group)
            {
                Console.WriteLine($"#################This is from {nameof(Update)}! We gotta update this pokémon's infos!##############");
                return _inner.Update(group);
            }
        }
    }
}
