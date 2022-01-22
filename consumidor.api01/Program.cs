// See https://aka.ms/new-console-template for more information
using consumidor.api01;
using Flurl;
using Flurl.Http;

Console.WriteLine("Hello, World!");

string url = "https://localhost:7035/";

#region "Objetos"
Item tarefa1 = new Item();
tarefa1.Id = 1;
tarefa1.Nome = "Pagar a conta";
tarefa1.Finalizado = true;

Item tarefa2 = new Item();
tarefa2.Id = 3;
tarefa2.Nome = "Lavar louças xxx";
tarefa2.Finalizado = false;
#endregion 

//gerar um tarefa
string endpoint = url + "api/TarefaItems";

#region "POST e Listar"
Console.WriteLine("Vamos incluir");

//flurl => POST (incluir) 
await endpoint.PostJsonAsync(tarefa1);
await endpoint.PostJsonAsync(tarefa2);

//ler a lista
IEnumerable<Item> listaTarefas = await endpoint.GetJsonAsync<IEnumerable<Item>>();
foreach (var item in listaTarefas)
{
    Console.WriteLine($"A tarefa: {item.Nome} está {item.Finalizado}");
}

#endregion

#region "Alterar e Listar"
Console.WriteLine("Vamos alterar, digite um ID");

//alterar
int id = Convert.ToInt32(Console.ReadLine());
string endpoint_alterar = url + $"api/TarefaItems/{id}";

Item tarefa3 = new Item();
tarefa3.Id = 1;
tarefa3.Nome = "Receber salário";
tarefa3.Finalizado = false;

await endpoint_alterar.PutJsonAsync(tarefa3);

//ler a lista
listaTarefas = await endpoint.GetJsonAsync<IEnumerable<Item>>();
foreach (var item in listaTarefas)
{
    Console.WriteLine($"A tarefa: {item.Nome} está {item.Finalizado}");
}

#endregion

Console.WriteLine("Vamos deletar");
//deletar um item da lista
string endpoint_deletar = url + $"api/TarefaItems/3";
await endpoint_deletar.DeleteAsync();

//ler a lista
listaTarefas = await endpoint.GetJsonAsync<IEnumerable<Item>>();

foreach (var item in listaTarefas)
{
    Console.WriteLine($"A tarefa: {item.Nome} está {item.Finalizado}");
}

Console.WriteLine("Aperta Qualquer tecla para finalizar a aplicação");
Console.Read();