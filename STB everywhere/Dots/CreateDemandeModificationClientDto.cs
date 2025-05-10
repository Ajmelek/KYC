using System.ComponentModel.DataAnnotations;

public class CreateDemandeModificationClientDto
{
    [Required(ErrorMessage = "Client ID is required")]
    public long ClientID { get; set; }

    [Required(ErrorMessage = "Status is required")]
    [Range(0, 2, ErrorMessage = "Status must be between 0-2")]
    public int Etat { get; set; } = 0; 

    public string IndicateurTel { get; set; }

    public string Adresse { get; set; }
    public string AdresseComplete { get; set; }
    public string AdresseLieuTravail { get; set; }
    public string Agence { get; set; }
    public string AgenceResidence { get; set; }

    public string Cin { get; set; }

    public string Civilite { get; set; }
    public string Clientautrebanque { get; set; }
    public string Codepostal { get; set; }
    public string ConfidenceRate { get; set; }

    [DataType(DataType.Date)]
    public string DateRDV { get; set; }

    [DataType(DataType.Date)]
    public string Datecin { get; set; }

    [DataType(DataType.Date)]
    public string Datenaissance { get; set; }

    public string DeviseCompteReserved { get; set; }
    public string Environment { get; set; }
    public string Etatcivil { get; set; }
    public string Gouvernorat { get; set; }

    public string Mailprincipal { get; set; }

    public string Nationalite { get; set; }

    public string Nom { get; set; }

    public string Nommere { get; set; }
    public string Nompere { get; set; }
    public string Pays { get; set; }
    public string PaysRelations { get; set; }
    public string Paysnaissance { get; set; }

    public string Prenom { get; set; }

    public string Rcin { get; set; }
    public string Referentiel { get; set; }
    public string Resident { get; set; }
    public string Secondenationalite { get; set; }
    public string Selfie { get; set; } // Consider using IFormFile for file uploads
    public string Statutpro { get; set; }
    public string Rib { get; set; }

    public string NumeroTelephone { get; set; }

    public string AutreNationalite { get; set; }

    public string Prenommere { get; set; }

    public string Prenompere { get; set; }

    [DataType(DataType.Date)]
    public string Datedelivrance { get; set; }

    public string Motif { get; set; }
    public string Objetrelation { get; set; }

    public string Login { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string Commentaire { get; set; }
}