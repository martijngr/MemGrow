using System;

namespace Common.Cqs
{
    public interface ICommandHandler<T>
    {
        CommandResult Handle(T command);
    }
}
