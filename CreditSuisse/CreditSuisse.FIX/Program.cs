internal class Program
{
    private static void Main(string[] args)
    {
        var timeBuckets = GetTimeBucketsDictionary();
        var filePath = @"C:\Users\YURI FRANCO\Desktop\fiix_session.summary";

        var lines = File.ReadAllLines(filePath)
            .Where(msg => msg.StartsWith(" IN") && msg.Contains("35=D"))
            .Select(msg => msg.Substring(13, 8))
            .GroupBy(t => t)
            .Select(x => (chave: x.Key, valor: x.Count()));

        foreach (var line in lines)
        {
            timeBuckets[line.chave] = line.valor;
        }

        SaveCSV(timeBuckets, @"C:\Users\YURI FRANCO\Desktop\output.csv");
    }

    private static Dictionary<string, int> GetTimeBucketsDictionary()
    {
        var dict = new Dictionary<string, int>();
        var startingDate = new DateTime(2021, 02, 22, 10, 00, 00);
        var targetTime = new DateTime(2021, 02, 22, 21, 00, 00);

        for (DateTime date = startingDate; date <= targetTime; date = date.AddSeconds(1))
        {
            dict.Add(date.TimeOfDay.ToString(), 0);
        }
        return dict;
    }

    private static void SaveCSV(Dictionary<string, int> dict, string outputFilePath)
    {
        var file = dict.Select(x => $"{x.Key},{x.Value}").ToArray();
        File.WriteAllLines(outputFilePath, file);
    }
}