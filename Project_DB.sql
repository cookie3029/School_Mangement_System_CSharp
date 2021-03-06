--------------------------------------------------------
--  DDL for Table CONSULTING
--------------------------------------------------------

  CREATE TABLE "CONSULTING" 
   (	"STU_NUM" NUMBER(8,0), 
	"CONSULT_NO" NUMBER, 
	"CONSULT_DATE" DATE, 
	"CONSULT_CONTENT" NVARCHAR2(200)
   );
--------------------------------------------------------
--  DDL for Table DEPT
--------------------------------------------------------

  CREATE TABLE "DEPT" 
   (	"DEPT_CODE" NUMBER(8,0), 
	"DEPT_NAME" NVARCHAR2(12)
   );
--------------------------------------------------------
--  DDL for Table LECTURE
--------------------------------------------------------

  CREATE TABLE "LECTURE" 
   (	"LEC_CODE" NUMBER(8,0), 
	"LEC_NAME" NVARCHAR2(12), 
	"LEC_CREDIT" NUMBER(1,0), 
	"LEC_ROOM" CHAR(4 CHAR), 
	"LEC_CLASSIFY" NCHAR(2)
   ) ;
--------------------------------------------------------
--  DDL for Table LECTURE_LEARNER
--------------------------------------------------------

  CREATE TABLE "LECTURE_LEARNER" 
   (	"LEC_CODE" NUMBER(8,0), 
	"STU_NUM" NUMBER(8,0), 
	"LEARNER_GRADE" CHAR(2 BYTE)
   );
--------------------------------------------------------
--  DDL for Table LECTURE_TEACH
--------------------------------------------------------

  CREATE TABLE "LECTURE_TEACH" 
   (	"PROF_NUM" NUMBER(8,0), 
	"LEC_CODE" NUMBER(8,0)
   );
--------------------------------------------------------
--  DDL for Table PROFESSOR
--------------------------------------------------------

  CREATE TABLE "PROFESSOR" 
   (	"PROF_NUM" NUMBER(8,0), 
	"PROF_NAME" NVARCHAR2(4), 
	"DEPT_CODE" NUMBER(8,0), 
	"PROF_ADDRESS" NVARCHAR2(20), 
	"PROF_TEL" CHAR(13 BYTE), 
	"PROF_OFFICE" CHAR(4 BYTE), 
	"PROF_PASSWORD" VARCHAR2(20 BYTE), 
	"PROF_BIRTH" DATE
   );
--------------------------------------------------------
--  DDL for Table STUDENT
--------------------------------------------------------

  CREATE TABLE "STUDENT" 
   (	"STU_NUM" NUMBER(8,0), 
	"STU_NAME" NVARCHAR2(4), 
	"STU_ADDR" NVARCHAR2(20), 
	"STU_TEL" CHAR(13 BYTE), 
	"STU_CONDITION" NCHAR(2), 
	"STU_PASSWORD" VARCHAR2(20 BYTE), 
	"STU_MAIN_PROF" NUMBER(8,0), 
	"DEPT_CODE" NUMBER(8,0), 
	"STU_GRADE" NCHAR(3), 
	"STU_BIRTH" DATE, 
	"STU_ADMISSION_DATE" DATE
   );
   
