using System;
using System.Collections.Generic;



using FINT.Model.Felles.Kompleksedatatyper;

namespace FINT.Model.Arkiv.Noark
{
	public class Tilgang {
		public enum Relasjonsnavn
        {
			ROLLE,
			ARKIVRESSURS,
			ADMINISTRATIVENHET,
			ARKIVDEL
        }
        
	
		public Identifikator SystemId { get; set; }
		public string Tittel { get; set; }
		
	}
}
