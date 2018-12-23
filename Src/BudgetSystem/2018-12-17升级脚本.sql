
/*==============================================================*/
/*  流程配置节点新增列，节点提交扩展事件				                      */
/*==============================================================*/

ALTER TABLE `flownode` 
ADD COLUMN `NodeExtEvent` varchar(30) NULL COMMENT '节点提交扩展事件' AFTER `NodeValueRemark`;

Alter table `PaymentNotes`
add column   IsActive             bit;
Alter table `PaymentNotes`
add column     RemarkState          int;