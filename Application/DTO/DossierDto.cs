namespace Application.DTO
{
    public record DossierDto(
        Guid Id,
        string UniteProprietaire,
        List<string> NatureDossier,
        List<string> TypeDossier,
        DateTime DateConstatations,
        DateTime? DateCloturePv,
        DateTime DateEnregistrement
    );
}
