CREATE DATABASE OnlineSMS
GO
USE OnlineSMS
GO

CREATE TABLE Account
(
    AccId INT PRIMARY KEY IDENTITY(1,1),
	FullName NVARCHAR(255) NOT NULL,
	Email VARCHAR(255) UNIQUE NOT NULL,
	Phone VARCHAR(10) UNIQUE NOT NULL,
	Password VARCHAR(255) NOT NULL,
	Avatar VARCHAR(255),
	CreatedAt DATETIME
)
GO

CREATE TABLE AccountInfo
(
    Id INT PRIMARY KEY IDENTITY(1,1),
	AccId INT FOREIGN KEY REFERENCES Account(AccId),
	Gender BIT NOT NULL,
	Birthday DATE NOT NULL,
	Address NVARCHAR(255) NOT NULL,
	MaritalStatus NVARCHAR(255),
	Interests NVARCHAR(255),
	Dislike NVARCHAR(255),
	Degree NVARCHAR(255),
	Schools NVARCHAR(255),
	JobStatus NVARCHAR(255),
)
GO

CREATE TABLE Friend
(
    Id INT PRIMARY KEY IDENTITY(1,1),
	AccId INT FOREIGN KEY REFERENCES Account(AccId),
	AccIdFriend INT FOREIGN KEY REFERENCES Account(AccId),
	Relationship BIT NOT NULL,
	Status BIT NOT NULL,
	CreatedAt DATETIME NOT NULL
)
GO

CREATE TABLE Post
(
   PostId INT PRIMARY KEY IDENTITY(1,1),
   AccId INT FOREIGN KEY REFERENCES Account(AccId),
   Image VARCHAR(255),
   Content NTEXT,
   Status INT NOT NULL,
   CreatedAt DATETIME 
)
GO

CREATE TABLE Message
(
    Id INT PRIMARY KEY IDENTITY(1,1),
	FromAccId INT NOT NULL,
	ToAccId INT NOT NULL,
	Content NTEXT NOT NULL,
	Status INT NOT NULL,
	CreatedAt DATETIME 
)
GO
insert into Account(FullName,Email,Phone,Password,Avatar,CreatedAt) values(N'Ha Dinh Tien','tien@gmail.com','0985173353','12341234','avatar.png','11-01-2022')
insert into Account(FullName,Email,Phone,Password,Avatar,CreatedAt) values(N'Nguyen Huu Hoang','hoang@gmail.com','0985173352','12341234','avatar.png','11-01-2022')
insert into Account(FullName,Email,Phone,Password,Avatar,CreatedAt) values(N'Nguyen Duc Vinh','vinh@gmail.com','0985173351','12341234','avatar.png','11-01-2022')
insert into Account(FullName,Email,Phone,Password,Avatar,CreatedAt) values(N'Ngo Kim Tring','trung@gmail.com','0985173350','12341234','avatar.png','11-01-2022')
insert into Account(FullName,Email,Phone,Password,Avatar,CreatedAt) values(N'Ngoc anh','ngocanh@gmail.com','0985173354','12341234','Anh1.png','11-01-2022')
insert into Account(FullName,Email,Phone,Password,Avatar,CreatedAt) values(N'Khánh huyền','huyen@gmail.com','0985173355','12341234','avatar.png','11-01-2022')
GO
insert into Friend(AccId,AccIdFriend,Relationship,Status,CreatedAt) values(1,3,1,1,'11-01-2022')
insert into Friend(AccId,AccIdFriend,Relationship,Status,CreatedAt) values(3,1,1,1,'11-01-2022')
insert into Friend(AccId,AccIdFriend,Relationship,Status,CreatedAt) values(1,4,1,1,'11-01-2022')
insert into Friend(AccId,AccIdFriend,Relationship,Status,CreatedAt) values(4,1,1,1,'11-01-2022')
insert into Friend(AccId,AccIdFriend,Relationship,Status,CreatedAt) values(5,2,1,1,'11-01-2022')
insert into Friend(AccId,AccIdFriend,Relationship,Status,CreatedAt) values(2,5,1,1,'11-01-2022')
insert into Friend(AccId,AccIdFriend,Relationship,Status,CreatedAt) values(6,2,1,1,'11-01-2022')
insert into Friend(AccId,AccIdFriend,Relationship,Status,CreatedAt) values(2,6,1,1,'11-01-2022')

