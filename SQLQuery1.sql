-- 1. Önce eski verileri temizle (İlişki sırasına göre)
DELETE FROM Districts;
DELETE FROM Cities;
DELETE FROM Regions;

-- 2. BÖLGELERİ EKLE
SET IDENTITY_INSERT Regions ON;
INSERT INTO Regions (Id, Name) VALUES (1, 'Marmara'), (2, 'İç Anadolu'), (3, 'Ege'), (4, 'Akdeniz'), (5, 'Karadeniz'), (6, 'Güneydoğu Anadolu'), (7, 'Doğu Anadolu');
SET IDENTITY_INSERT Regions OFF;

-- 3. ŞEHİRLERİ EKLE (81 İL)
SET IDENTITY_INSERT Cities ON;
INSERT INTO Cities (Id, Name, RegionId) VALUES 
(1, 'Adana', 4), (2, 'Adıyaman', 6), (3, 'Afyonkarahisar', 3), (4, 'Ağrı', 7), (5, 'Amasya', 5), (6, 'Ankara', 2), (7, 'Antalya', 4), (8, 'Artvin', 5), (9, 'Aydın', 3), (10, 'Balıkesir', 1), (11, 'Bilecik', 1), (12, 'Bingöl', 7), (13, 'Bitlis', 7), (14, 'Bolu', 5), (15, 'Burdur', 4), (16, 'Bursa', 1), (17, 'Çanakkale', 1), (18, 'Çankırı', 2), (19, 'Çorum', 5), (20, 'Denizli', 3), (21, 'Diyarbakır', 6), (22, 'Edirne', 1), (23, 'Elazığ', 7), (24, 'Erzincan', 7), (25, 'Erzurum', 7), (26, 'Eskişehir', 2), (27, 'Gaziantep', 6), (28, 'Giresun', 5), (29, 'Gümüşhane', 5), (30, 'Hakkari', 7), (31, 'Hatay', 4), (32, 'Isparta', 4), (33, 'Mersin', 4), (34, 'İstanbul', 1), (35, 'İzmir', 3), (36, 'Kars', 7), (37, 'Kastamonu', 5), (38, 'Kayseri', 2), (39, 'Kırklareli', 1), (40, 'Kırşehir', 2), (41, 'Kocaeli', 1), (42, 'Konya', 2), (43, 'Kütahya', 3), (44, 'Malatya', 7), (45, 'Manisa', 3), (46, 'Kahramanmaraş', 4), (47, 'Mardin', 6), (48, 'Muğla', 3), (49, 'Muş', 7), (50, 'Nevşehir', 2), (51, 'Niğde', 2), (52, 'Ordu', 5), (53, 'Rize', 5), (54, 'Sakarya', 1), (55, 'Samsun', 5), (56, 'Siirt', 6), (57, 'Sinop', 5), (58, 'Sivas', 2), (59, 'Tekirdağ', 1), (60, 'Tokat', 5), (61, 'Trabzon', 5), (62, 'Tunceli', 7), (63, 'Şanlıurfa', 6), (64, 'Uşak', 3), (65, 'Van', 7), (66, 'Yozgat', 2), (67, 'Zonguldak', 5), (68, 'Aksaray', 2), (69, 'Bayburt', 5), (70, 'Karaman', 2), (71, 'Kırıkkale', 2), (72, 'Batman', 6), (73, 'Şırnak', 6), (74, 'Bartın', 5), (75, 'Ardahan', 7), (76, 'Iğdır', 7), (77, 'Yalova', 1), (78, 'Karabük', 5), (79, 'Kilis', 6), (80, 'Osmaniye', 4), (81, 'Düzce', 5);
SET IDENTITY_INSERT Cities OFF;

-- 4. İLÇELERİ EKLE
-- Districts tablosunda Id belirtmediğimiz için IDENTITY_INSERT açmaya gerek yok.
INSERT INTO Districts (Name, CityId) VALUES ('Adalar', 34), ('Arnavutköy', 34), ('Ataşehir', 34), ('Avcılar', 34), ('Bağcılar', 34), ('Bahçelievler', 34), ('Bakırköy', 34), ('Başakşehir', 34), ('Bayrampaşa', 34), ('Beşiktaş', 34), ('Beykoz', 34), ('Beylikdüzü', 34), ('Beyoğlu', 34), ('Büyükçekmece', 34), ('Çatalca', 34), ('Çekmeköy', 34), ('Esenler', 34), ('Esenyurt', 34), ('Eyüpsultan', 34), ('Fatih', 34), ('Gaziosmanpaşa', 34), ('Güngören', 34), ('Kadıköy', 34), ('Kağıthane', 34), ('Kartal', 34), ('Küçükçekmece', 34), ('Maltepe', 34), ('Pendik', 34), ('Sancaktepe', 34), ('Sarıyer', 34), ('Silivri', 34), ('Sultanbeyli', 34), ('Sultangazi', 34), ('Şile', 34), ('Şişli', 34), ('Tuzla', 34), ('Ümraniye', 34), ('Üsküdar', 34), ('Zeytinburnu', 34);
INSERT INTO Districts (Name, CityId) VALUES ('Akyurt', 6), ('Altındağ', 6), ('Ayaş', 6), ('Bala', 6), ('Beypazarı', 6), ('Çamlıdere', 6), ('Çankaya', 6), ('Çubuk', 6), ('Elmadağ', 6), ('Etimesgut', 6), ('Evren', 6), ('Gölbaşı', 6), ('Güdül', 6), ('Haymana', 6), ('Kahramankazan', 6), ('Kalecik', 6), ('Keçiören', 6), ('Kızılcahamam', 6), ('Mamak', 6), ('Nallıhan', 6), ('Polatlı', 6), ('Pursaklar', 6), ('Sincan', 6), ('Şereflikoçhisar', 6), ('Yenimahalle', 6);
INSERT INTO Districts (Name, CityId) VALUES ('Aliağa', 35), ('Balçova', 35), ('Bayındır', 35), ('Bayraklı', 35), ('Bergama', 35), ('Beydağ', 35), ('Bornova', 35), ('Buca', 35), ('Çeşme', 35), ('Çiğli', 35), ('Dikili', 35), ('Foça', 35), ('Gaziemir', 35), ('Güzelbahçe', 35), ('Karabağlar', 35), ('Karaburun', 35), ('Karşıyaka', 35), ('Kemalpaşa', 35), ('Kınık', 35), ('Kiraz', 35), ('Konak', 35), ('Menderes', 35), ('Menemen', 35), ('Narlıdere', 35), ('Ödemiş', 35), ('Seferihisar', 35), ('Selçuk', 35), ('Tire', 35), ('Torbalı', 35), ('Urla', 35);
INSERT INTO Districts (Name, CityId) VALUES ('Merkez', 57), ('Ayancık', 57), ('Boyabat', 57), ('Dikmen', 57), ('Durağan', 57), ('Erfelek', 57), ('Gerze', 57), ('Saraydüzü', 57), ('Türkeli', 57);