DROP TABLE IF EXISTS timeentry;
DROP TABLE IF EXISTS user;

CREATE TABLE user (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    username    VARCHAR NOT NULL,
    password    VARCHAR NOT NULL,
	accessToken VARCHAR
);

CREATE TABLE timeentry(
	id          INTEGER PRIMARY KEY AUTOINCREMENT,
	userId		INTEGER NOT NULL,
	entryDate   DATETIME,
	distance    DOUBLE,
	timeElapsed INTEGER,
	FOREIGN KEY(userId) REFERENCES user(id)
);