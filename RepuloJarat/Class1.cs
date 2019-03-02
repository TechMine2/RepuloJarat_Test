﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepuloJarat
{
    public class JaratKezelo
    {
        List<Jarat> jaratok = new List<Jarat>();

        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            foreach (var item in this.jaratok)
            {
                if (item.Jaratszam == jaratSzam)
                {
                    ArgumentException e = new ArgumentException("Egyező járat" + jaratSzam);
                    throw e;
                }
            }
            Jarat jarat = new Jarat();
            jarat.Jaratszam = jaratSzam;
            jarat.RepterHonnan = repterHonnan;
            jarat.RepterHova = repterHova;
            jarat.Indulas = indulas;
            jarat.Keses = 0;


            jaratok.Add(jarat);
        }

        public void Keses(string jaratSzam, int keses)
        {
            foreach (var item in jaratok)
            {
                if (item.Jaratszam == jaratSzam)
                {
                    item.Keses += keses;
                }
            }
        }

        public DateTime MikorIndul(string jaratSzam)
        {
            foreach (var item in jaratok)
            {
                if (item.Jaratszam == jaratSzam)
                {
                    return item.Indulas;
                }
            }
            throw new ArgumentException();
        }

        public List<string> JaratokRepuloterrol(string repter)
        {
            List<string> jaratok = new List<string>();
            return jaratok;
        }

        public int Jaratkesese(string jaratszam)
        {
            foreach (var item in jaratok)
            {
                return item.Keses;
            }
            throw new ArgumentException();
        }
    }

    public class Jarat
    {
        private string jaratszam;
        private string repterHonnan;
        private string repterHova;
        private DateTime indulas;
        private int keses;

        public string Jaratszam
        {
            get
            {
                return jaratszam;
            }

            set
            {
                jaratszam = value;
            }
        }

        public string RepterHonnan
        {
            get
            {
                return repterHonnan;
            }

            set
            {
                repterHonnan = value;
            }
        }

        public string RepterHova
        {
            get
            {
                return repterHova;
            }

            set
            {
                repterHova = value;
            }
        }

        public DateTime Indulas
        {
            get
            {
                return indulas;
            }

            set
            {
                indulas = value;
            }
        }

        public int Keses
        {
            get
            {
                return keses;
            }

            set
            {
                keses = value;
            }
        }

    }

}