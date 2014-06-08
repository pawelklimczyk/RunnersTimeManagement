DROP TABLE IF EXISTS timeentry;
DROP TABLE IF EXISTS user;

CREATE TABLE user (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    username    VARCHAR NOT NULL,
    password    VARCHAR NOT NULL,
	AccessToken VARCHAR
);

CREATE TABLE timeentry(
	id          INTEGER PRIMARY KEY AUTOINCREMENT,
	entryDate   DATETIME
	distance    DOUBLE,
	timeElapsed INTEGER 
);