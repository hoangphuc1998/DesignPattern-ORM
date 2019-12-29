use school;

drop table if exists Students;
drop table if exists Classes;

CREATE TABLE Classes (
    ID INT NOT NULL AUTO_INCREMENT,
	Name VARCHAR(10),
    PRIMARY KEY (ID)
);

create table Students (
	ID int NOT NULL AUTO_INCREMENT,
    Name  varchar(100) CHARACTER SET utf8mb4,
	IsMale boolean,
    Email varchar(100),
    PhoneNumber varchar(100),
    Address varchar(100) CHARACTER SET utf8mb4,
    DOB date,
	ClassID int,
    primary key (ID),
    foreign key (ClassID) references Classes(ID)
);

INSERT INTO Classes(Name) VALUES ('10A1');
INSERT INTO Classes(Name) VALUES ('10A2');
INSERT INTO Classes(Name) VALUES ('11A1');
INSERT INTO Classes(Name) VALUES ('11A2');
INSERT INTO Classes(Name) VALUES ('12A1');
INSERT INTO Classes(Name) VALUES ('12A2');
INSERT INTO Classes(Name) VALUES ('12A3');

INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Antonio Hansley',FALSE,'ahansley44@youtu.be','367-724-9680',N'518 Northview Place','2004-10-18',4);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Ram Paler',FALSE,'rpalerc6@jalbum.net','453-657-8250',N'4264 Shasta Court','2004-03-19',7);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Christoforo Harroll',TRUE,'charrollav@hhs.gov','533-752-0371',N'91 Columbus Junction','2004-08-14',3);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Cecily Santry',FALSE,'csantry43@vistaprint.com','950-338-3720',N'52 Monica Plaza','2003-12-23',2);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Cynthea Skamell',FALSE,'cskamell67@twitter.com','442-587-7959',N'13 Gina Plaza','2003-12-25',1);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Francisca Laite',FALSE,'flaite75@washington.edu','879-630-6685',N'56 Heath Pass','2002-10-28',2);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Deanne Tremayle',TRUE,'dtremayle9b@nbcnews.com','382-923-1672',N'29201 Bellgrove Road','2004-12-04',6);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Gaultiero Lowes',FALSE,'glowes9i@craigslist.org','255-361-6017',N'8 Helena Crossing','2002-10-19',5);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Ricky Hughes',TRUE,'rhughes51@google.cn','679-821-1405',N'3 Melody Center','2002-03-23',4);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Irvine Brosius',FALSE,'ibrosiusa0@technorati.com','311-893-7432',N'5125 Oneill Street','2003-04-09',5);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Sanson Bowlas',TRUE,'sbowlas3s@usa.gov','427-696-9385',N'8 Mockingbird Trail','2003-10-03',2);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Loutitia Weatherley',FALSE,'lweatherleybn@netvibes.com','961-953-3112',N'8999 Knutson Avenue','2003-03-01',6);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Edith Abramovitch',FALSE,'eabramovitch2z@adobe.com','131-556-1375',N'248 Dahle Parkway','2004-12-22',6);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Eimile Chettle',TRUE,'echettlecb@instagram.com','437-793-9208',N'5 Buena Vista Circle','2002-01-25',2);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Alley MacAllister',FALSE,'amacallister6s@altervista.org','109-213-7632',N'4 Brickson Park Park','2002-10-29',2);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Dene Slack',FALSE,'dslack7c@hhs.gov','111-453-7065',N'6 Steensland Junction','2002-10-12',7);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Tyne McDowall',FALSE,'tmcdowallay@example.com','517-905-7226',N'1 Starling Point','2002-03-07',2);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Tab Greenway',FALSE,'tgreenwaydm@ning.com','869-493-6112',N'373 Larry Park','2003-07-25',4);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Jocelyn Philipot',FALSE,'jphilipota2@quantcast.com','262-166-4922',N'8 Monica Crossing','2002-08-08',5);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Viviyan Magne',FALSE,'vmagneat@alexa.com','139-842-4296',N'5 Elka Terrace','2002-10-28',4);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Geri Pontain',TRUE,'gpontain2e@dagondesign.com','535-975-6652',N'7 Roxbury Circle','2003-12-22',3);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Keefe Wilkinson',TRUE,'kwilkinson8o@google.com.au','857-167-1721',N'05374 Annamark Center','2002-04-18',5);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Oralle Esel',TRUE,'oesel5u@jalbum.net','912-373-0380',N'63 Darwin Circle','2004-12-28',7);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Harlan Pengelly',TRUE,'hpengelly7r@loc.gov','563-684-7067',N'24 Gulseth Court','2004-09-26',2);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Britni Odgaard',FALSE,'bodgaardcr@globo.com','928-936-1183',N'2 Aberg Lane','2003-04-28',1);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Sonny Spybey',TRUE,'sspybey64@businesswire.com','196-830-2230',N'7 Norway Maple Alley','2003-05-10',4);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Alfred Sailes',FALSE,'asailes9u@multiply.com','314-509-1354',N'9540 Granby Point','2004-05-21',2);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Stephannie Salack',FALSE,'ssalack6n@disqus.com','455-614-5260',N'81577 Almo Lane','2003-12-19',5);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Bevin Noah',FALSE,'bnoah9q@illinois.edu','573-805-8586',N'96853 Hauk Lane','2003-08-21',2);
INSERT INTO Students(Name,IsMale,Email,PhoneNumber,Address,DOB,ClassID) VALUES (N'Beilul Poplee',FALSE,'bpoplee6f@themeforest.net','271-957-3783',N'5 Autumn Leaf Junction','2002-04-16',4);