REM INSERTING into CONSULTING
SET DEFINE OFF;
Insert into CONSULTING (STU_NUM,CONSULT_NO,CONSULT_DATE,CONSULT_CONTENT) values (20185932,2,to_date('20/12/04','RR/MM/DD'),'???????? ??');
Insert into CONSULTING (STU_NUM,CONSULT_NO,CONSULT_DATE,CONSULT_CONTENT) values (20185932,1,to_date('20/12/04','RR/MM/DD'),'???????????? ??????????????.');
Insert into CONSULTING (STU_NUM,CONSULT_NO,CONSULT_DATE,CONSULT_CONTENT) values (20191004,1,to_date('19/07/01','RR/MM/DD'),'?????? ???? ?????? ????
');

Insert into CONSULTING (STU_NUM,CONSULT_NO,CONSULT_DATE,CONSULT_CONTENT) values (20185932,3,to_date('20/12/04','RR/MM/DD'),'?????? ????????.');
Insert into CONSULTING (STU_NUM,CONSULT_NO,CONSULT_DATE,CONSULT_CONTENT) values (20191004,2,to_date('20/12/05','RR/MM/DD'),'123123');
Insert into CONSULTING (STU_NUM,CONSULT_NO,CONSULT_DATE,CONSULT_CONTENT) values (20185932,4,to_date('20/12/08','RR/MM/DD'),'????????????');
Insert into CONSULTING (STU_NUM,CONSULT_NO,CONSULT_DATE,CONSULT_CONTENT) values (20185932,5,to_date('20/12/09','RR/MM/DD'),'???????? ???? ??????????.');

REM INSERTING into DEPT
SET DEFINE OFF;
Insert into DEPT (DEPT_CODE,DEPT_NAME) values (20000001,'??????????????????');
Insert into DEPT (DEPT_CODE,DEPT_NAME) values (20000002,'??????????');

REM INSERTING into LECTURE
SET DEFINE OFF;
Insert into LECTURE (LEC_CODE,LEC_NAME,LEC_CREDIT,LEC_ROOM,LEC_CLASSIFY) values (10000001,'??????????',2,'K702','????');
Insert into LECTURE (LEC_CODE,LEC_NAME,LEC_CREDIT,LEC_ROOM,LEC_CLASSIFY) values (10000002,'????????',2,'K704','????');
Insert into LECTURE (LEC_CODE,LEC_NAME,LEC_CREDIT,LEC_ROOM,LEC_CLASSIFY) values (10000003,'??????',3,'K405','????');
Insert into LECTURE (LEC_CODE,LEC_NAME,LEC_CREDIT,LEC_ROOM,LEC_CLASSIFY) values (10000004,'C????',3,'K406','????');
Insert into LECTURE (LEC_CODE,LEC_NAME,LEC_CREDIT,LEC_ROOM,LEC_CLASSIFY) values (10000005,'????????????',2,'K507','????');
Insert into LECTURE (LEC_CODE,LEC_NAME,LEC_CREDIT,LEC_ROOM,LEC_CLASSIFY) values (10000009,'??????1',3,'K801','????');
Insert into LECTURE (LEC_CODE,LEC_NAME,LEC_CREDIT,LEC_ROOM,LEC_CLASSIFY) values (10000007,'????',3,'K802','????');
Insert into LECTURE (LEC_CODE,LEC_NAME,LEC_CREDIT,LEC_ROOM,LEC_CLASSIFY) values (10000011,'????????',1,'K804','????');

REM INSERTING into LECTURE_LEARNER
SET DEFINE OFF;
Insert into LECTURE_LEARNER (LEC_CODE,STU_NUM,LEARNER_GRADE) values (10000009,20171125,null);
Insert into LECTURE_LEARNER (LEC_CODE,STU_NUM,LEARNER_GRADE) values (10000001,20171125,null);
Insert into LECTURE_LEARNER (LEC_CODE,STU_NUM,LEARNER_GRADE) values (10000011,20171125,null);
Insert into LECTURE_LEARNER (LEC_CODE,STU_NUM,LEARNER_GRADE) values (10000001,20171165,null);
Insert into LECTURE_LEARNER (LEC_CODE,STU_NUM,LEARNER_GRADE) values (10000004,20181445,null);
Insert into LECTURE_LEARNER (LEC_CODE,STU_NUM,LEARNER_GRADE) values (10000007,20181445,null);
Insert into LECTURE_LEARNER (LEC_CODE,STU_NUM,LEARNER_GRADE) values (10000005,20181463,null);
Insert into LECTURE_LEARNER (LEC_CODE,STU_NUM,LEARNER_GRADE) values (10000002,20181463,null);
Insert into LECTURE_LEARNER (LEC_CODE,STU_NUM,LEARNER_GRADE) values (10000007,20201119,null);
Insert into LECTURE_LEARNER (LEC_CODE,STU_NUM,LEARNER_GRADE) values (10000002,20201119,null);
Insert into LECTURE_LEARNER (LEC_CODE,STU_NUM,LEARNER_GRADE) values (10000009,20201119,null);
Insert into LECTURE_LEARNER (LEC_CODE,STU_NUM,LEARNER_GRADE) values (10000002,20181445,'A+');
Insert into LECTURE_LEARNER (LEC_CODE,STU_NUM,LEARNER_GRADE) values (10000003,20171125,null);
Insert into LECTURE_LEARNER (LEC_CODE,STU_NUM,LEARNER_GRADE) values (10000005,20181445,null);

REM INSERTING into LECTURE_TEACH
SET DEFINE OFF;
Insert into LECTURE_TEACH (PROF_NUM,LEC_CODE) values (40000011,10000001);
Insert into LECTURE_TEACH (PROF_NUM,LEC_CODE) values (40000011,10000005);
Insert into LECTURE_TEACH (PROF_NUM,LEC_CODE) values (40000011,10000007);
Insert into LECTURE_TEACH (PROF_NUM,LEC_CODE) values (40000011,10000009);
Insert into LECTURE_TEACH (PROF_NUM,LEC_CODE) values (40001111,10000002);
Insert into LECTURE_TEACH (PROF_NUM,LEC_CODE) values (40001111,10000003);
Insert into LECTURE_TEACH (PROF_NUM,LEC_CODE) values (40001111,10000004);
Insert into LECTURE_TEACH (PROF_NUM,LEC_CODE) values (40001111,10000011);

REM INSERTING into PROFESSOR
SET DEFINE OFF;
Insert into PROFESSOR (PROF_NUM,PROF_NAME,DEPT_CODE,PROF_ADDRESS,PROF_TEL,PROF_OFFICE,PROF_PASSWORD,PROF_BIRTH) values (40000011,'??????',20000002,'???? ??????','010-1234-1111','E209','1q2w3e4r',to_date('70/08/21','RR/MM/DD'));
Insert into PROFESSOR (PROF_NUM,PROF_NAME,DEPT_CODE,PROF_ADDRESS,PROF_TEL,PROF_OFFICE,PROF_PASSWORD,PROF_BIRTH) values (40001111,'??????',20000001,'???? ????','010-1234-2222','E304','1q2w3e4r',to_date('75/06/21','RR/MM/DD'));

REM INSERTING into STUDENT
SET DEFINE OFF;
Insert into STUDENT (STU_NUM,STU_NAME,STU_ADDR,STU_TEL,STU_CONDITION,STU_PASSWORD,STU_MAIN_PROF,DEPT_CODE,STU_GRADE,STU_BIRTH,STU_ADMISSION_DATE) values (20191004,'??????','???? ????','010-1234-1234','????','1q2w3e4r',40001111,20000001,'2????',to_date('99/07/12','RR/MM/DD'),to_date('19/03/05','RR/MM/DD'));
Insert into STUDENT (STU_NUM,STU_NAME,STU_ADDR,STU_TEL,STU_CONDITION,STU_PASSWORD,STU_MAIN_PROF,DEPT_CODE,STU_GRADE,STU_BIRTH,STU_ADMISSION_DATE) values (20181445,'??????','???? ????','010-1234-1111','????','1q2w3e4r',40000011,20000002,'1????',to_date('96/11/05','RR/MM/DD'),to_date('18/03/06','RR/MM/DD'));
Insert into STUDENT (STU_NUM,STU_NAME,STU_ADDR,STU_TEL,STU_CONDITION,STU_PASSWORD,STU_MAIN_PROF,DEPT_CODE,STU_GRADE,STU_BIRTH,STU_ADMISSION_DATE) values (20181463,'??????','???? ????','010-1234-2222','????','1q2w3e4r',40000011,20000002,'2????',to_date('98/06/05','RR/MM/DD'),to_date('18/03/06','RR/MM/DD'));
Insert into STUDENT (STU_NUM,STU_NAME,STU_ADDR,STU_TEL,STU_CONDITION,STU_PASSWORD,STU_MAIN_PROF,DEPT_CODE,STU_GRADE,STU_BIRTH,STU_ADMISSION_DATE) values (20171125,'??????','???? ????','010-1234-3333','????','1q2w3e4r',40000011,20000002,'3????',to_date('97/05/30','RR/MM/DD'),to_date('17/03/04','RR/MM/DD'));
Insert into STUDENT (STU_NUM,STU_NAME,STU_ADDR,STU_TEL,STU_CONDITION,STU_PASSWORD,STU_MAIN_PROF,DEPT_CODE,STU_GRADE,STU_BIRTH,STU_ADMISSION_DATE) values (20181543,'??????','???? ????','010-1234-1029','????','1q2w3e4r',40001111,20000001,'1????',to_date('98/08/06','RR/MM/DD'),to_date('18/03/06','RR/MM/DD'));
Insert into STUDENT (STU_NUM,STU_NAME,STU_ADDR,STU_TEL,STU_CONDITION,STU_PASSWORD,STU_MAIN_PROF,DEPT_CODE,STU_GRADE,STU_BIRTH,STU_ADMISSION_DATE) values (20201119,'??????','???? ????','010-1234-5555','????','1q2w3e4r',40000011,20000002,'1????',to_date('00/07/08','RR/MM/DD'),to_date('20/03/02','RR/MM/DD'));
Insert into STUDENT (STU_NUM,STU_NAME,STU_ADDR,STU_TEL,STU_CONDITION,STU_PASSWORD,STU_MAIN_PROF,DEPT_CODE,STU_GRADE,STU_BIRTH,STU_ADMISSION_DATE) values (20208676,'??????','???? ??????','010-1234-6058','????','1q2w3e4r',40001111,20000001,'1????',to_date('00/10/12','RR/MM/DD'),to_date('20/03/02','RR/MM/DD'));
Insert into STUDENT (STU_NUM,STU_NAME,STU_ADDR,STU_TEL,STU_CONDITION,STU_PASSWORD,STU_MAIN_PROF,DEPT_CODE,STU_GRADE,STU_BIRTH,STU_ADMISSION_DATE) values (20185932,'??????','???? ????','010-1234-3847','????','1q2w3e4r',40001111,20000001,'2????',to_date('98/06/05','RR/MM/DD'),to_date('18/03/06','RR/MM/DD'));
Insert into STUDENT (STU_NUM,STU_NAME,STU_ADDR,STU_TEL,STU_CONDITION,STU_PASSWORD,STU_MAIN_PROF,DEPT_CODE,STU_GRADE,STU_BIRTH,STU_ADMISSION_DATE) values (20171165,'??????','???? ????','010-1234-4444','????','1q2w3e4r',40000011,20000002,'3????',to_date('96/04/21','RR/MM/DD'),to_date('17/03/04','RR/MM/DD'));

--------------------------------------------------------
--  Constraints for Table CONSULTING
--------------------------------------------------------

  ALTER TABLE "CONSULTING" ADD CONSTRAINT "CONSULTING_PK" PRIMARY KEY ("STU_NUM", "CONSULT_NO");
  ALTER TABLE "CONSULTING" MODIFY ("CONSULT_CONTENT" NOT NULL ENABLE);
  ALTER TABLE "CONSULTING" MODIFY ("CONSULT_DATE" NOT NULL ENABLE);
  ALTER TABLE "CONSULTING" MODIFY ("CONSULT_NO" NOT NULL ENABLE);
  ALTER TABLE "CONSULTING" MODIFY ("STU_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table DEPT
--------------------------------------------------------

  ALTER TABLE "DEPT" MODIFY ("DEPT_NAME" NOT NULL ENABLE);
  ALTER TABLE "DEPT" ADD CONSTRAINT "DEPT_PK" PRIMARY KEY ("DEPT_CODE");
  ALTER TABLE "DEPT" MODIFY ("DEPT_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table LECTURE
--------------------------------------------------------

  ALTER TABLE "LECTURE" MODIFY ("LEC_CLASSIFY" NOT NULL ENABLE);
  ALTER TABLE "LECTURE" MODIFY ("LEC_ROOM" NOT NULL ENABLE);
  ALTER TABLE "LECTURE" MODIFY ("LEC_CREDIT" NOT NULL ENABLE);
  ALTER TABLE "LECTURE" MODIFY ("LEC_NAME" NOT NULL ENABLE);
  ALTER TABLE "LECTURE" MODIFY ("LEC_CODE" NOT NULL ENABLE);
  ALTER TABLE "LECTURE" ADD CONSTRAINT "LECTURE_PK" PRIMARY KEY ("LEC_CODE");
--------------------------------------------------------
--  Constraints for Table LECTURE_LEARNER
--------------------------------------------------------

  ALTER TABLE "LECTURE_LEARNER" MODIFY ("STU_NUM" NOT NULL ENABLE);
  ALTER TABLE "LECTURE_LEARNER" MODIFY ("LEC_CODE" NOT NULL ENABLE);
  ALTER TABLE "LECTURE_LEARNER" ADD CONSTRAINT "LECTURE_LEARNER_PK" PRIMARY KEY ("LEC_CODE", "STU_NUM");
--------------------------------------------------------
--  Constraints for Table LECTURE_TEACH
--------------------------------------------------------

  ALTER TABLE "LECTURE_TEACH" MODIFY ("LEC_CODE" NOT NULL ENABLE);
  ALTER TABLE "LECTURE_TEACH" MODIFY ("PROF_NUM" NOT NULL ENABLE);
  ALTER TABLE "LECTURE_TEACH" ADD CONSTRAINT "LECTURE_TEACH_PK" PRIMARY KEY ("PROF_NUM", "LEC_CODE");
--------------------------------------------------------
--  Constraints for Table PROFESSOR
--------------------------------------------------------

  ALTER TABLE "PROFESSOR" MODIFY ("DEPT_CODE" NOT NULL ENABLE);
  ALTER TABLE "PROFESSOR" MODIFY ("PROF_BIRTH" NOT NULL ENABLE);
  ALTER TABLE "PROFESSOR" MODIFY ("PROF_PASSWORD" NOT NULL ENABLE);
  ALTER TABLE "PROFESSOR" MODIFY ("PROF_OFFICE" NOT NULL ENABLE);
  ALTER TABLE "PROFESSOR" MODIFY ("PROF_TEL" NOT NULL ENABLE);
  ALTER TABLE "PROFESSOR" MODIFY ("PROF_ADDRESS" NOT NULL ENABLE);
  ALTER TABLE "PROFESSOR" MODIFY ("PROF_NAME" NOT NULL ENABLE);
  ALTER TABLE "PROFESSOR" ADD CONSTRAINT "PROFESSOR_PK" PRIMARY KEY ("PROF_NUM");
  ALTER TABLE "PROFESSOR" MODIFY ("PROF_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table STUDENT
--------------------------------------------------------

  ALTER TABLE "STUDENT" MODIFY ("DEPT_CODE" NOT NULL ENABLE);
  ALTER TABLE "STUDENT" MODIFY ("STU_MAIN_PROF" NOT NULL ENABLE);
  ALTER TABLE "STUDENT" MODIFY ("STU_ADDR" NOT NULL ENABLE);
  ALTER TABLE "STUDENT" ADD CONSTRAINT "TABLE1_PK" PRIMARY KEY ("STU_NUM");
  ALTER TABLE "STUDENT" MODIFY ("STU_ADMISSION_DATE" NOT NULL ENABLE);
  ALTER TABLE "STUDENT" MODIFY ("STU_BIRTH" NOT NULL ENABLE);
  ALTER TABLE "STUDENT" MODIFY ("STU_GRADE" NOT NULL ENABLE);
  ALTER TABLE "STUDENT" MODIFY ("STU_PASSWORD" NOT NULL ENABLE);
  ALTER TABLE "STUDENT" MODIFY ("STU_CONDITION" NOT NULL ENABLE);
  ALTER TABLE "STUDENT" MODIFY ("STU_TEL" NOT NULL ENABLE);
  ALTER TABLE "STUDENT" MODIFY ("STU_NAME" NOT NULL ENABLE);
  ALTER TABLE "STUDENT" MODIFY ("STU_NUM" NOT NULL ENABLE);
--------------------------------------------------------
--  Ref Constraints for Table CONSULTING
--------------------------------------------------------

  ALTER TABLE "CONSULTING" ADD CONSTRAINT "CONSULTING_FK1" FOREIGN KEY ("STU_NUM")
	  REFERENCES "STUDENT" ("STU_NUM") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table LECTURE_LEARNER
--------------------------------------------------------

  ALTER TABLE "LECTURE_LEARNER" ADD CONSTRAINT "LECTURE_LEARNER_FK1" FOREIGN KEY ("STU_NUM")
	  REFERENCES "STUDENT" ("STU_NUM") ON DELETE CASCADE ENABLE;
  ALTER TABLE "LECTURE_LEARNER" ADD CONSTRAINT "LECTURE_LEARNER_FK2" FOREIGN KEY ("LEC_CODE")
	  REFERENCES "LECTURE" ("LEC_CODE") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table LECTURE_TEACH
--------------------------------------------------------

  ALTER TABLE "LECTURE_TEACH" ADD CONSTRAINT "LECTURE_TEACH_FK1" FOREIGN KEY ("LEC_CODE")
	  REFERENCES "LECTURE" ("LEC_CODE") ON DELETE CASCADE ENABLE;
  ALTER TABLE "LECTURE_TEACH" ADD CONSTRAINT "LECTURE_TEACH_FK2" FOREIGN KEY ("PROF_NUM")
	  REFERENCES "PROFESSOR" ("PROF_NUM") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table PROFESSOR
--------------------------------------------------------

  ALTER TABLE "PROFESSOR" ADD CONSTRAINT "PROFESSOR_FK1" FOREIGN KEY ("DEPT_CODE")
	  REFERENCES "DEPT" ("DEPT_CODE") ON DELETE SET NULL ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table STUDENT
--------------------------------------------------------

  ALTER TABLE "STUDENT" ADD CONSTRAINT "STUDENT_FK1" FOREIGN KEY ("DEPT_CODE")
	  REFERENCES "DEPT" ("DEPT_CODE") ON DELETE CASCADE ENABLE;
  ALTER TABLE "STUDENT" ADD CONSTRAINT "STUDENT_FK2" FOREIGN KEY ("STU_MAIN_PROF")
	  REFERENCES "PROFESSOR" ("PROF_NUM") ON DELETE CASCADE ENABLE;
