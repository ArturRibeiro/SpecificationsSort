public interface ISpecificationSort<T>
{
    IQueryable<T> Apply(IQueryable<T> query, TypeSort typeSort);
}