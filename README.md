# Вопрос №1. Навигация решения:

    - FigureAreaLib (целевая библиотека классов)
        - Figures
            - Circle.cs (класс круга)
            - Triangle.cs (класс треугольника)
        - Figure.cs (абстрактный класс для наследования)
        - UnknownFigure.cs (статический класс для использования метода абстрактной фигуры)
    
    - FigureAreaLib.UnitTests
        - Figures
            - CircleTest.cs (тест круга)
            - TriangleTest.cs (тест треугольника)
        - GlobalUsing.cs
    
    - ConsoleApp (консольное приложение, имеет референс на FigureAreaLib)
        - Program.cs (для пробного использования библиотеки классов)
        
# Вопрос №2. MS SQL

**Так как в SQL Server мы не можем на уровне базы сделать связь "многие ко многим", сначала требуется сделать промежуточную таблицу (например, "ProductsCategories").**

#### 1. Подготовим первоначальные условия:
    create table Product(
        ProductID int not null identity(1,1) primary key,
        ProductName varchar(255) not null
    ); 
    create table Category(
        CategoryID int not null identity(1,1) primary key,
        CategoryName varchar(255) not null
    );
    insert into Product values ('Телефон'), ('Электробритва'), ('Телевизор'), ('Шампунь'), ('Гитара');
    insert into Category values ('Электроника'), ('Средство связи'), ('Предметы личной гигиены');

#### 2. Создадим промежуточную таблицу и заполним её
    create table ProductsCategories(
        Id int not null identity(1,1) primary key,
        ProductID int not null foreign key references Product(ProductID),
        CategoryID int not null foreign key references Category(CategoryID)
    );
    insert into ProductsCategories values
    (1, 1), -- телефон = электроника
    (1, 2), -- телефон = средство связи
    (2, 1), -- электробритва = электроника
    (2, 3), -- электробритва = предмет личной гигиены
    (3, 1), -- телевизор = электроника
    (3, 2), -- телевизор = средство связи
    (4, 3); -- шампунь = предмет личной гигиены

#### 3. Итоговый запрос:
    select p.ProductName, c.CategoryName from Product as p
    left join ProductsCategories as pc on p.ProductID = pc.ProductID
    left join Category as c on c.CategoryID = pc.CategoryID

В таком случае мы получим следующую запись:
(№ записи)|ProductName|CategoryName|
|-|--|--|
|1|Телефон|Электроника|
|2|Телефон|Средство связи|
|3|Электробритва|Электроника|
|4|Электробритва|Предметы личной гигиены|
|5|Телевизор|Электроника|
|6|Телевизор|Средство связи|
|7|Шампунь|Предметы личной гигиены|
|8|Гитара|NULL|
