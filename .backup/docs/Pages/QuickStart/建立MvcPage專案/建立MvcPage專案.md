---
layout: default
title: 建立MvcPage專案
parent: 快速開始(QuickStart)
nav_order: 1
---

# 建立MvcPage專案

本篇文件介紹，如何建立使用MDP.Net的MvcPage專案。

## 操作步驟

### 1. 建立新專案

開啟Visual Studio，選擇使用範本「空的ASP.NET Core」，建立新的專案「WebApplication1」。並且修改WebApplication1.csproj，開啟C# 11.0語言版本支援。

```
<LangVersion>11.0</LangVersion>
```

### 2. 新增NuGet套件

在專案裡使用NuGet套件管理員，新增下列NuGet套件。

```
MDP.AspNetCore
```

### 3. 修改Program.cs

在專案裡修改Program.cs為下列程式碼。

```csharp
using Microsoft.Extensions.Hosting;

namespace WebApplication1
{
    public class Program
    {
        // Methods
        public static void Main(string[] args)
        {
            // Host
            MDP.AspNetCore.Host.Create(args).Run();
        }
    }
}
```

### 4. 修改appsettings.json

在專案裡修改appsettings.json，並移除appsettings.Development.json。

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.*": "Warning",
      "System.*": "Warning"
    }
  }
}
```

### 5. 新增HomeController

在專案裡新增Controllers資料夾，並加入HomeController.cs。

```csharp
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1
{
    public class HomeController : Controller
    {
        // Methods
        public ActionResult Index()
        {
            // Message
            this.ViewBag.Message = "Hello World";

            // Return
            return View();
        }
    }
}
```

### 6. 新增Index.cshtml

在專案裡新增Views\Home資料夾，並加入Index.cshtml。

```html
<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8" />
    <title></title>
</head>
<body>

    <!--Title-->
    <h2>@ViewBag.Message</h2>
    <hr />

</body>
</html>
```

### 7. 執行專案

完成以上操作步驟後，就已成功建立使用MDP.Net的MvcPage專案。按F5執行專案，使用Browser開啟Page：/Home/Index，可以在網頁內容看到"Hello World"的訊息。

## 範例檔案

[https://github.com/Clark159/MDP.Net/tree/master/demo/QuickStart/建立MvcPage專案](https://github.com/Clark159/MDP.Net/tree/master/demo/QuickStart/建立MvcPage專案)
