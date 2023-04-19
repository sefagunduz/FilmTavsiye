# FilmTavsiye
.Net Core Web API - Film Tavsiye Servisi


PostgreSql veritabanı kullanılmıştır.
Hosted Service yöntemi ile her 1 saatte TMDB API'ına istek atarak verileri eşitler.
.NET 7 ile N-Tier Architecture olarak inşa edilmiştir.
Projeyi çalıştırmadan önce appsettings.json dosyasından konfigürasyonlarınızı yapınız.
İlişkisel tablolardan veri çekilirken Eager Loading yöntemi kullanılmaktadır.

Beare JWT Authentication kullanılmıştır. Projeyi uzatmamak için User tablosu açılmamıştır.
Statik kullanıcı adı ve şifre kullanılmıştır. (Kullanıcı Adı ve Şifre: Test)
