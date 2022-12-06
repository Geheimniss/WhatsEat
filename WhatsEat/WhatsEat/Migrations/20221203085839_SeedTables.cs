﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsEat.Migrations
{
    /// <inheritdoc />
    public partial class SeedTables : Migration
    { 
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRegionAndCountryTables(migrationBuilder);
            SeedProductAndProductTypes(migrationBuilder);
        }

        private void SeedRegionAndCountryTables(MigrationBuilder migrationBuilder)
        {
            //Азия и ее страны
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Regions] ([Name]) VALUES ('Азия');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Countries] ([regionId], [Name]) 
            VALUES 
            ('1', 'Кыргызстан'),
            ('1', 'Узбекистан'),
            ('1', 'Япония'),
            ('1', 'Индия'),
            ('1', 'Китай'),
            ('1', 'Вьетнам'),
            ('1', 'Турция'),
            ('1', 'Корея'),
            ('1', 'Казахстан')");

            //Европа
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Regions] ([Name]) VALUES ('Европа');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Countries] ([regionId], [Name]) 
            VALUES 
            ('2', 'Франция'),
            ('2', 'Германия'),
            ('2', 'Италия'),
            ('2', 'Испания'),
            ('2', 'Португалия'),
            ('2', 'Венгрия'),
            ('2', 'Россия'),
            ('2', 'Нидерланды'),
            ('2', 'Швейцария'),
            ('2', 'Украина'),
            ('2', 'Беларусь'),
            ('2', 'Грузия'),
            ('2', 'Греция'),
            ('2', 'Польша'),
            ('2', 'Молдавия'),
            ('2', 'Чехия'),
            ('2', 'Страны Скандинавии')");

            //Обе Америки
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Regions] ([Name]) VALUES ('Северная и Южная Америки');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Countries] ([regionId], [Name]) 
            VALUES 
            ('3', 'США'),
            ('3', 'Мексика'),
            ('3', 'Канада'),
            ('3', 'Бразилия'),
            ('3', 'Аргентина'),
            ('3', 'Чили')");
        }

        private void SeedProductAndProductTypes(MigrationBuilder migrationBuilder)
        {
            //мясо и мясное
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Мясо и мясное');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('1', 'Баранина'),
            ('1', 'Баранина (фарш)'),
            ('1', 'Бараньи ребрышки'),
            ('1', 'Бекон'),
            ('1', 'Говядина'),
            ('1', 'Говядина (фарш'),
            ('1', 'Говяжья печень'),
            ('1', 'Говяжий язык'),
            ('1', 'Говяжье сердце'),
            ('1', 'Говяжьи ребра'),
            ('1', 'Индейка (грудка)'),
            ('1', 'Индейка (крылышки)'),
            ('1', 'Индейка (ножки)'),
            ('1', 'Индейка (окорочка)'),
            ('1', 'Индейка (фарш)'),
            ('1', 'Индейка (целая)'),
            ('1', 'Карбонад'),
            ('1', 'Курица (целиком)'),
            ('1', 'Курица (бедро)'),
            ('1', 'Курица (голень)'),
            ('1', 'Курица (желудочки)'),
            ('1', 'Курица копченая'),
            ('1', 'Курица (крылышки)'),
            ('1', 'Курица (сердце)'),
            ('1', 'Курица (фарш)'),
            ('1', 'Курица (филе)'),
            ('1', 'Курица (печень)'),
            ('1', 'Сало'),
            ('1', 'Свинина'),
            ('1', 'Свинина (вырезка)'),
            ('1', 'Свинина (сердце)'),
            ('1', 'Свинина (фарш)'),
            ('1', 'Свиные ребрышки'),
            ('1', 'Ветчина'),
            ('1', 'Ветчина из индейки'),
            ('1', 'Прошутто'),
            ('1', 'Говяжий бульон'),
            ('1', 'Колбаса вареная'),
            ('1', 'Колбаски куриные'),
            ('1', 'Колбаса ливерная'),
            ('1', 'Колбаса полукопченая'),
            ('1', 'Колбаса сырокопченая'),
            ('1', 'Куриный бульон'),
            ('1', 'Салями'),
            ('1', 'Сардельки'),
            ('1', 'Сервелат'),
            ('1', 'Сосиски')");

            //морепродукты
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Морепродукты');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('2', 'Анчоусы'),
            ('2', 'Икра красная'),
            ('2', 'Икра черная'),
            ('2', 'Камбала'),
            ('2', 'Крабовое мясо'),
            ('2', 'Лосось (филе)'),
            ('2', 'Морской гребешок'),
            ('2', 'Селедь'),
            ('2', 'Окунь'),
            ('2', 'Треска (филе)'), 
            ('2', 'Морская капуста'),
            ('2', 'Минтай (филе)'),
            ('2', 'Щука'),
            ('2', 'Дорадо'),
            ('2', 'Кальмары'),
            ('2', 'Сёмга'),
            ('2', 'Горбуша'), 
            ('2', 'Консервированная рыба'),
            ('2', 'Форель'),
            ('2', 'Мидии'),
            ('2', 'Нори'),
            ('2', 'Скумбрия'),
            ('2', 'Креветки')");

            //молочные продукты
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Молочные продукты');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('3', 'Йогурт греческий'),
            ('3', 'Кефир'),
            ('3', 'Масло сливочное'),
            ('3', 'Масло шоколадное'),
            ('3', 'Молоко'),
            ('3', 'Молоко козье'),
            ('3', 'Молоко обезжиренное'),
            ('3', 'Молоко топленое'),
            ('3', 'Мороженое'),
            ('3', 'Сметана'), 
            ('3', 'Сливки обезжиренные'),
            ('3', 'Сливки 10%'),
            ('3', 'Сливки 20%'),
            ('3', 'Сливки 33%'),
            ('3', 'Творог'),
            ('3', 'Творог обезжиренный'),
            ('3', 'Молоко сухое'), 
            ('3', 'Айран'),
            ('3', 'Сыр творожный'),
            ('3', 'Взбитые сливки'),
            ('3', 'Творожная масса'),
            ('3', 'Сгущеное молоко')");

            //Овощи
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Овощи');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('4', 'Артишок'),
            ('4', 'Баклажан'),
            ('4', 'Батат'),
            ('4', 'Брокколи'),
            ('4', 'Имбирный корень'),
            ('4', 'Кабачок'),
            ('4', 'Капуста'),
            ('4', 'Капуста брюссельская'),
            ('4', 'Капуста кале'),
            ('4', 'Капуста красная'),
            ('4', 'Капуста пекинская'),
            ('4', 'Капуста цветная'),
            ('4', 'Картофель'),
            ('4', 'Кукуруза (початок)'),
            ('4', 'Лук красный'),
            ('4', 'Лук репчатый'),
            ('4', 'Лук-шалот'),
            ('4', 'Морковь'),
            ('4', 'Огурец'),
            ('4', 'Перец чили'),
            ('4', 'Перец сладкий'),
            ('4', 'Томат'),
            ('4', 'Редис'),
            ('4', 'Редька белая'),
            ('4', 'Свекла'),
            ('4', 'Сельдерей'),
            ('4', 'Спаржа'),
            ('4', 'Помидорки черри'),
            ('4', 'Тыква'),
            ('4', 'Чеснок'),
            ('4', 'Морковь'),
            ('4', 'Горох сушеный'),
            ('4', 'Фасоль сухая')");

            //Мучное и конд.
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Мучное и кондитерское');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('5', 'Багет'),
            ('5', 'Батон нарезной'),
            ('5', 'Булочки для гамбургеров'),
            ('5', 'Лаваш'),
            ('5', 'Печенье крекер'),
            ('5', 'Пита'),
            ('5', 'Сухарики ржаные'),
            ('5', 'Сухарики из белого хлеба'),
            ('5', 'Тортилья'),
            ('5', 'Хлеб белый'),
            ('5', 'Хлеб серый'),
            ('5', 'Хлеб кукурузный'),
            ('5', 'Хлеб черный'),
            ('5', 'Ванилин'),
            ('5', 'Ванильная эссенция'),
            ('5', 'Дрожжи'),
            ('5', 'Желатин'),
            ('5', 'Какао-порошок'),
            ('5', 'Крахмал картофельный'),
            ('5', 'Крахмал кукурузный'),
            ('5', 'Кокосовая стружка'),
            ('5', 'Корица молотая'),
            ('5', 'Корица палочками'),
            ('5', 'Кунжут'),
            ('5', 'Мука пшеничная'),
            ('5', 'Мука кукурузная'),
            ('5', 'Мука миндальная'),
            ('5', 'Патока (солодовый сахар'),
            ('5', 'Разрыхлитель теста'),
            ('5', 'Сахар'),
            ('5', 'Сахар тростниковый'),
            ('5', 'Сахарная пудра'),
            ('5', 'Сода пищевая'),
            ('5', 'Цедра лимона'),
            ('5', 'Цедра апельсина'),
            ('5', 'Сахар ванильный'),
            ('5', 'Повидло')");

            //Сыры
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Сыры');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('6', 'Сыр Азиаго'),
            ('6', 'Сыр Бри'),
            ('6', 'Сыр Гауда'),
            ('6', 'Сыр Горгонзола'),
            ('6', 'Сыр Грюйер'),
            ('6', 'Сыр Козий'),
            ('6', 'Сыр Маскарпоне'),
            ('6', 'Сыр Моцарелла'),
            ('6', 'Сыр Панир'),
            ('6', 'Сыр Пармезан'),
            ('6', 'Сыр Рикотта'),
            ('6', 'Сыр'),
            ('6', 'Сыр сливочный'),
            ('6', 'Сыр с голубой плесенью'),
            ('6', 'Сыр Фета'),
            ('6', 'Сыр плавленый'),
            ('6', 'Сыр колбасный копченый'),
            ('6', 'Тофу')");

            //Макароны и лапша
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Макароны и лапша');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('7', 'Букатини'),
            ('7', 'Вермишель'),
            ('7', 'Звездочки'),
            ('7', 'Каннеллони'),
            ('7', 'Капеллини'),
            ('7', 'Ракушки'),
            ('7', 'Соба лапша'),
            ('7', 'Лапша домашняя'),
            ('7', 'Лапша рисовая'),
            ('7', 'Лингвини'),
            ('7', 'Листы для лазаньи'),
            ('7', 'Манная крупа'),
            ('7', 'Пенне'),
            ('7', 'Рожки'),
            ('7', 'Спагетти'),
            ('7', 'Бабочки'),
            ('7', 'Феттучини'),
            ('7', 'Спиральки'),
            ('7', 'Фунчоза'),
            ('7', 'Яичная лапша'),
            ('7', 'Перловая крупа')");

            //Консервы и полуфабрикаты
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Консервы и полуфабрикаты');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('8', 'Ананас консервированный'),
            ('8', 'Артишок консервированный'),
            ('8', 'Варенье из инжира'),
            ('8', 'Варенье из вишни'),
            ('8', 'Горошек замороженный'),
            ('8', 'Говяжья тушенка'),
            ('8', 'Горошек консервированный'),
            ('8', 'Джем абрикосовый'),
            ('8', 'Джем апельсиновый'),
            ('8', 'Джем черничный'),
            ('8', 'Мёд'),
            ('8', 'Имбирь маринованный'),
            ('8', 'Каперсы консервированные'),
            ('8', 'Кукуруза консервированная'),
            ('8', 'Лечо'),
            ('8', 'Маслины'),
            ('8', 'Молоко кокосовое'),
            ('8', 'Молоко ореховое'),
            ('8', 'Нут консервированный'),
            ('8', 'Овощная смесь замороженная'),
            ('8', 'Оливки'),
            ('8', 'Основа для пиццы'),
            ('8', 'Перец халапеньо'),
            ('8', 'Повидло абрикосовое'),
            ('8', 'Повидло сливовое'),
            ('8', 'Сельдь консервированная'),
            ('8', 'Свиная тушенка'),
            ('8', 'Сироп кленовый'),
            ('8', 'Тесто дрожжевое'),
            ('8', 'Тесто слоеное'),
            ('8', 'Томат маринованный'),
            ('8', 'Фасоль белая консервированная'),
            ('8', 'Фасоль в томатном соусе'),
            ('8', 'Фасоль красная консервированная'),
            ('8', 'Фасоль черная консервированная'),
            ('8', 'Карнишоны маринованные'),
            ('8', 'Томат вяленый'),
            ('8', 'Бульонный кубик'),
            ('8', 'Пельмени')");

            //фрукты ягоды 

            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Фрукты ягоды');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('9', 'Авокадо'),
            ('9', 'Ананас'),
            ('9', 'Апельсин'),
            ('9', 'Банан'),
            ('9', 'Виноград'),
            ('9', 'Гранат'),
            ('9', 'Грейпфрут'),
            ('9', 'Груша'),
            ('9', 'Клубника'),
            ('9', 'Клюква'),
            ('9', 'Лайм'),
            ('9', 'Лимон'),
            ('9', 'Малина'),
            ('9', 'Манго'),
            ('9', 'Мандарин'),
            ('9', 'Персик'),
            ('9', 'Помело'),
            ('9', 'Черника'),
            ('9', 'Яблоко зеленое'),
            ('9', 'Яблоко красное'),
            ('9', 'Яблоко фуджи'),
            ('9', 'Вишня'),
            ('9', 'Арбуз'),
            ('9', 'Дыня'),
            ('9', 'Чернослив'),
            ('9', 'Киви'),
            ('9', 'Смородина'),
            ('9', 'Земляника'),
            ('9', 'Брусника'),
            ('9', 'Слива')");

            //Зелень
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Зелень');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('10', 'Базилик свежий'),
            ('10', 'Зеленый горошек'),
            ('10', 'Кинза'),
            ('10', 'Лемонграсс'),
            ('10', 'Листья салата'),
            ('10', 'Зеленый лук'),
            ('10', 'Мята свежая'),
            ('10', 'Душица'),
            ('10', 'Петрушка'),
            ('10', 'Розмарин'),
            ('10', 'Руккола'),
            ('10', 'Салат Фризе'),
            ('10', 'Соя (ростки)'),
            ('10', 'Укроп'),
            ('10', 'Стручковая зеленая фасоль'),
            ('10', 'Тимьян'),
            ('10', 'Шалфей'),
            ('10', 'Шпинат'),
            ('10', 'Эстрагон'),
            ('10', 'Щавель')");

            //Соусы
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Соусы');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('11', 'Аджика'),
            ('11', 'Бальзамический сироп'),
            ('11', 'Васаби'),
            ('11', 'Горчица'),
            ('11', 'Горчица белая'),
            ('11', 'Горчица дижонская'),
            ('11', 'Горчица зернистая'),
            ('11', 'Кетчуп'),
            ('11', 'Кокосовый соус'),
            ('11', 'Майонез'),
            ('11', 'Соус барбекю'),
            ('11', 'Соус вустерский'),
            ('11', 'Соус рыбный'),
            ('11', 'Соус сальса'),
            ('11', 'Соус соевый'),
            ('11', 'Соус Табаско'),
            ('11', 'Соус чили'),
            ('11', 'Соус шрирача'),
            ('11', 'Соус Энчилада'),
            ('11', 'Томатная паста'),
            ('11', 'Уксус бальзамический'),
            ('11', 'Уксус белый винный'),
            ('11', 'Уксус красный винный'),
            ('11', 'Уксус рисовый'),
            ('11', 'Уксус яблочный'),
            ('11', 'Тертый хрен'),
            ('11', 'Шампанский уксус'),
            ('11', 'Уксус столовый '),
            ('11', 'Соус терияки')");

            //приправы
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Приправы');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('12', 'Базилик сушеный'),
            ('12', 'Гвоздика'),
            ('12', 'Горчичный порошок'),
            ('12', 'Имбирь сухой'),
            ('12', 'Карри'),
            ('12', 'Кинза сушеная молотая'),
            ('12', 'Кофе натуральный молотый сухой'),
            ('12', 'Куркума'),
            ('12', 'Лавровый лист'),
            ('12', 'Лук сушеный'),
            ('12', 'Мускатный орех молотый'),
            ('12', 'Мята сушеная'),
            ('12', 'Орегано'),
            ('12', 'Паприка сушеная'),
            ('12', 'Перец горошком'),
            ('12', 'Перец кайенский'),
            ('12', 'Перец черный молотый'),
            ('12', 'Перец сычуанский'),
            ('12', 'Порошок чили'),
            ('12', 'Розмарин сушеный'),
            ('12', 'Семена горчицы'),
            ('12', 'Семена укропа'),
            ('12', 'Соль чесночная'),
            ('12', 'Сухари панировочные'),
            ('12', 'Тимьян сушеный'),
            ('12', 'Тмин'),
            ('12', 'Чай зеленый'),
            ('12', 'Чай зеленый матча'),
            ('12', 'Чай черный'),
            ('12', 'Чесночный порошок'),
            ('12', 'Шалфей сушеный'),
            ('12', 'Приправа для курицы'),
            ('12', 'Приправа для рыбы'),
            ('12', 'Приправа универсальная')");

            //Алкоголь
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Алкоголь');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('13', 'Вино белое'),
            ('13', 'Вино красное'),
            ('13', 'Вино рисовое'),
            ('13', 'Пиво светлое'),
            ('13', 'Пиво темное'),
            ('13', 'Ром'),
            ('13', 'Яблочный сидр')");

            //Грибы
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Грибы');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('14', 'Шампиньоны'),
            ('14', 'Белые маринованные грибы'),
            ('14', 'Шиитаке'),
            ('14', 'Опята'),
            ('14', 'Вешенки'),
            ('14', 'Белые сушенные грибы'),
            ('14', 'Трюфель')");

            //Напитки, соки
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Напитки и соки');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('15', 'Ананасовый сок'),
            ('15', 'Апельсиновый сок'),
            ('15', 'Гранатовый сок'),
            ('15', 'Лаймовый сок'),
            ('15', 'Лимонный сок'),
            ('15', 'Мультифрукт сок'),
            ('15', 'Яблочный сок'),
            ('15', 'Компот'),
            ('15', 'Вода с газом'),
            ('15', 'Томатный сок')");

            //Орехи и сухофрукты
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Орехи и сухофрукты');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('16', 'Арахис'),
            ('16', 'Грецкий орех'),
            ('16', 'Вишня сушеная'),
            ('16', 'Изюм'),
            ('16', 'Кишмиш'),
            ('16', 'Инжир'),
            ('16', 'Инжир сушеный'),
            ('16', 'Кедровые орехи'),
            ('16', 'Кешью'),
            ('16', 'Клюква сушеная'),
            ('16', 'Курага'),
            ('16', 'Миндаль'),
            ('16', 'Миндальные лепестки'),
            ('16', 'Финики'),
            ('16', 'Фисташки'),
            ('16', 'Фундук'),
            ('16', 'Цукаты из ананаса'),
            ('16', 'Цукаты из апельсина'),
            ('16', 'Цукаты из груш'),
            ('16', 'Цукаты из дыни'),
            ('16', 'Цукаты из папайи')");

            //Крупы
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Крупы');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('17', 'Булгур'),
            ('17', 'Киноа'),
            ('17', 'Кукурузная крупа'),
            ('17', 'Кус-кус'),
            ('17', 'Нут'),
            ('17', 'Мак'),
            ('17', 'Овсяные хлопья'),
            ('17', 'Рис басамати'),
            ('17', 'Рис бурый'),
            ('17', 'Рис дикий черный'),
            ('17', 'Семена сои'),
            ('17', 'Чечевица'),
            ('17', 'Гречневая крупа'),
            ('17', 'Отруби ржаные')");

            //Другое
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[ProductTypes] ([Name]) VALUES ('Другое');");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[Products] ([productTypeId], [Name]) 
            VALUES 
            ('18', 'Вода'),
            ('18', 'Лед'),
            ('18', 'Квас хлебный'),
            ('18', 'Масло кокосовое'),
            ('18', 'Масло кунжутное'),
            ('18', 'Масло оливковое'),
            ('18', 'Масло растительное'),
            ('18', 'Маргарин'),
            ('18', 'Бобы сои'),
            ('18', 'Чипсы'),
            ('18', 'Начос'),
            ('18', 'Шоколад'),
            ('18', 'Шоколад белый'),
            ('18', 'Яйцо куриное'),
            ('18', 'Яйцо перепелиное'),
            ('18', 'Яйцо страусиное'),
            ('18', 'Масло арахисовое')");
        }






        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
