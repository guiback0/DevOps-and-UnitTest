using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EvaluationSampleCode;

namespace EvaluationSampleCode.UnitTests
{
    [TestClass]
    public class MathOperationTests
    {
        private MathOperation _mathOperation = null!;

        [TestInitialize]
        public void Initialiser()
        {
            _mathOperation = new MathOperation();
        }

        #region Addition Tests

        [TestMethod]
        public void Addition_Avec5Et3_Retourne8()
        {
            // Arrange
            int a = 5;
            int b = 3;
            int resultatAttendu = 8;

            // Act
            var resultat = _mathOperation.Addition(a, b);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void Addition_Avec0Et0_Retourne0()
        {
            // Arrange
            int a = 0;
            int b = 0;
            int resultatAttendu = 0;

            // Act
            var resultat = _mathOperation.Addition(a, b);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void Addition_AvecNombresNegatifs_RetourneResultatCorrect()
        {
            // Arrange
            int a = -5;
            int b = -3;
            int resultatAttendu = -8;

            // Act
            var resultat = _mathOperation.Addition(a, b);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        #endregion

        #region Soustraction Tests

        [TestMethod]
        public void Soustraction_Avec10Et4_Retourne6()
        {
            // Arrange
            int a = 10;
            int b = 4;
            int resultatAttendu = 6;

            // Act
            var resultat = _mathOperation.Soustraction(a, b);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void Soustraction_Avec5Et5_Retourne0()
        {
            // Arrange
            int a = 5;
            int b = 5;
            int resultatAttendu = 0;

            // Act
            var resultat = _mathOperation.Soustraction(a, b);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void Soustraction_AvecNombresNegatifs_RetourneResultatCorrect()
        {
            // Arrange
            int a = -5;
            int b = -3;
            int resultatAttendu = -2;

            // Act
            var resultat = _mathOperation.Soustraction(a, b);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        #endregion

        #region Multiplication Tests

        [TestMethod]
        public void Multiplication_Avec6Et7_Retourne42()
        {
            // Arrange
            int a = 6;
            int b = 7;
            int resultatAttendu = 42;

            // Act
            var resultat = _mathOperation.Multiplication(a, b);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void Multiplication_AvecZero_RetourneZero()
        {
            // Arrange
            int a = 5;
            int b = 0;
            int resultatAttendu = 0;

            // Act
            var resultat = _mathOperation.Multiplication(a, b);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void Multiplication_AvecNombresNegatifs_RetourneResultatCorrect()
        {
            // Arrange
            int a = -4;
            int b = 3;
            int resultatAttendu = -12;

            // Act
            var resultat = _mathOperation.Multiplication(a, b);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        #endregion

        #region Division Tests

        [TestMethod]
        public void Division_Avec15Et3_Retourne5()
        {
            // Arrange
            int a = 15;
            int b = 3;
            int resultatAttendu = 5;

            // Act
            var resultat = _mathOperation.Division(a, b);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void Division_Avec10Et4_Retourne2()
        {
            // Arrange
            int a = 10;
            int b = 4;
            int resultatAttendu = 2;

            // Act
            var resultat = _mathOperation.Division(a, b);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Division_ParZero_LeveException()
        {
            // Arrange
            int a = 10;
            int b = 0;

            // Act
            _mathOperation.Division(a, b);

            // Assert is handled by ExpectedException
        }

        #endregion
    }
}
