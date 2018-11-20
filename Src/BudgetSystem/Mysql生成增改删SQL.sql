DROP PROCEDURE
IF EXISTS `CreateSql`;

CREATE PROCEDURE CreateSql (IN tName VARCHAR(30))
BEGIN
	DECLARE done INT DEFAULT 0; 

	DECLARE pkey VARCHAR(30);
	DECLARE cname VARCHAR(300);
	DECLARE csel VARCHAR(10);
	DECLARE cint VARCHAR(10);
	DECLARE cup VARCHAR(10);
	DECLARE cdel VARCHAR(10);
	DECLARE cno int DEFAULT 0; 

	DECLARE mycursor CURSOR FOR 
		SELECT COLUMN_NAME ,COLUMN_KEY FROM	information_schema.`COLUMNS` WHERE	TABLE_SCHEMA = 'budgetsystem' AND TABLE_NAME = tName;
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done=1;

	DROP TEMPORARY TABLE IF EXISTS `sqltable`;


	CREATE TEMPORARY TABLE sqltable (sqltype VARCHAR(30),str VARCHAR(300),nn int) ;
	
	INSERT Into sqltable values ('select',CONCAT('string selectSql = "Select * From `',tName,'` Where '),cno);
	set cno = cno+1;
	INSERT Into sqltable values ('insert',CONCAT('string insertSql = "Insert Into `',tName,'` ('),cno);
	set cno = cno+1;
	INSERT Into sqltable values ('update',CONCAT('string updateSql = "Update `',tName,'` Set '),cno);
	set cno = cno+1;
	INSERT Into sqltable values ('delete',CONCAT('string deleteSql = "Delete From `',tName,'` Where '),cno);
	set cno = cno+1;

	Set csel='';
	Set cint='';
	Set cup='';
	Set cdel='';

	open mycursor; 

		REPEAT 

			FETCH mycursor into cname,pkey; 

			IF NOT DONE THEN 
				
				INSERT Into sqltable values ('insert',CONCAT(cint,'`',cname,'`'),cno);
				set cno = cno+1;
				Set cint = ',';
				
				if pkey <> 'PRI' then
					INSERT Into sqltable values ('update',CONCAT(cup,'`',cname,'` = @',cname),cno);
					set cno = cno+1;
					Set cup=',';
				end if;

			END IF;

		UNTIL done END REPEAT;

	close mycursor;

	INSERT Into sqltable values ('insert',CONCAT(') Values ('),cno);
	set cno = cno+1;
	INSERT Into sqltable values ('update',CONCAT(') Where '),cno);
	set cno = cno+1;

	set done =0;
	Set csel='';
	Set cint='';
	Set cup='';
	Set cdel='';


	open mycursor; 

		REPEAT 

			FETCH mycursor into cname,pkey; 

			IF NOT DONE THEN 


				if pkey = 'PRI' then
					INSERT Into sqltable values ('select',CONCAT(csel,'`',cname,'` = @',cname),cno);
					set cno = cno+1;
					Set csel=' and ';
				end if;

				INSERT Into sqltable values ('insert',CONCAT(cint,'@',cname,''),cno);
				set cno = cno+1;
				Set cint=',';

				if pkey = 'PRI' then
					INSERT Into sqltable values ('update',CONCAT(cup,'`',cname,'` = @',cname),cno);
					set cno = cno+1;
					Set cup=' and ';
				end if;

				if pkey = 'PRI' then
					INSERT Into sqltable values ('delete',CONCAT(cdel,'`',cname,'` = @',cname),cno);
					set cno = cno+1;
					Set cdel=' and ';
				end if;



			END IF;

		UNTIL done END REPEAT;

	close mycursor;

	INSERT Into sqltable values ('select',CONCAT('";'),cno);
	set cno = cno+1;
	INSERT Into sqltable values ('insert',CONCAT(')";'),cno);
	set cno = cno+1;
	INSERT Into sqltable values ('update',CONCAT('";'),cno);
  set cno = cno+1;
	INSERT Into sqltable values ('delete',CONCAT('";'),cno);

  select group_concat(str Order by nn SEPARATOR  '') as sqlstr from sqltable  group by sqltype;


END;

CALL CreateSql ('User');