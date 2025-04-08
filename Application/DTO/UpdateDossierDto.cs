namespace Application.DTO
{
    public record UpdateDossierDto(
        string UniteProprietaire,
        List<string> NatureDossier,
        List<string> TypeDossier,
        DateTime DateDesConstatations,
        DateTime? DateDeClotureDuPv,
        DateTime DateEnregistrement
    );
}
