using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EvaluationSampleCode;

namespace EvaluationSampleCode.UnitTests
{
    [TestClass]
    public class MathOperationsTests
    {
       
        private MathOperations _mathOperations;

        [TestInitialize]
        public void Init()
        {
            _mathOperations = new MathOperations();
        }
       

        #region Addition Tests
        [TestMethod]
        [DataRow(5, 3, 8)]
        [DataRow(0, 0, 0)]
        [DataRow(-5, 3, -2)]
        [DataRow(10, -5, 5)]
        [DataRow(-10, -5, -15)]
        public void Addition_AvecDeuxNombres_RetourneLaSomme(int nombreUn, int nombreDeux, int resultatAttendu)
        {
            

            // Act
            var resultat = _mathOperations.Add(nombreUn, nombreDeux);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }
        #endregion

        #region Division Tests
        [TestMethod]
        [DataRow(10, 2, 5.0f)]
        [DataRow(7, 2, 3.5f)]
        [DataRow(0, 5, 0.0f)]
        [DataRow(-10, 2, -5.0f)]
        [DataRow(10, -2, -5.0f)]
        public void Divide_AvecDeuxNombresValides_RetourneLaDivision(int nombreUn, int nombreDeux, float resultatAttendu)
        {
            

            // Act
            var resultat = _mathOperations.Divide(nombreUn, nombreDeux);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat, 0.001f);
        }

        [TestMethod]
        [DataRow(10, 0)]
        [DataRow(5, 0)]
        [DataRow(-10, 0)]
        [DataRow(0, 0)]
        [DataRow(100, 0)]
        public void Divide_AvecDiviseurZero_LeveUneException(int dividende, int diviseurZero)
        {
            
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _mathOperations.Divide(dividende, diviseurZero));
        }
        #endregion

        #region GetOddNumbers Tests
        [TestMethod]
        [DataRow(10, new int[] { 1, 3, 5, 7, 9 })]
        [DataRow(5, new int[] { 1, 3, 5 })]
        [DataRow(0, new int[] { })]
        [DataRow(1, new int[] { 1 })]
        [DataRow(2, new int[] { 1 })]
        public void GetOddNumbers_AvecLimiteValide_RetourneLesNombresImpairs(int limite, int[] nombresImparisAttendus)
        {
            
            // Act
            var resultat = _mathOperations.GetOddNumbers(limite);

            // Assert
            CollectionAssert.AreEqual(nombresImparisAttendus, resultat.ToArray());
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-10)]
        [DataRow(-100)]
        public void GetOddNumbers_AvecLimiteNegative_LeveUneException(int limiteNegative)
        {

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _mathOperations.GetOddNumbers(limiteNegative));
        }
        #endregion
    }
}
