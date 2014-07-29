/****** Object:  Table [dbo].[TokenStorage]    Script Date: 24/07/2014 09:47:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TokenStorage](
	[id] [nvarchar](255) NOT NULL,
	[id_salt] [nvarchar](255) NOT NULL,
	[token_hash] [nvarchar](255) NOT NULL,
	[token_salt] [nvarchar](255) NOT NULL,
	[token_method] [nvarchar](10) NOT NULL,
	[token_iterations] [int] NOT NULL,
	[issued_at] [datetime] NOT NULL,
	[refreshed] [datetime] NOT NULL,
	[user_id] int NOT NULL
 CONSTRAINT [PK_TokenStorage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


