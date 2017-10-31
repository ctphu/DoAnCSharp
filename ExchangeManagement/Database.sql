/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4206)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [VIDO]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 10/31/2017 2:02:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/31/2017 2:02:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[IsDisable] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPermission]    Script Date: 10/31/2017 2:02:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPermission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[PermissionID] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_UserPermission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsDisable]  DEFAULT ((0)) FOR [IsDisable]
GO
ALTER TABLE [dbo].[UserPermission]  WITH CHECK ADD  CONSTRAINT [FK_UserPermission_Permission] FOREIGN KEY([PermissionID])
REFERENCES [dbo].[Permission] ([ID])
GO
ALTER TABLE [dbo].[UserPermission] CHECK CONSTRAINT [FK_UserPermission_Permission]
GO
ALTER TABLE [dbo].[UserPermission]  WITH CHECK ADD  CONSTRAINT [FK_UserPermission_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[UserPermission] CHECK CONSTRAINT [FK_UserPermission_User]
GO
/****** Object:  StoredProcedure [dbo].[usp_USER_ChangePassword]    Script Date: 10/31/2017 2:02:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_USER_ChangePassword]
@psUsername varchar(50),
@psPassword varchar(50),
@psChangePasword varchar(50),
@pResultCode int output,
@pResultMessage varchar(50) output
AS
BEGIN
	--Chuyen Password Ma Hoa
	DECLARE @lPasswordHash varchar(32)
	DECLARE @lChangePasswordHash varchar(32)
	SET @lPasswordHash = HASHBYTES('SHA2_256', @psPassword)
	SET @lChangePasswordHash = HASHBYTES('SHA2_256', @psChangePasword)
	--KT User, Pass
	IF Exists(Select ID from [User] where UserName = @psUsername and PassWord = @lPasswordHash)
	--Neu Ton Tai
	BEGIN
		--Doi MK
		Update [User] SET PassWord = @lChangePasswordHash WHERE UserName = @psUsername 
		SELECT @pResultCode = ID, @pResultMessage = 'CHANGEPASSWORDOK' from [User] where UserName = @psUsername and PassWord = @lChangePasswordHash
		RETURN
	END
	--Khong Ton Tai
	ELSE
	BEGIN
		SELECT @pResultCode = -1 , @pResultMessage = 'CHANGEPASSWORDFAILED' 
		RETURN
	END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_USER_CheckUser]    Script Date: 10/31/2017 2:02:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_USER_CheckUser]
@psUsername varchar(50),
@psPassword varchar(50),
@pResultCode int output,
@pResultMessage varchar(50) output
AS
BEGIN
/*
DECLARE @psUsername varchar(50) = 'admin',
		@psPassword varchar(50) = 'admin',
		@pResultCode int,
		@pResultMessage varchar(50)

EXEC VIDO.dbo.usp_USER_CheckUser @psUsername, @psPassword, @pResultCode output, @pResultMessage output
SELECT @pResultCode, @pResultMessage
*/
	DECLARE @lPasswordHash varchar(32)
	SET @lPasswordHash = HASHBYTES('SHA2_256', @psPassword)
	IF Not Exists(Select ID from [User] where UserName = @psUsername and PassWord = @lPasswordHash)
	BEGIN
		SELECT @pResultCode = -1, @pResultMessage = 'LOGINFAILED'
		RETURN
	END
	ELSE
	BEGIN
		SELECT @pResultCode = ID , @pResultMessage = 'LOGINOK'  from [User] where UserName = @psUsername and PassWord = @lPasswordHash
		RETURN
	END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_USER_CreateUser]    Script Date: 10/31/2017 2:02:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_USER_CreateUser]
	@psUsername varchar(50)
	,@psPassword varchar(255)
	,@pResultCode int output
	,@pResultMessage varchar(50) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @lPasswordHash varchar(32)

	IF Exists(Select ID from [User] WHERE Username = @psUsername)
	BEGIN
		SELECT @pResultCode = -1, @pResultMessage = 'USEREXISTED'
		RETURN
	END

	SET @lPasswordHash = HASHBYTES('SHA2_256', @psPassword)

	INSERT INTO [User](Username, Password, IsDisable) Values(@psUsername, @lPasswordHash, 0)
	
	SELECT @pResultCode = SCOPE_IDENTITY(), @pResultMessage = 'USERCREATEDOK'
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[usp_USER_DeleteUser]    Script Date: 10/31/2017 2:02:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_USER_DeleteUser]
@psUsername varchar(50),
@psPassword varchar(50),
@pResultCode int output,
@pResultMessage varchar(50) output
AS
BEGIN
	--Chuyen Password Ma Hoa
	DECLARE @lPasswordHash varchar(32)
	SET @lPasswordHash = HASHBYTES('SHA2_256', @psPassword)
	--KT User, Pass
	IF Exists(Select ID from [User] where UserName = @psUsername and PassWord = @lPasswordHash)
	--Neu Ton Tai
	BEGIN	
		--Thong Bao Thanh Cong
		SELECT @pResultCode = ID, @pResultMessage = 'DELETEUSEROK' from [User] where UserName = @psUsername and PassWord = @lPasswordHash
		--Xoa User
		DELETE FROM [User] WHERE UserName = @psUsername
		RETURN
	END
	--Khong Ton Tai
	ELSE
	BEGIN
		SELECT @pResultCode = -1 , @pResultMessage = 'DELETEUSERFAILED' 
		RETURN
	END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_USER_GetUserList]    Script Date: 10/31/2017 2:02:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_USER_GetUserList]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT * FROM [User]
END
GO
