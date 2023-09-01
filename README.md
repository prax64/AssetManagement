# Asset management and QR code generation for the product

Платформа: ASP.NET Core NET 7.0


## Из чего состоит проект

В реализации будут использоваться следующие технологии, сборки, фреймворки, подходы, паттерны:

* База данных MSSQL
* EntityFrameworkCore
* Unit of Work
* Mediatr
* FluentValidation
* PredicatesBuilder
* OperationResult (as RFC7807)
* Microsoft Identity
* Vertical Slice Architecture
* Minimal API
* OpenIddict Auth2.0
* Nimble Framework 
* Swagger
* AppDefinitions

# Требования, правила, бизнес-логика

## Роли в системе

В проекте используется две роли, которые регламентируют доступ к функционалу.
`Administrator` - (главная роль) пользователь, у которого есть эта роль, может выполнять все операции с любыми сущностями).
`User` - пользоватеть, у которого есть эта роль может добавлять обзоры к товарам.

Незарегистрированные пользователи работают с системой в режиме "readonly".

## Сущность "Category"
* [x] `Name` должно быть не менее 5 и не более 50 символов.
* [x] `Description` должно быть не более 1024 символов, но может быть пустым.
* [x] `Category` можно создать без товаров.
* [ ] `Category` можно выключить/выключить (скрыть/показать для всеобщего просмотра).
* [ ] При выключении каталога все товары в каталоге тоже должны выключиться.
* [ ] При включении каталога необходимо явно указать, включать или не включать товары.
* [x] При получении всех товаров `GetAll()` администратор должен получать и скрытые данные.
* [ ] Просмотр всех каталогов должно использоваться разбиение на страницы (paging)
* [ ] При создании нового каталога, он должен быть невидимый по умолчанию.
* [ ] API должна содержать методы CRUD для управления сущностью `Category`:
	* [ ] `GetPaged(int pageIndex, int pageSize)`
	* [x] `GetAll()`
	* [x] `Create(CategoryViewModel model)`
	* [ ] `GetById(Guid id)`
	* [ ] `Update(CategoryUpdateViewModel)`
	* [ ] `Delete(Guid id)`
---
## Сущность "Product"
* [x] `Name` должно быть не менее 5 и не более 128 символов.
* [x] `Description` должно быть не более 2048 символов, но может быть пустым.
* [x] `Price` может быть не задана (null).
* [ ] `CategoryId` обязательно при создании нового товара.
* [ ] `Product` можно выключить/выключить (скрыть/показать для всеобщего просмотра).
* [ ] Товар нельзя включить, если каталог товара выключен
* [ ] Просмотр всех товаров должно использоваться разбиение на страницы (paging)
* [ ] При создании товар он должен быть невидимый.
* [ ] API должна содержать методы CRUD для управления сущностью `Product`:
	* [ ] `GetPaged(int pageIndex, int pageSize)`
	* [ ] `GetAll()`
	* [ ] `Create(ProductViewModel model)
	* [ ] `GetById(Guid id)`
	* [ ] `Update(ProductUpdateViewModel)`
	* [ ] `Delete(Guid id)`
	* [ ] `GetMostReviewed(int count)`
	* [ ] `GetMostRated(int count)`
---

## Сущность "Tag" ("Метка")
* [ ] Один продукт должен иметь одну и более меток (до 8 шт).
* [ ] При создании и при редактировании товара к нему можно добавить несколько меток. Если метка не существует в системе, то она создается. Если метка уже существует, то к товару привязывается ссылка нее.
* [ ] Если из описания товара удаляется метка, то надо проверить что эта метка не используется других товарах. Если метка больше нигде не используется, ее требуется удалить.
* [ ] Данные о продукте должны включать в себя метки товара (`GetById` и `GetPaged`)
* [ ] Просмотр всех меток, которые используются в каталоге можно осуществить на странице "Облако меток" (см. `GetCloud()`).
* [ ] API должна содержать методы CRUD для управления сущностью `Tag`:
	* [ ] `GetCloud()`
	* [ ] `Update(TagUpdateViewModel)`
	* [ ] `Delete(Guid id)`
---

## Требования для роли Администратор

1. Администратор должен иметь возможность удалить любой отзыв
2. Администратор должен иметь возможность удалять товары
3. Администратор должен иметь возможность удалять пользователей
4. Администратор должен иметь возможность удалять метки
---

## Требования для роли Пользователь

1. Пользователь может добавить сколько угодно отзывов на любой товар
2. Пользователь может удалить свой и только свой отзыв
3. Пользователь может изменить рейтинг своего отзыва и текст содержания

## Диаграмма классов

``` mermaid
classDiagram
	direction RL
	Product "*" <-- "1" Category
	Tag "1..8" <-- "*" Product
	Auditable <|-- Identity
	Category <|-- Identity
	EventItem <|-- Identity
	Tag <|-- Identity
	Product <|-- Auditable

```

``` mermaid
---
title: Сущность Category
---
classDiagram
class Category {
	+string Name
	+string Description
	+List~Product~
	bool Visible
}
```

``` mermaid
---
title: Сущность Product
---
classDiagram
class Product {
	+string Name
	+string Description
	Guid CategoryId
	+int Price
	+List~Review~
	+List~Tag~
	bool Visible
}
```

``` mermaid
---
title: Сущность EventItem
---
classDiagram
class EventItem {
	DateTime CreatedAt
	string Logger
	string Level
	string Message
	string? ThreadId
	string? ExceptionMessage
}
```

``` mermaid
---
title: Сущность Tag
---
classDiagram
class Tag {
	string Name
	List<Product>? Products
}
```

``` mermaid
---
title: Сущность Identity
---
classDiagram
class Identity{
	<<Abstract>>
	+Guid Id
}
```

``` mermaid
---
title: Сущность Auditable
---
classDiagram
class Auditable{
	<<Abstract>>
	DateTime CreatedAt
	string CreatedBy
	DateTime? UpdatedAt
	string? UpdatedBy
}
```

