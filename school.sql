CREATE DATABASE school;


CREATE TABLE STUDENTS
(
	ID int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
	BSN int(9),
	Enrollment_Year int(4),
	Name varchar(255),
	Surname varchar(255)
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
	FOREIGN KEY (Owner) REFERENCES TEACHERS(BSN),
	FOREIGN KEY (STID) REFERENCES STUDENTS(ID)
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




INSERT INTO ASSIGNMENTS
VALUES ('Final Maymay assignment', 34, 2016, 'summative');


INSERT INTO COURSES
VALUES ('maymayCourse', 'Learn 2 meme', 6);


INSERT INTO STUDENTS
VALUES ('589761961', 2016, 'John', 'Smith');


-- get student 👌
SELECT * FROM STUDENTS WHERE ID = 1337

UPDATE COURSES, ASSIGNMENTS, STUDENTS;



