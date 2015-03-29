USE [master]
GO

CREATE DATABASE [Atm]
GO

USE [Atm]
GO
 
CREATE TABLE [dbo].[CardAccounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [char](10) NOT NULL,
	[CardPIN] [char](4) NOT NULL,
	[CardCash] [money] NOT NULL,
 CONSTRAINT [PK_dbo.CardAccounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[TransactionHistories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [char](10) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Amount] [money] NOT NULL,
 CONSTRAINT [PK_dbo.TransactionHistories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
 
SET IDENTITY_INSERT [dbo].[CardAccounts] ON 

GO
INSERT [dbo].[CardAccounts] ([Id], [CardNumber], [CardPIN], [CardCash]) VALUES (1, N'1234567890', N'0000', 800.0000)
GO
INSERT [dbo].[CardAccounts] ([Id], [CardNumber], [CardPIN], [CardCash]) VALUES (2, N'0123456789', N'1234', 0.0000)
GO
INSERT [dbo].[CardAccounts] ([Id], [CardNumber], [CardPIN], [CardCash]) VALUES (3, N'2034567899', N'4321', 199.0000)
GO
INSERT [dbo].[CardAccounts] ([Id], [CardNumber], [CardPIN], [CardCash]) VALUES (4, N'1111111111', N'0001', 200.0000)
GO
SET IDENTITY_INSERT [dbo].[CardAccounts] OFF
GO

USE [master]
GO
ALTER DATABASE [Atm] SET  READ_WRITE 
GO
