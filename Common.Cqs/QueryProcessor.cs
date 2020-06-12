namespace Common.Cqs
{
    public class QueryProcessor
    {
        private readonly ITypeResolver _typeResolver;

        public QueryProcessor(ITypeResolver typeResolver)
        {
            _typeResolver = typeResolver;
        }

        public T Handle<T>(IQuery<T> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(T));
            dynamic handler = _typeResolver.Resolve(handlerType);

            var result = handler.Handle((dynamic)query);

            return result;
        }
    }
}
