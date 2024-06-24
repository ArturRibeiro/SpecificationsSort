public class VagaService
{
    public List<Vaga> OrdenarVagas(IQueryable<Vaga> queryable, OrdenacaoVaga criterio, TypeSort typeSort)
    {
        ISpecificationSort<Vaga> specification = criterio switch
        {
            OrdenacaoVaga.OrdenarPorDataEntrada => new SortByDataEntradaSpecification(),
            OrdenacaoVaga.OrdenarPorTotalDoDia => new SortByTotalDoDiaSpecification(),
            OrdenacaoVaga.OrdenarPorTotalDoMes => new SortByTotalDoMesSpecification(),
            _ => throw new ArgumentException("Critério de ordenação inválido.")
        };

        return OrdenarVagas(queryable, specification, typeSort);
    }
    
    public List<Vaga> OrdenarVagas(IQueryable<Vaga> queryable, ISpecificationSort<Vaga> specification, TypeSort typeSort) 
        => specification.Apply(queryable, typeSort).ToList();
}