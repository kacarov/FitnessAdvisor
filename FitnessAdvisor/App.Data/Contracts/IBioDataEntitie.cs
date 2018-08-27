namespace App.Data.Contracts
{
    public interface IBioDataEntitie
    {
        int BioDataId { get; set; }

        int Age { get; set; }

        double Weight { get; set; }

        double Height { get; set; }

        double NeckSize { get; set; }

        double WaistSize { get; set; }

        double HipsSize { get; set; }

        int Gender { get; set; }
    }
}
