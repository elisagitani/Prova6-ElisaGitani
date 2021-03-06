using System;
using System.Collections.Generic;
using System.Text;

namespace Prova6_ElisaGitani
{
    class Agente: Persona
    {
        public string AreaGeografica { get; set; }
        public int AnnoDiInizioAttivita { get; set; }
        public int AnniDiServizio { get { return CalcoloAnniDiServizio(); }  }

        public Agente(string nome, string cognome,string codiceFiscale,string areaGeografica, int annoDiInizioAttivita)
            :base(nome, cognome, codiceFiscale)
        {
            AreaGeografica = areaGeografica;
            AnnoDiInizioAttivita = annoDiInizioAttivita;
        }

        public int CalcoloAnniDiServizio()
        {
            return DateTime.Today.Year - AnnoDiInizioAttivita;
        }

        public override string StampaDati()
        {
            return $"{base.StampaDati()} - Anni di servizio: {AnniDiServizio}";
        }
    }
}
