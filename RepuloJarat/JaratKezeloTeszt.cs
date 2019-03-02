﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepuloJarat
{
    [TestFixture]
    class JaratKezeloTeszt
    {
        [Test]
        public void UjJaratJokorIndul()
        {
            JaratKezelo jk = new JaratKezelo();
            jk.UjJarat("S213", "Budapest", "Berlin", new DateTime(2019, 03, 01, 12, 50, 0));
            Assert.AreEqual(
                new DateTime(2019, 03, 01, 12, 50, 0),
                jk.MikorIndul("S213")
                );
        }
        [Test]
        public void UjJaratEgyezonev()
        {
            JaratKezelo jk = new JaratKezelo();
            jk.UjJarat("S213", "Budapest", "Berlin", new DateTime(2019, 03, 01, 12, 50, 0));

            Assert.Throws<ArgumentException>(
                () =>
                {
                    jk.UjJarat("S213", "New York", "Berlin", new DateTime(2019, 03, 01, 10, 51, 0));
                }
            );


        }

        [Test]
        public void Keses()
        {
            JaratKezelo jk = new JaratKezelo();
            jk.UjJarat("S213", "Budapest", "Berlin", new DateTime(2019, 03, 01, 12, 50, 0));
            jk.Keses("S213", 5);

            Assert.AreEqual(
                5,
                jk.Jaratkesese("S213")
                );

        }
    }
}