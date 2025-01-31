
namespace MedievalAutoBattlerV2.Utilities
{
    public class Helper
    {
        public static int GetCardLevel(int power, int upperhand)
        {
            return (power + upperhand) /2;
        }
    }
}
