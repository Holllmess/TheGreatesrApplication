# TheGreatestApplication
### GeekBrains: итоговая аттестация 

Задание:
1. Используя команду cat в терминале операционной системы Linux, создать
два файла Домашние животные (заполнив файл собаками, кошками,
хомяками) и Вьючные животными заполнив файл Лошадьми, верблюдами и
ослы), а затем объединить их. Просмотреть содержимое созданного файла.
Переименовать файл, дав ему новое имя (Друзья человека).
2. Создать директорию, переместить файл туда.
3. Подключить дополнительный репозиторий MySQL. Установить любой пакет
из этого репозитория.
4. Установить и удалить deb-пакет с помощью dpkg.
5. Выложить историю команд в терминале ubuntu

*Решение:* 
>1. cat > Pets
>2. cat > PackAnimals
>3. cat Pets PackAnimals > MansFriends
>4. cat MansFriends
>5. history

>6. mkdir newdir
>7. mv MansFriends newdir
>8. history

>9. sudo apt-get install mysql-server
>10. sudo apt-get install mysql-client
>11. history

>12. sudo dpkg -i man-db_2.9.4-2_amd64.deb
>13. sudo dpkg -r debian-cd
>14. history

6. Нарисовать диаграмму, в которой есть класс родительский класс, домашние
животные и вьючные животные, в составы которых в случае домашних
животных войдут классы: собаки, кошки, хомяки, а в класс вьючные животные
войдут: Лошади, верблюды и ослы)  
**Здесь полноценная UML-диаграмма приложения**

![GreatestDiagram](https://user-images.githubusercontent.com/96007270/218310656-7ab270f2-084a-43cf-8518-5be24f2cc31a.png)

7. В подключенном MySQL репозитории создать базу данных “Друзья
человека”  
*Решение:*  
**CREATE SCHEMA IF NOT EXISTS MansFriends;**  
8. Создать таблицы с иерархией из диаграммы в БД  
*Решение:*  
**USE MansFriends**  
**CREATE TABLE IF NOT EXISTS Dog (  
                                         ->   iddog INT PRIMARY KEY NOT NULL AUTO_INCREMENT,  
                                         ->   name VARCHAR(45) NOT NULL,  
                                         ->   birthday DATETIME NOT NULL,  
                                         ->   skill VARCHAR(45) NULL);**  
Повторяем для cat, hamster, horse, camel, donkey.
9. Заполнить низкоуровневые таблицы именами(животных), командами
которые они выполняют и датами рождения  
*Решение:*  
**INSERT Dog (  
                                          ->     name,  
                                          ->     birthday,  
                                          ->     skill  
                                          -> )  
                                          -> VALUES  
                                          ->    ('Марк', '2022-01-01', 'кушать'),  
                                          ->    ('Арчи', '2021-01-01', 'сидеть'),  
                                          ->    ('Пыня', '2012-01-01', 'охранять');**  
10. Удалив из таблицы верблюдов, т.к. верблюдов решили перевезти в другой
питомник на зимовку. Объединить таблицы лошади, и ослы в одну таблицу  
*Решение:*  
**DELETE FROM camel;**  
**CREATE TABLE PackAnimals (  
                                         -> idpack_animals INT PRIMARY KEY NOT NULL AUTO_INCREMENT  
                                         -> )
                                         -> SELECT  
                                         ->     name,  
                                         ->     birthday,  
                                         ->     skill,  
                                         ->     'horse' as animal_type  
                                         -> FROM  
                                         -> horse;**                                           
**INSERT INTO PackAnimals (  
                                         ->   name,  
                                         ->   birthday,  
                                         ->   skill,  
                                         ->   animal_type)  
                                         -> SELECT name, birthday, skill, 'donkey' as animal_type  
                                         -> FROM donkey;**
11. Создать новую таблицу “молодые животные” в которую попадут все
животные старше 1 года, но младше 3 лет и в отдельном столбце с точностью
до месяца подсчитать возраст животных в новой таблице  
*Решение:*  
**CREATE TABLE YoungAnimals (  
                                         -> idyoung_animals INT PRIMARY KEY NOT NULL AUTO_INCREMENT  
                                         -> )  
                                         -> SELECT  
                                         ->   name,  
                                         ->   birthday,  
                                         ->   skill,  
                                         ->   animal_type,  
                                         ->   (TIMESTAMPDIFF(MONTH, birthday, CURDATE())) as age_months  
                                         -> FROM    
                                         ->   (SELECT * FROM PackAnimals UNION SELECT * FROM Pet) s  
                                         -> WHERE birthday BETWEEN CURDATE() - INTERVAL 3 YEAR  
                                         -> AND CURDATE() - INTERVAL 1 YEAR;**  
12. Объединить все таблицы в одну, при этом сохраняя поля, указывающие на
прошлую принадлежность к старым таблицам  
*Решение:*  
**CREATE TABLE Animals (  
                                         -> idanimals INT PRIMARY KEY NOT NULL AUTO_INCREMENT  
                                         -> )  
                                         -> SELECT  
                                         ->   name,   
                                         ->   birthday,  
                                         ->   skill,  
                                         ->   animal_type  
                                         -> FROM  
                                         ->   (SELECT * FROM PackAnimals UNION SELECT * FROM Pet) s;**  
13. Создать класс с Инкапсуляцией методов и наследованием по диаграмме
14. Написать программу, имитирующую работу реестра домашних животных
В программе должен быть реализован следующий функционал:  
14.1 Завести новое животное  
14.2 определять животное в правильный класс  
14.3 увидеть список команд, которое выполняет животное  
14.4 обучить животное новым командам  
14.5 Реализовать навигацию по меню  
15. Создайте класс Счетчик, у которого есть метод add(), увеличивающий̆
значение внутренней̆ int переменной̆ на 1 при нажатии “Завести новое
животное” Сделайте так, чтобы с объектом такого типа можно было работать в
блоке try-with-resources. Нужно бросить исключение, если работа с объектом
типа счетчик была не в ресурсном try и/или ресурс остался открыт. Значение
считать в ресурсе try, если при заведении животного заполнены все поля



