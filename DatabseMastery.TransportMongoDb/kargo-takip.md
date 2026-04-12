# 🗄️ MongoDB Kullanımı (ASP.NET Core)

## 📦 Kullanılan Paketler

Projede MongoDB ile veri işlemleri için aşağıdaki NuGet paketleri kullanılmıştır:

- MongoDB.Bson  
- MongoDB.Driver  
- MongoDB.Driver.Core  

---

## 🧩 MongoDB Attribute Kullanımı

### 🔑 [BsonId]

MongoDB’de her document (veri kaydı) benzersiz bir kimliğe sahiptir.  
`[BsonId]` attribute’u, ilgili property’nin MongoDB tarafında **primary key (ID)** olarak kullanılmasını sağlar.

---

### 🔄 [BsonRepresentation(BsonType.ObjectId)]

MongoDB’de ID alanı genellikle `ObjectId` tipindedir.  
Ancak C# tarafında bu alan çoğunlukla `string` olarak tanımlanır.

`[BsonRepresentation(BsonType.ObjectId)]` attribute’u sayesinde:

- MongoDB → ObjectId  
- C# → string  

arasında otomatik dönüşüm yapılır.

Bu yapı, iki farklı sistem arasında bir **çevirmen görevi** görür.

---

## 💻 Örnek Kullanım

```csharp
public class Slider
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string SliderId { get; set; }

    public string Title { get; set; }
}

