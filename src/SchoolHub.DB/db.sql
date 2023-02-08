
CREATE DATABASE Schoolhub IF NOT EXISTS;

USE Schoolhub;

CREATE TABLE Role (
    id VARCHAR(36) NOT NULL DEFAULT UUID(),
    `Role` VARCHAR(10) NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE User (
    id VARCHAR(36) NOT NULL DEFAULT UUID(),
    username VARCHAR(100) NOT NULL,
    primaryMail VARCHAR(999) NOT NULL,
    `password` VARCHAR(255) NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE School (
    id VARCHAR(36) NOT NULL DEFAULT UUID(),
    schoolName VARCHAR(15),
    PRIMARY KEY(id)
);

CREATE TABLE Subject (
    id VARCHAR(36) NOT NULL DEFAULT UUID(),
    `subject` VARCHAR(25) NOT NULL,
    `weight` FLOAT NOT NULL,
    schoolId VARCHAR(36) NOT NULL,
    userId VARCHAR(36) NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(schoolId) REFERENCES School(id),
    FOREIGN KEY(userId) REFERENCES User(id)
);

CREATE TABLE SubjectSemester(
    subjectId VARCHAR(36) NOT NULL,
    semester INT NOT NULL,
    PRIMARY KEY(subjectId, semester),
    FOREIGN KEY (subjectId) REFERENCES `Subject`(id)
);

CREATE TABLE Grades (
    id VARCHAR(36) NOT NULL DEFAULT UUID(),
    grade FLOAT NOT NULL,
    `description` VARCHAR(30) NOT NULL,,
    userId VARCHAR(36) NOT NULL,
    `weight` FLOAT NOT NULL,
    subjectId VARCHAR(36) NOT NULL,
    semester INT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY (schoolId) REFERENCES School(id),
    FOREIGN KEY (subjectId) REFERENCES `Subject`(id),
    FOREIGN KEY (userId) REFERENCES User(id),
    FOREIGN KEY (subjectId, semester) REFERENCES SubjectSemester(subjectId, semester)
    
);

CREATE TABLE AppConnection (
    id VARCHAR(36) NOT NULL DEFAULT UUID(),
    email VARCHAR(255),
    token VARCHAR(255),
    appId VARCHAR(36) NOT NULL,
    userId VARCHAR(36) NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY (appId) REFERENCES App(id),
    FOREIGN KEY (userId) REFERENCES User(id)
);

CREATE TABLE App (
    id VARCHAR(36) NOT NULL DEFAULT UUID(),
    appName VARCHAR(30) NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE Appointment (
    id VARCHAR(36) NOT NULL DEFAULT UUID(),
    appointment VARCHAR(20) NOT NULL,
    `description` VARCHAR(50),
    `from` DATE NOT NULL,
    `to` DATE NOT NULL,
    userId VARCHAR(36) NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY (userId) REFERENCES User(id)
);

CREATE TABLE GradeConfigSubject (
    gradeConfigId VARCHAR(36) NOT NULL,
    subjectId VARCHAR(36) NOT NULL,
    PRIMARY KEY(gradeConfigId, subjectId),
    FOREIGN KEY (gradeConfigId) REFERENCES GradeConfig(id),
    FOREIGN KEY (subjectId) REFERENCES `Subject` (id)
);

CREATE TABLE GradeConfig (
    id VARCHAR(36) NOT NULL,
    numberOfSemesters INT NOT NULL,
    gradesRounding FLOAT NOT NULL,
    schoolRounding FLOAT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY (id) REFERENCES User(id)
);