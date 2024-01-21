USE [Employee]
GO

/****** Object:  Table [dbo].[tbl_Employee]    Script Date: 22-01-2024 03:16:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,--primary key
	[EmployeeName] [varchar](50) NULL,
	[Designation] [varchar](100) NOT NULL,
	[Salary] [decimal](18, 5) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[DateOfJoining] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


