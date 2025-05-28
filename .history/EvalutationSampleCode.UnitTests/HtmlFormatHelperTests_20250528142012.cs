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

        [TestMethod]
        [DataRow("Hello", "<b>Hello</b>")]
        [DataRow("World", "<b>World</b>")]
        [DataRow("", "<b></b>")]
        [DataRow("Test avec espaces", "<b>Test avec espaces</b>")]
        [DataRow("123", "<b>123</b>")]
        [DataRow("Caractères spéciaux !@#", "<b>Caractères spéciaux !@#</b>")]
        public void GetBoldFormat_AvecContenu_RetourneContenuEnGras(string contenu, string resultatAttendu)
        {
            // Arrange
            // Les paramètres sont fournis par DataRow

            // Act
            var resultat = _htmlFormatHelper.GetBoldFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        [DataRow("Hello", "<i>Hello</i>")]
        [DataRow("World", "<i>World</i>")]
        [DataRow("", "<i></i>")]
        [DataRow("Test avec espaces", "<i>Test avec espaces</i>")]
        [DataRow("123", "<i>123</i>")]
        [DataRow("Caractères spéciaux !@#", "<i>Caractères spéciaux !@#</i>")]
        public void GetItalicFormat_AvecContenu_RetourneContenuEnItalique(string contenu, string resultatAttendu)
        {
            // Act
            var resultat = _htmlFormatHelper.GetItalicFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

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
    }
}