using System.Globalization;

class Program {
    public static void Main(string[] args) {
        Console.Clear();

        // var data = new DateTime(2003, 6, 10);
        var data = DateTime.Now;

        // Formatação de Datas
        // var formatada = string.Format("{0:u}", data);

        // Comparação de Datas
        // if (data.Date == DateTime.Now.Date) {
        //    Console.WriteLine("É Hoje mesmo");
        // }

        // Usando o CultureInfo
        // var br = new CultureInfo("pt-BR");
        // var pt = new CultureInfo("pt-PT");
        // var en = new CultureInfo("en-US");
        // var de = new CultureInfo("de-DE");
        // var atual = CultureInfo.CurrentCulture;

        // Console.WriteLine(data.ToString("D", pt));
        // Console.WriteLine(data.ToString("D", en));
        // Console.WriteLine(data.ToString("D", de));
        // Console.WriteLine(data.ToString("D", atual));

        // Usando TimeZones
        // var dataUtc = DateTime.UtcNow;

        // Console.WriteLine(dataUtc);
        // Console.WriteLine(dataUtc.ToLocalTime());

        // var timezoneMontanhas = TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time");
        // Console.WriteLine(timezoneMontanhas);

        // var conversao = TimeZoneInfo.ConvertTimeFromUtc(dataUtc, timezoneMontanhas);
        // Console.WriteLine(conversao);

        // Usando TimeSpan
        // var spanTempo = new TimeSpan(9, 5, 32, 19, 25);
        // Console.Write(spanTempo);

        // Mais métodos legais
        // Console.WriteLine(DateTime.DaysInMonth(DateTime.Now.Year, 6));
        // Console.WriteLine(DateTime.Now.IsDaylightSavingTime());
    }

    
}