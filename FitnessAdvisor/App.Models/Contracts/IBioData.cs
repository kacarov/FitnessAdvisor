using App.Models.Enums;

namespace App.Models.Contracts
{
    public interface IBioData
    {
        int Age { get; }

        GenderType Gender { get; }

        double Weight { get; }

        double Height { get; }

        double NeckSize { get; }

        double WaistSize { get; }

        double HipsSize { get; }

        double BodyFatPercentage { get; }
    }
}
