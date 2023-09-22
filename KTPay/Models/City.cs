namespace KTPay.Models {
    
    public sealed class City {
    
        // City ISO 3166-1 Alpha-2 Codes
        // Ref: https://www.iso.org/obp/ui/#iso:code:3166:TR
        
        private readonly string _value;

        public static readonly City Adana               = new City("01");
        public static readonly City Adiyaman            = new City("02");
        public static readonly City Afyonkarahisar      = new City("03");
        public static readonly City Agri                = new City("04");
        public static readonly City Aksaray             = new City("68");
        public static readonly City Amasya              = new City("05");
        public static readonly City Ankara              = new City("06");
        public static readonly City Antalya             = new City("07");
        public static readonly City Ardahan             = new City("75");
        public static readonly City Artvin              = new City("08");
        public static readonly City Aydin               = new City("09");
        public static readonly City Balikesir           = new City("10");
        public static readonly City Bartin              = new City("74");
        public static readonly City Batman              = new City("72");
        public static readonly City Bayburt             = new City("69");
        public static readonly City Bilecik             = new City("11");
        public static readonly City Bingol              = new City("12");
        public static readonly City Bitlis              = new City("13");
        public static readonly City Bolu                = new City("14");
        public static readonly City Burdur              = new City("15");
        public static readonly City Bursa               = new City("16");
        public static readonly City Canakkale           = new City("17");
        public static readonly City Cankiri             = new City("18");
        public static readonly City Corum               = new City("19");
        public static readonly City Denizli             = new City("20");
        public static readonly City Diyarbakir          = new City("21");
        public static readonly City Duzce               = new City("81");
        public static readonly City Edirne              = new City("22");
        public static readonly City Elazig              = new City("23");
        public static readonly City Erzincan            = new City("24");
        public static readonly City Erzurum             = new City("25");
        public static readonly City Eskisehir           = new City("26");
        public static readonly City Gaziantep           = new City("27");
        public static readonly City Giresun             = new City("28");
        public static readonly City Gumushane           = new City("29");
        public static readonly City Hakkari             = new City("30");
        public static readonly City Hatay               = new City("31");
        public static readonly City Igdir               = new City("76");
        public static readonly City Isparta             = new City("32");
        public static readonly City Istanbul            = new City("34");
        public static readonly City Izmir               = new City("35");
        public static readonly City Kahramanmaras       = new City("46");
        public static readonly City Karabuk             = new City("78");
        public static readonly City Karaman             = new City("70");
        public static readonly City Kars                = new City("36");
        public static readonly City Kastamonu           = new City("37");
        public static readonly City Kayseri             = new City("38");
        public static readonly City Kirikkale           = new City("71");
        public static readonly City Kirklareli          = new City("39");
        public static readonly City Kirsehir            = new City("40");
        public static readonly City Kilis               = new City("79");
        public static readonly City Kocaeli             = new City("41");
        public static readonly City Konya               = new City("42");
        public static readonly City Kutahya             = new City("43");
        public static readonly City Malatya             = new City("44");
        public static readonly City Manisa              = new City("45");
        public static readonly City Mardin              = new City("47");
        public static readonly City Mersin              = new City("33");
        public static readonly City Mugla               = new City("48");
        public static readonly City Mus                 = new City("49");
        public static readonly City Nevsehir            = new City("50");
        public static readonly City Nigde               = new City("51");
        public static readonly City Ordu                = new City("52");
        public static readonly City Osmaniye            = new City("80");
        public static readonly City Rize                = new City("53");
        public static readonly City Sakarya             = new City("54");
        public static readonly City Samsun              = new City("55");
        public static readonly City Siirt               = new City("56");
        public static readonly City Sinop               = new City("57");
        public static readonly City Sivas               = new City("58");
        public static readonly City Sanliurfa           = new City("63");
        public static readonly City Sirnak              = new City("73");
        public static readonly City Tekirdag            = new City("59");
        public static readonly City Tokat               = new City("60");
        public static readonly City Trabzon             = new City("61");
        public static readonly City Tunceli             = new City("62");
        public static readonly City Usak                = new City("64");
        public static readonly City Van                 = new City("65");
        public static readonly City Yalova              = new City("77");
        public static readonly City Yozgat              = new City("66");
        public static readonly City Zonguldak           = new City("67");

        private City(string value) {
            
            _value = value;
        }

        public override string ToString() {
            
            return _value;
        }
    }
}