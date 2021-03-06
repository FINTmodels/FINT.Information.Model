using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FINT.Model.Resource;

using FINT.Model.Utdanning.Basisklasser;

namespace FINT.Model.Utdanning.Timeplan
{

    public class UndervisningsgruppeResource : GruppeResource 
    {

    
            

        public void AddElevforhold(Link link)
        {
            AddLink("elevforhold", link);
        }

        public void AddFag(Link link)
        {
            AddLink("fag", link);
        }

        public void AddTermin(Link link)
        {
            AddLink("termin", link);
        }

        public void AddSkole(Link link)
        {
            AddLink("skole", link);
        }

        public void AddSkolear(Link link)
        {
            AddLink("skolear", link);
        }

        public void AddUndervisningsforhold(Link link)
        {
            AddLink("undervisningsforhold", link);
        }

        public void AddTime(Link link)
        {
            AddLink("time", link);
        }

        public void AddGruppemedlemskap(Link link)
        {
            AddLink("gruppemedlemskap", link);
        }
    }
}
