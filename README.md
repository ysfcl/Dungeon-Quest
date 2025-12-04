# Oyun Adı: [Dungeon-Quest]

## Tanıtım
Bu proje, Unity kullanılarak geliştirilmiş bir 2D aksiyon oyunudur. Şövalye karakteri, düşman iskeletlerle karakterlerle etkileşimde bulunabilir ve çeşitli aksiyonlar gerçekleştirebilir. Oyun WebGL platformunda oynanabilir.

---

## Oynanış
- Oyuncu karakteri WASD veya ok tuşları ile hareket eder.  
- **E** tuşu ile saldırı, **X** tuşu ile kayma, **W** tuşu ile zıplama yapılabilir.  
- Rakip karakterin canı 3’tür ve saldırıya göre azalmaktadır.  
- Oyuncu ve rakip karakter birbirinin saldırılarından etkilenir.  

---

## Oynanabilir Link
[[Buraya tıklayınız]](https://ysfcl.itch.io/dungeon-quest)

---

## Oyuncu ve Rakip Karakter Aksiyonları
- **Oyuncu Karakter:**  
  1. Yürüme  
  2. Zıplama  
  3. Saldırı  
  4. Kayma  

- **Rakip Karakter:**  
  1. Yürüme  
  2. Saldırı  
  3. Hasar alma animasyonu  
  4. Ölüm  

> Not: Rakip karakter şu an için pasif, aksiyonlar olduğu yerde hareket etme ve hasar alma ile sınırlıdır.

---

## Ana Menü
- Yeni oyun başlatma butonu  
- Müzik sesini ayarlayan slider  
- Oyun içi SFX sesini ayarlayan slider  

---

## Sesler
- Müzik ve SFX sesleri **MusicManager_sc** ve **MainMenu_sc** scriptleri ile kontrol edilmektedir.  
- SFX ve müzik dosyaları `Assets/Audio` klasöründe yer almaktadır.

---

## Kurulum ve Çalıştırma
1. Unity ile projeyi açın (Unity 2021 veya üstü önerilir).  
2. `MainMenu` sahnesini açın ve `MainMenu_sc` scriptinde slider referanslarının doğru olduğundan emin olun.  
3. `File → Build Settings → WebGL → Build` ile WebGL build alın.  
4. Build klasörünü zipleyip itch.io veya benzeri bir platforma yükleyin.  

---

## Notlar
- Proje tek kişi tarafından geliştirilmiştir.  
- Kodlar tamamen bireysel çalışmaya aittir.  
- Oyunun ilerleyen sürümlerinde rakip karakter hareketleri AI olarak eklenecektir.
