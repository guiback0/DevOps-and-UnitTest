using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EvaluationSampleCode;

namespace EvaluationSampleCode.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        private User _utilisateurNormal = null!;
        private User _utilisateurAdmin = null!;
        private User _autreUtilisateur = null!;
        private Reservation _reservation = null!;

        [TestInitialize]
        public void Init()
        {
            _utilisateurNormal = new User { IsAdmin = false };
            _utilisateurAdmin = new User { IsAdmin = true };
            _autreUtilisateur = new User { IsAdmin = false };
            _reservation = new Reservation(_utilisateurNormal);
        }

        #region CanBeCancelledBy Tests

        [TestMethod]
        public void CanBeCancelledBy_AvecUtilisateurQuiAFaitLaReservation_RetourneVrai()
        {

            // Act
            var resultat = _reservation.CanBeCancelledBy(_utilisateurNormal);

            // Assert
            Assert.IsTrue(resultat);
        }

        [TestMethod]
        public void CanBeCancelledBy_AvecUtilisateurAdmin_RetourneVrai()
        {
            // Arrange
            // La réservation a été créée par _utilisateurNormal mais on teste avec un admin

            // Act
            var resultat = _reservation.CanBeCancelledBy(_utilisateurAdmin);

            // Assert
            Assert.IsTrue(resultat);
        }

        [TestMethod]
        public void CanBeCancelledBy_AvecAutreUtilisateurNonAdmin_RetourneFaux()
        {
            // Arrange
            // La réservation a été créée par _utilisateurNormal, on teste avec 

            // Act
            var resultat = _reservation.CanBeCancelledBy(_autreUtilisateur);

            // Assert
            Assert.IsFalse(resultat);
        }

        [TestMethod]
        public void CanBeCancelledBy_AvecUtilisateurAdminQuiAFaitLaReservation_RetourneVrai()
        {
            // Arrange
            var reservationParAdmin = new Reservation(_utilisateurAdmin);

            // Act
            var resultat = reservationParAdmin.CanBeCancelledBy(_utilisateurAdmin);

            // Assert
            Assert.IsTrue(resultat);
        }

        #endregion

        #region Constructor Tests

        [TestMethod]
        public void Constructor_AvecUtilisateur_InitialiseMadeByCorrectement()
        {
            // Arrange
            var utilisateur = new User { IsAdmin = false };

            // Act
            var reservation = new Reservation(utilisateur);

            // Assert
            Assert.AreEqual(utilisateur, reservation.MadeBy);
        }

        [TestMethod]
        public void Constructor_AvecUtilisateurAdmin_InitialiseMadeByCorrectement()
        {
            // Arrange
            var utilisateurAdmin = new User { IsAdmin = true };

            // Act
            var reservation = new Reservation(utilisateurAdmin);

            // Assert
            Assert.AreEqual(utilisateurAdmin, reservation.MadeBy);
        }

        #endregion

        #region MadeBy Property Tests

        [TestMethod]
        public void MadeBy_ProprieteSet_ModifieLUtilisateur()
        {
            // Arrange
            var nouvelUtilisateur = new User { IsAdmin = true };

            // Act
            _reservation.MadeBy = nouvelUtilisateur;

            // Assert
            Assert.AreEqual(nouvelUtilisateur, _reservation.MadeBy);
        }

        #endregion
    }
}
