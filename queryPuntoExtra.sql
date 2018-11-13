create database bd_prueba_3_java;
go

use bd_prueba_3_java;
GO

create table asignatura(
    id int IDENTITY(1,1),
    nombre varchar(200),
    primary key(id)
);
go

insert into asignatura values('Estructuras de programación');
insert into asignatura values('Programación orientada a objetos');
insert into asignatura values('Programación Java');

create table nota(
    id int IDENTITY(1,1),
    valor float,/*Nota en sí*/
    porcentaje float,
    asignatura int,
    primary key(id),
    foreign key(asignatura) references asignatura(id)
);
go

select * from asignatura;
select * from nota;

/*
use master
go
DROP DATABASE bd_prueba_3_java
go

*/