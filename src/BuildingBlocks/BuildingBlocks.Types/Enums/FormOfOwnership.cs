using System.ComponentModel.DataAnnotations;

namespace BuildingBlocks.Types.Enums;

public enum FormOfOwnership
{
    [Display(Name = "Legal entity")]
    LegalEntity,

    [Display(Name = "Individual entrepreneur")]
    IndividualEntrepreneur,

    Individual
}
