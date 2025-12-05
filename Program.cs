using System;

class Program
{
    static async Task Main(string[] args)
    {
        HolidayService service = new HolidayService();

        Dictionary<int, List<Holiday>> holidayCache = new Dictionary<int, List<Holiday>>();

        for (int year = 2023; year <= 2025; year++)
        {
            holidayCache[year] = await service.GetHolidaysAsync(year);
        }

        while (true)
        {
            Console.WriteLine("===== PublicHolidayTracker =====");
            Console.WriteLine("1. Tatil listesini göster (yıl seçmeli)");
            Console.WriteLine("2. Tarihe göre tatil ara (gg-aa formatı)");
            Console.WriteLine("3. İsme göre tatil ara");
            Console.WriteLine("4. Tüm tatilleri 3 yıl boyunca göster (2023–2025)");
            Console.WriteLine("5. Çıkış");
            Console.Write("Seçiminiz: ");

            string secim = Console.ReadLine();
            Console.WriteLine();

            switch (secim)
            {
                case "1":
                    Console.Write("Yıl giriniz (2023–2025): ");
                    int year = int.Parse(Console.ReadLine());

                    if (holidayCache.ContainsKey(year))
                        service.PrintHolidayList(holidayCache[year]);
                    else
                        Console.WriteLine("Geçersiz yıl!\n");
                    break;

                case "2":
                    Console.Write("Tarih (gg-aa): ");
                    string date = Console.ReadLine();

                    foreach (var kv in holidayCache)
                    {
                        var result = service.FindByDate(kv.Value, date);
                        if (result != null)
                        {
                            Console.WriteLine($"{kv.Key} → {result.date} - {result.localName}");
                        }
                    }
                    break;

                case "3":
                    Console.Write("Tatil adı giriniz: ");
                    string isim = Console.ReadLine();

                    foreach (var kv in holidayCache)
                    {
                        var list = service.FindByName(kv.Value, isim);

                        if (list.Any())
                        {
                            Console.WriteLine($"\n--- {kv.Key} ---");
                            foreach (var h in list)
                                Console.WriteLine($"{h.date} - {h.localName}");
                        }
                    }
                    Console.WriteLine();
                    break;

                case "4":
                    for (int y = 2023; y <= 2025; y++)
                    {
                        Console.WriteLine($"\n----- {y} Tatilleri -----");
                        service.PrintHolidayList(holidayCache[y]);
                    }
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Hatalı seçim!\n");
                    break;
            }

            Console.WriteLine();
        }
    }
}
