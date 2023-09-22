# ktpay-dotnet 

This project contains integration infrastructure code developed for Kuveyt Turk Participation Bank Virtual POS services. The codes included in the project must be used to integrate and perform virtual POS transactions for online payment services provided by Kuveyt Turk Participation Bank. Any unauthorized use for different purposes will be detected by the bank, and punitive measures will be applied.

[Türkçe](https://github.com/osmanozen/ktpay-dotnet/blob/main/README.md)

## Requirements

* **.NET Standart 2.0, .NET Standart 2.1**
* **.NET Core 7** (for Tests ve Web)

## Installation

You can download the latest version .zip file from the following address:
https://github.com/osmanozen/ktpay-dotnet/releases

## Example Code

> Payment

```csharp
var request = new PaymentRequest() {
    PaymentType = 1,
    Language = Language.EN.GetValue(),
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

> Payment with Installment

```csharp
var request = new PaymentRequest() {
    PaymentType = 1,
    Language = Language.EN.GetValue(),
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

> Cancel, Drawback and Partial Drawback

```csharp
var request = new SaleReversalRequest() {
    Language = Language.EN.GetValue(),
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

> Find Transaction

```csharp
var request = new GetTransactionRequest() {
    Language = Language.EN.GetValue(),
    MerchantId = Convert.ToInt32(envConfig.MerchantId),
    CustomerId = Convert.ToInt32(envConfig.CustomerId),
    Username = envConfig.Username,
    OrderId = 155139799
};
request.SetHashData(envConfig.Password);
```

> List Transactions

```csharp
var request = new GetTransactionsRequest() {
    Language = Language.EN.GetValue(),
    MerchantId = Convert.ToInt32(envConfig.MerchantId),
    CustomerId = Convert.ToInt32(envConfig.CustomerId),
    Username = envConfig.Username,
    MerchantOrderId = "KT TEST"
};
request.SetHashData(envConfig.Password);
```

## License

This project is licensed under the MIT License. For details, please review the [LICENSE](https://github.com/osmanozen/ktpay-dotnet/blob/main/LICENSE) file.