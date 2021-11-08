using CabinetMedical.ClassesMetier;
using CabinetMedical.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCabinetMedical
{
    [TestClass]
    class PrestationTest
    {
        [TestMethod]
        public void TesteDatePrestationSuperieurOK()
        {
            Intervenant intervenant1 = new Intervenant("Dupont", "Jean");
            Cotation cotation = new Cotation("3e", "nomenclature 1", 3);
            Prestation prestation1 = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant1, cotation);
            Dossier dossier = new Dossier("Robert", "Jean", new DateTime(1989, 12, 3), new DateTime(2013, 09, 15), prestation1);
            Assert.IsInstanceOfType(dossier, typeof(Dossier));
        }

        [TestMethod]
        [ExpectedException(typeof(CabinetMedicalException))]
        public void TesteDatePrestationKO()
        {
            DateTime dateCreationDossier = DateTime.Now.AddDays(10);
            Intervenant intervenant1 = new Intervenant("Dupont", "Jean");
            Cotation cotation = new Cotation("3e", "nomenclature 1", 3);
            Prestation prestation1 = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant1, cotation);
            Dossier dossier = new Dossier("Robert", "Jean", new DateTime(1989, 12, 3), dateCreationDossier, prestation1);
        }

        [TestMethod]
        public void TestCompareToDateAnterieureALaDeuxiemeDate()
        {

            Cotation cotation1 = new Cotation("3e", "nomenclature 1", 2);
            Cotation cotation2 = new Cotation("3b", "nomenclature 1", 3);
            Prestation prestation1 = new Prestation("P1", new DateTime(2021, 09, 10, 12, 0, 0), new Intervenant("Dupont", "Jean"), cotation1);
            Prestation prestation2 = new Prestation("P2", new DateTime(2021, 09, 15, 12, 0, 0), new Intervenant("Dumont", "Hubert"), cotation2);
            Assert.AreEqual(-1, Prestation.CompareTo(prestation1, prestation2));
        }

        [TestMethod]
        public void TestCompareToDateEgaleALaDeuxiemeDate()
        {

            Cotation cotation1 = new Cotation("3e", "nomenclature 1", 2);
            Cotation cotation2 = new Cotation("3b", "nomenclature 1", 3);
            Prestation prestation1 = new Prestation("P1", new DateTime(2021, 09, 10, 12, 0, 0), new Intervenant("Dupont", "Jean"), cotation1);
            Prestation prestation2 = new Prestation("P2", new DateTime(2021, 09, 10, 14, 0, 0), new Intervenant("Dumont", "Hubert"), cotation2);
            Assert.AreEqual(0, Prestation.CompareTo(prestation1, prestation2));
        }

        [TestMethod]
        public void TestCompareToDatePosterieureALaDeuxiemeDate()
        {
            Cotation cotation1 = new Cotation("3e", "nomenclature 1", 2);
            Cotation cotation2 = new Cotation("3b", "nomenclature 1", 3);
            Prestation prestation1 = new Prestation("P1", new DateTime(2021, 09, 20, 12, 0, 0), new Intervenant("Dupont", "Jean"), cotation1);
            Prestation prestation2 = new Prestation("P2", new DateTime(2021, 09, 15, 12, 0, 0), new Intervenant("Dumont", "Hubert"), cotation2);
            Assert.AreEqual(1, Prestation.CompareTo(prestation1, prestation2));
        }
    }
}
