using System;
using System.Collections.Generic;
using System.Text;

namespace Prova6_ElisaGitani
{
    static class GestioneAttivita
    {
        public static void ReturnListaAgenti()
        {
            List<Agente> agenti = DbManagerAgenti.GetAllAgents();
            foreach(var agente in agenti)
            {
                Console.WriteLine($"{agente.StampaDati()}");
                Console.WriteLine("--------------------------------------------------------------------");   
            }
            Console.WriteLine();
        }
        public static void ReturnAgentiInArea()
        {
            string area = InterazioneConUtente.ReturnArea();
            if (DbManagerAgenti.VerificaEsistenzaAgenteConArea(area))
            {
                List<Agente> agentiInArea = DbManagerAgenti.AgentiInArea(area);
                Console.WriteLine();
                Console.WriteLine($"Agenti presenti in {area}:\n");
                Console.WriteLine("--------------------------------------------------------------------");
                foreach (var agente in agentiInArea)
                {
                    Console.WriteLine(agente.StampaDati());
                    Console.WriteLine("--------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Non sono presenti agenti in {area}");
            }
        }
        public static void ReturnAgentiConAnniDiServizio()
        {
            int anni = InterazioneConUtente.ReturnAnniDiServizio();
            if (DbManagerAgenti.VerificaEsistenzaAgenteConAnniServizio(anni))
            {
                List<Agente> agentiConAnniDiServizio = DbManagerAgenti.AgentiConAnniDiServizio(anni);
                Console.WriteLine();
                Console.WriteLine($"Agenti con anni di servizio maggiori o uguali a {anni} anni:\n");
                Console.WriteLine("--------------------------------------------------------------------");
                foreach (var agente in agentiConAnniDiServizio)
                {
                    Console.WriteLine(agente.StampaDati());
                    Console.WriteLine("--------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Non sono presenti agenti con anni di servizio maggiori o uguali a {anni} anni");
            }
        }
        public static void InserisciAgente()
        {
            InterazioneConUtente.ReturnDatiAnagraficiAgente(out string nome, out string cognome, out string cf);
            if (DbManagerAgenti.VerificaEsistenzaAgentiConCF(cf))
            {
                Console.WriteLine("\nIl codice fiscale indicato è già presente nella lista dei codici fiscali degli agenti");
            }
            else
            {
                InterazioneConUtente.ReturnAltriDatiAgente(out string area, out int annoInizio);
                Agente agente = new Agente(nome, cognome, cf, area, annoInizio);
                DbManagerAgenti.InserisciAgente(agente);
                Console.WriteLine();
                Console.WriteLine("Inserimento avvenuto con successo");
            }
        }
    }
}
