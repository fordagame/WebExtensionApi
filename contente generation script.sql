--ALTER TABLE Blogs
--add Title nvarchar(350)

--For reverting
--DELETE BlogImages
--DELETE BlogComments
--DELETE Blogs


--For generating
DECLARE @Text1 nvarchar(max) = 'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.'
DECLARE @Text2 nvarchar(max) = 'Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.

The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from "de Finibus Bonorum et Malorum" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.'
DECLARE @Text3 nvarchar(max) = 'It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using "Content here, content here", making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for "lorem ipsum" will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).'
DECLARE @Text4 nvarchar(max) = 'There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don"t look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn"t anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.'
DECLARE @Text5 nvarchar(max) = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'

DECLARE @Title1 nvarchar(350) = 'What is Lorem Ipsum'
DECLARE @Title2 nvarchar(350) = 'Where does it come from'
DECLARE @Title3 nvarchar(350) = 'Why do we use it?'
DECLARE @Title4 nvarchar(350) = 'Where can I get some?'
DECLARE @Title5 nvarchar(350) = 'Example of Lorem Ipsum'

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

	Declare @Title nvarchar(350) = ''
	if(@counter % 5 = 0 )
	BEGIN
		Set @Title = @Title1
	END
	if(@counter % 5 = 1 )
	BEGIN
		Set @Title = @Title2
	END
	if(@counter % 5 = 2 )
	BEGIN
		Set @Title = @Title3
	END
	if(@counter % 5 = 3 )
	BEGIN
		Set @Title = @Title4
	END
	if(@counter % 5 = 4 )
	BEGIN
		Set @Title = @Title5
	END

	insert into Blogs (Text, Rating, CategoryID, Title)
	Values (@Text, CAST((RAND() * 400 ) as int), CAST((RAND() * 6 ) as int) + 1, @Title)
	
	DECLARE @BlogID int = SCOPE_IDENTITY()
	
	-- insert random comments
	DECLARE @RandomNumber int = 0
	DECLARE @CounterComments int = 1
	DECLARE @whileComment int = CAST((RAND() * 10 ) as int)
	WHILE @CounterComments < @whileComment
	BEGIN
		Declare @CommentText nvarchar(max) = ''
		set @RandomNumber = CAST((RAND() * 10 ) as int)
		if(@RandomNumber  % 5 = 0 )
		BEGIN
			Set @CommentText = @Comment1
		END
		if(@RandomNumber  % 5  = 1 )
		BEGIN
			Set @CommentText = @Comment2
		END
		if(@RandomNumber  % 5  = 2 )
		BEGIN
			Set @CommentText = @Comment3
		END
		if(@RandomNumber % 5  = 3 )
		BEGIN
			Set @CommentText = @Comment4
		END
		if(@RandomNumber  % 5 = 4 )
		BEGIN
			Set @CommentText = @Comment5
		END
		insert into BlogComments(Text, BlogID)
		values (@CommentText, @BlogID)

		set @CounterComments = @CounterComments + 1
	END
	-- insert random images
	set @CounterComments = 0
	DECLARE @whileImages int = CAST((RAND() * 10 ) as int) + 1
	WHILE @CounterComments < @whileImages
		BEGIN
		set @RandomNumber = CAST((RAND() * 10 ) as int)
		Declare @ImageText nvarchar(max) = ''
		if(@RandomNumber % 5 = 0 )
		BEGIN
			Set @ImageText = @Image1
		END
		if(@RandomNumber % 5  = 1 )
		BEGIN
			Set @ImageText = @Image2
		END
		if(@RandomNumber  % 5  = 2 )
		BEGIN
			Set @ImageText = @Image3
		END
		if(@RandomNumber  % 5  = 3 )
		BEGIN
			Set @ImageText = @Image4
		END
		if(@RandomNumber  % 5  = 4 )
		BEGIN
			Set @ImageText = @Image5
		END

		insert into BlogImages(ImageURL, BlogID)
		values (@ImageText, @BlogID)

		set @CounterComments = @CounterComments + 1
	END

	Set @counter = @counter + 1
END