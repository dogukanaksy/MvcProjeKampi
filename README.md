# MvcProjeKampi

ASP.NET MVC 5 ve Entity Framework ile geliştirilen, katmanlı mimariye sahip bir içerik/yazar yönetim paneli.
[Murat Yücedağ – MVC Proje Kampı](https://www.youtube.com/@MuratYucedag) eğitim serisi kapsamında, ders ders ilerlenerek geliştirilmektedir.

> 🚧 Durum: Devam ediyor (63. derse kadar tamamlandı)

## Teknolojiler

- ASP.NET MVC 5 (.NET Framework)
- Entity Framework (Code First) · MS SQL Server
- Katmanlı mimari: Entity · DataAccess · Business · UI
- Generic Repository pattern
- FluentValidation
- AdminLTE · Bootstrap

## Proje yapısı

```
EntityLayer       Veritabanı varlıkları (Category, Heading, Content, Writer, Message, Contact, About...)
DataAccessLayer   DbContext, generic repository, EF implementasyonları
BusinessLayer     İş kuralları, servisler (Manager sınıfları) ve validasyonlar
MvcProjeKampi     MVC arayüzü: controller'lar, view'lar, admin paneli
```

## Özellikler

- Admin paneli (AdminLTE)
- Kategori, başlık, içerik ve yazar yönetimi (CRUD)
- Gelen / giden mesaj kutusu ve iletişim formu yönetimi
- Hakkımızda sayfası yönetimi
- İstatistik sayfası (LINQ sorguları)
- Form validasyonları (FluentValidation)

## Ekran görüntüleri

![Ekran görüntüsü 1](Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202026-11-07%20020849.png)
![Ekran görüntüsü 2](Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202026-11-07%20020916.png)

## Çalıştırma

1. Projeyi Visual Studio ile açın (`MvcProjeKampi.sln`).
2. `MvcProjeKampi/Web.config` içindeki bağlantı dizesini kendi SQL Server'ınıza göre düzenleyin.
3. Package Manager Console'da `DataAccessLayer` projesini seçip `Update-Database` çalıştırın.
4. `MvcProjeKampi` projesini başlangıç projesi yapıp çalıştırın.

## Yol haritası

- [ ] Kampın kalan derslerini tamamlamak (giriş/yetkilendirme, yazar paneli, vitrin sayfası)
- [ ] Projeyi ASP.NET Core'a taşımak
