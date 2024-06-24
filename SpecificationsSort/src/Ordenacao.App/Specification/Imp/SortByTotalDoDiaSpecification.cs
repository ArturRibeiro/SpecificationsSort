using System.Linq.Expressions;

public class SortByTotalDoDiaSpecification : ISpecificationSort<Vaga>
{
    private readonly Expression<Func<Vaga, int>> criterio = v => v.Totalizadores.Sum(t => t.TotalDia);
    public IQueryable<Vaga> Apply(IQueryable<Vaga> query, TypeSort sortOrder) =>
        sortOrder == TypeSort.Ascending
            ? query.OrderBy(criterio)
            : query.OrderByDescending(criterio);
}