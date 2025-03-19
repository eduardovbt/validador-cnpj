
create table cnpj_records (
id UUID not null,
cnpj varchar (14) not null,
create_at  timestamp,
constraint CnpjPK primary key (id)
)

