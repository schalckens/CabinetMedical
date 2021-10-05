// <copyright file="TempException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.Exceptions
{
    using System;

    /// <summary>
    /// Classe TempExcepition qui hérite de la classe Exception.
    /// </summary>
    internal class TempException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TempException"/> class.
        /// </summary>
        /// <param name="classeException">Classe de l'Exception levée.</param>
        /// <param name="messageException">Message de l'Exception levée.</param>
        /// <param name="userException">Utilisateur lors de l'Exception.</param>
        /// <param name="userMachine">Machine losrs de l'Exception.</param>
        public TempException(string classeException, string messageException, string userException, string userMachine)
        {
            this.Application = "Soins2021";
            this.ClasseException = classeException;
            this.DateException = DateTime.Now;
            this.MessageException = messageException;
            this.UserException = userException;
            this.UserMachine = userMachine;
        }

        /// <summary>
        /// Gets or Sets.
        /// </summary>
        public string Application { get; set; }

        /// <summary>
        /// Gets or Sets.
        /// </summary>
        public string ClasseException { get; set; }

        /// <summary>
        /// Gets or Sets.
        /// </summary>
        public DateTime DateException { get; set; }

        /// <summary>
        /// Gets or Sets.
        /// </summary>
        public string MessageException { get; set; }

        /// <summary>
        /// Gets or Sets.
        /// </summary>
        public string UserException { get; set; }

        /// <summary>
        /// Gets or Sets.
        /// </summary>
        public string UserMachine { get; set; }
    }
}
