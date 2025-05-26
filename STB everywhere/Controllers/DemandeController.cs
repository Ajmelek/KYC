using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STB_everywhere.Data;

[ApiController]
[Route("api/[controller]")]
public class DemandeController : ControllerBase
{
    private readonly ILogger<DemandeController> _logger;
    private readonly KycDbContext _context;

    public DemandeController(ILogger<DemandeController> logger, KycDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost("AddDemande")]
    public async Task<IActionResult> AddDemande([FromBody] CreateDemandeModificationClientDto demandeDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var demande = new DemandeModificationClient
            {
                clientID = demandeDto.ClientID,
                etat = 0,
                IndicateurTel = demandeDto.IndicateurTel,
                adresse = demandeDto.Adresse,
                adresseComplete = demandeDto.AdresseComplete,
                adresseLieuTravail = demandeDto.AdresseLieuTravail,
                agence = demandeDto.Agence,
                agenceResidence = demandeDto.AgenceResidence,
                cin = demandeDto.Cin,
                civilite = demandeDto.Civilite,
                clientautrebanque = demandeDto.Clientautrebanque,
                codepostal = demandeDto.Codepostal,
                confidenceRate = demandeDto.ConfidenceRate,
                dateRDV = demandeDto.DateRDV,
                datecin = demandeDto.Datecin,
                datenaissance = demandeDto.Datenaissance,
                deviseCompteReserved = demandeDto.DeviseCompteReserved,
                environment = demandeDto.Environment,
                etatcivil = demandeDto.Etatcivil,
                gouvernorat = demandeDto.Gouvernorat,
                mailprincipal = demandeDto.Mailprincipal,
                nationalite = demandeDto.Nationalite,
                nom = demandeDto.Nom,
                nommere = demandeDto.Nommere,
                nompere = demandeDto.Nompere,
                pays = demandeDto.Pays,
                paysRelations = demandeDto.PaysRelations,
                paysnaissance = demandeDto.Paysnaissance,
                prenom = demandeDto.Prenom,
                rcin = demandeDto.Rcin,
                referentiel = demandeDto.Referentiel,
                resident = demandeDto.Resident,
                secondenationalite = demandeDto.Secondenationalite,
                selfie = demandeDto.Selfie,
                statutpro = demandeDto.Statutpro,
                rib = demandeDto.Rib,
                NumeroTelephone = demandeDto.NumeroTelephone,
                AutreNationalite = demandeDto.AutreNationalite,
                prenommere = demandeDto.Prenommere,
                prenompere = demandeDto.Prenompere,
                Datedelivrance = demandeDto.Datedelivrance,
                Motif = demandeDto.Motif,
                Objetrelation = demandeDto.Objetrelation,
                login = demandeDto.Login,
                password = demandeDto.Password,
                commentaire = demandeDto.Commentaire,
                dateDemande = DateTime.Now
            };

            _context.DemandeModificationClients.Add(demande);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Success = true,
                Message = "Demande created successfully",
                DemandeId = demande.ID
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating demande");
            return StatusCode(500, new
            {
                Success = false,
                Message = "An error occurred while creating the demande"
            });
        }
    }
    [HttpGet("GetAllDemandes")]
    public async Task<IActionResult> GetAllDemandes()
    {
        try
        {
            var demandes = await _context.DemandeModificationClients
                .OrderByDescending(d => d.dateDemande) // Newest first (optional)
                .ToListAsync();

            return Ok(new
            {
                Success = true,
                Message = "All demands retrieved successfully",
                Data = demandes
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving demands");
            return StatusCode(500, new
            {
                Success = false,
                Message = "An error occurred while retrieving demands"
            });
        }
    }
}