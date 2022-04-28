--������� ���� ������
create database TestDb

use TestDb

--������� �������
CREATE TABLE [dbo].[ProjectTable](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Code] [varchar](20) NOT NULL,
	[DateCreate] [datetime] NOT NULL,
	[DateUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProjectTable] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DesignObjectTable](
	[DesignObjectId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Code] [varchar](20) NOT NULL,
	[DateCreate] [datetime] NOT NULL,
	[DateUpdate] [datetime] NOT NULL,
	[ProjectId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DesignObjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DesignObjectTable]  WITH CHECK ADD FOREIGN KEY([ProjectId])
REFERENCES [dbo].[ProjectTable] ([ProjectId])
GO

CREATE TABLE [dbo].[ObjectTable](
	[ObjectId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Code] [varchar](20) NOT NULL,
	[DateCreate] [datetime] NOT NULL,
	[DateUpdate] [datetime] NOT NULL,
	[DesignObjectId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ObjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ObjectTable]  WITH CHECK ADD FOREIGN KEY([DesignObjectId])
REFERENCES [dbo].[DesignObjectTable] ([DesignObjectId])
GO

--������� ������
insert into ProjectTable (Name, Code, DateCreate, DateUpdate)
values 
('������� �������', '', GETDATE(), GETDATE()),
('����������', '', GETDATE(), GETDATE()),
('��������� � �������', '', GETDATE(), GETDATE())

insert into DesignObjectTable (Name, Code, ProjectId, DateCreate, DateUpdate)
values
('����������', '', (select top 1 ProjectId from ProjectTable where Name = '������� �������'), GETDATE(), GETDATE()),
('������������', '', (select top 1 ProjectId from ProjectTable where Name = '������� �������'), GETDATE(), GETDATE()),
('��������', '', (select top 1 ProjectId from ProjectTable where Name = '����������'), GETDATE(), GETDATE()),
('���������', '', (select top 1 ProjectId from ProjectTable where Name = '����������'), GETDATE(), GETDATE()),
('��������� ��������', '', (select top 1 ProjectId from ProjectTable where Name = '��������� � �������'), GETDATE(), GETDATE()),
('���������', '', (select top 1 ProjectId from ProjectTable where Name = '��������� � �������'), GETDATE(), GETDATE())

insert into ObjectTable (Name, Code, DesignObjectId, DateCreate, DateUpdate)
values
('LG', '', (select top 1 DesignObjectId from DesignObjectTable where Name = '����������'), GETDATE(), GETDATE()),
('Samsung', '', (select top 1 DesignObjectId from DesignObjectTable where Name = '����������'), GETDATE(), GETDATE()),
('Hyundai', '', (select top 1 DesignObjectId from DesignObjectTable where Name = '������������'), GETDATE(), GETDATE()),
('DEXP', '', (select top 1 DesignObjectId from DesignObjectTable where Name = '������������'), GETDATE(), GETDATE()),
('ASUS', '', (select top 1 DesignObjectId from DesignObjectTable where Name = '��������'), GETDATE(), GETDATE()),
('Lenovo', '', (select top 1 DesignObjectId from DesignObjectTable where Name = '��������'), GETDATE(), GETDATE()),
('HP', '', (select top 1 DesignObjectId from DesignObjectTable where Name = '���������'), GETDATE(), GETDATE()),
('Acer', '', (select top 1 DesignObjectId from DesignObjectTable where Name = '���������'), GETDATE(), GETDATE()),
('INOI', '', (select top 1 DesignObjectId from DesignObjectTable where Name = '��������� ��������'), GETDATE(), GETDATE()),
('Digma', '', (select top 1 DesignObjectId from DesignObjectTable where Name = '��������� ��������'), GETDATE(), GETDATE()),
('Xiaomi', '', (select top 1 DesignObjectId from DesignObjectTable where Name = '���������'), GETDATE(), GETDATE()),
('IPhone', '', (select top 1 DesignObjectId from DesignObjectTable where Name = '���������'), GETDATE(), GETDATE())


