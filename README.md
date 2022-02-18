
# MyCarParking
Veritabanı ile basit CRUD(Create-Read-Update-Delete) işlemleri yapan, Ototparka yalnızca beş araç girişine izin veren ve sadece admin kullanıcısının tüm otoparktaki kişileri görmesini sağlayan bir otopark projesidir.

## Gereksinimler
- ASP.NET CORE MVC 5
- Ajax
- Singleton Pattern
- Repository Pattern
- PostgreSql
## Gerekli Kurulumlar
-   Bir dizinde açtığınız terminalde aşağıdaki komut satırı ile repo'nun bir klonunu yerel makinenize indiriniz:  `https://github.com/ceydatekin/MyCarParking.git`
    
-   Repo yerel makinenize indikten sonra  `MyCarParking.git isimli dosyanızı visual-studio ile açınız.` 
    
-   Gerekli paket gereksinimlerini `Nuget-paket-yöneticisinden` indiriniz.
- .Net 5 kullanıldığı için versiyonlarına dikkat ediniz.
- postgresql veya başka bir veri tabanından yararlanarak aşağıdaki tablolarınızı ekleyiniz. 

>   admin tablosu

| id | int |
|--|--|
| username | text |
| surname | text  |
|--|--|
| password| text  |
>   carpark tablosu

| id | int |
|--|--|
| carplate| text |
| start| text  |

>   tenant tablosu

| id | int |
|--|--|
| name| text |
| surname | text  |
|--|--|
| plate| text  |
- `Scaffold-DbContext "Server=localhost;Database=myparking;Port=5432;User Id=postgres;Password=*****" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir ParkContext -force` komutu ile database'inizi projenize dahil edin.



## To Do List Özellikleri
:round_pushpin: Dosyanızı Çalıştırdığınızda ilk karşınıza dört seçenek gelecektir bu seçeneklerden 3 tanesi kimlik bilgisi istemezken admin konumuna ulaşmak için kimlik bilgisine ihtiyaç vardır. Butonlara tıklandılığında `modal` açılır ve ilgili formlar doldurulur.
>username="admin"
>password="123"

![1](https://user-images.githubusercontent.com/54938901/154643086-0a7aafd0-6c6d-43d7-8104-c21022aa7d78.png)

:round_pushpin:Programımdaki kullanılan dosya yapısı aşağıdaki gibidir.


![2](https://user-images.githubusercontent.com/54938901/154643104-3dd48a89-e07f-400e-adfd-f7dbebb795f0.png)

## Proje Detayı

> Projemiz bir ASP.NET Core 5 Projesidir.
 - [ ] `Repository` Dosyası ***Abstract yada Interface***  olarak **CRUD** işlemlerini yaparak kod tekrarını önlemeye yardımcı olur.
 - [ ] `Manager` Dosyası ***Repository***  den kalıtılmış olup gerekli veri tabanı işlemlerinin yapılmasını sağlar.
 - [ ] `APIController`Dosyası ajaxtan gelen istekleri karşılayan fonksiyonların bulunduğu dosyadır.
 - [ ] `Helper`Dosyası giriş işlemleri için kullanılan **Session** yapısına yardımcı dosyadır.

