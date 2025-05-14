
# A* Algoritması ile 8-Taş Bulmacası Çözümü 🎯

Bu proje, A* (A-Star) algoritması kullanarak klasik 8-Taş Bulmacasını (8 Puzzle) en kısa adımlarla çözmekte ve çözüm adımlarını kullanıcıya **görsel olarak** sunmaktadır. ASP.NET MVC mimarisiyle geliştirilmiştir.

---

## 🚀 Özellikler

- 🔢 Başlangıç ve hedef durumu elle girme veya hazır örnekleri seçme
- 🎯 Her durumu çözülebilir hale getirme (swap algoritması ile)
- 🧠 A* algoritması (F = G + H) ile çözüm hesaplama
- 📐 3x3 kutucuklarla adım adım çözüm görselleştirme
- 🎀 Responsive pembe temalı kullanıcı arayüzü
- 📘 Konu anlatımı sayfası ile A* algoritması açıklaması

## ⚙️ Kullanılan Teknolojiler

- ASP.NET Core MVC (.NET 9)
- C#
- Bootstrap 5
- HTML/CSS
- Git & GitHub

---

## 🧠 A* Algoritması Nedir?

A* algoritması, **F(n) = G(n) + H(n)** formülünü kullanarak hedefe en kısa yoldan ulaşmaya çalışan sezgisel bir algoritmadır:

- **G(n):** Başlangıçtan o ana kadar olan maliyet
- **H(n):** Hedefe olan tahmini uzaklık (heuristic)

Bu projede, **Manhattan Distance** kullanılarak A* algoritması uygulandı.

---

## 📂 Proje Yapısı

```bash
aStarAlgorithm/
├── Controllers/
├── Models/
├── Views/
├── wwwroot/
├── screens/          # Ekran görüntüleri burada
│   ├── mainPage.png
│   └── konu.png
├── Program.cs
└── README.md
