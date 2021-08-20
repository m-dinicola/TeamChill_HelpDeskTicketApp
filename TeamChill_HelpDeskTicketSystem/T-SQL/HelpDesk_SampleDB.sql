CREATE DATABASE HelpDeskDB;
GO

USE HelpDeskDB;
GO

CREATE TABLE UserTable
(
[UserEmail] NVARCHAR(63) PRIMARY KEY NOT NULL,
);
GO

CREATE TABLE HDTicket
(
  [TicketID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  [OpenDateTime] DATETIME NOT NULL,
  [Title] NVARCHAR(63) NOT NULL,
  [Type] NVARCHAR(31),
  [Department] NVARCHAR(31),
  [Complete] BIT NOT NULL,
  [UserEmail] NVARCHAR(63)FOREIGN KEY REFERENCES UserTable(UserEmail)
);
GO

CREATE TABLE HDComment (
CommentID INT PRIMARY KEY IDENTITY(0,1),
CommentDateTime DATETIME NOT NULL,
Body NVARCHAR(MAX),
UserEmail NVARCHAR(63) FOREIGN KEY REFERENCES UserTable(UserEmail),
TicketID INT NOT NULL FOREIGN KEY REFERENCES HDTicket(TicketID)
)

CREATE TABLE Bookmarks(
BookmarkID int Primary Key Identity(0,1),
TicketID int NOT NULL Foreign Key References HDTicket(TicketID),
UserEmail Nvarchar(63) NOT NULL Foreign Key References UserTable(UserEmail),
)
GO

TRUNCATE TABLE Bookmarks;
TRUNCATE TABLE HDComment;
DELETE FROM HDTicket;
DELETE FROM UserTable;
DBCC CHECKIDENT (HDTicket, RESEED, 0);
GO

INSERT INTO UserTable (UserEmail) VALUES
('Leonardo@TMNT.com'),
('Donetello@TMNT.com'),
('Michelangelo@TMNT.com'),
('Raphael@TMNT.com'),
('JasonLeeScott@MMPR.com'),
('ZackTaylor@MMPR.com'),
('BillyCranston@MMPR.com'),
('TriniKwan@MMPR.com'),
('KimberlyAnnHart@MMPR.com'),
('TommyOliver@MMPR.com');
GO

INSERT INTO HDTicket (OpenDateTime, UserEmail, Title, Department, Complete) VALUES
('2021-08-19 19:31:00', 'Leonardo@TMNT.com','Broken Katana', 'Weapons', 0),
('2021-07-19 13:45:00', 'Donetello@TMNT.com','Upgrade needed', 'Technology', 0),
('2021-08-07 13:45:00', 'Michelangelo@TMNT.com','Missng Pizza', 'Food', 0),
('2021-01-07 13:45:00', 'Raphael@TMNT.com','More Missing Pizza', 'Food', 0),
('2021-08-07 10:00:00', NULL,'Tyrannosaurus Tune-up', 'Technology', 0),
('2021-02-25 12:45:00', NULL,'Broken speakers', 'Technology', 0),
('2021-08-07 13:45:00', NULL,'Alpha-5 malfunction', 'Technology', 0),
('2021-04-06 01:33:00', NULL,'Sabre Tooth Extraction', 'Weapons', 0),
('2021-01-03 09:45:00', NULL,'Archery question', 'Technology', 0),
('2021-08-07 13:45:00', NULL,'Rita Spam Calls', 'Technology', 0);
GO

INSERT INTO HDComment (CommentDateTime, Body, UserEmail, TicketID) VALUES 
('2021-08-19 19:31:00', 
	'Master Splinter? I broke one of my katanas the other day and now I need a new one. I don''t know where the tip is...', 
	'Leonardo@TMNT.com', 
	1),
('2021-07-19 13:45:00', 
	'Ummm... I think we need a new fridge... Don''t ask why...', 
	'Donetello@TMNT.com',
	2),
('2021-08-07 13:45:00', 
	'Sooo, I was saving a pie that April got for me, but I cant find it anywhere.',
	'Michelangelo@TMNT.com',
	3),
('2021-08-07 14:40:00', 
	'It wasn''t me, bro. Dunno what to tell you Mikie. *shrug* Maybe it was Raffi?',
	'Leonardo@TMNT.com',
	3),
('2021-08-07 14:42:00', 
	'I KNEW it was you Leo! The lock on the fridge was all cut up and I found a piece of Katana wedged in the door!',
	'Michelangelo@TMNT.com',
	3),
('2021-01-07 13:45:00',
	'Hey guys? Have you seen my Whipped cream, Sashimi, Banana and Sausage pizza? It''s the third pizza I''ve lost this week! ',
	'Raphael@TMNT.com',
	4);

Select * from Bookmarks;
Select * from HDComment;
Select * from HDTicket;
Select * from UserTable;
