# FilmTavsiye Projesi

### .Net Core Web API - Film Tavsiye 


> PostgreSql veritabanı kullanılmıştır.

### 

> Hosted Service yöntemi ile her 1 saatte TMDB API'ına istek atarak verileri eşitler.

### 

> .NET 7 ile N-Tier Architecture olarak inşa edilmiştir.

### 

Projeyi çalıştırmadan önce appsettings.json dosyasından konfigürasyonlarınızı yapınız.
```javascript
{
  "ConnectionStrings": {
    "WebApiDatabase": "Host=localhost; Database=FilmTavsiye; Username=postgres; Password=***"
  },
  "ApiKeys": {
    "TMDB": "***"
  },
  "HostMail": {
    "Port": 587,
    "HostMailServer": "smtp-mail.outlook.com",
    "SenderMail": "***@outlook.com.tr",
    "SenderPassword": "***"
  }
}
```

> İlişkisel tablolardan veri çekilirken Eager Loading yöntemi kullanılmaktadır.

### 

> Bearer JWT Authentication kullanılmıştır. Projeyi uzatmamak için User tablosu açılmamıştır.
> Statik kullanıcı adı ve şifre kullanılmıştır. (Kullanıcı Adı ve Şifre: Test)

### 

> NUnit ile Birim Testleri yapılmıştır.

### 

> Postman Collection dosyasını indirerek EndPoint'leri test edebilirsiniz.