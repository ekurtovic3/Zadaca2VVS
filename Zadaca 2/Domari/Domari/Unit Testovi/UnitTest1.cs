using Domari;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Zadatak1Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPromjenaInformacijaOSkolovanju()
        {
            LicniPodaci data = new LicniPodaci();
            Skolovanje school = new Skolovanje();
            Student s = new Student("Emir", "password123", data, null, school);
            s.PromjenaInformacijaOSkolovanju("Elektrotehnički fakultet", 3, 1);
            Assert.AreEqual(3, s.Skolovanje.GodinaStudija);                     //Emir Kurtovic
            s.PromjenaInformacijaOSkolovanju("ETF", 2, 1);
            Assert.AreEqual(2,s.Skolovanje.GodinaStudija);
          

        }

        [TestMethod]
        public void TestKorisnik()               //Medina Sirco
        {
            Korisnik student = new Student();
            student.Username = "Username";                         
            student.Password = "Pass123";
            Assert.AreEqual("Username", student.Username);

        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestUsername()               //Medina Sirco
        {
            Korisnik student = new Student();           
            student.Username = "";
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestPassword()           //Medina Sirco
        {
            Korisnik student = new Student();
            student.Password = "pass";
        }


        [TestMethod]
        public void TestPromjenaSobe() //Muamer Bandic
        {
            var dom = new Domari.StudentskiDom(15);
            var soba = dom.Sobe[0];

            var kapacitet = soba.Kapacitet;


            Student s1 = new Student();
            s1.Skolovanje = new Skolovanje();
            s1.Skolovanje.MaticniFakultet = "ETF";

            Student s2 = new Student();
            s2.Skolovanje = new Skolovanje();
            s2.Skolovanje.MaticniFakultet = "ETF";

            dom.UpisUDom(s1, kapacitet, true);
            dom.UpisUDom(s2, kapacitet, true);

            dom.PromjenaSobe(soba, kapacitet);

            Assert.IsTrue(dom.Sobe[0].Stanari.Count == 0);

        }


    }
}
