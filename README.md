# YC_MVCTest (程式開發人員面試)

## 關於專案
- 開發工具：Visual Studio 2022 (Community)
- 開發技術：.NET 8.0 / MVC / Entity Framework Core / C# / Razor Pages
- 資料庫：LocalDB (Northwind)
- 資料庫來源：[Northwind](https://github.com/microsoft/sql-server-samples/tree/master/samples/databases)

```
CREATE DATABASE NorthwindDb;
GO
```

## 專案結構

- `Models/`：資料模型
- `Views/`：檢視頁面（Razor 頁面、 Partial View）
- `Controllers/`：頁面控制（目前只有HomeController）
- `Data/`：資料存取（目前放資料庫相關設定）
- `Services/`：商業邏輯

## 主要功能頁面（CRUD皆在同個頁面）

- 訂單列表與查詢
- 訂單明細檢視
- 新增訂單表單
- 編輯訂單表單
- 刪除訂單