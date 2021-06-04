using System;
using System.Collections.Generic;
using System.Text;

namespace Prova6_ElisaGitani
{
    static class InterazioneConUtente
    {
        public static string ReturnArea()
        {
            Console.Write("Inserisci area geografica: ");
            string area = Console.ReadLine();
            return area;
        }

        public static int ReturnAnniDiServizio()
        {
            int anni;
            do
            {
                Console.Write("Inserisci gli anni di servizio: ");

            } while (!int.TryParse(Console.ReadLine(), out anni)&& anni>=0);

            return anni;
        }

        public static void ReturnDatiAnagraficiAgente(out string nome, out string cognome, out string cf)
        {
            Console.Write("Inserisci il nome dell'agente: ");
            nome = Console.ReadLine();
            Console.Write("Inserisci il cognome dell'agente: ");
            cognome = Console.ReadLine();
            do
            {
                Console.Write("Inserisci il codice fiscale dell'agente: ");
                cf = Console.ReadLine();
            } while (cf.Length != 16);        

        }

        public static void ReturnAltriDatiAgente(out string area,out int annoInizio)
        {
            Console.Write("Inserisci area: ");
            area = Console.ReadLine();
            do
            {
                Console.Write("Inserisci l'anno di inizio attività: ");

            } while ((!int.TryParse(Console.ReadLine(), out annoInizio)) || annoInizio>2021);
        }
    }
}
