// See https://aka.ms/new-console-template for more information

var vagas = VagaFaker.GenerateVagas();

var vagaService = new VagaService();

Console.WriteLine("Ordenação por Data de Entrada (Ascendente):");
var sortedPorDataEntradaAsc = vagaService.OrdenarVagas(vagas, OrdenacaoVaga.OrdenarPorDataEntrada, TypeSort.Ascending);
ImprimirVagas(sortedPorDataEntradaAsc);

Console.WriteLine("Ordenação por Total do Dia (Descendente):");
var sortedPorTotalDiaDesc = vagaService.OrdenarVagas(vagas, OrdenacaoVaga.OrdenarPorTotalDoDia, TypeSort.Descending);
ImprimirVagas(sortedPorTotalDiaDesc);

Console.WriteLine("Ordenação por Total do Mês (Ascendente):");
var sortedPorTotalMesAsc = vagaService.OrdenarVagas(vagas, OrdenacaoVaga.OrdenarPorTotalDoMes, TypeSort.Ascending);
ImprimirVagas(sortedPorTotalMesAsc);

return;

static void ImprimirVagas(List<Vaga> vagas)
{
    foreach (var vaga in vagas)
    {
        var totalizador = vaga.Totalizadores.First();
        Console.WriteLine($"Data: {totalizador.Data}, Total do Dia: {totalizador.TotalDia}");
    }
}