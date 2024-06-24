using System.Linq.Expressions;

public class SortByDataEntradaSpecification : ISpecificationSort<Vaga>
{
    private readonly Expression<Func<Vaga, DateTime>> criterio = v => v.Totalizadores.Min(t => t.Data);
    
    public IQueryable<Vaga> Apply(IQueryable<Vaga> query, TypeSort sortOrder) =>
        sortOrder == TypeSort.Ascending
            ? query.OrderBy(criterio)
            : query.OrderByDescending(criterio);
}