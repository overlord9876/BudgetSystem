
/*==============================================================*/
/*  �������ýڵ������У��ڵ��ύ��չ�¼�				                      */
/*==============================================================*/

ALTER TABLE `flownode` 
ADD COLUMN `NodeExtEvent` varchar(30) NULL COMMENT '�ڵ��ύ��չ�¼�' AFTER `NodeValueRemark`;

Alter table `PaymentNotes`
add column   IsActive             bit;
Alter table `PaymentNotes`
add column     RemarkState          int;