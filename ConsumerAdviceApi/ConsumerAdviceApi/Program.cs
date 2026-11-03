// Importa a biblioteca para realizar requisições HTTP
using System.Net.Http;

// Importa a biblioteca para interpretar dados JSON
using System.Text.Json;

// Cria um cliente para realizar requisições HTTP
using HttpClient cliente = new HttpClient();

// Armazena o endereço da API
string enderecoApi = "https://api.adviceslip.com/advice";

// Mostra uma mensagem no console
Console.WriteLine("Iniciando requisição para obter um conselho...");

// Envia uma requisição GET e aguarda a resposta
string resposta = await cliente.GetStringAsync(enderecoApi);

// Converte o texto JSON em uma estrutura que o C# consegue consultar
using JsonDocument documento = JsonDocument.Parse(resposta);

// Acessa o objeto chamado "slip" dentro do JSON
JsonElement slip = documento.RootElement.GetProperty("slip");

// Acessa a propriedade "advice" e obtém seu texto
string? conselho = slip.GetProperty("advice").GetString();

// Exibe o título solicitado pelo professor
Console.WriteLine("\nConselho de Hoje:\n");

// Exibe somente o conselho
Console.WriteLine(conselho);