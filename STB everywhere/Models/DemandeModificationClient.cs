using STB_everywhere.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("DemandeModificationClient")] // Singular table name
public class DemandeModificationClient
{
    [Key]
    public long ID { get; set; }

    [Required]
    public long clientID { get; set; }

    [Required]
    public int etat { get; set; }

    public DateTime? dateDemande { get; set; } = DateTime.Now;
    public DateTime? dateTraitement { get; set; }

    [StringLength(50)]
    public string utilisateur { get; set; }

    // Client fields
    [StringLength(4)]
    public string IndicateurTel { get; set; }

    public string adresse { get; set; }
    public string adresseComplete { get; set; }
    public string adresseLieuTravail { get; set; }
    public string agence { get; set; }
    public string agenceResidence { get; set; }
    public string cin { get; set; }
    public string civilite { get; set; }
    public string clientautrebanque { get; set; }
    public string codepostal { get; set; }
    public string confidenceRate { get; set; }
    public string dateRDV { get; set; }
    public string datecin { get; set; }
    public string datenaissance { get; set; }
    public string deviseCompteReserved { get; set; }
    public string environment { get; set; }
    public string etatcivil { get; set; }
    public string gouvernorat { get; set; }

    [EmailAddress]
    public string mailprincipal { get; set; }

    public string nationalite { get; set; }

    [Required]
    public string nom { get; set; }

    public string nommere { get; set; }
    public string nompere { get; set; }
    public string pays { get; set; }
    public string paysRelations { get; set; }
    public string paysnaissance { get; set; }

    [Required]
    public string prenom { get; set; }

    public string rcin { get; set; }
    public string referentiel { get; set; }
    public string resident { get; set; }
    public string secondenationalite { get; set; }
    public string selfie { get; set; }
    public string statutpro { get; set; }
    public string rib { get; set; }

    [StringLength(20)]
    public string NumeroTelephone { get; set; }

    [StringLength(100)]
    public string AutreNationalite { get; set; }

    [Required]
    [StringLength(100)]
    public string prenommere { get; set; }

    [Required]
    [StringLength(100)]
    public string prenompere { get; set; }

    public string Datedelivrance { get; set; }
    public string Motif { get; set; }
    public string Objetrelation { get; set; }

    [StringLength(50)]
    public string login { get; set; }

    [StringLength(255)]
    public string password { get; set; }

    public string commentaire { get; set; }

    // Navigation property
    [ForeignKey("clientID")]
    public virtual Client Client { get; set; }
}