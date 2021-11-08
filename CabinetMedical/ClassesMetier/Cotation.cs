// <copyright file="Cotation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using CabinetMedical.Exceptions;

    /// <summary>
    /// Classe Cotation.
    /// </summary>
    public class Cotation
    {
        private string id;
        private string libelle;
        private int indice;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cotation"/> class.
        /// Constructeur de la Classe Cotation.
        /// </summary>
        /// <param name="id"> id de la cotation. </param>
        /// <param name="libelle">l libellé de la cotation. </param>
        /// <param name="indice"> indice de cotation. </param>
        public Cotation(string id, string libelle, int indice)
        {
            this.id = id;
            this.libelle = libelle;
            if (indice > 0)
            {
                this.indice = indice;
            }
            else
            {
                throw new CabinetMedicalException("Indice négatif ou égale à 0.");
            }
        }

        /// <summary>
        /// Gets id.
        /// </summary>
        public string Id { get => this.id; }

        /// <summary>
        /// Gets or Sets libelle.
        /// </summary>
        public string Libelle { get => this.libelle; set => this.libelle = value; }

        /// <summary>
        /// Gets or Sets indice.
        /// </summary>
        public int Indice { get => this.indice; set => this.indice = value; }
    }
}
