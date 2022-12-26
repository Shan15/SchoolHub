drop
database if exists  hub;
create
database hub;
use
hub;
CREATE TABLE Role
(
    id   varchar(255) PRIMARY KEY not null unique,
    role varchar(20)              not null unique
);

CREATE TABLE User
(
    id       varchar(255) PRIMARY KEY NOT NULL UNIQUE,
    username varchar(30) unique       not null,
    password varchar(255)             NOT NULL,
    email    VARCHAR(50)              NOT NULL UNIQUE ,
    role_id   varchar(255)             NOT NULL REFERENCES Role (id)
);

CREATE TABLE Type
(
    id     varchar(255) PRIMARY KEY NOT NULL UNIQUE,
    type   varchar(20)              NOT NULL UNIQUE,
    user_id varchar(255)             NOT NULL REFERENCES User (id)
);

CREATE TABLE Appointment
(
    id          varchar(255) PRIMARY KEY NOT NULL UNIQUE,
    appointment varchar(20)              NOT NULL,
    description varchar(255) NULL,
    startDate   date                     NOT NULL,
    endDate     date                     NOT NULL,
    type_id      varchar(255)             NOT NULL REFERENCES Type (id),
    user_id      varchar(255)             NOT NULL REFERENCES User (id)
);

CREATE TABLE Subject
(
    id      varchar(255) PRIMARY KEY NOT NULL UNIQUE,
    subject varchar(20)              NOT NULL UNIQUE,
    user_id  varchar(255)             NOT NULL REFERENCES User (id)
);

CREATE TABLE Grade
(
    id        varchar(255) PRIMARY KEY NOT NULL UNIQUE,
    grade     float                    NOT NULL,
    date      date                     NOT NULL,
    semester  int                      NOT NULL,
    user_id    varchar(255)             NOT NULL REFERENCES User (id),
    subject_id varchar(255)             NOT NULL REFERENCES Subject (id)
);

CREATE TABLE Homework
(
    id        varchar(255) PRIMARY KEY NOT NULL UNIQUE,
    homework  varchar(30)              NOT NULL,
    dueDate   date                     NOT NULL,
    isDone    boolean                  NOT NULL,
    subject_id varchar(255)             NOT NULL REFERENCES Subject (id),
    user_id    varchar(255)             NOT NULL REFERENCES User (id)
);

CREATE TABLE Note
(
    id         varchar(255) PRIMARY KEY NOT NULL UNIQUE,
    note       text                     NOT NULL,
    date       date NULL,
    user_id     varchar(255)             NOT NULL REFERENCES User (id),
    homework_id varchar(255)             NOT NULL REFERENCES Homework (id)
);