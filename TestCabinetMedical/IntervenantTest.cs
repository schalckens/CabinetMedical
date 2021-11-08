using CabinetMedical.ClassesMetier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCabinetMedical
{
    [TestClass]
    class IntervenantTest
    {
        [TestMethod]
        public void TesteGetNbPrestationsI()
        {
            Intervenant intervenant = new Intervenant("Dupont", "Pierre");
            Cotation cotation1 = new Cotation("3e", "nomenclature 1", 2);
            Cotation cotation2 = new Cotation("3g", "nomenclature 2", 3);
            intervenant.AjoutePrestation(new Prestation("Presta 10", new DateTime(2019, 6, 12), intervenant, cotation1));
            intervenant.AjoutePrestation(new Prestation("Presta 11", new DateTime(2019, 6, 15), intervenant, cotation2));
            Assert.AreEqual(2, intervenant.GetNbPrestations());
        }
        [TestMethod]
        public void TesteGetNbPrestationIE() 
        {
            IntervenantExterne intervenant = new IntervenantExterne("Dupont", "Pierre", "spécialité", "adresse 6 rue adresse", "00 00 00 00 00");
            Cotation cotation1 = new Cotation("3e", "nomenclature 1", 2);
            Cotation cotation2 = new Cotation("3g", "nomenclature 2", 3);
            intervenant.AjoutePrestation(new Prestation("Presta 10", new DateTime(2019, 6, 12), intervenant, cotation1));
            intervenant.AjoutePrestation(new Prestation("Presta 11", new DateTime(2019, 6, 15), intervenant, cotation2));
            Assert.AreEqual(2, intervenant.GetNbPrestations());
        }
    }
}
