-- opdracht 1
SELECT * FROM COURSES, TEACHERS WHERE COURSES.Owner = TEACHERS.BSN AND STID NOT NULL;

-- opdracht 2
SELECT * FROM COURSES, ASSIGMENTS, STUDENTS WHERE STUDENTS.STID = ASSIGMENTS.STID

