# ParkMark API

Для запуска нужен .NET 10 SDK. Откройте [ParkMark.slnx](ParkMark.slnx) в Visual Studio и запустите проект `ParkMark.Input`. Для запуска из терминала выполните следующую команду в каталоге `backend`.

```powershell
dotnet run --project ParkMark.Input
```

- [Swagger UI](http://localhost:5118/swagger)
- [Документ OpenAPI](http://localhost:5118/openapi/v1.json)

Контроллеры и HTTP-модели находятся в модуле `Api` входного слоя. Swagger UI показывает ожидаемые запросы, ответы и требования к доступу для 40 операций. Вызов заглушки через **Try it out** возвращает `501 Not Implemented`.

Проверки HTTP-контракта запускаются следующей командой из каталога `backend`.

```powershell
dotnet test ParkMark.slnx
```
