
CREATE TABLE [dbo].[Admins](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[User_Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Applications]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applications](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Carrer_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Banner]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banner](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstHead] [nvarchar](50) NOT NULL,
	[FirstHead_AR] [nvarchar](50) NOT NULL,
	[SecondHead] [nvarchar](50) NOT NULL,
	[SecondHead_AR] [nvarchar](50) NOT NULL,
	[Link] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Carrers]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Salary] [nvarchar](10) NOT NULL,
	[Type] [nvarchar](20) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comments]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[Project_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Subject] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gallery]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gallery](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Name_AR] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Description_AR] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Heads]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Heads](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Name_AR] [nvarchar](50) NOT NULL,
	[Service_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Price_ID] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[User_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pricing]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pricing](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Name_AR] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Project_Videos]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project_Videos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Link] [nvarchar](max) NOT NULL,
	[Project_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Projects]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UnderWork] [bit] NOT NULL,
	[Finished] [bit] NOT NULL,
	[Expire_Date] [date] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[User_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Requirments]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requirments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Carrer_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Services]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Name_AR] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Description_AR] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Skills]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Carrer_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subscribers]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscribers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Project_ID] [int] NOT NULL,
	[Finished] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Team]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Job] [nvarchar](50) NOT NULL,
	[FaceBook] [nvarchar](max) NULL,
	[Twitter] [nvarchar](max) NULL,
	[LinkedIn] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/19/2019 10:21:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Admins] ON 

GO
INSERT [dbo].[Admins] ([ID], [Name], [User_Name], [Password], [Type]) VALUES (4, N'Ahmed', N'ahmed', N'123456', 0)
GO
INSERT [dbo].[Admins] ([ID], [Name], [User_Name], [Password], [Type]) VALUES (5, N'Ata Sabri', N'atasabri', N'01142229025', 1)
GO
SET IDENTITY_INSERT [dbo].[Admins] OFF
GO
SET IDENTITY_INSERT [dbo].[Banner] ON 

GO
INSERT [dbo].[Banner] ([ID], [FirstHead], [FirstHead_AR], [SecondHead], [SecondHead_AR], [Link]) VALUES (1, N'Head 1', N'موقع رؤية', N'Rooya Development', N'Start Your Software', NULL)
GO
INSERT [dbo].[Banner] ([ID], [FirstHead], [FirstHead_AR], [SecondHead], [SecondHead_AR], [Link]) VALUES (2, N'Head 1', N'رؤية للتطور', N'Rooya Development', N'Start Your Work', NULL)
GO
INSERT [dbo].[Banner] ([ID], [FirstHead], [FirstHead_AR], [SecondHead], [SecondHead_AR], [Link]) VALUES (3, N'Head 1', N'شسش', N'Head 2', N'شسشسشسشس', NULL)
GO
INSERT [dbo].[Banner] ([ID], [FirstHead], [FirstHead_AR], [SecondHead], [SecondHead_AR], [Link]) VALUES (4, N'Head 1', N'ابدأ عملك', N'Head 2', N'بوابتك لعالم التكنولوجيا', N'https://www.we.com/')
GO
SET IDENTITY_INSERT [dbo].[Banner] OFF
GO
SET IDENTITY_INSERT [dbo].[Carrers] ON 

GO
INSERT [dbo].[Carrers] ([ID], [Name], [Description], [Salary], [Type], [Country]) VALUES (2, N'.Net Developer', N'this carrer is for test      ', N'4000', N'full time', N'Egypt')
GO
INSERT [dbo].[Carrers] ([ID], [Name], [Description], [Salary], [Type], [Country]) VALUES (5, N'Job 1', N'This Is For Test', N'2000', N'full time', N'Egypt')
GO
SET IDENTITY_INSERT [dbo].[Carrers] OFF
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 

