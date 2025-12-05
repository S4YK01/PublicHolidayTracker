# 🎉 PublicHolidayTracker

Türkiye'nin **2023–2025** yılları arasındaki resmi tatil bilgilerini **Nager.Date API** kullanarak alan, konsol üzerinden kolay arama ve listeleme yapan bir **C# Console Application**.

---

## 🖥️✨ Uygulama Ekran Görüntüleri & Akış

### 🏠 **Ana Menü**
```
===== PublicHolidayTracker =====
1. Tatil listesini göster (yıl seçmeli)
2. Tarihe göre tatil ara (gg-aa formatı)
3. İsme göre tatil ara
4. Tüm tatilleri 3 yıl boyunca göster (2023–2025)
5. Çıkış
Seçiminiz:
```
🎯 *Kullanıcı dostu sade menü yapısı*

---

### 📅 **Yıllık Tatil Listesi Çıktısı**
```
2024-04-23 - Ulusal Egemenlik ve Çocuk Bayramı 🇹🇷
2024-05-01 - Emek ve Dayanışma Günü 🛠️
2024-05-19 - Atatürk'ü Anma, Gençlik ve Spor Bayramı 🕊️
...
```
🗓️ *Tarihler otomatik olarak API'den çekilir*

---

### 🔎 **Tarihe Göre Arama (gg-aa)**
```
Aranan tarih: 01-05
2023 → 2023-05-01 - Emek ve Dayanışma Günü
2024 → 2024-05-01 - Emek ve Dayanışma Günü
2025 → 2025-05-01 - Emek ve Dayanışma Günü
```
📌 *Tarihi yalnızca gün-ay formatında girerek 3 yıl arasında sorgu yapılabilir*

---

### 🔍 **İsme Göre Arama**
```
Aranan kelime: bayram 🎉

--- 2023 ---
2023-04-23 - Ulusal Egemenlik ve Çocuk Bayramı
2023-05-19 - Atatürk'ü Anma, Gençlik ve Spor Bayramı

--- 2024 ---
...
```
💡 *Hem localName hem name içinde arama yapılır*

---

## 🌐 Kullanılan API Adresleri
```
https://date.nager.at/api/v3/PublicHolidays/2023/TR
https://date.nager.at/api/v3/PublicHolidays/2024/TR
https://date.nager.at/api/v3/PublicHolidays/2025/TR
```
⚡ *Her yıl için ayrı sorgu, önbelleğe alınmış şekilde çalışır*

---

## 🔧 Kullanılan Sınıf — Holiday.cs
```csharp
class Holiday
{
    public string date { get; set; }
    public string localName { get; set; }
    public string name { get; set; }
    public string countryCode { get; set; }
    public bool fixed { get; set; }
    public bool global { get; set; }
}
```
🧱 *API JSON yapısına birebir uyumlu model*

---

## ⚙️ Uygulama Özellikleri
- 🛰️ API üzerinden JSON formatında resmi tatil verisi alma
- 🔄 JSON → C# sınıf dönüşümü
- 📁 2023–2025 tatillerinin başlangıçta otomatik yüklenmesi
- 📅 Yıla göre tatil listeleme
- 🔎 Tarihe göre arama (gg-aa formatı)
- 📝 İsim ile tatil araması
- 🧾 3 yılın tamamını toplu gösterme
- 🎛️ Menü tabanlı kullanıcı arayüzü

---

## 📂 Proje Klasör Yapısı
```
PublicHolidayTracker
│   Program.cs
│   Holiday.cs
│   HolidayService.cs
│   README.md
```
📦 *Temiz ve düzenli bir proje yapısı*

---

## 👤 Geliştirici Bilgileri
**Ceyhun Emre Şener — 20230108065**

📘 *Görsel Programlama Dersi Vize Ödevi kapsamında hazırlanmıştır.*
