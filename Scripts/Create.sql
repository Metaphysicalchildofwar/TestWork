--Создать базу данных
create database TestDb

use TestDb

--Создать таблицы
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

--Создать данные
insert into ProjectTable (Name, Code, DateCreate, DateUpdate)
values 
('Бытовая техника', '', GETDATE(), GETDATE()),
('Компьютеры', '', GETDATE(), GETDATE()),
('Смартфоны и гаджеты', '', GETDATE(), GETDATE())

insert into DesignObjectTable (Name, Code, ProjectId, DateCreate, DateUpdate)
values
('Телевизоры', '', (select top 1 ProjectId from ProjectTable where Name = 'Бытовая техника'), GETDATE(), GETDATE()),
('Холодильники', '', (select top 1 ProjectId from ProjectTable where Name = 'Бытовая техника'), GETDATE(), GETDATE()),
('Ноутбуки', '', (select top 1 ProjectId from ProjectTable where Name = 'Компьютеры'), GETDATE(), GETDATE()),
('Моноблоки', '', (select top 1 ProjectId from ProjectTable where Name = 'Компьютеры'), GETDATE(), GETDATE()),
('Кнопочные телефоны', '', (select top 1 ProjectId from ProjectTable where Name = 'Смартфоны и гаджеты'), GETDATE(), GETDATE()),
('Смартфоны', '', (select top 1 ProjectId from ProjectTable where Name = 'Смартфоны и гаджеты'), GETDATE(), GETDATE())

insert into ObjectTable (Name, Code, DesignObjectId, DateCreate, DateUpdate)
values
('LG', '', (select top 1 DesignObjectId from DesignObjectTable where Name = 'Телевизоры'), GETDATE(), GETDATE()),
('Samsung', '', (select top 1 DesignObjectId from DesignObjectTable where Name = 'Телевизоры'), GETDATE(), GETDATE()),
('Hyundai', '', (select top 1 DesignObjectId from DesignObjectTable where Name = 'Холодильники'), GETDATE(), GETDATE()),
('DEXP', '', (select top 1 DesignObjectId from DesignObjectTable where Name = 'Холодильники'), GETDATE(), GETDATE()),
('ASUS', '', (select top 1 DesignObjectId from DesignObjectTable where Name = 'Ноутбуки'), GETDATE(), GETDATE()),
('Lenovo', '', (select top 1 DesignObjectId from DesignObjectTable where Name = 'Ноутбуки'), GETDATE(), GETDATE()),
('HP', '', (select top 1 DesignObjectId from DesignObjectTable where Name = 'Моноблоки'), GETDATE(), GETDATE()),
('Acer', '', (select top 1 DesignObjectId from DesignObjectTable where Name = 'Моноблоки'), GETDATE(), GETDATE()),
('INOI', '', (select top 1 DesignObjectId from DesignObjectTable where Name = 'Кнопочные телефоны'), GETDATE(), GETDATE()),
('Digma', '', (select top 1 DesignObjectId from DesignObjectTable where Name = 'Кнопочные телефоны'), GETDATE(), GETDATE()),
('Xiaomi', '', (select top 1 DesignObjectId from DesignObjectTable where Name = 'Смартфоны'), GETDATE(), GETDATE()),
('IPhone', '', (select top 1 DesignObjectId from DesignObjectTable where Name = 'Смартфоны'), GETDATE(), GETDATE())


