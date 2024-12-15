use db_tst;
/*
drop table venda_item;
drop table venda;
drop table produto;
drop table filial;
drop table cliente;
*/

create table cliente 
( num_cliente int not null GENERATED ALWAYS AS IDENTITY,
  nom_cliente varchar(100) not null,
  cod_telefone varchar(11),
  end_cliente varchar(500),
  idc_situacao char(1) not null,
  constraint pk_cliente primary key (num_cliente),
  constraint ck1_cliente check (idc_situacao = 'A' or idc_situacao = 'I'));

create table filial
 (num_filial int not null GENERATED ALWAYS AS IDENTITY,
  nom_filial varchar(100) not null,
  idc_situacao char(1) not null,
  constraint pk_filial primary key (num_filial),
  constraint ck1_filial check (idc_situacao = 'A' or idc_situacao = 'I'));

create table produto
(num_produto int not null GENERATED ALWAYS AS IDENTITY,
 cod_produto varchar(15) not null,
 nom_produto varchar(100) not null,
 desc_produto varchar(500) not null,
 val_preco_unitario decimal not null,
 idc_situacao char(1) not null,
 constraint pk_produto primary key (num_produto),
 constraint ck1_produto check (idc_situacao = 'A' or idc_situacao = 'I'),
 constraint uk1_produto unique (cod_produto));

create table venda
(num_venda int not null GENERATED ALWAYS AS IDENTITY,
 cod_venda int not null,
 dth_venda timestamp not null,
 num_cliente int not null,
 num_filial  int not null,
 idc_situacao char(1) not null,
 constraint pk_venda primary key (num_venda),
 constraint uk1_venda unique(cod_venda),
 constraint fk1_venda foreign key (num_cliente) references cliente(num_cliente),
 constraint fk2_venda foreign key (num_filial) references filial(num_filial),
 constraint ck1_venda check (idc_situacao = 'A' or idc_situacao = 'I'));

create table venda_item
 (num_venda int not null,
  num_venda_item int not null,
  num_produto int not null,
  qte_produto decimal not null,
  val_preco_unitario decimal not null,
  val_desconto_unitario decimal not null,
  idc_situacao char(1) not null,
  constraint fk1_venda_item foreign key (num_venda) references venda(num_venda),
  constraint fk2_venda_item foreign key (num_produto) references produto(num_produto),
  constraint ck1_venda_item check (idc_situacao = 'A' or idc_situacao = 'I'));
 