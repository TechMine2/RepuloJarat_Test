using NUnit.Framework;
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
        #region ujjarat tesztelése
        [Test]
        public void UjJarat_JokorIndul()
        {
            JaratKezelo jk = new JaratKezelo();
            jk.UjJarat("S213", "Budapest", "Berlin", new DateTime(2019, 03, 01, 12, 50, 0));
            Assert.AreEqual(
                new DateTime(2019, 03, 01, 12, 50, 0),
                jk.MikorIndul("S213")
                );
        }
        [Test]
        public void UjJarat_FelvehetoEUgyanazANev()
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
        #endregion

        #region keses tesztelése
        [Test]
        public void Keses_JohozAdjaHozza()
        {
            JaratKezelo jk = new JaratKezelo();
            jk.UjJarat("S213", "Budapest", "Berlin", new DateTime(2019, 03, 01, 12, 50, 0));
            jk.Keses("S213", 5);

            Assert.AreEqual(
                5,
                jk.Jaratkesese("S213")
                );

        }

        [Test]
        public void Keses_NemLetezoJarat()
        {
            JaratKezelo jk = new JaratKezelo();
            jk.UjJarat("S213", "Budapest", "Berlin", new DateTime(2019, 03, 01, 12, 50, 0));

            Assert.Throws<ArgumentException>(
                () =>
                {
                    jk.Keses("A123", 5);
                }
           );
        }
        #endregion

        #region mikorindul tesztelése
        [Test]
        public void MikorIndul_NemLetezoJarat()
        {
            JaratKezelo jk = new JaratKezelo();
            jk.UjJarat("S213", "Budapest", "Berlin", new DateTime(2019, 03, 01, 12, 50, 0));
            Assert.Throws<ArgumentException>(
                () =>
                {
                    jk.MikorIndul("A123");
                }
           );
        }
        [Test]
        public void MikorIndul_JoIndulasiIdo()
        {
            JaratKezelo jk = new JaratKezelo();
            jk.UjJarat("S213", "Budapest", "Berlin", new DateTime(2019, 03, 01, 12, 50, 0));
            Assert.AreEqual(
                new DateTime(2019, 03, 01, 12, 50, 0),
                jk.MikorIndul("S213")
                );
        }
        #endregion

        #region jaratok repterrol
        [Test]
        public void JaratokRepuloterrol_LetezoHonnan()
        {
            JaratKezelo jk = new JaratKezelo();
            jk.UjJarat("S213", "Budapest", "Berlin", new DateTime(2019, 03, 01, 12, 50, 0));
            Assert.AreEqual(
                "Budapest",
                jk.JaratokRepuloterrol("Budapest")[0].RepterHonnan
                );
        }
        [Test]
        public void JaratokRepuloterrol_NemLetezo()
        {
            JaratKezelo jk = new JaratKezelo();
            jk.UjJarat("S213", "Budapest", "Berlin", new DateTime(2019, 03, 01, 12, 50, 0));
            Assert.IsEmpty(jk.JaratokRepuloterrol("Berlin"));

        }
        #endregion
    }
}