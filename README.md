# Ömer Faruk Akkaya 3.Hafta Ödevi
***
![Vehicle](https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/assignment-3-watarzie/blob/main/PayCore-HW3/ScreenShots/VehicleTable.png?raw=true)
![Container](https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/assignment-3-watarzie/blob/main/PayCore-HW3/ScreenShots/ContainerTable.png?raw=true)
***
## Ödev Gereksinimleri
* Sistemde 2 Adet SQL tablosu kullanılmıştır.
* Bu tabloları en az 2 araç ve her araç için rastgele  8 er adet container içerecek
şekilde doldurunuz.
* Konumlar gerçek konum olabilir.
* Sistemdeki tum araçları listeleyen ve yeni bir araç ekleyen  end pointleri ekleyiniz.  
(VehicleController)
* Arac bilgisini guncelleyen bir api ekleyiniz.
* Sistemdeki aracı silecek bir delete apisi ekleyiniz. Bu api araca ait container
bilgisini varsa onları da silecek şekilde çalışmalıdır
* Container ve Vehicle ilişkisi, container uzerindeki VehicleId uzerinden kurulmustur.
* Sistemdeki tum container listeleyen ve  yeni bir container ekleyen apileri ekleyiniz.
(ContainerController)
* Container bilgisini güncelleyecek bir api ekleyiniz. Güncelleme sırasında container
tablosundaki VehicleId nin güncellenmediğinden emin olunuz.
* Container silecek bir api ekleyiniz.
* VehicleId ile istek yapıldığında o araca ait tum konteynerlari listeleyen apiyi
ekleyiniz.
* Yeni bir api ekleyip 2 adet parametre aliniz. VehicleId ve N(küme sayısı). Araca ait
containerlari eşit eleman olacak şekilde N kümeye ayırıp tum kumeleri tek
response olarak hazirlayiniz.
## Installation
***
```
git clone https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/assignment-3-watarzie.git
```
## Usage
*** 
* Projeyi clone ettikten sonra Visual Studio ile birlikte çalıştırabilirsiniz.
* appsetttings dosyası içerisinden veritabanı bağlantısı için <b>connectionstringi<b> kendi veritabanınıza göre uyarlayınız
```
"ConnectionStrings": {
    "PostgreSqlConnection": "User ID=youruserid;Password=Yourpassword;Server=Yourservername;Port=yourport;Database=Databasename;Integrated Security=true;Pooling=true;"
```
## Teknolojiler
***
* [Automapper](https://automapper.org/): version 10.1.1
* [FluentNHibernate](https://www.nuget.org/packages/FluentNHibernate/): version 3.1.0
* [Nhibernate](https://www.nuget.org/packages/NHibernate): version 5.3.12
* [Npgsql](https://www.npgsql.org/): version 5.0.14
## Swagger Ekran Görüntüsü
***
![Swagger](https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/assignment-3-watarzie/blob/main/PayCore-HW3/ScreenShots/Swagger.png?raw=true)






