using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace _03_TaskMult
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> lista = new List<Task>();
            //lista.Add(Task.Factory.StartNew(Metodo01));
            //lista.Add(Task.Factory.StartNew(Metodo01));
            //lista.Add(Task.Factory.StartNew(Metodo01));
            //lista.Add(Task.Factory.StartNew(Metodo01));

            //Task.WaitAll(lista.ToArray()); //Epera todas as tarfeas da lista finalizar e continua
            //Task.WaitAny(lista.ToArray()); //Espera pelo menos uma tarefa finalizar e continua
            //Task.WhenAll(lista.ToArray()); //Não Espera nenhama tarefa finalizar e continua

            WebClient web = new WebClient();
            string[] enderecos = new string[] { "http://www.google.com.br", "http://www.microsoft.com.br", "http://www.globo.com" };

            var listEnd = (from end in enderecos select DownloadPagina(end));
            Task.WaitAll(listEnd.ToArray());
            Console.WriteLine("Finalizado");
            Console.ReadKey();
        }
        static void Metodo01()
        {
            for (var i = 0; i < 1000; i++)
            {
                Console.WriteLine("Valor: " + i + " TaskId - " + Task.CurrentId);
            }
        }

        static async Task DownloadPagina(string end)
        {
            WebClient web = new WebClient();
            string html = await web.DownloadStringTaskAsync(end);
            Console.WriteLine("Download Pagina: " + end);
        }
    }
}
