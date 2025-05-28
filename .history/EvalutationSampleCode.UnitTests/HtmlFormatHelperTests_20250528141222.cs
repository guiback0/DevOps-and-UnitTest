namespace EvalutationSampleCode.UnitTests;

usi

namespace EvaluationSampleCode.Tests
{
    [TestClass]
    public class HtmlFormatHelperTests
    {
        private HtmlFormatHelper _htmlFormatHelper;

        [TestInitialize]
        public void TestInitialize()
        {
            _htmlFormatHelper = new HtmlFormatHelper();
        }

        #region Tests pour GetBoldFormat

        [TestMethod]
        public void GetBoldFormat_AvecTexteNormal_RetourneTexteEnGras()
        {
            // Arrange
            string contenu = "Hello World";
            string resultatAttendu = "<b>Hello World</b>";

            // Act
            string resultat = _htmlFormatHelper.GetBoldFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetBoldFormat_AvecTexteVide_RetourneBalisesGrasVides()
        {
            // Arrange
            string contenu = "";
            string resultatAttendu = "<b></b>";

            // Act
            string resultat = _htmlFormatHelper.GetBoldFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetBoldFormat_AvecEspaces_RetourneEspacesEnGras()
        {
            // Arrange
            string contenu = "   ";
            string resultatAttendu = "<b>   </b>";

            // Act
            string resultat = _htmlFormatHelper.GetBoldFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetBoldFormat_AvecCaracteresSpeciaux_RetourneCaracteresSpeciauxEnGras()
        {
            // Arrange
            string contenu = "Test & <script>";
            string resultatAttendu = "<b>Test & <script></b>";

            // Act
            string resultat = _htmlFormatHelper.GetBoldFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        #endregion

        #region Tests pour GetItalicFormat

        [TestMethod]
        public void GetItalicFormat_AvecTexteNormal_RetourneTexteEnItalique()
        {
            // Arrange
            string contenu = "Hello World";
            string resultatAttendu = "<i>Hello World</i>";

            // Act
            string resultat = _htmlFormatHelper.GetItalicFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetItalicFormat_AvecTexteVide_RetourneBalisesItaliquesVides()
        {
            // Arrange
            string contenu = "";
            string resultatAttendu = "<i></i>";

            // Act
            string resultat = _htmlFormatHelper.GetItalicFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetItalicFormat_AvecEspaces_RetourneEspacesEnItalique()
        {
            // Arrange
            string contenu = "   ";
            string resultatAttendu = "<i>   </i>";

            // Act
            string resultat = _htmlFormatHelper.GetItalicFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetItalicFormat_AvecCaracteresSpeciaux_RetourneCaracteresSpeciauxEnItalique()
        {
            // Arrange
            string contenu = "Test & <div>";
            string resultatAttendu = "<i>Test & <div></i>";

            // Act
            string resultat = _htmlFormatHelper.GetItalicFormat(contenu);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        #endregion

        #region Tests pour GetFormattedListElements

        [TestMethod]
        public void GetFormattedListElements_AvecListeNormale_RetourneListeHtmlComplete()
        {
            // Arrange
            var contenus = new List<string> { "Element 1", "Element 2", "Element 3" };
            string resultatAttendu = "<ul><li>Element 1</li><li>Element 2</li><li>Element 3</li></ul>";

            // Act
            string resultat = _htmlFormatHelper.GetFormattedListElements(contenus);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetFormattedListElements_AvecListeVide_RetourneListeHtmlVide()
        {
            // Arrange
            var contenus = new List<string>();
            string resultatAttendu = "<ul></ul>";

            // Act
            string resultat = _htmlFormatHelper.GetFormattedListElements(contenus);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetFormattedListElements_AvecUnSeulElement_RetourneListeHtmlAvecUnElement()
        {
            // Arrange
            var contenus = new List<string> { "Seul element" };
            string resultatAttendu = "<ul><li>Seul element</li></ul>";

            // Act
            string resultat = _htmlFormatHelper.GetFormattedListElements(contenus);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetFormattedListElements_AvecElementsVides_RetourneListeHtmlAvecElementsVides()
        {
            // Arrange
            var contenus = new List<string> { "", "Element normal", "" };
            string resultatAttendu = "<ul><li></li><li>Element normal</li><li></li></ul>";

            // Act
            string resultat = _htmlFormatHelper.GetFormattedListElements(contenus);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void GetFormattedListElements_AvecCaracteresSpeciaux_RetourneListeHtmlAvecCaracteresSpeciaux()
        {
            // Arrange
            var contenus = new List<string> { "Element & spécial", "<script>alert('test')</script>" };
            string resultatAttendu = "<ul><li>Element & spécial</li><li><script>alert('test')</script></li></ul>";

            // Act
            string resultat = _htmlFormatHelper.GetFormattedListElements(contenus);

            // Assert
            Assert.AreEqual(resultatAttendu, resultat);
        }

        #endregion
    }
}
