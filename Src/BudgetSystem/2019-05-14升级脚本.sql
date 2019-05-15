
/*==============================================================*/
/*  预算单表新增归档征求日期和归档日期列			                      */
/*==============================================================*/

ALTER TABLE Budget add COLUMN ArchiveApplyDate     datetime comment '归档征求日期';
ALTER TABLE Budget add COLUMN ArchiveDate          datetime comment '归档日期';

-- 变更状态枚举值 
UPDATE budget SET `State`=8 WHERE `State`=3;
UPDATE budget SET `State`=4 WHERE `State`=2;
UPDATE budget SET `State`=2 WHERE `State`=1;
UPDATE budget SET `State`=1 WHERE `State`=0;