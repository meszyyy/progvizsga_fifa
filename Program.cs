using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FIFAvilagranglista
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 2. feladat
            StreamReader Olvas = new StreamReader("fifa.txt", Encoding.Default);
            List<Valogatott> Ranglista = new List<Valogatott>();
            string Fejlec = Olvas.ReadLine();
            while (!Olvas.EndOfStream)
            {
                Ranglista.Add(new Valogatott(Olvas.ReadLine()));
            }
            Olvas.Close();
            #endregion

            #region 3. feladat
            Console.WriteLine($"3. feladat: A vilagranglistan {Ranglista.Count} csapat szerepel");
            #endregion

            #region 4. feladat
            double OsszPont = 0;
            for (int i = 0; i < Ranglista.Count; i++)
            {
                OsszPont += Ranglista[i].Pontszam;
            }
            Console.WriteLine($"4. feladat: A csapatok atlagos pontszama: {Math.Round((OsszPont/Ranglista.Count),2)} pont");
            #endregion

            #region 5. feladat
            int legnagyobbjavulas = 0;
            for (int i = 0; i < Ranglista.Count; i++)
            {
                if (Ranglista[i].Valtozas > legnagyobbjavulas)
                {
                    legnagyobbjavulas = Ranglista[i].Valtozas;
                }
            }
            Console.WriteLine("5. feladat: A legtöbbet javito csapat:");
            for (int i = 0; i < Ranglista.Count; i++)
            {
                if (Ranglista[i].Valtozas == legnagyobbjavulas)
                {
                    Console.WriteLine($"\tHelyezes: {Ranglista[i].Helyezes}");
                    Console.WriteLine($"\tCsapat: {Ranglista[i].Csapat}");
                    Console.WriteLine($"\tPontszam: {Ranglista[i].Pontszam}");
                }
            }
            #endregion

            #region 6. feladat
            bool SzerepelE = false;
            for (int i=0; i<Ranglista.Count; i++)
            {
                if (Ranglista[i].Csapat == "Magyarország")
                {
                    SzerepelE = true;
                }
            }
            if (SzerepelE == true)
            {
                Console.WriteLine("6. feladat: A csapatok között van Magyarország");
            }
            else
            {
                Console.WriteLine("6. feladat: A csapatok között nincs Magyarország");
            }
            #endregion

            #region 7. feladat
            Console.WriteLine("7. feladat: Statisztika");
            List<int> ValtozasLista = new List<int>();
            for (int i = 0; i < Ranglista.Count; i++)
            {
                bool SzerepeltE = false;
                for (int j = 0; j < ValtozasLista.Count; j++)
                {
                    if (Ranglista[i].Valtozas == ValtozasLista[j])
                    {
                        SzerepeltE = true;
                    }
                }
                if (SzerepeltE == false)
                {
                    ValtozasLista.Add(Ranglista[i].Valtozas);
                }
            }
            int[] ValtozasListaSeged = new int[ValtozasLista.Count];
            for (int i = 0; i < Ranglista.Count; i++)
            {
                for (int j = 0; j < ValtozasLista.Count; j++)
                {
                    if (Ranglista[i].Valtozas == ValtozasLista[j])
                    {
                        ValtozasListaSeged[j]++;
                    }
                }
            }
            for (int i = 0; i < ValtozasLista.Count; i++)
            {
                if (ValtozasListaSeged[i] > 1)
                {
                    Console.WriteLine($"\t{ValtozasLista[i]} helyet valtozott: {ValtozasListaSeged[i]} csapat");
                }
            }
            #endregion
            Console.ReadKey();
        }
    }
    class Valogatott
    {
        public string Csapat;
        public int Helyezes;
        public int Valtozas;
        public int Pontszam;

        public Valogatott(string AdatSor)
        {
            string[] AdatsorElemek = AdatSor.Split(';');
            this.Csapat = AdatsorElemek[0];
            this.Helyezes = Convert.ToInt32(AdatsorElemek[1]);
            this.Valtozas = Convert.ToInt32(AdatsorElemek[2]);
            this.Pontszam = Convert.ToInt32(AdatsorElemek[3]);

        }
    }
}
