using System;

namespace Common.Cqs
{
    public interface ITypeResolver
    {
        object Resolve(Type type);
    }
}
