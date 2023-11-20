drop table dblab.booking;
drop table dblab.boleto;
drop table dblab.lab;
drop table dblab.user;
drop table dblab.user_type;
drop schema dblab;

select * from dblab.booking;
select * from dblab.boleto;
select * from dblab.lab;
select * from dblab.user;
select * from dblab.user_type;

select * from dblab.booking
where date >= '2023-10-26 09:00:00.000' and date >= '2023-10-26 10:00:00.000';