INSERT INTO user (username, password) values("initialUser","initialPassword");
INSERT INTO user (username, password, AccessToken) values("initialUserWithToken","initialPassword","token");


INSERT INTO timeentry(userId, entryDate, distance, timeElapsed) values (2, date('now'), 10, 10);
INSERT INTO timeentry(userId, entryDate, distance, timeElapsed) values (2, date('now'), 40, 40);
INSERT INTO timeentry(userId, entryDate, distance, timeElapsed) values (2, date('now','-5 day'), 10, 10);
INSERT INTO timeentry(userId, entryDate, distance, timeElapsed) values (2, date('now','-3 day'), 10, 10);