using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabinetMedical.ClassesMetier;
using CabinetMedical.Exceptions;

namespace TestCabinetMedical
{
    
    [TestClass]
    public class DossierTest
    {
        [TestMethod]
        public void TestDateCreationDossierOK()
        {
            
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2019, 3, 31));
            Assert.IsInstanceOfType(dossier, typeof(Dossier));
            //Assert.IsTrue(DateTime.Compare(dossier.DateCreation.Date, DateTime.Now.Date) <= 0);
        }

        [TestMethod]
        [ExpectedException(typeof(CabinetMedicalException))]
        public void TestDateCreationDossierKO()
        {
            DateTime dateCreationDossier = DateTime.Now.AddDays(10);
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(2019, 3, 31), dateCreationDossier);
        }

        [TestMethod]
        public void TesteDatePrestationSuperieurOK() 
        {
            Intervenant intervenant1 = new Intervenant("Dupont", "Jean");
            Prestation prestation1 = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant1);
            Dossier dossier = new Dossier("Robert", "Jean", new DateTime(1989, 12, 3), new DateTime(2013, 09, 15), prestation1);
            Assert.IsInstanceOfType(dossier, typeof(Dossier));
        }

        [TestMethod]
        [ExpectedException(typeof(CabinetMedicalException))]
        public void TesteDatePrestationKO() 
        {
            DateTime dateCreationDossier = DateTime.Now.AddDays(10);
            Intervenant intervenant1 = new Intervenant("Dupont", "Jean");
            Prestation prestation1 = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant1);
            Dossier dossier = new Dossier("Robert", "Jean", new DateTime(1989, 12, 3), dateCreationDossier, prestation1);
        }

        [TestMethod]
        public void TesteGetNbPrestationExt() 
        {
            List<Prestation> listePresta = new List<Prestation>();
            Intervenant intervenant1 = new Intervenant("Dupont", "Jean");
            Prestation prestation1 = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant1);
            IntervenantExterne intervenant2 = new IntervenantExterne("Duponti", "Jean-Claude", "Spécialité", "Rue 365 Addresse", "00.00.00.00.00");
            Prestation prestation2 = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant1);
            listePresta.Add(prestation1);
            listePresta.Add(prestation2);
            Dossier dossier = new Dossier("Ducati", "Julio", new DateTime(1990, 11, 12), listePresta);
            Assert.AreEqual(1, dossier.GetNbPrestationsExternes());
        }

        [TestMethod]
        public void TesteNbJoursSoins() 
        {
            List<Prestation> listePresta = new List<Prestation>();
            Intervenant intervenant1 = new Intervenant("Dupont", "Jean");
            Prestation prestation1 = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant1);
            IntervenantExterne intervenant2 = new IntervenantExterne("Duponti", "Jean-Claude", "Spécialité", "Rue 365 Addresse", "00.00.00.00.00");
            Prestation prestation2 = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant1);
            listePresta.Add(prestation1);
            listePresta.Add(prestation2);
            Dossier dossier = new Dossier("Ducati", "Julio", new DateTime(1990, 11, 12), listePresta);
            Assert.AreEqual(2, dossier.GetNbJoursSoinsV1());
        }

        [TestMethod]
        public void TesteNbJoursSoinsV2() 
        {
            List<Prestation> listePresta = new List<Prestation>();
            Intervenant intervenant1 = new Intervenant("Dupont", "Jean");
            Prestation prestation1 = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant1);
            IntervenantExterne intervenant2 = new IntervenantExterne("Duponti", "Jean-Claude", "Spécialité", "Rue 365 Addresse", "00.00.00.00.00");
            Prestation prestation2 = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant1);
            listePresta.Add(prestation1);
            listePresta.Add(prestation2);
            Dossier dossier = new Dossier("Ducati", "Julio", new DateTime(1990, 11, 12), listePresta);
            Assert.AreEqual(2, dossier.GetNbJoursSoinsV2());
        }

        [TestMethod]
        public void TesteNbJoursSoinsV3() 
        {
            List<Prestation> listePresta = new List<Prestation>();
            Intervenant intervenant1 = new Intervenant("Dupont", "Jean");
            Prestation prestation1 = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant1);
            IntervenantExterne intervenant2 = new IntervenantExterne("Duponti", "Jean-Claude", "Spécialité", "Rue 365 Addresse", "00.00.00.00.00");
            Prestation prestation2 = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant1);
            listePresta.Add(prestation1);
            listePresta.Add(prestation2);
            Dossier dossier = new Dossier("Ducati", "Julio", new DateTime(1990, 11, 12), listePresta);
            Assert.AreEqual(2, dossier.GetNbJoursSoinsV3());
        }
    }
}