insert into Friend(AccId,AccIdFriend,Relationship,Status,CreatedAt) values(1,5,1,0,'11-01-2022')
insert into Friend(AccId,AccIdFriend,Relationship,Status,CreatedAt) values(2,4,1,0,'11-01-2022')
insert into Friend(AccId,AccIdFriend,Relationship,Status,CreatedAt) values(3,6,1,0,'11-01-2022')
insert into Friend(AccId,AccIdFriend,Relationship,Status,CreatedAt) values(1,6,1,0,'11-01-2022')
insert into Friend(AccId,AccIdFriend,Relationship,Status,CreatedAt) values(5,3,1,0,'11-01-2022')
insert into Friend(AccId,AccIdFriend,Relationship,Status,CreatedAt) values(4,6,1,0,'11-01-2022')
insert into Friend(AccId,AccIdFriend,Relationship,Status,CreatedAt) values(6,5,1,0,'11-01-2022')

select * from Friend
GO
insert into Message(FromAccId,ToAccId,Content,Status,CreatedAt) values(3,1,'Hi, how are you ?',1,'11-01-2022')
insert into Message(FromAccId,ToAccId,Content,Status,CreatedAt) values(3,1,'What are you doing tonight ? Want to go take a drink ?',1,'11-01-2022')
insert into Message(FromAccId,ToAccId,Content,Status,CreatedAt) values(1,3,'Hey Megan ! Its been a while 😃',1,'11-01-2022')
insert into Message(FromAccId,ToAccId,Content,Status,CreatedAt) values(1,3,'When can we meet ?',1,'11-01-2022')
insert into Message(FromAccId,ToAccId,Content,Status,CreatedAt) values(3,1,'9 pm at the bar if possible 😳',1,'11-01-2022')
insert into Message(FromAccId,ToAccId,Content,Status,CreatedAt) values(2,5,'Helo',1,'11-01-2022')
insert into Message(FromAccId,ToAccId,Content,Status,CreatedAt) values(5,2,'Hi',1,'11-01-2022')
insert into Message(FromAccId,ToAccId,Content,Status,CreatedAt) values(2,5,'Helo',1,'11-01-2022')
insert into Message(FromAccId,ToAccId,Content,Status,CreatedAt) values(5,2,'Hi',1,'11-01-2022')
insert into Message(FromAccId,ToAccId,Content,Status,CreatedAt) values(2,6,'Helo',1,'11-01-2022')
insert into Message(FromAccId,ToAccId,Content,Status,CreatedAt) values(6,2,'Hi',1,'11-01-2022')
insert into Message(FromAccId,ToAccId,Content,Status,CreatedAt) values(2,6,'where are you from',1,'11-01-2022')
insert into Message(FromAccId,ToAccId,Content,Status,CreatedAt) values(1,4,'where are you from',1,'11-01-2022')
GO
insert into Post(AccId,Content,Image,Status,CreatedAt) values (2,'Earth is the only planet currently known to support life, and its natural features are the subject of many areas of scientific research.','anh1.jpeg',1,'11-01-2022')
insert into Post(AccId,Content,Image,Status,CreatedAt) values (3,'i don t have a girlfriend','vinh.jpg',1,'11-01-2022')
insert into Post(AccId,Content,Image,Status,CreatedAt) values (3,'lover','nyvinh.jpg',1,'11-01-2022')
insert into Post(AccId,Content,Image,Status,CreatedAt) values (4,'Can t be subjective !! #VamosEspana','Spana.jpg',1,'11-01-2022')
insert into Post(AccId,Content,Image,Status,CreatedAt) values (6,'Ahihi','huyen.jpg',1,'11-01-2022')
insert into Post(AccId,Content,Image,Status,CreatedAt) values (5,'lover','anhngoc.jpg',1,'11-01-2022')
insert into Post(AccId,Content,Image,Status,CreatedAt) values (1,'Can t be subjective','1.jpg',1,'11-01-2022')