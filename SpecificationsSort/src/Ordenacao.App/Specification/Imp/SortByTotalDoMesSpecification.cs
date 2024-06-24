using System.Linq.Expressions;

public class SortByTotalDoMesSpecification : ISpecificationSort<Vaga>
{
    private readonly Expression<Func<Vaga, int>> criterio = v => v.Totalizadores
        .GroupBy(t => new { t.Data.Year, t.Data.Month })
        .Select(g => g.Sum(t => t.TotalDia))
        .FirstOrDefault();
    
    public IQueryable<Vaga> Apply(IQueryable<Vaga> query, TypeSort sortOrder) =>
        sortOrder == TypeSort.Ascending
            ? query.OrderBy(criterio)
            : query.OrderByDescending(criterio);
}