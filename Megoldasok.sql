--1. Feladat
create database bufe default charset=utf8 collate=utf8_hungarian_ci;
--2. Feladat
select vasarlokod, osszeg,idopont from vasarlas where osszeg<500 order by idopont;
--3. Feladat
select kod from vasarlas, vasarlo where vasarlas.vasarlokod=kod and idopont>"11:00:00" and idopont<"11:14:59" and csoport = "T";
--4. Feladat
select sum(osszeg) from vasarlas,vasarlo where vasarlokod=kod and csoport!="T";
--5. Feladat
select vasarlokod, idopont, osszeg from vasarlas order by osszeg desc limit 1;