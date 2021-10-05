// <copyright file="Dossier.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CabinetMedical.Exceptions;

    /// <summary>
    /// Classe Dossier.
    /// </summary>
    internal class Dossier
    {
        private DateTime dateNaissance;
        private List<Prestation> prestations;

        // Méthodes

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">Nom de la personne.</param>
        /// <param name="prenom">Prenom de la personne.</param>
        /// <param name="dateNaissance">Date de naissance de la personne.</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            if (DateTime.Compare(DateTime.Now.Date, dateNaissance) >= 0)
            {
                this.dateNaissance = dateNaissance;
            }
            else
            {
                throw new CabinetMedicalException("Date non conforme");
            }

            this.DateCreation = DateTime.Now;

            // this.dateCreation = new DateTime(2015, 10, 8, 12, 00, 00);
            this.prestations = new List<Prestation>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">Nom de la personne.</param>
        /// <param name="prenom">Prenom de la personne.</param>
        /// <param name="dateNaissance">Date de naissance de la personne.</param>
        /// <param name="dateCreation">Date de création de la personne.</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, DateTime dateCreation)
            : this(nom, prenom, dateNaissance)
        {
            if (DateTime.Compare(DateTime.Now.Date, dateCreation) >= 0)
            {
                this.DateCreation = dateCreation;
            }
            else
            {
                throw new CabinetMedicalException("Date non conforme");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">Nom de la personne.</param>
        /// <param name="prenom">Prenom de la personne.</param>
        /// <param name="dateNaissance">Date de naissance de la personne.</param>
        /// <param name="prestation">Objet de la classe Prestation.</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, Prestation prestation)
            : this(nom, prenom, dateNaissance)
        {
            this.AjoutePrestation(prestation);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">Nom de la personne.</param>
        /// <param name="prenom">Prenom de la personne.</param>
        /// <param name="dateNaissance">Date de naissance de la personne.</param>
        /// <param name="prestations">Objet de la classe Prestation.</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, List<Prestation> prestations)
            : this(nom, prenom, dateNaissance)
        {
            foreach (Prestation prestation in prestations)
            {
                this.AjoutePrestation(prestation);
            }
        }

        // Properties

        /// <summary>
        /// Gets.
        /// </summary>
        public string Nom { get; }

        /// <summary>
        /// Gets.
        /// </summary>
        public string Prenom { get; }

        /// <summary>
        /// Gets.
        /// </summary>
        public DateTime DateNaissance { get => this.dateNaissance; }

        /// <summary>
        /// Gets.
        /// </summary>
        public DateTime DateCreation { get; }

        /// <summary>
        /// Gets.
        /// </summary>
        internal List<Prestation> Prestations { get => this.prestations; }

        /// <inheritdoc/>
        public override string ToString()
        {
            string contenu = string.Empty;
            foreach (Prestation presta in this.prestations)
            {
                contenu += presta;
            }

            return "-------------Début dossier ------------ \n" + "Nom : " + this.Nom + " Prenom : " + this.Prenom + " Date de naissance : " + this.dateNaissance + "\n\t" + contenu + "\n -------------Fin dossier --------------";
        }

        /// <summary>
        /// Ajoute une prestation (objet de la classe Prestation) à la liste d'objet prestations de la classe.
        /// </summary>
        /// <param name="prestation">Objet de la classe Prestation.</param>
        public void AjoutePrestation(Prestation prestation)
        {
            // pour que le test renvoi tru il faut que la date de gauche soit supérieure ou égal
            if (DateTime.Compare(prestation.DateHeureSoin.Date, this.DateCreation.Date) >= 0)
            {
                this.prestations.Add(prestation);
            }
            else
            {
                throw new CabinetMedicalException("Date non-valide");
            }
        }

        /// <summary>
        /// Permet d'obtenir le nombre de Prestations effectué par un intervenant externe.
        /// </summary>
        /// <returns>Un nombre (Int32).</returns>
        public int GetNbPrestationsExternes()
        {
            int cpt = 0;
            foreach (Prestation prestation in this.prestations)
            {
                if (prestation.Intervenant is IntervenantExterne)
                {
                    cpt++;
                }
            }

            return cpt;
        }

        /// <summary>
        /// Permet d'obtenir le nombre de prestation effectuée par un intervenant.
        /// </summary>
        /// <returns>Un nombre (Int32).</returns>
        public int GetNbPrestations()
        {
            return this.prestations.Count;
        }

        /// <summary>
        /// Première méthode pour obtenir le nb de jours de prestation.
        /// Méthode double boucle.
        /// </summary>
        /// <returns>Nb jour soins.</returns>
        public int GetNbJoursSoinsV1()
        {
            int nb = this.prestations.Count;
            for (int i = 0; i < this.prestations.Count - 1; i++)
            {
                for (int j = i + 1; j < this.prestations.Count; j++)
                {
                    if (Prestation.CompareTo(this.prestations[i], this.prestations[j]) == 0)
                    {
                        nb--;
                    }
                }
            }

            return nb;
        }

        /// <summary>
        /// Deuxième méthode pour obtenir le nb de jours de prestation.
        /// Ajout dans une liste viste si pas déjà présente.
        /// </summary>
        /// <returns>Nb jour soins.</returns>
        public int GetNbJoursSoinsV2()
        {
            List<DateTime> dates = new List<DateTime>();
            foreach (Prestation presta in this.prestations)
            {
                if (!dates.Contains(presta.DateHeureSoin.Date))
                {
                    dates.Add(presta.DateHeureSoin.Date);
                }
            }

            return dates.Count;
        }

        /// <summary>
        /// Troisième méthode pour obtenir le nb de jours de prestation.
        /// Ajout dans une liste viste si pas déjà présente.
        /// </summary>
        /// <returns>Nb jour soins.</returns>
        public int GetNbJoursSoinsV3()
        {
            List<Prestation> dateTrie = this.prestations.OrderBy(prest => prest.DateHeureSoin).ToList(); // ordre croissant

            // List<Prestation> dateTrie = prestations.OrderByDescending(prest => prest.DateHeureSoin).ToList(); //ordre décroissant
            DateTime baser = dateTrie[0].DateHeureSoin.Date;
            int cpt = 0;

            foreach (Prestation date in dateTrie)
            {
                if (!(date.DateHeureSoin.Date == baser))
                {
                    cpt++;
                    baser = date.DateHeureSoin.Date;
                }
            }

            return cpt + 1;
        }
    }
}
