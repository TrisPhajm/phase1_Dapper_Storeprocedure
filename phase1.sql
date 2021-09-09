USE [DEMO]
GO

/****** Object:  Table [dbo].[Tri_StudentGrade]    Script Date: 9/9/2021 5:05:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tri_StudentGrade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[Grade] [int] NOT NULL,
	[DeleteFlag] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tri_StudentGrade]  WITH CHECK ADD  CONSTRAINT [fk_StudentGrade_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Tri_Students] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Tri_StudentGrade] CHECK CONSTRAINT [fk_StudentGrade_Students]
GO

ALTER TABLE [dbo].[Tri_StudentGrade]  WITH CHECK ADD  CONSTRAINT [fk_StudentGrade_Subjects] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Tri_Subjects] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Tri_StudentGrade] CHECK CONSTRAINT [fk_StudentGrade_Subjects]
GO

CREATE TABLE [dbo].[Tri_Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Class] [varchar](100) NOT NULL,
	[DeleteFlag] [tinyint] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Tri_Subjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[DeleteFlag] [tinyint] NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE proc [dbo].[Tri_CreateStudent]
	@Name varchar(100),
	@Class varchar(100)
as
begin
	DECLARE @MyTableVar table( Id int,
                           Name varchar(100),
                           Class varchar(100) );
	insert into dbo.Tri_Students(Name,Class,DeleteFlag) output inserted.Id,inserted.Name,inserted.Class into @MyTableVar values (@Name,@Class,0)
	select Id,Name,Class from @MyTableVar
end
GO

CREATE proc [dbo].[Tri_CreateSubject]
	@Name varchar(100)
as
begin
	DECLARE @MyTableVar table( Id int,
                           Name varchar(100)
						   );
	insert into dbo.Tri_Subjects(Name,DeleteFlag) output inserted.Id,inserted.Name into @MyTableVar values (@Name,0)
	select Id,Name from @MyTableVar
end
GO

Create proc [dbo].[Tri_DeleteStudentById]
	@Id int
as
begin
	UPDATE dbo.Tri_Students
	SET DeleteFlag = 1
	WHERE Id = @Id;
end
GO

Create proc [dbo].[Tri_DeleteSubjectById]
	@Id int
as
begin
	UPDATE dbo.Tri_Subjects
	SET DeleteFlag = 1
	WHERE Id = @Id;
end
GO

CREATE PROCEDURE [dbo].[Tri_GetStudentById]
            @Id int
        AS
        BEGIN
            SET NOCOUNT ON;
            select * from dbo.Tri_Students where Id = @Id and DeleteFlag = 0
        END
GO

CREATE PROCEDURE [dbo].[Tri_GetStudentGradeByStudentId]
            @StudentId int
        AS
        BEGIN
            select dbo.Tri_StudentGrade.Grade, dbo.Tri_StudentGrade.Id, dbo.Tri_StudentGrade.StudentId , dbo.Tri_StudentGrade.SubjectId , dbo.Tri_Subjects.Name as SubjectName
			from dbo.Tri_StudentGrade,dbo.Tri_Subjects
			where dbo.Tri_StudentGrade.StudentId = @StudentId and dbo.Tri_StudentGrade.SubjectId = dbo.Tri_Subjects.Id and dbo.Tri_StudentGrade.DeleteFlag = 0 and dbo.Tri_Subjects.DeleteFlag = 0
        END
GO

CREATE proc [dbo].[Tri_GetStudents]
as
begin
	select * from dbo.Tri_Students where DeleteFlag = 0
end
GO

CREATE PROCEDURE [dbo].[Tri_GetSubjectById]
            @Id int
        AS
        BEGIN
            SET NOCOUNT ON;
            select * from dbo.Tri_Subjects where Id = @Id and DeleteFlag = 0
        END
GO

CREATE proc [dbo].[Tri_GetSubjects]
as
begin
	select * from dbo.Tri_Subjects where DeleteFlag = 0
end
GO

Create proc [dbo].[Tri_PutStudentById]
	@Id int,
	@Name varchar(100),
	@Class varchar(100)
as
begin
	UPDATE dbo.Tri_Students
	SET Name = @Name, Class=@Class
	WHERE Id = @Id;
end
GO

Create proc [dbo].[Tri_PutSubjectById]
	@Id int,
	@Name varchar(100)
as
begin
	UPDATE dbo.Tri_Subjects
	SET Name = @Name
	WHERE Id = @Id;
end
GO


