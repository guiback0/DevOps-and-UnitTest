using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EvaluationSampleCode;

namespace EvaluationSampleCode.UnitTests
{
    [TestClass]
    public class CustomStackTests
    {
        
        private CustomStack _customStack;

        [TestInitialize]
        public void Init()
        {
            _customStack = new CustomStack();
        }


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
        [DataRow(5, 1)]
        [DataRow(0, 1)]
        [DataRow(-10, 1)]
        [DataRow(100, 1)]
        public void Count_ApresAjoutDUnElement_RetourneUn(int valeur, int countAttendu)
        {
            // Act
            _customStack.Push(valeur);
            var resultat = _customStack.Count();

            // Assert
            Assert.AreEqual(countAttendu, resultat);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 3)]
        [DataRow(new int[] { 5, 10 }, 2)]
        [DataRow(new int[] { -1, -2, -3, -4 }, 4)]
        public void Count_ApresAjoutDePlusieursElements_RetourneLeNombreCorrect(int[] valeurs, int countAttendu)
        {
            // Act
            foreach (var valeur in valeurs)
            {
                _customStack.Push(valeur);
            }
            var resultat = _customStack.Count();

            // Assert
            Assert.AreEqual(countAttendu, resultat);
        }
        #endregion

        #region Push Tests
        [TestMethod]
        [DataRow(5)]
        [DataRow(0)]
        [DataRow(-10)]
        [DataRow(100)]
        [DataRow(-999)]
        public void Push_AvecValeur_AugmenteLeCount(int valeur)
        {
            // Act
            var countInitial = _customStack.Count();
            _customStack.Push(valeur);

            // Assert
            Assert.AreEqual(countInitial + 1, _customStack.Count());
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 3)]
        [DataRow(new int[] { 5, 10 }, 2)]
        [DataRow(new int[] { -1, -2, -3, -4, -5 }, 5)]
        public void Push_AvecPlusieursValeurs_AjouteCorrectement(int[] valeurs, int countAttendu)
        {
            // Act
            foreach (var valeur in valeurs)
            {
                _customStack.Push(valeur);
            }

            // Assert
            Assert.AreEqual(countAttendu, _customStack.Count());
        }
        #endregion

        #region Pop Tests
        [TestMethod]
        [DataRow(5)]
        [DataRow(0)]
        [DataRow(-10)]
        [DataRow(100)]
        [DataRow(-999)]
        public void Pop_AvecUnElement_RetourneLElementEtDiminueLeCount(int valeur)
        {
            // Act
            _customStack.Push(valeur);
            var resultat = _customStack.Pop();

            // Assert
            Assert.AreEqual(valeur, resultat);
            Assert.AreEqual(0, _customStack.Count());
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 3, 2)]
        [DataRow(new int[] { 5, 10, 15 }, 15, 2)]
        [DataRow(new int[] { -1, -2 }, -2, 1)]
        public void Pop_AvecPlusieursElements_RetourneLeDernierElementAjoute(int[] valeurs, int dernierElementAttendu, int countApresPopAttendu)
        {
            // Act
            foreach (var valeur in valeurs)
            {
                _customStack.Push(valeur);
            }
            var resultat = _customStack.Pop();

            // Assert
            Assert.AreEqual(dernierElementAttendu, resultat);
            Assert.AreEqual(countApresPopAttendu, _customStack.Count());
        }

        [TestMethod]
        public void Pop_AvecStackVide_LeveUneStackCantBeEmptyException()
        {
            // Act & Assert
            Assert.ThrowsException<CustomStack.StackCantBeEmptyException>(() => _customStack.Pop());
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(-10)]
        public void Pop_ApresViderLeStack_LeveUneStackCantBeEmptyException(int valeur)
        {
            // Act
            _customStack.Push(valeur);
            _customStack.Pop();

            // Assert
            Assert.ThrowsException<CustomStack.StackCantBeEmptyException>(() => _customStack.Pop());
        }
        #endregion

        #region Integration Tests
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [DataRow(new int[] { 5, 10, 15, 20 }, new int[] { 20, 15, 10, 5 })]
        [DataRow(new int[] { -1, -2 }, new int[] { -2, -1 })]
        public void PushEtPop_OperationsMultiples_ComportementLIFO(int[] valeursAPousser, int[] valeursAttenduesToPop)
        {
            // Act
            foreach (var valeur in valeursAPousser)
            {
                _customStack.Push(valeur);
            }

            var resultats = new List<int>();
            for (int i = 0; i < valeursAttenduesToPop.Length; i++)
            {
                resultats.Add(_customStack.Pop());
            }

            // Assert
            CollectionAssert.AreEqual(valeursAttenduesToPop, resultats);
            Assert.AreEqual(0, _customStack.Count());
        }

        [TestMethod]
        public void PushEtPop_OperationsMelangees_ComportementCorrect()
        {
            // Act
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
