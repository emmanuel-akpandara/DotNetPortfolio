namespace Adventures.Web.Helpers
{
    public class TravelTypeNotFoundException : ApplicationException { }

    public class TravelHelper
    {

        public enum TravelType
        {
            walking_vacation,
            safari,
            self_drive
        }
        public static TravelType GetTravelType(string description)
        {
            if (description.Contains("trail"))
            {
                return TravelType.walking_vacation;
            }
            if (description.Contains("game"))
            {
                return TravelType.safari;
            }
            if (description.Contains("road trip"))
            {
                return TravelType.self_drive;
            }
            else
            {
                throw new TravelTypeNotFoundException();
            }
        }
    }
}

