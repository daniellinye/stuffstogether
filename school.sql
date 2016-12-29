CREATE DATABASE school;




CREATE TABLE STUDENTS
(
	ID int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
	BSN int(9),
	Enrollment_Year int(4),
	Name varchar(255),
	Surname varchar(255),
	Teachers int(9),
	FOREIGN KEY (STID) REFERENCES COURSES(ID)
);




CREATE TABLE TEACHERS
(
	BSN int(9) NOT NULL PRIMARY KEY,
	Salary float(11),
	Scale float(4),
	Name varchar(255)
);




CREATE TABLE COURSES
(
	CODE varchar(255) NOT NULL PRIMARY KEY,
	Owner int(9),
	Name varchar(255),
	STID int(11),
	StudyPoints int(2),
	FOREIGN KEY (Owner) REFERENCES TEACHERS(BSN)
);




CREATE TABLE ASSIGNMENTS
(
	CODE varchar(255) NOT NULL PRIMARY KEY,
	Owner int(9),
	Week int(2),
	Year int(4),
	AssesmentType int(1),
	STID int(11),
	IsValid boolean,
	FOREIGN KEY (CODE) REFERENCES COURSES(CODE),
	FOREIGN KEY (Owner) REFERENCES TEACHERS(BSN),
	FOREIGN KEY (STID) REFERENCES STUDENTS(ID)
);


--Insert Statements

INSERT INTO ASSIGNMENTS
VALUES ('Final Maymay assignment', 123456782, 34, 2016, 1, 123, false);


INSERT INTO COURSES
VALUES ('maymayCourse', 9212121, 'Learn 2 meme', 12312321, 6);




INSERT INTO STUDENTS
VALUES ('589761961', 123456782, 2016, 'John', 'Smith');


SELECT * FROM STUDENTS WHERE ID = 1337