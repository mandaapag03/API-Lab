-- Criando as tabelas
create schema dblab;

-- tipo de usuário
create table if not exists dblab.user_type(
	id serial primary key,
	description varchar(10) not null CONSTRAINT user_type_description_uq UNIQUE NULLS NOT DISTINCT
);

-- usuário (1 fk)
create table if not exists dblab.user(
	id serial primary key,
	cpf_cnpj char(14) not null CONSTRAINT user_cpf_cnpj_uq UNIQUE NULLS NOT DISTINCT,
    name varchar(60) not null,
    email varchar(60) not null CONSTRAINT user_email_uq UNIQUE NULLS NOT DISTINCT,
    user_type_id smallint not null,
    password varchar(30) not null,
    is_active boolean not null DEFAULT true,
    phone varchar(15) not null,
	CONSTRAINT cpf_cnpj_invalid CHECK (length(cpf_cnpj) = 11 or length(cpf_cnpj) = 14),
	CONSTRAINT email_invalid CHECK (email like '%@%'),
	CONSTRAINT user_user_type_fk FOREIGN KEY (user_type_id) REFERENCES dblab.user_type(id)
);

-- boleto (1 fk)
create table if not exists dblab.boleto(
	boleto char(8) primary key,
	user_id int not null,
	payment_date date not null,
	status varchar(15) not null,
	CONSTRAINT boleto_user_id_fk FOREIGN KEY (user_id) REFERENCES dblab.user(id)
);
	
-- laboratório
create table if not exists dblab.lab(
	id serial primary key,
	lab char(6) not null,
	andar smallint not null,
	description varchar(60),
	is_active boolean not null DEFAULT true,
	CONSTRAINT lab_invalid_prefix CHECK (lab like 'LAB%'),
	CONSTRAINT lab_andar_uq UNIQUE (andar),
	CONSTRAINT lab_lab_uq UNIQUE (lab)
);
 
-- reserva (2 fk)
create table if not exists dblab.booking(
	id serial primary key,
	user_id int not null,
	lab_id int not null,
	date TIMESTAMP without time zone not null,
	CONSTRAINT booking_id_user_fk FOREIGN KEY (user_id) REFERENCES dblab.user(id),
	CONSTRAINT booking_id_lab_fk FOREIGN KEY (lab_id) REFERENCES dblab.lab(id) ON DELETE CASCADE
);

-- Inserindo alguns dados
insert into dblab.user_type (description) values ('Aluno'), ('Professor'), ('Admin');
insert into dblab.lab (lab, andar, is_active) values ('LAB100', 1, true), ('LAB101', 2, true),('LAB102', 3, true),('LAB200', 4, true);
