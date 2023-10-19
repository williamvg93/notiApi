# NotiApi

Notifications Api Developed in Net Core

# Crear una nueva solución

> Puede agregar un nombre a la solución, en caso de no colocar uno, se tomará el nombre de la carpeta donde se cree.

```
dotnet new sln
```

# Crear un nuevo proyecto Web Api

> Recuerde que puede colocar cualquier nombre al proyecto, es buena practica dejar en el nombre la palabra Api, en este caso lo dejaremos solo con le nombre Api.

```
dotnet new webapi -o Api
```

# Crear una nueva Class Lib llamada Core

> Más adelante en este proyecto se agregarán las **_Entidades_** y las **_Interfaces_**.

```
dotnet new classlib -o Core
```

# Crear una nueva Class Lib llamada Infrastructure

> Más adelante en este proyecto se agregarán las **_Configuraciones para las Interfaces_**, las **_Migraciones_**, La **_UnitOfWork_** y los **_Repositories_**.

```
dotnet new classlib -o Core
```

# Agregar los proyectos creados a la solución

> Cuando vaya a agregar la ruta de la carpeta del proyecto, basta con colocar la letra con la que inicia el nombre y oprima la **tecla** **_Tab_**, se autocompletara la ruta.

- ## Para el proyecto web Api

  - ```
    dotnet sln add -o .\Api\
    ```

- ## Para el proyecto Core

  - ```
    dotnet sln add -o .\Core\
    ```

- ## Para el proyecto Infrastructure
  - ```
    dotnet sln add -o .\Infrastructure\
    ```

# Verificar si se agregaron los proyectos a la solución

```
dotnet sln list
```

![Sln List](Img/slnList.png)

# Agregar Referencias entre los proyectos

> Es necesario ubicarse en la carpeta de donde se va a crear la referecnia, ejemplo si es desde **Api**, ubicarse en la carpeta Api: **_cd Api_**.

- ## Referencia entre el proyecto webApi y Infrastructure

  - ```
    dotnet add reference ..\Infrastructure\
    ```

- ## Referencia entre el proyecto Infrastructure y Core

  - ```
    dotnet add reference ..\Core\
    ```

# Instalar las dependecias o paquetes necesarios para realizar el proyecto

> la Instalación la realizaremos desde la Extencion **_Nuget Gallery_**.

- ## Para Api:
  - #### AspNetCoreRateLimit
    - ![Sln List](Img/CoreRate.png)
  - #### AutoMapper
    - ![Sln List](Img/AutoMapper.png)
  - #### Microsoft.EntityFrameworkCore.Design
    - ![Sln List](Img/EntityDesing.png)
- ## Para Infrastructure:
  - #### Microsoft.EntityFrameworkCore
    - ![Sln List](Img/EntityFra.png)
  - #### Pomelo.EntityFrameworkCore.MySql
    - ![Sln List](Img/AutoMapper.png)

# Crear La carpeta Entities y la clase BaseEntity

> Ubicarse en la carpeta **_Core_** del proyecto, crear una carpeta llamada **_Entities_**, dentro de esta carpeta crear la clase **_BaseEntity_**.

- ### Puede crear una nueva clase de la siguiente manera:
  - ![Sln List](Img/NewClass.png)

> En BaseEntity agregamos los datos(columnas o Atribbutos) que se repitn en todas las tablas de la DB, para este caso serian **_Id, CreationDate, ModificationDate_**.

![Sln List](Img/BaseEntity.png)

> Para todas las **_Entidades_** que se creen a partir de este punto, debemos hacer **_Herencia_** de la clase **_BaseEntity_**.

# Crear Entities para cada una de las tablas de la DB

> Ubicarse en la carpeta **_Core_** del proyecto, crear la carpeta **_Entities_**, dentro de esta carpeta se van a dividir crear 3 **_Subcarpetas (Block, Notifications, Person)_**, esto para crear una división entre las entidades y así poder acceder o realizar busquedas de manera rapida.
