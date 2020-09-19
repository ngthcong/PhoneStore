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
go

create table pro_variant(
	var_id					int identity(1,1) primary key not null,
	pro_id					int,
	var_color				nvarchar(20),
	var_color_icon			varchar(100),			
	var_qty					float,
	var_status				bit,
	date_created			datetime
)
create table var_images(
	img_id					int identity (1,1) primary key not null,
	var_id					int,
	img_path				varchar(200)
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
go
create table pro_type(
	type_id					int identity(1,1) primary key not null,
	group_id				int,
	type_name				nvarchar(100)
)

go
create table pro_group(
	group_id					int identity(1,1) primary key not null,
	group_name					nvarchar(100)
)
go


go
create table specification(
	spec_id					int identity(1,1) primary key not null,
	spec_name				nvarchar(50)
)
go
create table pro_specification(
	id						bigint identity(1,1) primary key not null,
	pro_id					int,
	spec_id					int,
	spec_value				nvarchar(200)
)

go
create table invoice(
	inv_id						int identity(1,1) primary key not null,
	inv_date					datetime,
	em_id						int,
	cus_id						int,
	inv_cus_name				nvarchar(50),
	inv_cus_email				nvarchar(50),
	inv_cus_phone				nvarchar(10),
	inv_city_id					int,
	inv_district_id				int,
	inv_ward_id					int,
	inv_address					nvarchar(100),
	inv_payment_method			int,
	inv_delivery_method			int,
	inv_note					nvarchar(200),
	inv_status					nvarchar(40),
	date_created				datetime
)
go
create table invoice_detail(
	inv_detail_id				int identity(1,1) primary key not null,
	inv_id						int,
	pro_id						int,
	var_id						int,
	pro_qty						int,
	pro_price					float
)

	
--create table employee(
--	em_id						int identity(1,1) primary key not null,
--	em_name						nvarchar(50),
--	em_email					nvarchar(50),
--	em_username					nvarchar(16),
--	em_salt						varchar(32),
--	em_pass						varchar(300),
--	em_phone					varchar(10),
--	em_identity_number			varchar(12),
--	em_birthday					date,
--	em_city_id					int,
--	em_district_id				int,
--	em_ward_id					int,
--	em_address_number			nvarchar(100),
--	em_note						nvarchar(500),
--	em_role_id					int,
--	em_shift_id					int,
--	em_status					bit,
--	date_created				datetime
--)
go
create table acc_role(
	role_id						int identity(1,1) primary key not null,
	role_name					nvarchar(20)
)
go
create table pro_view(
	id							char(13) primary key not null,
	pro_id						int,
	date_viewed					datetime,
	ip_address					nvarchar(20) 
)
go
create table account(
	acc_id						int identity(1,1) primary key not null,
	acc_name					nvarchar(50),
	acc_email					nvarchar(50),
	acc_salt					varchar(32),
	acc_pass					varchar(300),
	acc_phone					varchar(10),
	acc_birthday				date,
	acc_city_id					int,
	acc_district_id				int,
	acc_ward_id					int,
	acc_address_number			nvarchar(100),
	acc_note					nvarchar(500),
	acc_role_id					int,
	acc_status					bit,
	date_created				datetime	
)
go
create table address_city(
	city_id				int primary key not null,
	city_name			nvarchar(30)
)
go
create table address_district(
	district_id				int primary key not null,
	city_id					int,
	district_name			nvarchar(30)
)
go
create table address_ward(
	ward_id				int primary key not null,
	district_id			int,
	ward_name			nvarchar(30)
)
go

create table acc_basket(
	basket_id			bigint identity(1,1) primary key not null,
	acc_id				int,
	var_id				int,
	pro_id				int,
	qty					int
)
create table comment(
	com_id				int IDENTITY(1,1) primary key NOT NULL,
	pro_id				int ,
	com_text			nvarchar(1000) ,
	com_time			datetime ,
	com_acc_id			int,
	con_cus_name		nvarchar(50),
	com_cus_phone		varchar(10),
	parent_id			int,
	con_note			nvarchar(50),
	com_status			bit
)
create table rating(
	ra_id				int IDENTITY(1,1) primary key NOT NULL,
	pro_id				int,
	ra_point			int,
	ra_text				nvarchar(1000) ,
	ra_time				datetime ,
	ra_acc_id			int,
	ra_cus_name			nvarchar(50),
	ra_cus_phone		varchar(10)
)



SET IDENTITY_INSERT [dbo].[pro_brand] ON 

INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (1, N'Apple', NULL)
INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (2, N'Samsung', NULL)
INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (3, N'OPPO', NULL)
INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (4, N'Vsmart', NULL)
INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (5, N'Xiaomi', NULL)
INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (6, N'Realme', NULL)
INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (7, N'Vivo', NULL)
INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (8, N'Nokia', NULL)
INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (9, N'Huawei', NULL)
INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (10, N'Anker', NULL)
INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (11, N'iValue', NULL)
INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (12, N'UmeTravel', NULL)
INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (13, N'Vegar', NULL)
INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (14, N'Sony', NULL)
INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (15, N'JBL', NULL)
INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (16, N'Belkin', NULL)
INSERT [dbo].[pro_brand] ([brand_id], [brand_name], [brand_logo]) VALUES (17, N'Hyperdrive', NULL)
SET IDENTITY_INSERT [dbo].[pro_brand] OFF
GO

SET IDENTITY_INSERT [dbo].[pro_group] ON 

INSERT [dbo].[pro_group] ([group_id], [group_name]) VALUES (1, N'Điện thoại')
INSERT [dbo].[pro_group] ([group_id], [group_name]) VALUES (2, N'Phụ kiện')
INSERT [dbo].[pro_group] ([group_id], [group_name]) VALUES (3, N'Laptop')
SET IDENTITY_INSERT [dbo].[pro_group] OFF


GO
SET IDENTITY_INSERT [dbo].[pro_type] ON 

INSERT [dbo].[pro_type] ([type_id], [group_id], [type_name]) VALUES (1, 2, N'Sạc dự phòng')
INSERT [dbo].[pro_type] ([type_id], [group_id], [type_name]) VALUES (2, 2, N'Tai nghe')
INSERT [dbo].[pro_type] ([type_id], [group_id], [type_name]) VALUES (3, 2, N'Cáp sạc')
SET IDENTITY_INSERT [dbo].[pro_type] OFF
GO
SET IDENTITY_INSERT [dbo].[specification] ON 

INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (1, N'Màn hình')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (2, N'Camera trước')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (3, N'Camera sau')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (4, N'CPU')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (5, N'RAM')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (6, N'GPU')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (7, N'Bộ nhớ trong')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (8, N'Cảm biến')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (9, N'Hệ điều hành')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (10, N'Loại SIM')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (11, N'Kết nối')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (12, N'Pin')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (13, N'Thời gian bảo hành')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (14, N'Xuất xứ')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (15, N'Năm sản xuất')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (16, N'Chất liệu')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (17, N'Cổng cáp kết nối')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (18, N'Cường độ dòng điện')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (19, N'Độ dài dây cáp')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (20, N'Loại')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (21, N'Mẫu mã')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (22, N'Số cổng USB')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (23, N'Tính năng')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (24, N'Loại kết nối')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (25, N'Loại tai nghe')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (26, N'Màu sắc')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (27, N'Tần số')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (28, N'Trở kháng')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (29, N'Cổng nguồn ra')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (30, N'Cổng vào')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (31, N'Độ bền')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (32, N'Dung lượng')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (33, N'Thời gian sạc')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (34, N'Lõi pin')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (35, N'Mẫu mã')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (36, N'Nguồn ra')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (37, N'Nguồn vào')
INSERT [dbo].[specification] ([spec_id], [spec_name]) VALUES (38, N'Số cổng ra')

SET IDENTITY_INSERT [dbo].[specification] OFF
GO


GO
SET IDENTITY_INSERT [dbo].[brand_group] ON 

INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (1, 1, NULL, 1)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (2, 1, NULL, 2)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (3, 1, NULL, 3)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (4, 1, NULL, 4)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (5, 1, NULL, 5)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (6, 1, NULL, 6)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (7, 1, NULL, 7)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (8, 1, NULL, 8)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (9, 1, NULL, 9)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (10, 2, 1, 10)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (11, 2, 1, 11)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (12, 2, 1, 12)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (13, 2, 1, 13)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (14, 2, 2, 1)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (15, 2, 2, 10)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (16, 2, 2, 11)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (17, 2, 2, 14)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (18, 2, 2, 15)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (19, 2, 3, 1)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (20, 2, 3, 10)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (21, 2, 3, 11)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (22, 2, 3, 12)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (23, 2, 3, 16)
INSERT [dbo].[brand_group] ([id], [group_id], [type_id], [brand_id]) VALUES (24, 2, 3, 17)
SET IDENTITY_INSERT [dbo].[brand_group] OFF
GO










alter table product
--					tên khoá ngoại				cột ở bảng ngoại		bảng chính(cột)
	add constraint fk_product_brand foreign key(pro_brand_id) references pro_brand(brand_id),
		constraint fk_product_group foreign key(pro_group_id) references pro_group(group_id),
		constraint fk_product_type foreign key(pro_type_id) references pro_type(type_id)
go
	
alter table pro_specification	
	add constraint fk_pro_specification_pro_id	foreign key(pro_id)	references product(pro_id),
		constraint fk_pro_specification_spec_id	foreign key(spec_id)	references specification(spec_id)
go
alter table brand_group	
	add constraint fk_brand_group_group_id	foreign key(group_id)	references pro_group(group_id),
		constraint fk_brand_group_type_id	foreign key(type_id)	references pro_type(type_id)
go
alter table pro_type
	add constraint fk_pro_type_group_id foreign key(group_id) references pro_group(group_id) 
go
alter table pro_view
	add constraint fk_pro_view_pro_id foreign key(pro_id) references product(pro_id) 
go
alter table pro_variant
	add constraint fk_pro_variant_pro_id foreign key(pro_id) references product(pro_id)
go
alter table invoice
	add constraint fk_invoice_cus_id foreign key(cus_id) references account(acc_id),
		constraint fk_invoice_em_id foreign key(em_id) references account(acc_id),
		constraint fk_invoice_city_id foreign key(inv_city_id) references address_city(city_id),
		constraint fk_invoice_district_id foreign key(inv_district_id) references address_district(district_id),
		constraint fk_invoice_ward_id foreign key(inv_ward_id) references address_ward(ward_id)
go
alter table invoice_detail
	add constraint fk_invoice_detail_pro_id foreign key(pro_id) references product(pro_id),
		constraint fk_invoice_detail_vari_id foreign key(var_id) references pro_variant(var_id),
		constraint fk_invoice_detail_inv_id foreign key(inv_id) references invoice(inv_id)
go
alter table account
	add constraint fk_account_role_id foreign key(acc_role_id) references acc_role(role_id),
		constraint fk_account_city_id foreign key(acc_city_id) references address_city(city_id),
		constraint fk_account_district_id foreign key(acc_district_id) references address_district(district_id),
		constraint fk_account_ward_id foreign key(acc_ward_id) references address_ward(ward_id)
go
--alter table customer
--	add constraint fk_customer_city_id foreign key(cus_city_id) references address_city(city_id),
--		constraint fk_customer_district_id foreign key(cus_district_id) references address_district(district_id),
--		constraint fk_customer_ward_id foreign key(cus_ward_id) references address_ward(ward_id)
--go
alter table acc_basket
	add constraint fk_cus_basket_acc_id foreign key(acc_id) references account(acc_id),
		constraint fk_cus_basket_pro_id foreign key(pro_id) references product(pro_id),
		constraint fk_cus_basket_var_id foreign key(var_id) references pro_variant(var_id)
go
alter table rating
	add constraint fk_rating_acc_id foreign key(ra_acc_id) references account(acc_id),
	constraint fk_cus_rating_pro_id foreign key(pro_id) references product(pro_id)
go
alter table comment
	add constraint fk_comment_acc_id foreign key(com_acc_id) references account(acc_id),
		constraint fk_comment_parent_id foreign key(parent_id) references comment(com_id),
		constraint fk_comment_pro_id foreign key(pro_id) references product(pro_id)
GO
alter table address_district
	add constraint fk_address_district_city_id foreign key(city_id) references address_city(city_id)
	go
alter table address_ward
	add constraint fk_address_ward_district_id foreign key(district_id) references address_district(district_id)
	go

alter table var_images
	add constraint fk_var_images_var_id foreign key(var_id) references pro_variant(var_id)
	go

