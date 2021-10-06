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
            intervenant.AjoutePrestation(new Prestation("Presta 10", new DateTime(2019, 6, 12), intervenant));
            intervenant.AjoutePrestation(new Prestation("Presta 11", new DateTime(2019, 6, 15), intervenant));
            Assert.AreEqual(2, intervenant.GetNbPrestations());
        }
        [TestMethod]
        public void TesteGetNbPrestationIE() 
        {
            IntervenantExterne intervenant = new IntervenantExterne("Dupont", "Pierre", "spécialité", "adresse 6 rue adresse", "00 00 00 00 00");
            intervenant.AjoutePrestation(new Prestation("Presta 10", new DateTime(2019, 6, 12), intervenant));
            intervenant.AjoutePrestation(new Prestation("Presta 11", new DateTime(2019, 6, 15), intervenant));
            Assert.AreEqual(2, intervenant.GetNbPrestations());
        }
    }
}
