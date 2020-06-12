namespace Common.Cqs
{
    public interface IQueryHandler<IQuery, ReturnType>
    {
        ReturnType Handle(IQuery query);
    }
}
