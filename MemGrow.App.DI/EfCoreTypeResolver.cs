using Common.Cqs;
using System;

namespace MemGrow.App.DI
{
    public class EfCoreTypeResolver : ITypeResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public EfCoreTypeResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object Resolve(Type type)
        {
            return _serviceProvider.GetService(type);
        }
    }
}
