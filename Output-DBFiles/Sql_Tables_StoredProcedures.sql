USE [Rusada]
GO

/****** Object:  Table [dbo].[TblFlightDetails]    Script Date: 17-10-2022 10:15:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblFlightDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Make] [varchar](128) NULL,
	[Model] [varchar](128) NULL,
	[Registration] [varchar](25) NULL,
	[Location] [varchar](255) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_TblFlightDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE Procedure [dbo].[AddNewFlight]
@Make Varchar(128) = '',
@Model Varchar(128) = '',
@Registration Varchar(25) = '',
@Location Varchar(255) = '',
@FlightID int OUTPUT
as
Begin

Insert Into TblFlightDetails(Make,Model,Registration,Location,CreatedDate) Values(@Make,@Model,@Registration,@Location,GetDate())
Select @FlightID = @@IDENTITY

End

Go

CREATE Procedure [dbo].[GetAirCraftList]
as
Begin
Select Id,Make,Model,Registration,Location,CreatedDate from TblFlightDetails with (nolock) Order by CreatedDate desc
End

Go