GO
INSERT [dbo].[Contacts] ([ID], [Name], [Subject], [Email], [Message]) VALUES (1, N'Ata Sabri', N'test 1', N'ataeldon@gmail.com', N'  this is for test
')
GO
INSERT [dbo].[Contacts] ([ID], [Name], [Subject], [Email], [Message]) VALUES (2, N'ahmed sabri', N'Problem', N'programming@mediagatestudios.com', N'this is for test
')
GO
INSERT [dbo].[Contacts] ([ID], [Name], [Subject], [Email], [Message]) VALUES (3, N'Ata Sabri', N'test', N'ataeldon@gmail.com', N'kkjkjkj')
GO
INSERT [dbo].[Contacts] ([ID], [Name], [Subject], [Email], [Message]) VALUES (4, N'Ata Sabri', N'test', N'ataeldon@gmail.com', N'kkjkjkj')
GO
INSERT [dbo].[Contacts] ([ID], [Name], [Subject], [Email], [Message]) VALUES (5, N'Ata Sabri', N'Problem', N'ataeldon@gmail.com', N'hhgghghghghgh')
GO
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[Gallery] ON 

GO
INSERT [dbo].[Gallery] ([ID], [Name], [Name_AR], [Description], [Description_AR]) VALUES (9, N'cvxc', N'cxcxc', N'xczxczxzxczxc ', N' zxczxczxczxczxc ')
GO
SET IDENTITY_INSERT [dbo].[Gallery] OFF
GO
SET IDENTITY_INSERT [dbo].[Heads] ON 

GO
INSERT [dbo].[Heads] ([ID], [Name], [Name_AR], [Service_ID]) VALUES (5, N'head 1', N'jaja', 2)
GO
INSERT [dbo].[Heads] ([ID], [Name], [Name_AR], [Service_ID]) VALUES (6, N'asja', N'asa', 2)
GO
INSERT [dbo].[Heads] ([ID], [Name], [Name_AR], [Service_ID]) VALUES (7, N'sddsdsdsd', N'sdsdsddssd', 3)
GO
INSERT [dbo].[Heads] ([ID], [Name], [Name_AR], [Service_ID]) VALUES (8, N'sddsdsdsd', N'sdsdsddssd', 3)
GO
SET IDENTITY_INSERT [dbo].[Heads] OFF
GO
SET IDENTITY_INSERT [dbo].[Project_Videos] ON 

GO
INSERT [dbo].[Project_Videos] ([ID], [Link], [Project_ID]) VALUES (21, N'https://www.youtube.com/embed/0J0sbZDimjE', 21)
GO
INSERT [dbo].[Project_Videos] ([ID], [Link], [Project_ID]) VALUES (22, N'https://www.youtube.com/embed/6K5dRsHDL2g', 21)
GO
SET IDENTITY_INSERT [dbo].[Project_Videos] OFF
GO
SET IDENTITY_INSERT [dbo].[Projects] ON 

GO
INSERT [dbo].[Projects] ([ID], [Name], [UnderWork], [Finished], [Expire_Date], [Description], [User_ID]) VALUES (21, N'Traveller', 1, 0, CAST(0x853E0B00 AS Date), N'This Application Is For Test', 2)
GO
SET IDENTITY_INSERT [dbo].[Projects] OFF
GO
SET IDENTITY_INSERT [dbo].[Requirments] ON 

GO
INSERT [dbo].[Requirments] ([ID], [Name], [Carrer_ID]) VALUES (16, N'requirment 1', 2)
GO
INSERT [dbo].[Requirments] ([ID], [Name], [Carrer_ID]) VALUES (17, N'requirment 2', 2)
GO
INSERT [dbo].[Requirments] ([ID], [Name], [Carrer_ID]) VALUES (18, N'requirment 3', 2)
GO
SET IDENTITY_INSERT [dbo].[Requirments] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

GO
INSERT [dbo].[Services] ([ID], [Name], [Name_AR], [Description], [Description_AR]) VALUES (2, N'Service 1 ', N'الصورة الثانية', N'تاريخ الشركة
تأسست شركة رؤيا التطور عام 2013، لتلبى الاحتياجات المتنامية فى مجال التقنية فى المملكة العربية السعودية و مصر و العالم العربى بأسره، و ذلك عبر تقديم خدمات عالية الكفاءة و المصداقية فى مختلف فروع تقنية المعلومات. و لقد نشأت فكرة الشركة نتيجة لمتابعتنا المستمرة لواقع السوق السعودى و المصرى و العربى بشكل عام، و تطوره المستمر و المتزامن مع ما نحن فيه من ثورة معلوماتية و تقنية، و تشعب فى مجالات العمل، و تنوع فى احتياجات المؤسسات المختلفة؛ لتوفير معظم الانظمه والتقنيات ', N' تاريخ الشركة
تأسست شركة رؤيا التطور عام 2013، لتلبى الاحتياجات المتنامية فى مجال التقنية فى المملكة العربية السعودية و مصر و العالم العربى بأسره، و ذلك عبر تقديم خدمات عالية الكفاءة و المصداقية فى مختلف فروع تقنية المعلومات. و لقد نشأت فكرة الشركة نتيجة لمتابعتنا المستمرة لواقع السوق السعودى و المصرى و العربى بشكل عام، و تطوره المستمر و المتزامن مع ما نحن فيه من ثورة معلوماتية و تقنية، و تشعب فى مجالات العمل، و تنوع فى احتياجات المؤسسات المختلفة؛ لتوفير معظم الانظمه والتقنيات ')
GO
INSERT [dbo].[Services] ([ID], [Name], [Name_AR], [Description], [Description_AR]) VALUES (3, N'sdsds', N'sdsds', N'sdsds', N'sdsdsds')
GO
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[Skills] ON 

GO
INSERT [dbo].[Skills] ([ID], [Name], [Carrer_ID]) VALUES (6, N'Skill 1', 2)
GO
INSERT [dbo].[Skills] ([ID], [Name], [Carrer_ID]) VALUES (7, N'Skill 2', 2)
GO
INSERT [dbo].[Skills] ([ID], [Name], [Carrer_ID]) VALUES (8, N'Skill 3', 2)
GO
SET IDENTITY_INSERT [dbo].[Skills] OFF
GO
SET IDENTITY_INSERT [dbo].[Subscribers] ON 

GO
INSERT [dbo].[Subscribers] ([ID], [Email]) VALUES (1, N'ataeldon@gmail.com')
GO
INSERT [dbo].[Subscribers] ([ID], [Email]) VALUES (2, N'programming@mediagatestudios.com')
GO
INSERT [dbo].[Subscribers] ([ID], [Email]) VALUES (3, N'Company1@gmail.com')
GO
INSERT [dbo].[Subscribers] ([ID], [Email]) VALUES (4, N'ataeldon@gmail.com')
GO
INSERT [dbo].[Subscribers] ([ID], [Email]) VALUES (5, N'programming@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Subscribers] OFF
GO
SET IDENTITY_INSERT [dbo].[Tasks] ON 

GO
INSERT [dbo].[Tasks] ([ID], [Name], [Project_ID], [Finished]) VALUES (26, N'Create DataBase From Zero To End', 21, NULL)
GO
INSERT [dbo].[Tasks] ([ID], [Name], [Project_ID], [Finished]) VALUES (27, N'Create Web Api To Control All Application', 21, NULL)
GO
INSERT [dbo].[Tasks] ([ID], [Name], [Project_ID], [Finished]) VALUES (28, N'Create Wire Frame For Android Application', 21, NULL)
GO
INSERT [dbo].[Tasks] ([ID], [Name], [Project_ID], [Finished]) VALUES (29, N'Create IOS Application And Host on Store', 21, NULL)
GO
SET IDENTITY_INSERT [dbo].[Tasks] OFF
GO
SET IDENTITY_INSERT [dbo].[Team] ON 

GO
INSERT [dbo].[Team] ([ID], [Name], [Job], [FaceBook], [Twitter], [LinkedIn]) VALUES (3, N'Ata Sabri', N'.net developer', N'http://localhost:50803/Teams/Index', N'http://localhost:50803/Teams/Index', N'http://localhost:50803/Teams/Index')
GO
SET IDENTITY_INSERT [dbo].[Team] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([ID], [Name], [Email], [Password], [Phone], [Country]) VALUES (2, N'Ata Sabri', N'ataeldon@gmail.com', N'01142229025', N'01142229025', N'Egypt')
GO
INSERT [dbo].[Users] ([ID], [Name], [Email], [Password], [Phone], [Country]) VALUES (4, N'User 1', N'Programming@gmail.com', N'01142229025', N'12345678910', N'EGYPT')
GO
INSERT [dbo].[Users] ([ID], [Name], [Email], [Password], [Phone], [Country]) VALUES (5, N'Ata Sabri', N'ata@gmail.com', N'01142229025', N'01142229025', N'Egypt')
GO
INSERT [dbo].[Users] ([ID], [Name], [Email], [Password], [Phone], [Country]) VALUES (7, N'Atasabriata', N'ata.sabry@rooyadev.com', N'01142229025asdFGH', N'01142229025', N'Egypt')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Admins__681E8A6017E09FD7]    Script Date: 11/19/2019 10:21:15 AM ******/
ALTER TABLE [dbo].[Admins] ADD UNIQUE NONCLUSTERED 
(
	[User_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Admins__681E8A60235730D9]    Script Date: 11/19/2019 10:21:15 AM ******/
ALTER TABLE [dbo].[Admins] ADD UNIQUE NONCLUSTERED 
(
	[User_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Admins__681E8A60BD1949BF]    Script Date: 11/19/2019 10:21:15 AM ******/
ALTER TABLE [dbo].[Admins] ADD UNIQUE NONCLUSTERED 
(
	[User_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Users__A9D10534A92EC2FE]    Script Date: 11/19/2019 10:21:15 AM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Users__A9D10534F23BE4AF]    Script Date: 11/19/2019 10:21:15 AM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [FK__Applicati__Carre__25869641] FOREIGN KEY([Carrer_ID])
REFERENCES [dbo].[Carrers] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [FK__Applicati__Carre__25869641]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK__Comments__Projec__625A9A57] FOREIGN KEY([Project_ID])
REFERENCES [dbo].[Projects] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK__Comments__Projec__625A9A57]
GO
ALTER TABLE [dbo].[Heads]  WITH CHECK ADD  CONSTRAINT [FK__Heads__Service_I__173876EA] FOREIGN KEY([Service_ID])
REFERENCES [dbo].[Services] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Heads] CHECK CONSTRAINT [FK__Heads__Service_I__173876EA]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Orders__Price_ID__33D4B598] FOREIGN KEY([Price_ID])
REFERENCES [dbo].[Pricing] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Orders__Price_ID__33D4B598]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Orders__User_ID__34C8D9D1] FOREIGN KEY([User_ID])
REFERENCES [dbo].[Users] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Orders__User_ID__34C8D9D1]
GO
ALTER TABLE [dbo].[Project_Videos]  WITH CHECK ADD  CONSTRAINT [FK__Project_V__Proje__02FC7413] FOREIGN KEY([Project_ID])
REFERENCES [dbo].[Projects] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Project_Videos] CHECK CONSTRAINT [FK__Project_V__Proje__02FC7413]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK__Projects__User_I__2A4B4B5E] FOREIGN KEY([User_ID])
REFERENCES [dbo].[Users] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK__Projects__User_I__2A4B4B5E]
GO
ALTER TABLE [dbo].[Requirments]  WITH CHECK ADD  CONSTRAINT [FK__Requirmen__Carre__22AA2996] FOREIGN KEY([Carrer_ID])
REFERENCES [dbo].[Carrers] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Requirments] CHECK CONSTRAINT [FK__Requirmen__Carre__22AA2996]
GO
ALTER TABLE [dbo].[Skills]  WITH CHECK ADD  CONSTRAINT [FK__Skills__Carrer_I__1FCDBCEB] FOREIGN KEY([Carrer_ID])
REFERENCES [dbo].[Carrers] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Skills] CHECK CONSTRAINT [FK__Skills__Carrer_I__1FCDBCEB]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK__Tasks__Project_I__2D27B809] FOREIGN KEY([Project_ID])
REFERENCES [dbo].[Projects] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK__Tasks__Project_I__2D27B809]
GO
USE [master]
GO
ALTER DATABASE [RooyaDev] SET  READ_WRITE 
GO
