namespace RentACar.Shared.Models
{
    public enum TransmissionType
    {
        Automatic,
        Manual,
        AutomatedManual,
        ContinuouslyVariable
    }

    public static class TransmissionTypeExtensions
    {
        public static string GetName(this TransmissionType transmission)
        {
            switch(transmission)
            {
                case TransmissionType.AutomatedManual:
                    return "Automated Manual";
                case TransmissionType.ContinuouslyVariable:
                    return "Continuously Variable";
                default:
                    return transmission.ToString();
            }
        }
    }
}
