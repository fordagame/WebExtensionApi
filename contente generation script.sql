
--For reverting
--DELETE BlogImages
--DELETE BlogComments
--DELETE Blogs


--For generating
DECLARE @Text1 nvarchar(max) = 'Welcome to the Microsoft Help Viewer, an essential source of information for everyone who uses Microsoft tools, products, technologies, and services. The Help Viewer gives you access to how-to and reference information, sample code, technical articles, and more. To find the content you need, browse the table of contents, use full-text search, or navigate through content using the keyword index. You can manage your content and customize your help settings with the Help Library ManagerHelp Library Manager'
DECLARE @Text2 nvarchar(max) = 'There is no content installed on your computer, or Help Library Manager is currently installing or updating content. To see a list of installed content, please exit Help Library Manager when it is finished.'
DECLARE @Text3 nvarchar(max) = 'Use the Help Library Manager Help Library Manager to set your preference for viewing content to offline help, and then install content from online or from media.'
DECLARE @Text4 nvarchar(max) = 'Navigate to the directory that contains the content setup file (HelpContentSetup.msha).'
DECLARE @Text5 nvarchar(max) = 'Select the content to install by clicking the "Add" action next to the content title. When you are finished selecting content to install, click the "Update" button at the bottom of the screen'


DECLARE @Image1 nvarchar(300) = '/Images/GeneratedContent/img1.png'
DECLARE @Image2 nvarchar(300) = '/Images/GeneratedContent/img2.png'
DECLARE @Image3 nvarchar(300) = '/Images/GeneratedContent/img3.png'
DECLARE @Image4 nvarchar(300) = '/Images/GeneratedContent/img4.png'
DECLARE @Image5 nvarchar(300) = '/Images/GeneratedContent/img5.png'


DECLARE @Comment1 nvarchar(max) = 'Thank you!!!'
DECLARE @Comment2 nvarchar(max) = 'Very good article!'
DECLARE @Comment3 nvarchar(max) = 'Poor writing skills.'
DECLARE @Comment4 nvarchar(max) = 'I am not sure, but this topic is already covered several days ago'
DECLARE @Comment5 nvarchar(max) = 'Hm.. nice.'

DECLARE @counter int = 1
while @counter < 100
BEGIN

	Declare @Text nvarchar(max) = ''
	if(@counter % 5 = 0 )
	BEGIN
		Set @Text = @Text1
	END
	if(@counter % 5 = 1 )
	BEGIN
		Set @Text = @Text2
	END
	if(@counter % 5 = 2 )
	BEGIN
		Set @Text = @Text3
	END
	if(@counter % 5 = 3 )
	BEGIN
		Set @Text = @Text4
	END
	if(@counter % 5 = 4 )
	BEGIN
		Set @Text = @Text5
	END

	insert into Blogs (Text, Rating, CategoryID)
	Values (@Text, @counter % 10, (@counter % 7 + 1))
	
	DECLARE @BlogID int = SCOPE_IDENTITY()
	
	-- insert random comments
	DECLARE @CounterComments int = 1
	WHILE @CounterComments < 10
	BEGIN
		Declare @CommentText nvarchar(max) = ''
		if(@counter * @CounterComments  % 5 = 0 )
		BEGIN
			Set @CommentText = @Comment1
		END
		if(@counter * @CounterComments  % 5  = 1 )
		BEGIN
			Set @CommentText = @Comment2
		END
		if(@counter * @CounterComments  % 5  = 2 )
		BEGIN
			Set @CommentText = @Comment3
		END
		if(@counter * @CounterComments  % 5  = 3 )
		BEGIN
			Set @CommentText = @Comment4
		END
		if(@counter * @CounterComments  % 5  = 4 )
		BEGIN
			Set @CommentText = @Comment5
		END
		insert into BlogComments(Text, BlogID)
		values (@CommentText, @BlogID)

		set @CounterComments = @CounterComments + 1
	END
	-- insert random images
	set @CounterComments = 1
	WHILE @CounterComments < 10
	BEGIN
		Declare @ImageText nvarchar(max) = ''
		if(@counter * @CounterComments  % 5 = 0 )
		BEGIN
			Set @ImageText = @Image1
		END
		if(@counter * @CounterComments  % 5  = 1 )
		BEGIN
			Set @ImageText = @Image2
		END
		if(@counter * @CounterComments  % 5  = 2 )
		BEGIN
			Set @ImageText = @Image3
		END
		if(@counter * @CounterComments  % 5  = 3 )
		BEGIN
			Set @ImageText = @Image4
		END
		if(@counter * @CounterComments  % 5  = 4 )
		BEGIN
			Set @ImageText = @Image5
		END

		insert into BlogImages(ImageURL, BlogID)
		values (@ImageText, @BlogID)

		set @CounterComments = @CounterComments + 1
	END

	Set @counter = @counter + 1
END