USE [PhoneStoreDB]
GO
/****** Object:  Table [dbo].[acc_basket]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[acc_basket](
	[basket_id] [bigint] IDENTITY(1,1) NOT NULL,
	[acc_id] [int] NULL,
	[var_id] [int] NULL,
	[pro_id] [int] NULL,
	[qty] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[basket_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[acc_role]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[acc_role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[account]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[acc_id] [int] IDENTITY(1,1) NOT NULL,
	[acc_name] [nvarchar](50) NULL,
	[acc_email] [nvarchar](50) NULL,
	[acc_salt] [varchar](32) NULL,
	[acc_pass] [varchar](300) NULL,
	[acc_phone] [varchar](10) NULL,
	[acc_birthday] [date] NULL,
	[acc_city_id] [int] NULL,
	[acc_district_id] [int] NULL,
	[acc_ward_id] [int] NULL,
	[acc_address_number] [nvarchar](100) NULL,
	[acc_note] [nvarchar](500) NULL,
	[acc_role_id] [int] NULL,
	[acc_status] [bit] NULL,
	[date_created] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[acc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[address_city]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[address_city](
	[city_id] [int] NOT NULL,
	[city_name] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[city_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[address_district]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[address_district](
	[district_id] [int] NOT NULL,
	[city_id] [int] NULL,
	[district_name] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[district_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[address_ward]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[address_ward](
	[ward_id] [int] NOT NULL,
	[district_id] [int] NULL,
	[ward_name] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[ward_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[brand_group]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[brand_group](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[group_id] [int] NULL,
	[type_id] [int] NULL,
	[brand_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comment]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comment](
	[com_id] [int] IDENTITY(1,1) NOT NULL,
	[pro_id] [int] NULL,
	[com_text] [nvarchar](1000) NULL,
	[com_time] [datetime] NULL,
	[com_acc_id] [int] NULL,
	[con_cus_name] [nvarchar](50) NULL,
	[com_cus_phone] [varchar](10) NULL,
	[parent_id] [int] NULL,
	[con_note] [nvarchar](50) NULL,
	[com_status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[com_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoice]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoice](
	[inv_id] [int] IDENTITY(1,1) NOT NULL,
	[inv_date] [datetime] NULL,
	[em_id] [int] NULL,
	[cus_id] [int] NULL,
	[inv_cus_name] [nvarchar](50) NULL,
	[inv_cus_email] [nvarchar](50) NULL,
	[inv_cus_phone] [nvarchar](10) NULL,
	[inv_city_id] [int] NULL,
	[inv_district_id] [int] NULL,
	[inv_ward_id] [int] NULL,
	[inv_address] [nvarchar](100) NULL,
	[inv_payment_method] [int] NULL,
	[inv_delivery_method] [int] NULL,
	[inv_note] [nvarchar](200) NULL,
	[inv_status] [nvarchar](40) NULL,
	[date_created] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[inv_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoice_detail]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoice_detail](
	[inv_detail_id] [int] IDENTITY(1,1) NOT NULL,
	[inv_id] [int] NULL,
	[pro_id] [int] NULL,
	[var_id] [int] NULL,
	[pro_qty] [int] NULL,
	[pro_price] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[inv_detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pro_brand]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pro_brand](
	[brand_id] [int] IDENTITY(1,1) NOT NULL,
	[brand_name] [nvarchar](20) NULL,
	[brand_logo] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[brand_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pro_group]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pro_group](
	[group_id] [int] IDENTITY(1,1) NOT NULL,
	[group_name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[group_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pro_specification]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pro_specification](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[pro_id] [int] NULL,
	[spec_id] [int] NULL,
	[spec_value] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pro_type]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pro_type](
	[type_id] [int] IDENTITY(1,1) NOT NULL,
	[group_id] [int] NULL,
	[type_name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pro_variant]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pro_variant](
	[var_id] [int] IDENTITY(1,1) NOT NULL,
	[pro_id] [int] NULL,
	[var_color] [nvarchar](20) NULL,
	[var_color_icon] [varchar](100) NULL,
	[var_qty] [float] NULL,
	[var_status] [bit] NULL,
	[date_created] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[var_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pro_view]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pro_view](
	[id] [char](13) NOT NULL,
	[pro_id] [int] NULL,
	[date_viewed] [datetime] NULL,
	[ip_address] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[pro_id] [int] IDENTITY(1,1) NOT NULL,
	[pro_name] [nvarchar](100) NULL,
	[pro_image] [nvarchar](300) NULL,
	[pro_group_id] [int] NULL,
	[pro_brand_id] [int] NULL,
	[pro_type_id] [int] NULL,
	[pro_retail_price] [float] NULL,
	[pro_sale_price] [float] NULL,
	[pro_description] [nvarchar](max) NULL,
	[date_created] [datetime] NULL,
	[pro_status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[pro_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rating]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rating](
	[ra_id] [int] IDENTITY(1,1) NOT NULL,
	[pro_id] [int] NULL,
	[ra_point] [int] NULL,
	[ra_text] [nvarchar](1000) NULL,
	[ra_time] [datetime] NULL,
	[ra_acc_id] [int] NULL,
	[ra_cus_name] [nvarchar](50) NULL,
	[ra_cus_phone] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ra_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[specification]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[specification](
	[spec_id] [int] IDENTITY(1,1) NOT NULL,
	[spec_name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[spec_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[var_images]    Script Date: 15-Sep-20 11:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[var_images](
	[img_id] [int] IDENTITY(1,1) NOT NULL,
	[var_id] [int] NULL,
	[img_path] [varchar](200) NULL,
	[index] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[img_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[acc_basket]  WITH CHECK ADD  CONSTRAINT [fk_cus_basket_acc_id] FOREIGN KEY([acc_id])
REFERENCES [dbo].[account] ([acc_id])
GO
ALTER TABLE [dbo].[acc_basket] CHECK CONSTRAINT [fk_cus_basket_acc_id]
GO
ALTER TABLE [dbo].[acc_basket]  WITH CHECK ADD  CONSTRAINT [fk_cus_basket_pro_id] FOREIGN KEY([pro_id])
REFERENCES [dbo].[product] ([pro_id])
GO
ALTER TABLE [dbo].[acc_basket] CHECK CONSTRAINT [fk_cus_basket_pro_id]
GO
ALTER TABLE [dbo].[acc_basket]  WITH CHECK ADD  CONSTRAINT [fk_cus_basket_var_id] FOREIGN KEY([var_id])
REFERENCES [dbo].[pro_variant] ([var_id])
GO
ALTER TABLE [dbo].[acc_basket] CHECK CONSTRAINT [fk_cus_basket_var_id]
GO
ALTER TABLE [dbo].[account]  WITH CHECK ADD  CONSTRAINT [fk_account_city_id] FOREIGN KEY([acc_city_id])
REFERENCES [dbo].[address_city] ([city_id])
GO
ALTER TABLE [dbo].[account] CHECK CONSTRAINT [fk_account_city_id]
GO
ALTER TABLE [dbo].[account]  WITH CHECK ADD  CONSTRAINT [fk_account_district_id] FOREIGN KEY([acc_district_id])
REFERENCES [dbo].[address_district] ([district_id])
GO
ALTER TABLE [dbo].[account] CHECK CONSTRAINT [fk_account_district_id]
GO
ALTER TABLE [dbo].[account]  WITH CHECK ADD  CONSTRAINT [fk_account_role_id] FOREIGN KEY([acc_role_id])
REFERENCES [dbo].[acc_role] ([role_id])
GO
ALTER TABLE [dbo].[account] CHECK CONSTRAINT [fk_account_role_id]
GO
ALTER TABLE [dbo].[account]  WITH CHECK ADD  CONSTRAINT [fk_account_ward_id] FOREIGN KEY([acc_ward_id])
REFERENCES [dbo].[address_ward] ([ward_id])
GO
ALTER TABLE [dbo].[account] CHECK CONSTRAINT [fk_account_ward_id]
GO
ALTER TABLE [dbo].[address_district]  WITH CHECK ADD  CONSTRAINT [fk_address_district_city_id] FOREIGN KEY([city_id])
REFERENCES [dbo].[address_city] ([city_id])
GO
ALTER TABLE [dbo].[address_district] CHECK CONSTRAINT [fk_address_district_city_id]
GO
ALTER TABLE [dbo].[address_ward]  WITH CHECK ADD  CONSTRAINT [fk_address_ward_district_id] FOREIGN KEY([district_id])
REFERENCES [dbo].[address_district] ([district_id])
GO
ALTER TABLE [dbo].[address_ward] CHECK CONSTRAINT [fk_address_ward_district_id]
GO
ALTER TABLE [dbo].[brand_group]  WITH CHECK ADD  CONSTRAINT [fk_brand_group_group_id] FOREIGN KEY([group_id])
REFERENCES [dbo].[pro_group] ([group_id])
GO
ALTER TABLE [dbo].[brand_group] CHECK CONSTRAINT [fk_brand_group_group_id]
GO
ALTER TABLE [dbo].[brand_group]  WITH CHECK ADD  CONSTRAINT [fk_brand_group_type_id] FOREIGN KEY([type_id])
REFERENCES [dbo].[pro_type] ([type_id])
GO
ALTER TABLE [dbo].[brand_group] CHECK CONSTRAINT [fk_brand_group_type_id]
GO
ALTER TABLE [dbo].[comment]  WITH CHECK ADD  CONSTRAINT [fk_comment_acc_id] FOREIGN KEY([com_acc_id])
REFERENCES [dbo].[account] ([acc_id])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [fk_comment_acc_id]
GO
ALTER TABLE [dbo].[comment]  WITH CHECK ADD  CONSTRAINT [fk_comment_parent_id] FOREIGN KEY([parent_id])
REFERENCES [dbo].[comment] ([com_id])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [fk_comment_parent_id]
GO
ALTER TABLE [dbo].[comment]  WITH CHECK ADD  CONSTRAINT [fk_comment_pro_id] FOREIGN KEY([pro_id])
REFERENCES [dbo].[product] ([pro_id])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [fk_comment_pro_id]
GO
ALTER TABLE [dbo].[invoice]  WITH CHECK ADD  CONSTRAINT [fk_invoice_city_id] FOREIGN KEY([inv_city_id])
REFERENCES [dbo].[address_city] ([city_id])
GO
ALTER TABLE [dbo].[invoice] CHECK CONSTRAINT [fk_invoice_city_id]
GO
ALTER TABLE [dbo].[invoice]  WITH CHECK ADD  CONSTRAINT [fk_invoice_cus_id] FOREIGN KEY([cus_id])
REFERENCES [dbo].[account] ([acc_id])
GO
ALTER TABLE [dbo].[invoice] CHECK CONSTRAINT [fk_invoice_cus_id]
GO
ALTER TABLE [dbo].[invoice]  WITH CHECK ADD  CONSTRAINT [fk_invoice_district_id] FOREIGN KEY([inv_district_id])
REFERENCES [dbo].[address_district] ([district_id])
GO
ALTER TABLE [dbo].[invoice] CHECK CONSTRAINT [fk_invoice_district_id]
GO
ALTER TABLE [dbo].[invoice]  WITH CHECK ADD  CONSTRAINT [fk_invoice_em_id] FOREIGN KEY([em_id])
REFERENCES [dbo].[account] ([acc_id])
GO
ALTER TABLE [dbo].[invoice] CHECK CONSTRAINT [fk_invoice_em_id]
GO
ALTER TABLE [dbo].[invoice]  WITH CHECK ADD  CONSTRAINT [fk_invoice_ward_id] FOREIGN KEY([inv_ward_id])
REFERENCES [dbo].[address_ward] ([ward_id])
GO
ALTER TABLE [dbo].[invoice] CHECK CONSTRAINT [fk_invoice_ward_id]
GO
ALTER TABLE [dbo].[invoice_detail]  WITH CHECK ADD  CONSTRAINT [fk_invoice_detail_inv_id] FOREIGN KEY([inv_id])
REFERENCES [dbo].[invoice] ([inv_id])
GO
ALTER TABLE [dbo].[invoice_detail] CHECK CONSTRAINT [fk_invoice_detail_inv_id]
GO
ALTER TABLE [dbo].[invoice_detail]  WITH CHECK ADD  CONSTRAINT [fk_invoice_detail_pro_id] FOREIGN KEY([pro_id])
REFERENCES [dbo].[product] ([pro_id])
GO
ALTER TABLE [dbo].[invoice_detail] CHECK CONSTRAINT [fk_invoice_detail_pro_id]
GO
ALTER TABLE [dbo].[invoice_detail]  WITH CHECK ADD  CONSTRAINT [fk_invoice_detail_vari_id] FOREIGN KEY([var_id])
REFERENCES [dbo].[pro_variant] ([var_id])
GO
ALTER TABLE [dbo].[invoice_detail] CHECK CONSTRAINT [fk_invoice_detail_vari_id]
GO
ALTER TABLE [dbo].[pro_specification]  WITH CHECK ADD  CONSTRAINT [fk_pro_specification_pro_id] FOREIGN KEY([pro_id])
REFERENCES [dbo].[product] ([pro_id])
GO
ALTER TABLE [dbo].[pro_specification] CHECK CONSTRAINT [fk_pro_specification_pro_id]
GO
ALTER TABLE [dbo].[pro_specification]  WITH CHECK ADD  CONSTRAINT [fk_pro_specification_spec_id] FOREIGN KEY([spec_id])
REFERENCES [dbo].[specification] ([spec_id])
GO
ALTER TABLE [dbo].[pro_specification] CHECK CONSTRAINT [fk_pro_specification_spec_id]
GO
ALTER TABLE [dbo].[pro_type]  WITH CHECK ADD  CONSTRAINT [fk_pro_type_group_id] FOREIGN KEY([group_id])
REFERENCES [dbo].[pro_group] ([group_id])
GO
ALTER TABLE [dbo].[pro_type] CHECK CONSTRAINT [fk_pro_type_group_id]
GO
ALTER TABLE [dbo].[pro_variant]  WITH CHECK ADD  CONSTRAINT [fk_pro_variant_pro_id] FOREIGN KEY([pro_id])
REFERENCES [dbo].[product] ([pro_id])
GO
ALTER TABLE [dbo].[pro_variant] CHECK CONSTRAINT [fk_pro_variant_pro_id]
GO
ALTER TABLE [dbo].[pro_view]  WITH CHECK ADD  CONSTRAINT [fk_pro_view_pro_id] FOREIGN KEY([pro_id])
REFERENCES [dbo].[product] ([pro_id])
GO
ALTER TABLE [dbo].[pro_view] CHECK CONSTRAINT [fk_pro_view_pro_id]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [fk_product_brand] FOREIGN KEY([pro_brand_id])
REFERENCES [dbo].[pro_brand] ([brand_id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [fk_product_brand]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [fk_product_group] FOREIGN KEY([pro_group_id])
REFERENCES [dbo].[pro_group] ([group_id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [fk_product_group]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [fk_product_type] FOREIGN KEY([pro_type_id])
REFERENCES [dbo].[pro_type] ([type_id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [fk_product_type]
GO
ALTER TABLE [dbo].[rating]  WITH CHECK ADD  CONSTRAINT [fk_cus_rating_pro_id] FOREIGN KEY([pro_id])
REFERENCES [dbo].[product] ([pro_id])
GO
ALTER TABLE [dbo].[rating] CHECK CONSTRAINT [fk_cus_rating_pro_id]
GO
ALTER TABLE [dbo].[rating]  WITH CHECK ADD  CONSTRAINT [fk_rating_acc_id] FOREIGN KEY([ra_acc_id])
REFERENCES [dbo].[account] ([acc_id])
GO
ALTER TABLE [dbo].[rating] CHECK CONSTRAINT [fk_rating_acc_id]
GO
ALTER TABLE [dbo].[var_images]  WITH CHECK ADD  CONSTRAINT [fk_var_images_var_id] FOREIGN KEY([var_id])
REFERENCES [dbo].[pro_variant] ([var_id])
GO
ALTER TABLE [dbo].[var_images] CHECK CONSTRAINT [fk_var_images_var_id]
GO
