# MovieStore
Patika back-end project
# Movie Store Uygulaması

Bu proje, Movie Store uygulamasının servislerini sağlamak için tasarlanmıştır. Uygulama, film, oyuncu, yönetmen ve müşteri verilerini yönetmeyi ve müşterilerin filmleri satın almasını kolaylaştırmayı amaçlamaktadır.

## Proje Yapısı

1. **Film Özellikleri:**
   - Film Adı
   - Film Yılı
   - Film Türü
   - Yönetmen
   - Oyuncular
   - Fiyat

2. **Oyuncu Özellikleri:**
   - İsim
   - Soyisim
   - Oynadığı Filmler

3. **Yönetmen Özellikleri:**
   - İsim
   - Soyisim
   - Yönettiği Filmler

4. **Müşteri (Customer) Özellikleri:**
   - İsim
   - Soyisim
   - Satın Aldığı Filmler
   - Favori Türler

5. **Customer Giriş (Login) Endpoint'i:**
   - Yetkisiz kullanıcılar uygulama içerisinden satın alma işlemi yapamamalıdır.

6. **Satın Alma İşlemi Siparişler:**
   - Satın alan müşteri
   - Satın alınan film
   - Fiyat
   - Satın alma tarihi
   - Müşteri bazlı satın alma verisi listelenerek siparişlerin yönetimi sağlanmalıdır.

## Uygulama Gereksinimleri

1. **Film İşlemleri:**
   - Film Ekleme/Silme/Güncelleme/Listeleme işlemleri yapılmalıdır.

2. **Müşteri İşlemleri:**
   - Müşteri Ekleme/Silme işlemleri yapılmalıdır.

3. **Oyuncu İşlemleri:**
   - Oyuncu Ekleme/Silme/Güncelleme/Listeleme işlemleri yapılmalıdır.

4. **Yönetmen İşlemleri:**
   - Yönetmen Ekleme/Silme/Güncelleme/Listeleme işlemleri yapılmalıdır.

5. **Film Satın Alma:**
   - Müşteri istediği bir filmi uygulama üzerinden satın alabilir.

## Teknik Gereksinimler

1. **Entity ve Input/Output:**
   - Entity objeleri input/output olarak kullanılmamalı, model ve DTO'lar kullanılmalıdır. Automapper kütüphanesi ile objeler birbirine dönüştürülmelidir.

2. **Servis İşlemleri ve Validasyon:**
   - Controller içerisinde servis işleri yapılmamalı, her servisin bir validation sınıfı olmalıdır. Uygulama, sıkı kurallar ile korunmalı ve tüm validasyonlar yazılmalıdır.

3. **Exception ve Loglama:**
   - Exception ve loglama altyapısı middleware kullanılarak yazılmalıdır. Uygulama yapılan her request ve response console'a yazılarak loglanmalıdır. Hata ve validasyon hataları anlamlı bir şekilde console'a log olarak yazdırılmalıdır. Loglama yöntemi uygulama içerisine yayılmamalı, gerektiğinde sadece bir noktada değişiklik yaparak loglama şekli değiştirilebilmelidir.

4. **Bağımlılık Yönetimi:**
   - Proje içerisinde bağımlılık yaratılmamasına dikkat edilmeli, gerekli noktalarda DI Container ile Dependency Injection kullanılarak bağımlılıklar tek bir noktadan yönetilmelidir.

5. **Authentication ve Authorization:**
   - Projeye temel seviyede bir Authentication ve Authorization yapısı implemente edilmelidir. Satın alma endpoint'i sadece müşteri tarafından kullanılacak bir endpoint olmalıdır.

6. **Birim Testleri:**
   - Projede birim testleri eksiksiz şekilde yazılmalıdır. Tüm testler hatasız çalışmalıdır.

7. **Silme Servisleri ve Veri Tutarlılığı:**
   - Silme servislerinde veri tutarlılığı dikkate alınmalıdır. Diğer tablolarda ilişkili verisi bulunan kayıtlar silinemez.

## Uygulama Notları

Bu README dosyası, projenin temel gereksinimlerini ve yapısı ile ilgili bilgileri içermektedir. Proje geliştirilirken belirtilen gereksinimler ve kurallar doğrultusunda ilerlenmelidir. Herhangi bir soru veya sorun için proje ekibine danışılmalıdır. Projenin başarıyla tamamlanması ve tüm gereksinimlerin karşılanması temennisiyle!

