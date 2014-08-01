--Preconditions: 
--				an empty database named camdremData

--Postconditions:
--				a database with 9 tables representing users, user progress, user schedule,
--				and flashcards capable of holding text and multimedia

--Description:
--				tested on SQL Server 2012, if not user sqlexpress the "GO" statements should be omitted
--				if using with a database that already exist drop states need to be placed before every
--				create or constraint command.  This may cause errors but execution will complete with 
--				desired outcome

--Written By:
--				Cordell Dennis
--				7/27/14

USE camdremData;
GO

CREATE SCHEMA allData AUTHORIZATION dbo;
GO

CREATE TABLE camdremData.allData.Users ( 
	userId int 
		IDENTITY(1,1) CONSTRAINT PK_Users PRIMARY KEY CLUSTERED, 
	userName nvarchar(20) NOT NULL
		CONSTRAINT AK_Users_UserName UNIQUE,
	userPassword text NOT NULL
);
GO

CREATE TABLE camdremData.allData.ResourceTypes(
	resourceTypeID int 
		IDENTITY(1,1) CONSTRAINT PK_ResourceTypes PRIMARY KEY CLUSTERED,
	resourceTypename nvarChar(20) NOT NULL
);
GO

CREATE TABLE camdremData.allData.MultimediaResources(
	resourceID int 
		IDENTITY(1,1) CONSTRAINT PK_multimediaResources PRIMARY KEY CLUSTERED,
	resourceTypeID int NOT NULL
		CONSTRAINT FK_ResourceTypes_MultimediaResources FOREIGN KEY REFERENCES camdremData.allData.ResourceTypes( resourceTypeID ), 
	resourcePath text NOT NULL
);
GO

CREATE TABLE camdremData.allData.Cards (
	cardID int 
		IDENTITY(1,1) CONSTRAINT PK_Cards PRIMARY KEY CLUSTERED, 
		frontText text, 
		backText text, 
		frontMediaID int
			CONSTRAINT FK_MultimediaResources_Cards1 FOREIGN KEY REFERENCES camdremData.allData.MultimediaResources( resourceID ), 
		backMediaID int
			CONSTRAINT FK_MultimediaResources_Cards2  FOREIGN KEY REFERENCES camdremData.allData.MultimediaResources( resourceID ), 
);
GO

CREATE TABLE camdremData.allData.Decks(
	deckID int 
		IDENTITY(1,1) CONSTRAINT PK_Decks PRIMARY KEY CLUSTERED, 
	deckName nvarchar(50) NOT NULL, 
	deckDescription nvarchar(1000)
);
GO

CREATE TABLE camdremData.allData.UserDeckLookUp(
	userID int NOT NULL
		CONSTRAINT FK_Users_UserDeckLookUp FOREIGN KEY REFERENCES camdremData.allData.Users ( userID ), 
	deckID int NOT NUll
		CONSTRAINT FK_Decks_UserDeckLookUp FOREIGN KEY REFERENCES camdremData.allData.Decks( deckID ) 
);
GO

CREATE TABLE camdremData.allData.DeckCardLookUp(
	deckID int NOT NULL
		CONSTRAINT FK_Decks_DeckCardLookUp FOREIGN KEY REFERENCES camdremData.allData.Decks( deckID ), 
	cardID int NOT NULL
		CONSTRAINT FK_Cards_DeckCardLookUp FOREIGN KEY REFERENCES camdremData.allData.Cards( cardID )
);
GO

CREATE TABLE camdremData.allData.RecallLookUp (
	recallRating tinyint 
		CONSTRAINT PK_RecallLookup PRIMARY KEY CLUSTERED,
	description nvarchar NOT NULL
);
GO

CREATE TABLE camdremData.allData.ProgressRecords(
	userID int NOT NULL
		CONSTRAINT FK_Users_ProgressRecords FOREIGN KEY REFERENCES camdremData.allData.Users( userID ),
	cardID int NOT NULL
		CONSTRAINT FK_Cards_ProgressRecords FOREIGN KEY REFERENCES camdremData.allData.Cards( cardID ),
	recordDate datetime NOT NULL, 
	recallRating tinyint NOT NULL
		CONSTRAINT FK_RecallLookUp_ProgressRecords FOREIGN KEY REFERENCES camdremData.allData.RecallLookUp( recallRating )
);

ALTER TABLE camdremData.allData.ProgressRecords WITH NOCHECK 
	ADD CONSTRAINT PK_ProgressRecords PRIMARY KEY ( userID, cardID, recordDate );

GO

CREATE TABLE camdremData.allData.ScheduleRecords(
	userID int NOT NULL
		CONSTRAINT FK_Users_ScheduleRecords FOREIGN KEY REFERENCES camdremData.allData.Users( userID ),
	cardID int NOT NULL
		CONSTRAINT FK_Cards_Schedulerecords FOREIGN KEY REFERENCES camdremData.allData.Cards( cardID ),
	scheduleDate datetime NOT NULL
);

ALTER TABLE camdremData.allData.ScheduleRecords WITH NOCHECK
	ADD CONSTRAINT PK_ScheduleRecords PRIMARY KEY (userID, cardID );
GO

