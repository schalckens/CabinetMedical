// <copyright file="IntervenantExterne.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Classe IntervenantExterne.
    /// </summary>
    internal class IntervenantExterne : Intervenant
    {
        // Méthodes

        /// <summary>
        /// Initializes a new instance of the <see cref="IntervenantExterne"/> class.
        /// </summary>
        /// <param name="nom">Nom.</param>
        /// <param name="prenom">Prenom.</param>
        /// <param name="specialite">Spécialité.</param>
        /// <param name="adresse">Adresse.</param>
        /// <param name="tel">Téléphone.</param>
        public IntervenantExterne(string nom, string prenom, string specialite, string adresse, string tel)
            : base(nom, prenom)
        {
            this.Specialite = specialite;
            this.Adresse = adresse;
            this.Tel = tel;
        }

        // Properties

        /// <summary>
        /// Gets.
        /// </summary>
        public string Specialite { get; }

        /// <summary>
        /// Gets or Sets.
        /// </summary>
        public string Adresse { get; set; }

        /// <summary>
        /// Gets or Sets.
        /// </summary>
        public string Tel { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return base.ToString() + " Spécialité : " + this.Specialite + " - " + this.Adresse + " - " + this.Tel;
        }
    }
}
