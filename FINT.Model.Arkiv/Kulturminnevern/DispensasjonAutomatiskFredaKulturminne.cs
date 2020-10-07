using System;
using System.Collections.Generic;



using FINT.Model.Felles.Kompleksedatatyper;
using FINT.Model.Arkiv.Noark;

namespace FINT.Model.Arkiv.Kulturminnevern
{
	public class DispensasjonAutomatiskFredaKulturminne : Saksmappe {
		public enum Relasjonsnavn
        {
			SAKSSTATUS,
			JOURNALENHET,
			ADMINISTRATIVENHET,
			SAKSANSVARLIG,
			ARKIVDEL,
			AVSLUTTETAV,
			OPPRETTETAV
        }
        
	
		public string KulturminneId { get; set; }
		public Matrikkelnummer Matrikkelnummer { get; set; }
		public Identifikator Soknadsnummer { get; set; }
		
	}
}
