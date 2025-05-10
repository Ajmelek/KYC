using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STB_everywhere.Models
{
    [Table("Client")] 
    public class Client
    {
        [Key]
        [Column("ID")] 
        public long Id { get; set; }

        [StringLength(4)]
        public string IndicateurTel { get; set; }

        public string Adresse { get; set; }

        public string AdresseComplete { get; set; }

        public string AdresseLieuTravail { get; set; }

        public string Agence { get; set; }

        public string AgenceResidence { get; set; }

        public string Cin { get; set; }

        public string Civilite { get; set; }

        public string ClientAutreBanque { get; set; }

        public string CodePostal { get; set; }

        public string ConfidenceRate { get; set; }

        public string DateRdv { get; set; }

        public string DateCin { get; set; }

        public string DateNaissance { get; set; }

        public string Datedelivrance { get; set; }

        public string Objetrelation { get; set; }

        public string Motif { get; set; }

        public string DeviseCompteReserved { get; set; }

        public string Environment { get; set; }

        public string EtatCivil { get; set; }

        public string Gouvernorat { get; set; }

        public string MailPrincipal { get; set; }

        public string Nationalite { get; set; }

        public string Nom { get; set; }

        public string NomMere { get; set; }

        public string NomPere { get; set; }

        public string Pays { get; set; }
        public string Rib {  get ; set; }
        public string PaysRelations { get; set; }

        public string PaysNaissance { get; set; }

        public string Prenom { get; set; }

        public string RCin { get; set; }

        public string Referentiel { get; set; }

        public string Resident { get; set; }

        public string AutreNationalite { get; set; }
        public string prenompere { get; set; }
        public string prenommere { get; set; }
        public string etatcivil { get; set; }
   
        public string Selfie { get; set; }
        public string NumeroTelephone { get; set; }
        
        public string StatutPro { get; set; }

        public string Login { get; set; }
        
        public string Password { get; set; }
    }
}