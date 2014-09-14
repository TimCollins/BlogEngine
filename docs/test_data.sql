-- Test data for the various tables.

-- Create an admin user.
INSERT INTO User (ID, Name, Password, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES (1, "Admin", "admin", CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1); 

-- Create some categories.
INSERT INTO Category (Name, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES ("Uncategorised", CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1);

INSERT INTO Category (Name, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES ("Interesting Stuff", CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1);

INSERT INTO Category (Name, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES ("Sport", CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1);

INSERT INTO Category (Name, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES ("Television", CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1);

-- Create a couple of test posts.
INSERT INTO Post(CategoryID, Subject, Body, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES(1, "Something uncategorised", "This is a post describing something which has not been categorised.", CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1);

INSERT INTO Post(CategoryID, Subject, Body, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES(2, "Something interesting", "This is a post describing something interesting.", CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1);

-- Create some test comments.
INSERT INTO Comment(ID, PostID, Title, Body, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES(1, 1, "Comment 1 Title", "This is a comment.", CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1);

INSERT INTO Comment(ID, PostID, Title, Body, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES(2, 1, "Comment 2 Title", "This is also a comment.", CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1);
