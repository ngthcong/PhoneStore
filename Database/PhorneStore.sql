drop database PhoneStoreDB
go
use master
go
create database PhoneStoreDB
go
use  PhoneStoreDB
go
create table product(
	pro_id					int identity(1,1) primary key not null,
	pro_name				nvarchar(100),
	pro_image				nvarchar(300),
	pro_group_id			int,
	pro_brand_id			int,
	pro_type_id				int,
	pro_retail_price		float,
	pro_sale_price			float,
	pro_description			nvarchar(max),
	date_created			datetime,
	pro_status				bit
)
go--

create table pro_variant(
	var_id					int identity(1,1) primary key not null,
	pro_id					int,
	var_color				nvarchar(20),
	var_color_icon			varchar(100),			
	var_qty					float,
	var_status				bit,
	date_created			datetime
)
go--
create table var_images(
	img_id					int identity (1,1) primary key not null,
	var_id					int,
	img_path				varchar(200),
	img_index					int
)
go
create table pro_brand(
	brand_id				int identity(1,1) primary key not null,
	brand_name				nvarchar(20),
	brand_logo				nvarchar(100)
)
go
create table brand_group(
	id					int identity(1,1) primary key not null,
	group_id			int,
	type_id				int,
	brand_id			int
)
go--
create table pro_type(
	type_id					int identity(1,1) primary key not null,
	group_id				int,
	type_name				nvarchar(100)
)
go--
create table pro_group(
	group_id					int identity(1,1) primary key not null,
	group_name					nvarchar(100)
)
go--


go
create table specification(
	spec_id					int identity(1,1) primary key not null,
	spec_name				nvarchar(50)
)
go--
create table pro_specification(
	id						bigint identity(1,1) primary key not null,
	pro_id					int,
	spec_id					int,
	spec_value				nvarchar(200)
)
go--
create table invoice(
	inv_id						int identity(1,1) primary key not null,
	inv_date					datetime,
	em_id						int,
	cus_id						int,
	inv_cus_name				nvarchar(50),
	inv_cus_email				nvarchar(50),
	inv_cus_phone				nvarchar(10),
	inv_ward_id					int,
	inv_address					nvarchar(100),
	inv_note					nvarchar(200),
	inv_status					bit,
	date_created				datetime
)
go--
create table invoice_detail(
	inv_detail_id				int identity(1,1) primary key not null,
	inv_id						int,
	pro_id						int,
	var_id						int,
	pro_qty						int,
	pro_price					float
)--


go
create table acc_role(
	role_id						int identity(1,1) primary key not null,
	role_name					nvarchar(20)
)
go--


create table account(
	acc_id						int identity(1,1) primary key not null,
	acc_name					nvarchar(50),
	acc_email					nvarchar(50),
	acc_salt					varchar(32),
	acc_pass					varchar(100),
	acc_phone					varchar(10),
	acc_ward_id					int,
	acc_address					nvarchar(100),
	acc_note					nvarchar(200),
	acc_role_id					int,
	acc_status					bit,
	date_created				datetime	
)
go--
create table address_city(
	city_id				int primary key not null,
	city_name			nvarchar(30)
)
go--
create table address_district(
	district_id				int primary key not null,
	city_id					int,
	district_name			nvarchar(30)
)
go--
create table address_ward(
	ward_id				int primary key not null,
	district_id			int,
	ward_name			nvarchar(30)
)
go--


--create table comment(
--	com_id				int IDENTITY(1,1) primary key NOT NULL,
--	pro_id				int ,
--	com_text			nvarchar(1000) ,
--	com_time			datetime ,
--	com_acc_id			int,
--	con_cus_name		nvarchar(50),
--	com_cus_phone		varchar(10),
--	parent_id			int,
--	con_note			nvarchar(50),
--	com_status			bit
--)








alter table product
--					tên khoá ngoại				cột ở bảng ngoại		bảng chính(cột)
	add constraint fk_product_brand foreign key(pro_brand_id) references pro_brand(brand_id),
		constraint fk_product_group foreign key(pro_group_id) references pro_group(group_id),
		constraint fk_product_type foreign key(pro_type_id) references pro_type(type_id)
go
	
alter table pro_specification	
	add constraint fk_pro_specification_pro_id	foreign key(pro_id)	references product(pro_id) ON DELETE CASCADE,
		constraint fk_pro_specification_spec_id	foreign key(spec_id)	references specification(spec_id)
go
alter table brand_group	
	add constraint fk_brand_group_group_id	foreign key(group_id)	references pro_group(group_id),
		constraint fk_brand_group_type_id	foreign key(type_id)	references pro_type(type_id),
		constraint fk_brand_group_brand_id	foreign key(brand_id)	references pro_brand(brand_id)
go
alter table pro_type
	add constraint fk_pro_type_group_id foreign key(group_id) references pro_group(group_id) 
go
alter table pro_variant
	add constraint fk_pro_variant_pro_id foreign key(pro_id) references product(pro_id) ON DELETE CASCADE
go
alter table invoice
	add constraint fk_invoice_cus_id foreign key(cus_id) references account(acc_id) ,
		constraint fk_invoice_em_id foreign key(em_id) references account(acc_id),
		constraint fk_invoice_ward_id foreign key(inv_ward_id) references address_ward(ward_id)
go
alter table invoice_detail
	add constraint fk_invoice_detail_pro_id foreign key(pro_id) references product(pro_id),
		constraint fk_invoice_detail_vari_id foreign key(var_id) references pro_variant(var_id),
		constraint fk_invoice_detail_inv_id foreign key(inv_id) references invoice(inv_id) ON DELETE CASCADE
go
alter table account
	add constraint fk_account_role_id foreign key(acc_role_id) references acc_role(role_id),
		constraint fk_account_ward_id foreign key(acc_ward_id) references address_ward(ward_id)
go




alter table address_district
	add constraint fk_address_district_city_id foreign key(city_id) references address_city(city_id)
	go
alter table address_ward
	add constraint fk_address_ward_district_id foreign key(district_id) references address_district(district_id)
	go

alter table var_images
	add constraint fk_var_images_var_id foreign key(var_id) references pro_variant(var_id)
	go

