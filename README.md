# Turkcell Esirket Servis Entegrasyon Örneği

Bu proje, Turkcell e-Şirket ürünleri API entegrasyonu için geliştirilmiş .NET Web API uygulamasıdır.

Servis, OAuth 2.0 ile token alır ve turkcell e-şirket ürünleri endpoint’lerine yetkili istek gönderir.

### API Dokümantasyonu

Tüm request/response modelleri, endpoint detayları ve teknik dökümantasyon için:

👉 https://developer.turkcellesirket.com

Servis detayları ve payload yapıları ilgili dokümantasyonda yer almaktadır.

### Kimlik Doğrulama (OAuth 2.0)

Servis, OAuth 2.0 authentication kullanmaktadır.

#### Auth Endpoint

Canlı ortam:

https://core.turkcellesirket.com/v1/token

Test ortamı:

https://coretest.isim360.com/v1/token

#### Token İsteği (Form URL Encoded)

username=XXX
password=XXX
client_id=serviceApi

Örnek Token Response:

```json
{
  "access_token": "xxx...",
  "refresh_token": "",
  "expires_in": "86400",
  "token_type": "Bearer"
}
```

Tekrar tekrar token servisi çağrılmaması için örnekte de olduğu gibi token süresi expires_in alanına göre cache’lenir.

### Projeyi Çalıştırma

Gereksinimler:

.NET 9 SDK (veya projede tanımlı sürüm)

Visual Studio 2022+ veya VS Code

Projeyi Çalıştırma:

dotnet restore
dotnet run

Swagger UI:

https://localhost:5001/swagger

Konfigürasyon

appsettings.json içinde Turkcell ayarları yapılmalıdır:

 ```json
"Integration": {
  "Auth": {
    "Username": "yourUserName",
    "Password": "yourPassword",
    "ClientId": "serviceApi",
    "AuthUrl": "https://coretest.isim360.com/v1/token"
  },
  "Services": {
    "Efatura": {
      "BaseUrl": "https://efaturaservicetest.isim360.com"
    },
    "Eirsaliye": {
      "BaseUrl": "https://eirsaliyeservicetest.isim360.com"
    },
    "Ebilet": {
      "BaseUrl": "https://ebiletservicetest.isim360.com"
    }
  }
}
```

Mimari:

OAuth2 Token alma servisi
MemoryCache ile token yönetimi
Typed HttpClient kullanımı
Swagger ile API test imkanı
Serilog ile loglama altyapısı

📌 Önemli Notlar

Swagger UI erişimi için authentication zorunlu değildir.

Servise yapılan çağrılarda Bearer token otomatik olarak eklenir.

Token süresi dolmadan önce cache yenilenir.

Destek

Entegrasyon süreçleri öncesinde Turkcell e-Şirket satış ekibi ile iletişime geçilmelidir:

📧 satis@eplatform.com.tr
