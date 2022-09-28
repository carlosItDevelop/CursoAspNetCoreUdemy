namespace Cooperchip.ITDeveloper.Domain.Mensageria.Validations.Helpers
{
    public class StringUtils
    {
        public static string ApenasNumeros(string valor)
        {
            var onlyNumber = "";
            foreach (var s in valor)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber;
        }
    }
}
