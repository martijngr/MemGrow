namespace Common.Cqs
{
    public class CommandProcessor
    {
        private readonly ITypeResolver _typeResolver;

        public CommandProcessor(ITypeResolver typeResolver)
        {
            _typeResolver = typeResolver;
        }

        public CommandResult Handle(object command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic handler = _typeResolver.Resolve(handlerType);

            return handler.Handle((dynamic)command);
        }
    }
}