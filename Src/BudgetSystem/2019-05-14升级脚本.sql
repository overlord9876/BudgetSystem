
/*==============================================================*/
/*  Ԥ�㵥�������鵵�������ں͹鵵������			                      */
/*==============================================================*/

ALTER TABLE Budget add COLUMN ArchiveApplyDate     datetime comment '�鵵��������';
ALTER TABLE Budget add COLUMN ArchiveDate          datetime comment '�鵵����';

-- ���״̬ö��ֵ 
UPDATE budget SET `State`=8 WHERE `State`=3;
UPDATE budget SET `State`=4 WHERE `State`=2;
UPDATE budget SET `State`=2 WHERE `State`=1;
UPDATE budget SET `State`=1 WHERE `State`=0;