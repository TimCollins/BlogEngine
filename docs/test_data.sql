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
VALUES(1, "Something uncategorised", "1","1","Something uncategorised","<p>This blog post shows a few different types of content that's supported and styled with Bootstrap. Basic typography, images, and code are all supported.</p> <hr> <p>Cum sociis natoque penatibus et magnis <a href=""#"">dis parturient montes</a>, nascetur ridiculus mus. Aenean eu leo quam. Pellentesque ornare sem lacinia quam venenatis vestibulum. Sed posuere consectetur est at lobortis. Cras mattis consectetur purus sit amet fermentum.</p> <blockquote> <p>Curabitur blandit tempus porttitor. <strong>Nullam quis risus eget urna mollis</strong> ornare vel eu leo. Nullam id dolor id nibh ultricies vehicula ut id elit.</p> </blockquote> <p>Etiam porta <em>sem malesuada magna</em> mollis euismod. Cras mattis consectetur purus sit amet fermentum. Aenean lacinia bibendum nulla sed consectetur.</p> <h2>Heading</h2> <p>Vivamus sagittis lacus vel augue laoreet rutrum faucibus dolor auctor. Duis mollis, est non commodo luctus, nisi erat porttitor ligula, eget lacinia odio sem nec elit. Morbi leo risus, porta ac consectetur ac, vestibulum at eros.</p> <h3>Sub-heading</h3> <p>Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.</p> <pre><code>Example code block</code></pre> <p>Aenean lacinia bibendum nulla sed consectetur. Etiam porta sem malesuada magna mollis euismod. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa.</p> <h3>Sub-heading</h3> <p>Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean lacinia bibendum nulla sed consectetur. Etiam porta sem malesuada magna mollis euismod. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus.</p> <ul> <li>Praesent commodo cursus magna, vel scelerisque nisl consectetur et.</li> <li>Donec id elit non mi porta gravida at eget metus.</li> <li>Nulla vitae elit libero, a pharetra augue.</li> </ul> <p>Donec ullamcorper nulla non metus auctor fringilla. Nulla vitae elit libero, a pharetra augue.</p> <ol> <li>Vestibulum id ligula porta felis euismod semper.</li> <li>Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.</li> <li>Maecenas sed diam eget risus varius blandit sit amet non magna.</li> </ol> <p>Cras mattis consectetur purus sit amet fermentum. Sed posuere consectetur est at lobortis.</p>","2014-09-14 13:38:30","1","2014-09-14 13:38:30","1", CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1);

INSERT INTO Post(CategoryID, Subject, Body, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES(2, "Something interesting", "This is a post describing something interesting.", CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1);

-- Create some test comments.
INSERT INTO Comment(ID, PostID, Title, Body, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES(1, 1, "Comment 1 Title", "This is a comment.", CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1);

INSERT INTO Comment(ID, PostID, Title, Body, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES(2, 1, "Comment 2 Title", "This is also a comment.", CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1);
