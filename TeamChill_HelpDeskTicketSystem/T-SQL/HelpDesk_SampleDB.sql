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