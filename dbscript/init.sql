
/****** Object:  Table [dbo].[Role]    Script Date: 13/11/2017 5:16:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 13/11/2017 5:16:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Mobile] [char](10) NOT NULL,
	[Email] [varchar](250) NULL,
	[DateOfBirth] [date] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Role] ([RoleId], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([RoleId], [Name]) VALUES (2, N'SuperUser')
INSERT [dbo].[Role] ([RoleId], [Name]) VALUES (3, N'NormalUser')
INSERT [dbo].[Role] ([RoleId], [Name]) VALUES (4, N'Guest')
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [RoleId], [Username], [FirstName], [LastName], [Mobile], [Email], [DateOfBirth]) VALUES (1, 1, N'kevin', N'Kevin', N'Li', N'0401123456', N'kevin.li@globirdenergy.com.au', NULL)
INSERT [dbo].[User] ([UserId], [RoleId], [Username], [FirstName], [LastName], [Mobile], [Email], [DateOfBirth]) VALUES (2, 3, N'david', N'David', N'Li', N'0411999888', NULL, NULL)
INSERT [dbo].[User] ([UserId], [RoleId], [Username], [FirstName], [LastName], [Mobile], [Email], [DateOfBirth]) VALUES (3, 4, N'guest1', N'Hello', N'World', N'0488123456', NULL, CAST(N'1991-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
