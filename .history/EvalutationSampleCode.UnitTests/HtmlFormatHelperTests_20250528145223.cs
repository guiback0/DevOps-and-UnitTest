using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EvaluationSampleCode;

namespace EvaluationSampleCode.UnitTests
{
    [TestClass]
    public class HtmlFormatHelperTests
    {
        private HtmlFormatHelper _htmlFormatHelper = null!;

        [TestInitialize]
        public void Init()
        {
            _htmlFormatHelper = new HtmlFormatHelper();
        }

        #region GetBoldFormat Tests

        [TestMethod]
        public void GetBoldFormat_AvecContenuHello_RetourneContenuEnGras()
        {
            // Arrange
            string contenu = "Hello";
            string resultatAttendu = "<b>Hello</b>";

            // Act
            var resultat = _htmlFormatHelper.GetBoldFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }


        [TestMethod]
        public void GetBoldFormat_AvecContenuVide_RetourneContenuEnGras()
        {
            // Arrange
            string contenu = "";
            string resultatAttendu = "<b></b>";

            // Act
            var resultat = _htmlFormatHelper.GetBoldFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetBoldFormat_AvecContenuAvecEspaces_RetourneContenuEnGras()
        {
            // Arrange
            string contenu = "Test avec espaces";
            string resultatAttendu = "<b>Test avec espaces</b>";

            // Act
            var resultat = _htmlFormatHelper.GetBoldFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetBoldFormat_AvecContenuNumerique_RetourneContenuEnGras()
        {
            // Arrange
            string contenu = "123";
            string resultatAttendu = "<b>123</b>";

            // Act
            var resultat = _htmlFormatHelper.GetBoldFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetBoldFormat_AvecCaracteresSpeciaux_RetourneContenuEnGras()
        {
            // Arrange
            string contenu = "Caractères spéciaux !@#";
            string resultatAttendu = "<b>Caractères spéciaux !@#</b>";

            // Act
            var resultat = _htmlFormatHelper.GetBoldFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        #endregion

        #region GetItalicFormat Tests

        [TestMethod]
        public void GetItalicFormat_AvecContenuHello_RetourneContenuEnItalique()
        {
            // Arrange
            string contenu = "Hello";
            string resultatAttendu = "<i>Hello</i>";

            // Act
            var resultat = _htmlFormatHelper.GetItalicFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetItalicFormat_AvecContenuVide_RetourneContenuEnItalique()
        {
            // Arrange
            string contenu = "";
            string resultatAttendu = "<i></i>";

            // Act
            var resultat = _htmlFormatHelper.GetItalicFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetItalicFormat_AvecContenuAvecEspaces_RetourneContenuEnItalique()
        {
            // Arrange
            string contenu = "Test avec espaces";
            string resultatAttendu = "<i>Test avec espaces</i>";

            // Act
            var resultat = _htmlFormatHelper.GetItalicFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetItalicFormat_AvecContenuNumerique_RetourneContenuEnItalique()
        {
            // Arrange
            string contenu = "123";
            string resultatAttendu = "<i>123</i>";

            // Act
            var resultat = _htmlFormatHelper.GetItalicFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetItalicFormat_AvecCaracteresSpeciaux_RetourneContenuEnItalique()
        {
            // Arrange
            string contenu = "Caractères spéciaux !@#";
            string resultatAttendu = "<i>Caractères spéciaux !@#</i>";

            // Act
            var resultat = _htmlFormatHelper.GetItalicFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        #endregion

        #region GetFormattedListElements Tests

        [TestMethod]
        public void GetFormattedListElements_AvecListeVide_RetourneListeHtmlVide()
        {
            // Arrange
            var listeVide = new List<string>();
            var resultatAttendu = "<ul></ul>";

            // Act
            var resultat = _htmlFormatHelper.GetFormattedListElements(listeVide);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetFormattedListElements_AvecUnElement_RetourneListeHtmlAvecUnElement()
        {
            // Arrange
            var liste = new List<string> { "Premier élément" };
            var resultatAttendu = "<ul><li>Premier élément</li></ul>";

            // Act
            var resultat = _htmlFormatHelper.GetFormattedListElements(liste);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetFormattedListElements_AvecPlusieursElements_RetourneListeHtmlComplete()
        {
            // Arrange
            var liste = new List<string> { "Élément 1", "Élément 2", "Élément 3" };
            var resultatAttendu = "<ul><li>Élément 1</li><li>Élément 2</li><li>Élément 3</li></ul>";

            // Act
            var resultat = _htmlFormatHelper.GetFormattedListElements(liste);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetFormattedListElements_AvecElementsVides_RetourneListeHtmlAvecElementsVides()
        {
            // Arrange
            var liste = new List<string> { "", "Contenu", "" };
            var resultatAttendu = "<ul><li></li><li>Contenu</li><li></li></ul>";

            // Act
            var resultat = _htmlFormatHelper.GetFormattedListElements(liste);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetFormattedListElements_AvecCaracteresSpeciaux_RetourneListeHtmlAvecCaracteresSpeciaux()
        {
            // Arrange
            var liste = new List<string> { "Élément avec <tags>", "Élément & caractères", "Élément \"guillemets\"" };
            var resultatAttendu = "<ul><li>Élément avec <tags></li><li>Élément & caractères</li><li>Élément \"guillemets\"</li></ul>";

            // Act
            var resultat = _htmlFormatHelper.GetFormattedListElements(liste);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        #endregion
    }
}
