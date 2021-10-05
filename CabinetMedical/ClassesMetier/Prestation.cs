// <copyright file="Prestation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using CabinetMedical.Exceptions;

    /// <summary>
    /// Classe Prestation.
    /// </summary>
    internal class Prestation
    {
        // Méthodes

        /// <summary>
        /// Initializes a new instance of the <see cref="Prestation"/> class.
        /// </summary>
        /// <param name="libelle">Libéllé.</param>
        /// <param name="dateHeureSoin">Date et heure de la prestation.</param>
        /// <param name="intervenant">Objet de la classe Intervenant.</param>
        public Prestation(string libelle, DateTime dateHeureSoin, Intervenant intervenant)
        {
            this.Libelle = libelle;
            if (DateTime.Compare(DateTime.Now.Date, dateHeureSoin.Date) >= 0)
            {
                this.DateHeureSoin = dateHeureSoin;
            }
            else
            {
                throw new CabinetMedicalException(" Date non conforme ");
            }

            this.Intervenant = intervenant;
        }

        // Properties

        /// <summary>
        /// Gets.
        /// </summary>
        public string Libelle { get; }

        /// <summary>
        /// Gets.
        /// </summary>
        public DateTime DateHeureSoin { get; }

        /// <summary>
        /// Gets.
        /// </summary>
        internal Intervenant Intervenant { get; }

        /// <summary>
        /// Permet de comparer deux date de prestation.
        /// </summary>
        /// <param name="presta1">Objet de la classe Prestation.</param>
        /// <param name="presta2">Un autre objet de la classe Prestation.</param>
        /// <returns>Un nombre permettant de savoir si la date est antérieure ou non.</returns>
        public static int CompareTo(Prestation presta1, Prestation presta2)
        {
            return DateTime.Compare(presta1.DateHeureSoin.Date, presta2.DateHeureSoin.Date);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Libelle " + this.Libelle + " - " + this.DateHeureSoin + " - " + this.Intervenant + "\n\t";
        }
    }
}
