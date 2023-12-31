USE [master]
GO
/****** Object:  Database [PM_QLK]    Script Date: 8/23/2023 1:38:49 PM ******/
CREATE DATABASE [PM_QLK]
GO
USE [PM_QLK]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 8/23/2023 1:38:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[STT] [int] NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[ContractDate] [datetime] NULL DEFAULT (getdate()),
	[MoreInfo] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Input]    Script Date: 8/23/2023 1:38:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Input](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](250) NULL,
	[DateInput] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InputInfo]    Script Date: 8/23/2023 1:38:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InputInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[STT] [int] NULL,
	[IDObject] [int] NOT NULL,
	[IDInput] [int] NOT NULL,
	[Count] [float] NULL,
	[InputPrice] [float] NULL,
	[Total] [float] NULL,
	[Status] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Objects]    Script Date: 8/23/2023 1:38:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Objects](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[STT] [int] NULL,
	[DisplayName] [nvarchar](max) NULL,
	[IDUnit] [int] NOT NULL,
	[IDSuplier] [int] NOT NULL,
	[QRCode] [nvarchar](max) NULL,
	[BarCode] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OutputInfo]    Script Date: 8/23/2023 1:38:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutputInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[STT] [int] NULL,
	[IDObject] [int] NOT NULL,
	[IDOutput] [int] NOT NULL,
	[IDCustomer] [int] NOT NULL,
	[Count] [float] NULL,
	[OutputPrice] [float] NULL,
	[Total] [float] NULL,
	[Status] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Outputs]    Script Date: 8/23/2023 1:38:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Outputs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](250) NULL,
	[DateOutput] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Suplier]    Script Date: 8/23/2023 1:38:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suplier](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[STT] [int] NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[ContractDate] [datetime] NULL DEFAULT (getdate()),
	[MoreInfo] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Unit]    Script Date: 8/23/2023 1:38:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[STT] [int] NULL,
	[DisplayName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 8/23/2023 1:38:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/23/2023 1:38:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[IDRole] [int] NOT NULL DEFAULT ((2)),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([ID], [STT], [DisplayName], [Address], [Phone], [Email], [ContractDate], [MoreInfo]) VALUES (1, 1, N'Trần Tôn Khả', N'Quận 12', N'0384684207', N'trantonkha@gmail.com', CAST(N'2023-08-03 17:06:56.377' AS DateTime), N'Good Customer')
INSERT [dbo].[Customer] ([ID], [STT], [DisplayName], [Address], [Phone], [Email], [ContractDate], [MoreInfo]) VALUES (2, 2, N'Lê Đăng Như thế', N'Quận Thủ Đức', N'0384684207', N'nhuthe@gmail.com', CAST(N'2023-08-03 17:06:56.400' AS DateTime), N'Bad Customer')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Input] ON 

INSERT [dbo].[Input] ([ID], [DisplayName], [DateInput]) VALUES (1, N'Hóa đơn 1', CAST(N'2023-08-19 11:29:24.760' AS DateTime))
SET IDENTITY_INSERT [dbo].[Input] OFF
SET IDENTITY_INSERT [dbo].[InputInfo] ON 

INSERT [dbo].[InputInfo] ([ID], [STT], [IDObject], [IDInput], [Count], [InputPrice], [Total], [Status]) VALUES (1, 1, 1, 1, 20, 150000, 3000000, N'Good')
SET IDENTITY_INSERT [dbo].[InputInfo] OFF
SET IDENTITY_INSERT [dbo].[Objects] ON 

INSERT [dbo].[Objects] ([ID], [STT], [DisplayName], [IDUnit], [IDSuplier], [QRCode], [BarCode]) VALUES (1, 1, N'Xi măng', 2, 1, NULL, NULL)
INSERT [dbo].[Objects] ([ID], [STT], [DisplayName], [IDUnit], [IDSuplier], [QRCode], [BarCode]) VALUES (2, 2, N'Cát', 3, 2, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Objects] OFF
SET IDENTITY_INSERT [dbo].[OutputInfo] ON 

INSERT [dbo].[OutputInfo] ([ID], [STT], [IDObject], [IDOutput], [IDCustomer], [Count], [OutputPrice], [Total], [Status]) VALUES (5, 2, 1, 6, 1, 5, 150000, 750000, N'Good')
INSERT [dbo].[OutputInfo] ([ID], [STT], [IDObject], [IDOutput], [IDCustomer], [Count], [OutputPrice], [Total], [Status]) VALUES (6, 3, 1, 7, 1, 5, 150000, 750000, N'Good')
SET IDENTITY_INSERT [dbo].[OutputInfo] OFF
SET IDENTITY_INSERT [dbo].[Outputs] ON 

INSERT [dbo].[Outputs] ([ID], [DisplayName], [DateOutput]) VALUES (6, N'Hóa đơn 2', CAST(N'2023-08-19 00:00:00.000' AS DateTime))
INSERT [dbo].[Outputs] ([ID], [DisplayName], [DateOutput]) VALUES (7, N'Hóa đơn 1', CAST(N'2023-08-20 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Outputs] OFF
SET IDENTITY_INSERT [dbo].[Suplier] ON 

INSERT [dbo].[Suplier] ([ID], [STT], [DisplayName], [Address], [Phone], [Email], [ContractDate], [MoreInfo]) VALUES (1, 1, N'Seas', N'Quận 12', N'0384684207', N'trantonkha@gmail.com', CAST(N'2023-08-03 17:06:08.700' AS DateTime), N'Good Suplier')
INSERT [dbo].[Suplier] ([ID], [STT], [DisplayName], [Address], [Phone], [Email], [ContractDate], [MoreInfo]) VALUES (2, 2, N'Seas 1', N'Quận 12', N'0384684207', N'trantonkha@gmail.com', CAST(N'2023-08-03 17:06:08.727' AS DateTime), N'Good Suplier')
SET IDENTITY_INSERT [dbo].[Suplier] OFF
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([ID], [STT], [DisplayName]) VALUES (1, 1, N'Kg')
INSERT [dbo].[Unit] ([ID], [STT], [DisplayName]) VALUES (2, 2, N'Bao')
INSERT [dbo].[Unit] ([ID], [STT], [DisplayName]) VALUES (3, 3, N'Xe')
INSERT [dbo].[Unit] ([ID], [STT], [DisplayName]) VALUES (12, 4, N'Tấn ')
SET IDENTITY_INSERT [dbo].[Unit] OFF
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([ID], [DisplayName]) VALUES (1, N'Admin')
INSERT [dbo].[UserRole] ([ID], [DisplayName]) VALUES (2, N'Staff')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [DisplayName], [UserName], [Password], [IDRole]) VALUES (1, N'Trần Tôn Khả', N'K99', N'202cb962ac59075b964b07152d234b70', 1)
INSERT [dbo].[Users] ([ID], [DisplayName], [UserName], [Password], [IDRole]) VALUES (2, N'Lê Đăng Như Thế', N'T99', N'202cb962ac59075b964b07152d234b70', 2)
INSERT [dbo].[Users] ([ID], [DisplayName], [UserName], [Password], [IDRole]) VALUES (3, N'Khả', N'Tôn Khả', N'81dc9bdb52d04dc20036dbd8313ed055', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
USE [master]
GO
ALTER DATABASE [PM_QLK] SET  READ_WRITE 
GO
