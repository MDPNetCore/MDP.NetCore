# MDP.NetCore

MDP.NetCore是開源的.NET開發平台，協助開發人員快速建立Console程式。提供參數管理、依賴注入、身分驗證等多種功能模組，用以簡化開發流程並滿足多變的商業需求。

- 說明文件：[https://mdpcore.github.io/MDP.NetCore/](https://mdpcore.github.io/MDP.NetCore/)

- 程式源碼：[https://github.com/MDPCore/MDP.NetCore](https://github.com/MDPCore/MDP.NetCore)

 
## 快速開始

- [開發一個依賴注入+參數管理的API服務](https://mdpcore.github.io/MDP.NetCore/快速開始/開發一個依賴注入+參數管理的API服務/)

- [開發一個依賴注入+參數管理的Web站台](https://mdpcore.github.io/MDP.NetCore/快速開始/開發一個依賴注入+參數管理的Web站台/)

- [開發一個依賴注入+參數管理的Console程式](https://mdpcore.github.io/MDP.NetCore/快速開始/開發一個依賴注入+參數管理的Console程式/)


## 版本更新

### MDP.NetCore 8.0.3

- MDP.Security.Tokens.Jwt：加入多組Token同時使用功能。

- MDP.BlazorCore：整併至[MDPCore/MDP.BlazorCore](https://github.com/MDPCore/MDP.BlazorCore) 

- MDP.AspNetCore：整併至[MDPCore/MDP.AspNetCore](https://github.com/MDPCore/MDP.AspNetCore) 

### MDP.NetCore 8.0.2

- MDP.BlazorCore：加入Web、App跨平台執行能力。

### MDP.NetCore 8.0.1

- MDP.NetCore：升級至.NET8.0

### MDP.NetCore 6.1.17

- MDP.Security.Tokens.Jwt：加入MDP.Security.Tokens.Jwt，提供JwtToken生成功能。

### MDP.NetCore 6.1.16

- MDP.Hosting：加入AutoRegister，削減Config設定內容。

### MDP.NetCore 6.1.13

- MDP.Registration：加入ServiceBuilder，削減Domain層對於DI框架的相依。

### MDP.NetCore 6.1.12

- MDP.AspNetCore：加入ForwardedHeaders，提供302轉址使用HTTPS。

### MDP.NetCore 6.1.11

- MDP.Registration：加入ServiceRegistration，簡化Factory註冊服務的步驟。

### MDP.NetCore 6.1.8

- MDP.Logging.Serilog：加入此模組，提供Serilog日誌服務。

### MDP.NetCore 6.1.5

- MDP.NetCore：加入AddMdp()，提升平台識別。

- MDP.AspNetCore：加入AddMdp()，提升平台識別。

### MDP.NetCore 6.1.4

- MDP.DevKit.Line.Messaging：遷移此模組，遷移至獨立Repo進行維護。

### MDP.NetCore 6.1.2

- MDP.Hosting：移除Autofac參考。

### MDP.NetCore 6.1.0

- MDP.Registration：加入此模組，提供Attribute註冊功能，用以移除所有.Hosting註冊用專案。

### MDP.NetCore 6.0.16

- MDP.AspNetCore.Authentication.Liff.Services：加入此模組，提供Liff頁面客製化功能。

### MDP.NetCore 6.0.15

- MDP.AspNetCore.Authentication.Liff：調整Liff登入效能、調整Liff登入頁面提示文字。

### MDP.NetCore 6.0.14

- MDP.AspNetCore.Authentication.Liff：調整Liff登入效能、調整Liff登入頁面提示文字。

### MDP.NetCore 6.0.13

- MDP.AspNetCore.WebApp：WebApp專案設定加入GenerateDocumentationFile，讓系統產生API說明檔。

- MDP.AspNetCore：加入Swagger預設參數，讓SwaggerUI顯示API說明檔。

- MDP.IdentityModel.Tokens.Jwt：加入RSA非對稱金鑰支援。

- MDP.AspNetCore.Authentication.Jwt：加入RSA非對稱金鑰支援。

### MDP.NetCore 6.0.12

- MDP.AspNetCore：加入Swagger預設參數，讓SwaggerUI顯示API。

- MDP.IdentityModel.Tokens.Jwt：SecurityTokenFactory加入自訂ExpireMinutes功能。

- MDP.AspNetCore.Authentication.Jwt：加入多個JWT來源驗證功能，提供自訂HeaderName、TokenPrefix設定。

- MDP.AspNetCore.Authentication：加入PolicySchemeSelector，提供依照HttpContex選擇AuthenticationScheme功能。