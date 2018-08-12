using App.Models.Enums;

namespace App.Models.Contracts
{
    public interface ISupplement
    {
        string Brand { get; }

        string Name { get; }

        SupplementCategoryType Category { get; }

        int ServingSize { get; }

        string Description { get; }
    }
}
