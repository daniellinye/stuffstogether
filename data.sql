-- opdracht 1
SELECT COURSES.Name, COUNT(Teachers) 
FROM STUDENTS, COURSES 
WHERE STUDENTS.ID = COURSES.STID;

-- opdracht 2
SELECT * 
FROM ASSIGNMENTS, STUDENTS 
WHERE STUDENTS.ID = ASSIGNMENTS.STID AND ASSIGNMENTS.IsValid = false;

-- opdracht 3
SELECT TEACHERS.Name, COURSES.Owner, ASSIGNMENTS.Owner 
FROM TEACHERS, COURSES, ASSIGNMENTS 
WHERE TEACHERS.Name = COURSES.Owner AND NOT IN ASSIGNMENTS.Owner;

-- opdracht 4
SELECT * FROM COURSES, STUDENTS ORDER BY STUDENTS.Enrollment_Year DESC 
WHERE COURSES.STID = STUDENTS.ID;

-- opdracht 5 TODO IM SO DONE W THIS SHEIT  
SELECT COUNT(COURSES.Owner)/COUNT(COURSES) AS Average, COUNT(COURSES.Owner = TEACHERS.BSN) AS TClasses, * 
FROM COURSES, TEACHER 
WHERE COURSES.Owner = TEACHERS.BSN AND (TClasses < 2 OR TClasses > Average);

-- opdracht 6
SELECT STUDENTS.ID 
FROM STUDENTS, ASSIGNMENTS 
WHERE STUDENTS.ID = ASSIGNMENTS.STID AND ASSIGNMENTS.IsValid = true;

-- opdracht 7
SELECT STUDENTS.ID 
FROM STUDENTS, TEACHERS, COURSES 
WHERE COUNT(COURSE.Owner) = COUNT(STUDENTS.Teachers INTERSECT COURSE.Owner)

-- opdracht 8
SELECT ASSIGNMENTS.Owner AS Owner, COUNT(ASSIGNMENTS.Owner), TEACHERS.BSN as bsn
FROM ASSIGNMENTS, TEACHERS 
WHERE Owner = bsn

-- opdracht 9
SET @TempVar int = 0;
SELECT TEACHERS.Salary, COUNT(ASSIGNMENTS.Owner = TEACHERS.BSN) AS totalAss,  * 
FROM TEACHERS, COURSES, ASSIGNMENTS
WHERE COURSES.Owner = TEACHERS.BSN 
AND ASSIGNMENTS.Owner = TEACHERS.BSN 
AND TEACHERS.Salary < 2000 + COUNT(COURSE.STID) * 0.1 + totalAss * 50 + ROUND(COUNT(COURSE.STID) + totalAss), -1) * 50;
  