# Emlak-Otomasyonu

Proje detayları için -> https://blog.mustafaergec.com.tr/c-emlakci-otomasyonu-projesi-aciklama-ve-kodlari.html

Projede Entity Framework kullanılmıştır.

# Emlak Otomasyonu projesi genel olarak;

Giriş Ekranı <br>
Ana Menü ( Ev işlemlerinin yapıldığı bölüm ) <br>
Ev Düzenleme Ekranı<br>
Yeni Ev Ekleme Ekranı<br>
Ev Listeleme Ve Sorgulama Ekranı<br>
Yeni Kullanıcı Kayıt Ekranı<br>
Müşteri Ev Satış Ekranı<br>
Satılan veya Kiralanan Evlerin Sorgulandığı Sorgulama Ekranı<br>

# Emlak Otomasyonu Giriş Ekranı ve Yeni Kullanıcı Kayıt Ekranı
Projeyi açtığımızda bizleri giriş ekranı karşılamaktadır. Giriş ekranını sağ tarafta görebilirsiniz. Giriş ekranı yardımı ile projeye giriş yapabilir veya yeni kullanıcı ekleyebiliriz.<br>

Yeni kullanıcı eklemeye çalıştığımızda program yetkisiz kullanıcı ekleme işlemlerini engellemek için bizlerden bir kullanıcı şifresi isteyecektir.<br>

Kullanıcı şifre kolaylık olması amacıyla girili olarak gelmektedir.(!) ilgili Sql dosyası ve içerikleri yazının en sonunda verilmiştir.<br>

Yeni Kullanıcı Kayıt İşlemleri İçin Kullanıcı Şifresi:  123<br>

Kayıt işlemi sırasında sorulan şifre Kullanıcı Adı: Admin<br>

# Emlak Otomasyonu Yeni Ev Ekleme Ekranı
Yeni ev eklemek için ana menüde bulunan Yeni Ev Ekle Butonu kullanılabilir. Yeni Ev Ekleme ekranından ev ile ilgili bilgiler yer almaktadır. Kullanıcı İl seçtiğinde ilgili ildeki İlçeler otomatik olarak listelenmektedir.<br>

Ev yapım tarihi girildiğinde kullanıcıya ekstra bilgi olarak ev yaşı bilgisi gösterilmektedir.<br>

# Emlak Otomasyonu Ev Sorgulama Ekranı
Sorgulama ekranında kaydedilen evler çeşitli kriterlere göre sorgulanabilmektedir. Kısaca Sadece il veya İl, İlçe bilgisi girilerek, Ev Toplam Alan Bilgisi, Oda sayısı bilgisi ve ev türünü girerek, Ev Durumu bilgisi ile ve Ev tercihi bilgisi ile sorgulama yapılabilir.<br>

Sorgulanan sonuçlar yazdırılabilir veya istenilen ev bilgisi üzerine tıklayarak kayıtlı ev bilgisi silinebilir, müşteriye kiralanabilir/satılabilir.<br>

Kullanıcıya ev kiralama veya satılma işlemi sorgulama sonucunda yapılmaktadır. Aşağıda ilgili ekranın resmi yer almaktadır. Ev Satış Yap butonu tıklanarak seçili ev ile ilgili satış/kiralama işlemleri yapılabilmektedir.<br>

=> Ev Durumu ve Ev Tercihi bilgisi her ev için sorgulamada kullanılmaktadır.<br>
