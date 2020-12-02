using Domari;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Testovi
{
    [TestClass]
    public class NoviTestovi
    {
        #region Zamjenski Objekti

        [TestMethod]
        public void TestZamjenskiObjekat()
        {
            StudentskiDom dom = new StudentskiDom(15);

            Student s = new Student();
            s.Skolovanje = new Skolovanje();
            s.Skolovanje.MaticniFakultet = "ETF";

            dom.RadSaStudentom(s, 0);

            IPodaci paviljon = new Paviljon();

            List<Student> studenti = dom.DajStudenteIzPaviljona(paviljon);

            Assert.IsTrue(studenti.Find(student => student.IdentifikacioniBroj == s.IdentifikacioniBroj) != null);
        }

        #endregion

        #region TDD

        [TestMethod]
        public void TestPromjenaGodineStudija()        //Medina Sirco
        {
            Skolovanje s = new Skolovanje();

            double skolarina = s.PromjenaGodineStudija(1, 1);

            Assert.AreEqual(1800, skolarina);
        }

        [TestMethod]
        public void TestPromjenaGodineStudija2()         //Muamer Bandic
        {
            Skolovanje s = new Skolovanje();

            double skolarina = s.PromjenaGodineStudija(2, 2);

            Assert.AreEqual(2000, skolarina);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPromjenaGodineStudija3()       //Emir Kurtovic
        {
            Skolovanje s = new Skolovanje();

            double skolarina = s.PromjenaGodineStudija(7, 0);
        }

        [TestMethod]
        public void TestSoba()      //Emir Kurtovic
        {
            Soba s = new Soba(1, 5);
            Assert.AreEqual(5, s.Kapacitet);
            Assert.AreEqual(1, s.BrojSobe);
            //s.BrojSobe=2;
            s.Kapacitet = 2;
            Assert.AreEqual(2, s.Kapacitet);
            LicniPodaci data = new LicniPodaci();
            Skolovanje school = new Skolovanje();
            Student student = new Student("Emir", "password123", data, null, school);
            Assert.AreEqual(0, s.Stanari.Count); //Inisijalno nema stanara
            s.DodajStanara(student);
            Assert.AreEqual(1, s.Stanari.Count); //Stanar ispravno dodan

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDodajStanara()       //Emir Kurtovic
        {
            Soba s = new Soba(1, 1);
            Student student1 = new Student();
            Student student2 = new Student();
            s.DodajStanara(student1);
            s.DodajStanara(student2);

        }
        [TestMethod]
        public void TestIsprazniSobu()      // Emir Kurtovic
        {
            Soba s = new Soba(1, 1);
            Student student1 = new Student();

            s.DodajStanara(student1);
            Assert.AreNotEqual(0, s.Stanari.Count);
            s.IsprazniSobu();
            Assert.AreEqual(0, s.Stanari.Count);

        }

        [TestMethod]
        public void TestIzbaciStudenta()     // Emir Kurtovic
        {
            Soba s = new Soba(1, 1);
            Student student1 = new Student();
            s.DodajStanara(student1);
            Assert.AreNotEqual(0, s.Stanari.Count);
            s.IzbaciStudenta(student1);
            Assert.AreEqual(0, s.Stanari.Count);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIzbaciStudenta2()   // Emir Kurtovic
        {
            Soba s = new Soba(1, 1);
            Student student1 = new Student();
            LicniPodaci data = new LicniPodaci();
            Skolovanje school = new Skolovanje();
            Student student = new Student("Emir", "password123", data, null, school);
            s.DodajStanara(student1);

            s.IzbaciStudenta(student);


        }
        [TestMethod]
        public void TestDaLiJeStanar()  // Emir Kurtovic
        {
            Soba s = new Soba(1, 1);

            LicniPodaci data = new LicniPodaci();
            Skolovanje school = new Skolovanje();
            Student student = new Student("Student", "Password654", data, null, school);
            s.DodajStanara(student);

            Assert.IsTrue(s.DaLiJeStanar(student));


        }
        [TestMethod]
        public void TestPromjenaBrojaSobe()  //Emir Kurtovic
        {
            Soba s = new Soba(115, 2);
            s.PromjenaBrojaSobe(200);
            Assert.AreEqual(s.BrojSobe, 200);//provjera je li se broj dobro postavi
        }
        [TestMethod]
        public void TestPromjenaBrojaSobe2()   //Emir Kurtovic
        {
            Soba s = new Soba(100, 2);
            s.PromjenaBrojaSobe(200);
            Assert.AreEqual(s.Kapacitet, 3);//provjera je li se kapacitet promijeni
            s.PromjenaBrojaSobe(300);
            Assert.AreEqual(s.Kapacitet, 4);
            s.PromjenaBrojaSobe(150);
            Assert.AreEqual(s.Kapacitet, 2);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPromjenaBrojaSobe3()    //Emir Kurtovic
        {
            Soba s = new Soba(1, 3);
            Student student2 = new Student();
            Student student3 = new Student();
            LicniPodaci data = new LicniPodaci();
            Skolovanje school = new Skolovanje();
            Student student = new Student("Student", "Password654", data, null, school);
            Skolovanje skol = new Skolovanje();
            Assert.IsNotNull(skol.BrojIndeksa);
            s.DodajStanara(student);
            s.DodajStanara(student2);
            s.DodajStanara(student3);
            Assert.AreEqual(3, s.Stanari.Count);
            s.PromjenaBrojaSobe(101);
            Assert.AreEqual(2, s.Stanari.Count);
            s.PromjenaBrojaSobe(505);
        }


        [TestMethod]
        public void TestPRebivaliste()  //Emir Kurtovic
        {
            Soba s = new Soba(1, 5);
            Assert.AreEqual(5, s.Kapacitet);
            Assert.AreEqual(1, s.BrojSobe);
            //s.BrojSobe=2;
            s.Kapacitet = 2;
            Assert.AreEqual(2, s.Kapacitet);
            LicniPodaci data = new LicniPodaci();
            Skolovanje school = new Skolovanje();
            List<string> prebivaliste = new List<string>();
            prebivaliste.Add("Zmaj od Bosne bb");

            Student student = new Student("Emir", "password123", data, prebivaliste, school);
            Assert.AreEqual(1000, student.StanjeRacuna);
            Assert.IsNotNull(student.Podaci);
            Assert.AreEqual("Zmaj od Bosne bb", student.Prebivaliste[0]);
        }

        [TestMethod]
        public void TestStanjeRacuna() //Medina Sirco
        {
            Soba s = new Soba(1, 5);
            Assert.AreEqual(5, s.Kapacitet);
            Assert.AreEqual(1, s.BrojSobe);
            //s.BrojSobe=2;
            s.Kapacitet = 2;
            Assert.AreEqual(2, s.Kapacitet);
            LicniPodaci data = new LicniPodaci();
            Skolovanje school = new Skolovanje();
            Student student = new Student("Imee", "password123", data, null, school);
            Assert.AreEqual(1000, student.StanjeRacuna);

        }
        [TestMethod]
        public void TestAzurirajStanjeRacuna()   //Medina Sirco
        {

            Student student = new Student("Imee", "password123", null, null, null);
            Assert.AreEqual(1000, student.StanjeRacuna);
            student.AzurirajStanjeRacuna(-50);
            Assert.AreEqual(950, student.StanjeRacuna);

        }


        [TestMethod]
        public void TestDajPaviljon()   //Muamer Bandic
        {
            Paviljon paviljon = new Paviljon();
            Assert.IsNotNull(paviljon.DajImePaviljona());
            Assert.AreEqual("ETF", paviljon.DajImePaviljona());

        }
        #endregion
    
       
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestPromjenaPassworda2()  //Muamer Bandic
        {
            Korisnik student = new Student();
            student.Password = "Pass123";
            student.Username = "user";
            student.PromjenaPassworda("Pass123", " ");


        }


        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestPromjenaPassworda3()  //Muamer Bandic
        {
            Korisnik student = new Student();
            student.Password = "Pass123";
            student.Username = "user";
            student.PromjenaPassworda("pogresan", "Pass123");

        }

        //Licni podaci
        [TestMethod]
       public void TestLicniPodaci()        //Medina Sirco
        {
            DateTime dt = new DateTime(1992, 12, 12);
            LicniPodaci lp = new LicniPodaci("Niko", "Nikic", "Sarajevo", "niko-email", "moja-slika", "1211232992789", Spol.Muško, dt);
            Assert.AreEqual(lp.Ime, "Niko");
            Assert.AreEqual(lp.Prezime, "Nikic");
            Assert.AreEqual(lp.MjestoRodjenja, "Sarajevo");
            Assert.AreEqual(lp.Email, "niko-email");
            Assert.AreEqual(lp.Slika, "moja-slika");
            Assert.AreEqual(lp.JMBG, "1211232992789");
            Assert.AreEqual(lp.Spol, Spol.Muško);
            Assert.AreEqual(lp.DatumRodjenja, dt);

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Ime nije ispravno!")]
        public void TestLicniPodaci1()           //Medina Sirco
        {
            DateTime dt = new DateTime(1992, 12, 12);
            LicniPodaci licni = new LicniPodaci(" ", "Nikic", "Sarajevo", "niko-email", "moja-slika", "1212992789112", Spol.Muško, dt);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Prezime nije ispravno!")]
        public void TestLicniPodaci2()               //Medina Sirco
        {
            DateTime dt = new DateTime(1992, 12, 12);
            LicniPodaci licni = new LicniPodaci("Niko", " ", "Sarajevo", "niko-email", "moja-slika", "1212992789112", Spol.Muško, dt);
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException), "Mjesto rođenja je prazno!")]
        public void TestLicniPodaci3()  //Medina Sirco
        {
            DateTime dt = new DateTime(1992, 12, 12);
            LicniPodaci licni = new LicniPodaci("Niko", "Nikic", " ", "niko-email", "moja-slika", "1212992789112", Spol.Muško, dt);
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException), "Polje email je prazno!")]
        public void TestLicniPodaci4()  //Medina Sirco
        {
            DateTime dt = new DateTime(1992, 12, 12);
            LicniPodaci licni = new LicniPodaci("Niko", "Nikic", "Sarajevo", " ", "moja-slika", "1212992789112", Spol.Muško, dt);
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException), "Neispravan format matičnog broja!")]
        public void TestLicniPodaci5()  //Medina Sirco
        {
            DateTime dt = new DateTime(1992, 12, 12);
            LicniPodaci licni = new LicniPodaci("Niko", "Nikic", "Sarajevo", "niko-email", "moja-slika", "12h", Spol.Muško, dt);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Neispravan datum!")]
        public void TestLicniPodaci6()  //Medina Sirco
        {
            DateTime dt = new DateTime(2050, 12, 12);
            LicniPodaci licni = new LicniPodaci("Niko", "Nikic", "Sarajevo", "niko-email", "moja-slika", "1212992789112", Spol.Muško, dt);
        }

        [TestMethod]
        public void TestRadSaStudentom() //Muamer Bandic
        {
            var dom = new StudentskiDom(15);

            Student s1 = new Student();
            s1.Skolovanje = new Skolovanje();
            s1.Skolovanje.MaticniFakultet = "ETF";

            dom.RadSaStudentom(s1, 0);

            Assert.IsTrue(dom.Studenti.Count == 1);
        }


        [TestMethod]
        public void TestRadSaStudentom2() //Muamer Bandic
        {
            var dom = new StudentskiDom(15);
            var soba = dom.Sobe[0];

            var kapacitet = soba.Kapacitet;

            Student s1 = new Student();
            s1.Skolovanje = new Skolovanje();
            s1.Skolovanje.MaticniFakultet = "ETF";

            dom.UpisUDom(s1, kapacitet, true);
            dom.RadSaStudentom(s1, 1);

            Assert.IsTrue(soba.Stanari.Count == 0);
        }

        [TestMethod]
        public void TestRadSaStudentom3() //Muamer Bandic
        {
            var dom = new StudentskiDom(15);
            var soba = dom.Sobe[0];

            Student s1 = new Student();
            s1.Skolovanje = new Skolovanje();
            s1.Skolovanje.MaticniFakultet = "ETF";


            dom.RadSaStudentom(s1, 0);
            dom.RadSaStudentom(s1, 2);

            Assert.IsTrue(dom.Studenti.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException), "Nemoguće dodati postojećeg studenta!")]
        public void TestRadSaStudentom4() //Muamer Bandic
        {
            var dom = new StudentskiDom(15);

            Student s1 = new Student();
            s1.Skolovanje = new Skolovanje();
            s1.Skolovanje.MaticniFakultet = "ETF";

            dom.RadSaStudentom(s1, 0);
            dom.RadSaStudentom(s1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Student nije stanar nijedne sobe!")]
        public void TestRadSaStudentom5() //Muamer Bandic
        {
            var dom = new StudentskiDom(15);

            Student s1 = new Student();
            s1.Skolovanje = new Skolovanje();
            s1.Skolovanje.MaticniFakultet = "ETF";

            dom.RadSaStudentom(s1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException), "Student nije prijavljen u dom!")]
        public void TestRadSaStudentom6() //Muamer Bandic
        {
            var dom = new StudentskiDom(15);

            Student s1 = new Student();
            s1.Skolovanje = new Skolovanje();
            s1.Skolovanje.MaticniFakultet = "ETF";

            dom.RadSaStudentom(s1, 2);
        }

    

        [TestMethod]
        public void TestUpisUDom() //Emir Kurtovic
        {
            StudentskiDom dom = new StudentskiDom(2);
            Student student1 = new Student();
            Student student2 = new Student();


            dom.UpisUDom(student1, 3, true);
            dom.UpisUDom(student2, 3, true);
            Assert.AreEqual(2, dom.Sobe[0].Stanari.Count);
            // Assert.IsTrue(dom.Sobe[0].Stanari.Count == 1);

        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestUpisUDom2() //Muamer Bandic
        {
            StudentskiDom dom = new StudentskiDom(0);
            Student student1 = new Student();
            Student student2 = new Student();


            dom.UpisUDom(student1, 4, true);
            dom.UpisUDom(student2, 4, true);
        

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestUpisUDom3() //Muamer Bandic
        {
            StudentskiDom dom = new StudentskiDom(0);
            Student student1 = new Student();
            Student student2 = new Student();


            dom.UpisUDom(student1, 4, false);
            dom.UpisUDom(student2, 4, false);
           

        }
      
    }
}
