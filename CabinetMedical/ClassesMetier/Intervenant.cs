// <copyright file="Intervenant.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System.Collections.Generic;

    /// <summary>
    /// Classe Intervenant.
    /// </summary>
    internal class Intervenant
    {
        // Attibuts
        private string nom;
        private string prenom;
        private List<Prestation> prestations = new List<Prestation>();

        // Méthodes

        /// <summary>
        /// Initializes a new instance of the <see cref="Intervenant"/> class.
        /// </summary>
        /// <param name="nom">Nom.</param>
        /// <param name="prenom">Prenom.</param>
        public Intervenant(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        // Properties

        /// <summary>
        /// Gets.
        /// </summary>
        public string Nom { get => this.nom; }

        /// <summary>
        /// Gets.
        /// </summary>
        public string Prenom { get => this.prenom; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Intervenant : " + this.nom + " - " + this.prenom;
        }

        /// <summary>
        /// Permet d'Ajouter une prestation à la liste prestations.
        /// </summary>
        /// <param name="prestation">Objet de la classe Prestation.</param>
        public void AjoutePrestation(Prestation prestation)
        {
            this.prestations.Add(prestation);
        }

        /// <summary>
        /// Permet d'obtenir le nombre de prestation.
        /// </summary>
        /// <returns>Nombre de prestation.</returns>
        public int GetNbPrestations()
        {
            return this.prestations.Count;
        }
    }
}
