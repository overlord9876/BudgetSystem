DROP PROCEDURE
IF EXISTS `CreateClass`;

CREATE PROCEDURE CreateClass (IN tName VARCHAR(30))
BEGIN
	DECLARE done INT DEFAULT 0; 

	DECLARE typestring VARCHAR(30);
	DECLARE cname VARCHAR(300);
	DECLARE ctype VARCHAR(300);
	DECLARE cdesc VARCHAR(300);
	DECLARE mycursor CURSOR FOR 
		SELECT COLUMN_NAME ,DATA_TYPE,COLUMN_COMMENT FROM	information_schema.`COLUMNS` WHERE	TABLE_SCHEMA = 'budgetsystem' AND TABLE_NAME = tName;
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done=1;

	DROP TEMPORARY TABLE IF EXISTS `cc`;

	CREATE TEMPORARY TABLE cc (str VARCHAR(300)) ;

	INSERT Into cc values ('/// <summary>');


	SELECT table_comment into cdesc from information_schema.`TABLES` where TABLE_SCHEMA = 'budgetsystem' AND TABLE_NAME = tName;

	INSERT Into cc values (CONCAT('/// ',cdesc));
	INSERT Into cc values ('/// </summary>');
	INSERT Into cc values (CONCAT('public class ',tName,':IEntity'));
	INSERT Into cc values ('{');

	
	open mycursor; 

		REPEAT 

			FETCH mycursor into cname,ctype,cdesc; 

			IF NOT DONE THEN 
				
				if ctype = 'varchar' or ctype = 'text' THEN
					set typestring = 'string';
				elseif ctype ='bit' THEN
					set typestring = 'bool';
				elseif ctype ='datetime' or ctype ='date' or ctype ='time' THEN
					set typestring = 'DateTime';
				elseif ctype ='int' or ctype ='smallint'THEN
					set typestring = 'int';
				elseif ctype ='decimal' THEN
					set typestring = 'decimal';
				elseif ctype ='float' THEN
					set typestring = 'float';
				else 
					set typestring = ctype;
				end if;
				INSERT Into cc values ('    /// <summary>');
				INSERT Into cc values (CONCAT('    /// ',cdesc));
				INSERT Into cc values ('    /// </summary>');
				INSERT Into cc values (CONCAT( '    public ', typestring ,' ', cname,'{ get; set; }'));
				INSERT Into cc values ('');
			END IF;

		UNTIL done END REPEAT;

	close mycursor;




	INSERT Into cc values ('}');

	SELECT * from cc;

END;

CALL CreateClass ('User');