USE [Dictionary]
GO
/****** Object:  Table [dbo].[Tbl_Genelis]    Script Date: 22.05.2019 05:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Genelis](
	[id] [int] NOT NULL,
	[KelimeSayisi] [int] NOT NULL,
	[ogrenilmisKelime] [int] NOT NULL,
	[ogrenilenKelime] [int] NOT NULL,
	[Dogru] [int] NOT NULL,
	[Yanlis] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_Genelis] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Kelimeler]    Script Date: 22.05.2019 05:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Kelimeler](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tr] [varchar](50) NULL,
	[eng] [varchar](50) NULL,
	[turu] [varchar](30) NULL,
	[ogrenilme] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_ogrenilecek]    Script Date: 22.05.2019 05:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_ogrenilecek](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Ogrenilecekid] [varchar](50) NULL,
	[GosterilecegiTarih] [varchar](10) NULL,
	[OgrenmeSeviyesi] [tinyint] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Ogrenilen]    Script Date: 22.05.2019 05:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Ogrenilen](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Ogrenilenid] [varchar](10) NULL,
	[Ay] [varchar](2) NULL,
	[Yil] [varchar](4) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Tbl_Genelis] ([id], [KelimeSayisi], [ogrenilmisKelime], [ogrenilenKelime], [Dogru], [Yanlis]) VALUES (1, 0, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Tbl_Kelimeler] ON 

INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (1, N'araba', N'car', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2, N'aşınma', N'corrosion', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (3, N'korse', N'corset', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (4, N'cenaze alayı', N'cortege', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (5, N'kosinüs', N'cosine', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (6, N'kozmik', N'cosmic', N'Sıfat', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (7, N'kat', N'cot', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (8, N'çıldırmak', N'craze', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (9, N'emir', N'dictation', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (10, N'diktatör', N'dictator', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (11, N'pamuk', N'cotton', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (12, N'parmak', N'digit', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (1027, N'Şemsiye', N'Umbrella', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2027, N'Abate', N'Azaltmak', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2028, N'Yetenek', N'Ability', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2029, N'Konut', N'Abode', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2031, N'Üstüne', N'Above', N'Edat', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2032, N'Denklik Belgesi', N'Accredit', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2033, N'Akustik', N'Acoustics', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2034, N'Aklamak', N'Acquit', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2036, N'Ekşi', N'Acrid', N'Sıfat', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2038, N'Yapışmak', N'Adhere', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2039, N'Yönetici', N'Administrator', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2041, N'Tapınak', N'Adore', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2042, N'Süslemek', N'Adorn', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2043, N'Erişkin', N'Adult', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2045, N'İlerleme', N'Advence', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2047, N'Tavsiye', N'Advice', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2048, N'İzin vermek', N'Allow', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2050, N'Anarşi', N'Anarchy', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2052, N'Antika', N'Antic', N'Sıfat', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2054, N'Aritmmetik', N'Arithmetic', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2056, N'Asya', N'Asia', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2057, N'Sanatçı', N'Artist', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2060, N'Geriye', N'Astern', N'Zarf', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2063, N'Fırın', N'Baker', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2066, N'Top', N'Ball', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2067, N'Yasaklamak', N'Ban', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2068, N'Patlama', N'Bang', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2071, N'Barikat', N'Barricade', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2072, N'Bere', N'Barret', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2075, N'Güzel', N'Beautiful', N'Sıfat', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2078, N'Bomba', N'Bomb', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2081, N'Hesap', N'Calculus', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2084, N'Karton', N'Carton', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2085, N'Merkez', N'Center', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2086, N'Şampiyon', N'Campion', N'Sıfat', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2089, N'Peynir', N'Cheese', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2090, N'Talep', N'Claim', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2091, N'Sınıf', N'Class', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2093, N'Kapatmak', N'Close', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2094, N'Soğuk', N'Cold', N'Sıfat', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2097, N'Yapı', N'Construction', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2098, N'Bilgisayar', N'Computer', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2099, N'Veri', N'Data', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2100, N'Ölü', N'Dead', N'Sıfat', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2103, N'Veritabanı', N'Database', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2104, N'Ondalık', N'Decimal', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2105, N'Üzmek', N'Depress', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2106, N'Bırakmak', N'Desert', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2109, N'Geliştirmek', N'Develop', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2110, N'Sözlük', N'Dictionary', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2113, N'Köşegen', N'Diagonal', N'Sıfat', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2114, N'Rehber', N'Directory', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2115, N'Bölmek', N'Divide', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2116, N'Tanrısal', N'Divine', N'Sıfat', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2030, N'Düşük', N'Abortion', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2035, N'Aktör', N'Actor', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2040, N'Amiral', N'Admiral', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2044, N'Macera', N'Adventure', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2049, N'Yalnız', N'Alone', N'Sıfat', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2051, N'Pozitif elektrot', N'Anode', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2055, N'Ordu', N'Army', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2058, N'Sormak', N'Ask', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2061, N'Otomobil', N'Auto', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2064, N'Kel', N'Bald', N'Sıfat', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2069, N'Banka', N'Bank', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2073, N'Banyo', N'Bathroom', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2077, N'Ötede', N'Beyond', N'Edat', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2079, N'Yay', N'Bow', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2082, N'Sakin', N'Calm', N'Sıfat', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2092, N'Saat', N'Clock', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2095, N'Renk', N'Color', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2102, N'Hasar', N'Damage', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2108, N'Ayrıntı', N'Detail', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2112, N'Diyagram', N'Diagram', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2037, N'Adres', N'Address', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2046, N'Yarar', N'Advantage', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2053, N'Nisan', N'April', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2059, N'Atamak', N'Assing', N'Fiil', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2062, N'Yedek', N'Backup', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2065, N'Balya', N'Bale', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2070, N'Kısır', N'Barren', N'Sıfat', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2074, N'Ayı', N'Bear', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2076, N'Önce', N'Before', N'Zarf', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2080, N'Böcek', N'Bug', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2083, N'Kanal', N'Canal', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2087, N'Karakter', N'Character', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2096, N'Konser', N'Concert', N'İsim', 0)
GO
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2101, N'Gün', N'Day', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2107, N'Masaüstü', N'Desktop', N'İsim', 0)
INSERT [dbo].[Tbl_Kelimeler] ([id], [tr], [eng], [turu], [ogrenilme]) VALUES (2111, N'Kazmak', N'Dig', N'Fiil', 0)
SET IDENTITY_INSERT [dbo].[Tbl_Kelimeler] OFF
