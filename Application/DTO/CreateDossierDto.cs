namespace Application.DTO
{
    public record CreateDossierDto(
        string UniteProprietaire,
        List<string> NatureDossier,
        List<string> TypeDossier,
        DateTime DateDesConstatations,
        DateTime? DateDeClotureDuPv,
        DateTime DateEnregistrement
    );
}
