using System;
using System.Collections.Generic;



using FINT.Model.Felles.Kompleksedatatyper;

namespace FINT.Model.Utdanning.Basisklasser
{
	public abstract class Utdanningsforhold {
		public enum Relasjonsnavn
        {
			MEDLEMSKAP
        }
        
	
		public string Beskrivelse { get; set; }
		public Identifikator SystemId { get; set; }
		
	}
}
