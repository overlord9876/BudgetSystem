/*==============================================================*/
/* 新增了版本更新相关表    ByZxw                                */
/*==============================================================*/


create table Files
(
   MD5                  varchar(40) not null,
   Data             mediumblob not null,
   primary key (MD5)
);

alter table Files comment '文件表';

alter table Files modify column MD5  varchar(40) comment '文件MD5';

alter table Files modify column Data  mediumblob comment 'FileData';


create table VersionInfo
(
   ID                   int not null auto_increment,
   Version              varchar(20) not null,
   FileMD5              varchar(40) not null,
   FileName             varchar(100) not null,
   FilePath             varchar(200) not null,
   primary key (ID)
);

ALTER TABLE `versioninfo` 
MODIFY COLUMN `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID' FIRST;

alter table VersionInfo comment '版本清单表';

alter table VersionInfo modify column ID  int comment 'ID';

alter table VersionInfo modify column Version  varchar(20) comment '版本号';

alter table VersionInfo modify column FileMD5  varchar(40) comment '文件MD5';

alter table VersionInfo modify column FileName  varchar(100) comment '文件名';

alter table VersionInfo modify column FilePath  varchar(200) comment '所在目录';

alter table VersionInfo add constraint FK_Reference_33 foreign key (FileMD5)
      references Files (MD5) on delete restrict on update restrict;
