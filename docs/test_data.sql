-- Test data for the various tables.

-- Create an admin user.
INSERT INTO User (Name, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES ("Admin", CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1); 


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
INSERT INTO Comment(PostID, Body, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES(1, "This is a comment.", CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1);
