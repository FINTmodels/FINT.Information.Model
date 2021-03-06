using System;
using System.Collections.Generic;
using FINT.Model.Administrasjon.Kompleksedatatyper;
using FINT.Model.Administrasjon.Personal;
using FINT.Model.Felles.Kompleksedatatyper;
using Newtonsoft.Json;
using Xunit;

namespace FINT.Model.Resource.Administrasjon.Tests
{
    public class ModelSerializationTest
    {
        [Fact(DisplayName = "Serialize Fastlonn without Links")]
        public void Serialize_Fastlonn_without_Links()
        {
            var fastlonn = new Fastlonn
            {
                SystemId = new Identifikator {Identifikatorverdi = "ABC123"},
                Attestert = new DateTime(),
                Anvist = new DateTime(),
                Periode = new Periode {Start = new DateTime()},
                Prosent = 10000,
                Beskrivelse = "Test",
                Kontostreng = new Kontostreng()
            };

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new LowercaseContractResolver()
            };
            var json = JsonConvert.SerializeObject(fastlonn, settings);
            Console.WriteLine(json);

            var deserializeObject = JsonConvert.DeserializeObject<Fastlonn>(json);
            Assert.NotNull(deserializeObject);
            Assert.Equal(10000, deserializeObject.Prosent);
        }

        [Fact(DisplayName = "Serialize FastlonnResource with deep links")]
        public void Serialize_FastlonnResource_with_deep_links()
        {
            var kontostreng = new KontostrengResource();
            kontostreng.AddAnsvar(Link.with("/administrasjon/kodeverk/ansvar/systemid/2"));
            kontostreng.AddArt(Link.with("/administrasjon/kodeverk/art/systemid/1"));
            kontostreng.AddFunksjon(Link.with("/administrasjon/kodeverk/funksjon/systemid/3"));

            var fastlonn = new FastlonnResource
            {
                SystemId = new Identifikator {Identifikatorverdi = "ABC123"},
                Attestert = new DateTime(),
                Anvist = new DateTime(),
                Periode = new Periode {Start = new DateTime()},
                Prosent = 10000,
                Beskrivelse = "Test",
                Kontostreng = kontostreng
            };


            fastlonn.AddLonnsart(Link.with("/administrasjon/kodeverk/lonnsart/systemid/4"));
            fastlonn.AddArbeidsforhold(Link.with("/administrasjon/personal/arbeidsforhold/systemid/1234"));

            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new LowercaseContractResolver();
            var json = JsonConvert.SerializeObject(fastlonn, settings);

            Console.WriteLine(json);

            var deserializeObject = JsonConvert.DeserializeObject<FastlonnResource>(json);
            Assert.NotNull(deserializeObject);
            Assert.True(deserializeObject.Links.ContainsKey("arbeidsforhold"));
            Assert.True(deserializeObject.Kontostreng.Links.ContainsKey("art"));
        }

        [Fact(DisplayName = "Serialize FastlonnResource with only own links")]
        public void Serialize_FastlonnResource_with_only_own_links()
        {
            var fastlonn = new FastlonnResource
            {
                SystemId = new Identifikator {Identifikatorverdi = "ABC123"},
                Attestert = new DateTime(),
                Anvist = new DateTime(),
                Periode = new Periode {Start = new DateTime()},
                Prosent = 10000,
                Beskrivelse = "Test",
                Kontostreng = new KontostrengResource()
            };
            fastlonn.AddArbeidsforhold(Link.with(typeof(Arbeidsforhold), "systemid", "1234"));

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new LowercaseContractResolver()
            };
            var json = JsonConvert.SerializeObject(fastlonn, settings);

            Console.WriteLine(json);

            var deserializeObject = JsonConvert.DeserializeObject<FastlonnResource>(json);
            Assert.NotNull(deserializeObject);
            Assert.True(deserializeObject.Links.ContainsKey("arbeidsforhold"));
        }
    }
}