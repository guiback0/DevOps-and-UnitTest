using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EvaluationSampleCode;

namespace EvaluationSampleCode.Tests
{
    [TestClass]
    public class CustomStackTests
    {
        #region Setup
        private CustomStack _customStack;

        [TestInitialize]
        public void Initialiser()
        {
            _customStack = new CustomStack();
        }
        #endregion

        #region Count Tests
        [TestMethod]
        public void Count_AvecStackVide_RetourneZero()
        {
            // Act
            var resultat = _customStack.Count();

            // Assert
            Assert.AreEqual(0, resultat);
        }

        [TestMethod]
        public void Count_ApresAjoutDUnElement_RetourneUn()
        {
            // Arrange
            _customStack.Push(5);

            // Act
            var resultat = _customStack.Count();

            // Assert
            Assert.AreEqual(1, resultat);
        }

        [TestMethod]
        public void Count_ApresAjoutDePlusieursElements_RetourneLeNombreCorrect()
        {
            // Arrange
            _customStack.Push(1);
            _customStack.Push(2);
            _customStack.Push(3);

            // Act
            var resultat = _customStack.Count();

            // Assert
            Assert.AreEqual(3, resultat);
        }
        #endregion

        #region Push Tests
        [TestMethod]
        public void Push_AvecValeurPositive_AugmenteLeCount()
        {
            // Arrange
            var countInitial = _customStack.Count();

            // Act
            _customStack.Push(5);

            // Assert
            Assert.AreEqual(countInitial + 1, _customStack.Count());
        }

        [TestMethod]
        public void Push_AvecValeurZero_AugmenteLeCount()
        {
            // Arrange
            var countInitial = _customStack.Count();

            // Act
            _customStack.Push(0);

            // Assert
            Assert.AreEqual(countInitial + 1, _customStack.Count());
        }

        [TestMethod]
        public void Push_AvecValeurNegative_AugmenteLeCount()
        {
            // Arrange
            var countInitial = _customStack.Count();

            // Act
            _customStack.Push(-10);

            // Assert
            Assert.AreEqual(countInitial + 1, _customStack.Count());
        }

        [TestMethod]
        public void Push_AvecPlusieursValeurs_AjouteCorrectement()
        {
            // Act
            _customStack.Push(1);
            _customStack.Push(2);
            _customStack.Push(3);

            // Assert
            Assert.AreEqual(3, _customStack.Count());
        }
        #endregion

        #region Pop Tests
        [TestMethod]
        public void Pop_AvecUnElementPositif_RetourneLElementEtDiminueLeCount()
        {
            // Arrange
            _customStack.Push(5);

            // Act
            var resultat = _customStack.Pop();

            // Assert
            Assert.AreEqual(5, resultat);
            Assert.AreEqual(0, _customStack.Count());
        }

        [TestMethod]
        public void Pop_AvecUnElementZero_RetourneLElementEtDiminueLeCount()
        {
            // Arrange
            _customStack.Push(0);

            // Act
            var resultat = _customStack.Pop();

            // Assert
            Assert.AreEqual(0, resultat);
            Assert.AreEqual(0, _customStack.Count());
        }

        [TestMethod]
        public void Pop_AvecUnElementNegatif_RetourneLElementEtDiminueLeCount()
        {
            // Arrange
            _customStack.Push(-10);

            // Act
            var resultat = _customStack.Pop();

            // Assert
            Assert.AreEqual(-10, resultat);
            Assert.AreEqual(0, _customStack.Count());
        }

        [TestMethod]
        public void Pop_AvecPlusieursElements_RetourneLeDernierElementAjoute()
        {
            // Arrange
            _customStack.Push(1);
            _customStack.Push(2);
            _customStack.Push(3);

            // Act
            var resultat = _customStack.Pop();

            // Assert
            Assert.AreEqual(3, resultat);
            Assert.AreEqual(2, _customStack.Count());
        }

        [TestMethod]
        public void Pop_AvecStackVide_LeveUneStackCantBeEmptyException()
        {
            // Act & Assert
            Assert.ThrowsException<CustomStack.StackCantBeEmptyException>(() => _customStack.Pop());
        }

        [TestMethod]
        public void Pop_ApresViderLeStack_LeveUneStackCantBeEmptyException()
        {
            // Arrange
            _customStack.Push(1);
            _customStack.Pop();

            // Act & Assert
            Assert.ThrowsException<CustomStack.StackCantBeEmptyException>(() => _customStack.Pop());
        }
        #endregion

        #region Integration Tests
        [TestMethod]
        public void PushEtPop_OperationsMultiples_ComportementLIFO()
        {
            // Arrange & Act
            _customStack.Push(1);
            _customStack.Push(2);
            _customStack.Push(3);

            var premier = _customStack.Pop(); // Devrait être 3
            var deuxieme = _customStack.Pop(); // Devrait être 2
            var troisieme = _customStack.Pop(); // Devrait être 1

            // Assert
            Assert.AreEqual(3, premier);
            Assert.AreEqual(2, deuxieme);
            Assert.AreEqual(1, troisieme);
            Assert.AreEqual(0, _customStack.Count());
        }

        [TestMethod]
        public void PushEtPop_OperationsMelangees_ComportementCorrect()
        {
            // Arrange & Act
            _customStack.Push(1);
            _customStack.Push(2);
            var premier = _customStack.Pop(); // 2
            _customStack.Push(3);
            var deuxieme = _customStack.Pop(); // 3
            var troisieme = _customStack.Pop(); // 1

            // Assert
            Assert.AreEqual(2, premier);
            Assert.AreEqual(3, deuxieme);
            Assert.AreEqual(1, troisieme);
            Assert.AreEqual(0, _customStack.Count());
        }
        #endregion
    }
}
