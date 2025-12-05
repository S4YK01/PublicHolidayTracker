using System.Net.Http;
using System.Text.Json;

public class HolidayService
{
    private static readonly HttpClient client = new HttpClient();

    public async Task<List<Holiday>> GetHolidaysAsync(int year)
    {
        string url = $"https://date.nager.at/api/v3/PublicHolidays/{year}/TR";
        var response = await client.GetStringAsync(url);

        return JsonSerializer.Deserialize<List<Holiday>>(response);
    }

    public void PrintHolidayList(List<Holiday> holidays)
    {
        foreach (var h in holidays)
        {
            Console.WriteLine($"{h.date} - {h.localName} ({h.name})");
        }
    }

    public Holiday FindByDate(List<Holiday> holidays, string date)
    {
        return holidays.FirstOrDefault(x => x.date.EndsWith(date));
    }

    public List<Holiday> FindByName(List<Holiday> holidays, string name)
    {
        return holidays
            .Where(x => x.localName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                        x.name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
