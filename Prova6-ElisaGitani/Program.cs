using System;

namespace Prova6_ElisaGitani
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("\n-------------------------------------Menù---------------------------------------------");
                Console.WriteLine("1. Visualizzare tutti gli agenti di polizia");
                Console.WriteLine("2. Mostrare gli agenti assegnati ad una determinata area");
                Console.WriteLine("3. Mostrare gli agenti con anni di servizio maggiori o uguali ad una determinata cifra");
                Console.WriteLine("4. Inserire un nuovo agente");
                Console.WriteLine("0. Uscire dall'app");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine();
                int scelta;
                do
                {
                    Console.Write("Fai la tua scelta: ");
                    
                } while (!int.TryParse(Console.ReadLine(),out scelta) && scelta>=0 && scelta<=4);

                switch (scelta)
                {
                    case 1:
                        Console.WriteLine();
                        GestioneAttivita.ReturnListaAgenti();
                        break;
                    case 2:
                        Console.WriteLine();
                        GestioneAttivita.ReturnAgentiInArea();
                        break;
                    case 3:
                        Console.WriteLine();
                        GestioneAttivita.ReturnAgentiConAnniDiServizio();
                        break;
                    case 4:
                        Console.WriteLine();
                        GestioneAttivita.InserisciAgente();
                        break;
                    case 0:
                        return;
                }


            } while (true);
        }
    }
}
