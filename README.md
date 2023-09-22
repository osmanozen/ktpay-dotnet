# ktpay-dotnet 

Bu proje, Kuveyt Türk Katılım Bankası Sanal POS servisleri için geliştirilen entegrasyon alt yapı kodlarını içermektedir. Proje içerisinde yer alan kodlar, Kuveyt Türk Katılım Bankası tarafından sunulan çevrimiçi ödeme hizmetlerini entegre etmek ve sanal pos işlemlerini gerçekleştirmek amacıyla kullanılabilir. Aksi kullanımlar banka tarafından tespit edilip cezai yaptırımlar uygulanmaktadır.

[English](https://github.com/osmanozen/ktpay-dotnet/blob/main/README-EN.md)

## Gereksinimler

* **.NET Standart 2.0, .NET Standart 2.1**
* **.NET Core 7** (Tests ve Web projeleri için)

## Kurulum

Güncel sürüm .zip dosyasını şu adresten indirebilirsiniz:
https://github.com/osmanozen/ktpay-dotnet/releases

## Örnek Kodlar

> Satış

```csharp
var request = new PaymentRequest() {
    PaymentType = 1,
    Language = Language.TR.GetValue(),
    MerchantOrderId = "KT TEST",
    SuccessUrl = "http://localhost:3000/KTPay/Success",
    FailUrl = "http://localhost:3000/KTPay/Fail",
    MerchantId = Convert.ToInt32(envConfig.MerchantId),
    CustomerId = Convert.ToInt32(envConfig.CustomerId),
    Username = envConfig.Username,
    Amount = "100",
    Currency = Currency.TRY.ToString(),
    InstallmentCount = 1,
    Customer = new Customer() {
        FullName = "JOHN DOE",
        IdentityNumber = "12345678901",
        Email = "noreply@kuveytturk.com.tr",
        PhoneNumber = new Phone() {
            Cc = "90",
            Subscriber = "5001112233"
        },
        IpAddress = "127.0.0.1"
    },
    Card = new Card() {
        CardHolderName = cardConfig.CardHolderName,
        CardNumber = cardConfig.CardNumber,
        ExpireMonth = cardConfig.ExpireMonth,
        ExpireYear = cardConfig.ExpireYear,
        SecurityCode = cardConfig.SecurityCode 
    },
    Cart = new List<CartItem>() {
        new CartItem() {
            CartItemName = "Product PHYSICAL",
            CartItemUrl = "https://www.kuveytturk.com.tr",
            CartItemType = (int)CartItemType.PHYSICAL,
            Quantity = 1.5,
            Price = "10",
            TotalAmount = "15"
        },
        new CartItem() {
            CartItemName = "Product VIRTUAL",
            CartItemUrl = "https://www.kuveytturk.com.tr",
            CartItemType = (int)CartItemType.VIRTUAL,
            Quantity = 1,
            Price = "85",
            TotalAmount = "85"
        }
    },
    InvoiceAddress = new InvoiceAddress() {
        Company = "XXX LTD.STI.",
        TaxNumber = "111111111",
        TaxOffice = "XXXXXXXXX",
        Address = "ADDRESS",
        State = "IZMIT",
        City = City.Kocaeli.ToString(),
        Country = Country.Turkiye.ToString(),
        ZipCode = "123456"
    },
    ShippingAddress = new ShippingAddress() {
        FullName = "JOHN DOE",
        Address = "ADDRESS",
        State = "IZMIT",
        City = City.Kocaeli.ToString(),
        Country = Country.Turkiye.ToString(),
        ZipCode = "123456"
    }
};
request.SetHashData(envConfig.Password);
```

> Taksitli Satış

```csharp
var request = new PaymentRequest() {
    PaymentType = 1,
    Language = Language.TR.GetValue(),
    MerchantOrderId = "KT TEST",
    SuccessUrl = "http://localhost:3000/KTPay/Success",
    FailUrl = "http://localhost:3000/KTPay/Fail",
    MerchantId = Convert.ToInt32(envConfig.MerchantId),
    CustomerId = Convert.ToInt32(envConfig.CustomerId),
    Username = envConfig.Username,
    Amount = "100",
    Currency = Currency.TRY.ToString(),
    InstallmentCount = 2,
    Customer = new Customer() {
        FullName = "JOHN DOE",
        IdentityNumber = "12345678901",
        Email = "noreply@kuveytturk.com.tr",
        PhoneNumber = new Phone() {
            Cc = "90",
            Subscriber = "5001112233"
        },
        IpAddress = "127.0.0.1"
    },
    Card = new Card() {
        CardHolderName = cardConfig.CardHolderName,
        CardNumber = cardConfig.CardNumber,
        ExpireMonth = cardConfig.ExpireMonth,
        ExpireYear = cardConfig.ExpireYear,
        SecurityCode = cardConfig.SecurityCode 
    },
    Cart = new List<CartItem>() {
        new CartItem() {
            CartItemName = "Product PHYSICAL",
            CartItemUrl = "https://www.kuveytturk.com.tr",
            CartItemType = (int)CartItemType.PHYSICAL,
            Quantity = 1.5,
            Price = "10",
            TotalAmount = "15"
        },
        new CartItem() {
            CartItemName = "Product VIRTUAL",
            CartItemUrl = "https://www.kuveytturk.com.tr",
            CartItemType = (int)CartItemType.VIRTUAL,
            Quantity = 1,
            Price = "85",
            TotalAmount = "85"
        }
    },
    InvoiceAddress = new InvoiceAddress() {
        Company = "XXX LTD.STI.",
        TaxNumber = "111111111",
        TaxOffice = "XXXXXXXXX",
        Address = "ADDRESS",
        State = "IZMIT",
        City = City.Kocaeli.ToString(),
        Country = Country.Turkiye.ToString(),
        ZipCode = "123456"
    },
    ShippingAddress = new ShippingAddress() {
        FullName = "JOHN DOE",
        Address = "ADDRESS",
        State = "IZMIT",
        City = City.Kocaeli.ToString(),
        Country = Country.Turkiye.ToString(),
        ZipCode = "123456"
    }
};
request.SetHashData(envConfig.Password);
```

> Satış ve Taksitli Satış - Provizyon

```csharp
var request = new ProvisionRequest() {
	Language = Language.TR.GetValue(),
	MerchantId = Convert.ToInt32(envConfig.MerchantId),
	CustomerId = Convert.ToInt32(envConfig.CustomerId),
	Username = envConfig.Username,
	OrderId = 114294527,
	MerchantOrderId = "KT TEST",
	Amount = "100",
	Md = "9KTajMvFkCEmNHmdwS4NkUrYQjg6l89td4FfGrfFMAfBb61nxxUAbEktO4sCEz2f"
};
request.SetHashData(envConfig.Password);
```

> İptal, İade ve Kısmi İade

```csharp
var request = new SaleReversalRequest() {
    Language = Language.TR.GetValue(),
    SaleReversalType = SaleReversalType.CANCEL, //SaleReversalType.DRAWBACK, SaleReversalType.PARTIAL_DRAWBACK
    MerchantId = Convert.ToInt32(envConfig.MerchantId),
    CustomerId = Convert.ToInt32(envConfig.CustomerId),
    Username = envConfig.Username,
    OrderId = 155139799,
    MerchantOrderId = "KT TEST",
    Amount = "100"
};
request.SetHashData(envConfig.Password);
```

> İşlem Sorgulama

```csharp
var request = new GetTransactionRequest() {
    Language = Language.TR.GetValue(),
    MerchantId = Convert.ToInt32(envConfig.MerchantId),
    CustomerId = Convert.ToInt32(envConfig.CustomerId),
    Username = envConfig.Username,
    OrderId = 155139799
};
request.SetHashData(envConfig.Password);
```

> İşlem Listeleme

```csharp
var request = new GetTransactionsRequest() {
    Language = Language.TR.GetValue(),
    MerchantId = Convert.ToInt32(envConfig.MerchantId),
    CustomerId = Convert.ToInt32(envConfig.CustomerId),
    Username = envConfig.Username,
    MerchantOrderId = "KT TEST"
};
request.SetHashData(envConfig.Password);
```

## Lisans

Bu proje MIT altında lisanslanmıştır. Ayrıntılar için [LİSANS](https://github.com/osmanozen/ktpay-dotnet/blob/main/LICENSE) dosyasını inceleyin.