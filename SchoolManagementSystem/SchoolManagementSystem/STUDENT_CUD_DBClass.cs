using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Windows.Forms;
using System.Data;

namespace SchoolManagementSystem
{
    /*
     *  클래스 정보 : 학생에 관한 테이블을 다루는 사용자 정의 클래스
     *  주요 구현 정보 : 생성, 수정, 삭제
     */

    class STUDENT_CUD_DBClass
    {
        private string commandString;
        private string connectionString;

        private int selectedRowIndex;
        //수정하거나 삭제하기 위해 선택된 행의 인덱스를 저장한다. 

        private string  selectedKeyValue;
        // 수정, 삭제할 때 필요한 레코드의 키값을 보관할 필드

        OracleConnection myConnection;

        OracleDataAdapter dBAdapter;
        // Data Provider인 DBAdapter 입니다. 

        OracleDataReader dataReader;

        DataSet dS;
        // DataSet 객체입니다. 

        OracleCommandBuilder myCommandBuilder;


        DataTable refTable;
        // DataTable 객체입니다. 

        DataRowCollection rows;

        public int SelectedRowIndex { get { return selectedRowIndex; } set { selectedRowIndex = value; } }
        public string SelectedKeyValue { get { return selectedKeyValue; } set { selectedKeyValue = value; } }

        public string CommandString { get { return commandString; } set { commandString = value; } }
        public string ConnectionString { get { return connectionString; } set { connectionString = value; } }

        public OracleConnection MyConnection { get { return myConnection; } set { myConnection = value; } }
        public OracleDataAdapter DBAdapter { get { return dBAdapter; } set { dBAdapter = value; } }
        public OracleCommandBuilder MyCommandBuilder { get { return myCommandBuilder; } set { myCommandBuilder = value; } }
        public OracleDataReader DataReader { get { return dataReader; } set { dataReader = value; } }
        public DataRowCollection Rows { get { return rows; } set { rows = value; } }


        public DataSet DS { get { return dS; } set { dS = value; } }
        public DataTable RefTable { get { return refTable; } set { refTable = value; } }

        public void DB_CUD_Mode_Open()
        {
            try
            {
                ConnectionString = "User Id=test; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                CommandString = "Select STU_NUM, STU_NAME, STU_GRADE, STU_CONDITION, STU_ADDR, STU_TEL, DEPT_CODE, STU_MAIN_PROF, STU_BIRTH, STU_ADMISSION_DATE, STU_PASSWORD from student";

                DBAdapter = new OracleDataAdapter(CommandString, ConnectionString);
                MyCommandBuilder = new OracleCommandBuilder(DBAdapter);
                
                DS = new DataSet();
                DB_ObjCreate();

                DBAdapter.Fill(DS, "Student");
                RefTable = DS.Tables["Student"];
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        public void DB_Create_At_StudentTBL(string stu_num, string stu_name, string stu_grade, string stu_condition, string stu_addr, string stu_tel, string stu_major, string stu_main_prof, string stu_birth, string stu_admission_date)
        {

            try
            {
                DataRow newRow = RefTable.NewRow();

                newRow["STU_NUM"] = stu_num;
                newRow["STU_NAME"] = stu_name;
                newRow["STU_GRADE"] = stu_grade;
                newRow["STU_CONDITION"] = stu_condition;
                newRow["STU_ADDR"] = stu_addr;
                newRow["STU_TEL"] = stu_tel;
                newRow["DEPT_CODE"] = stu_major;
                newRow["STU_MAIN_PROF"] = stu_main_prof;
                newRow["STU_BIRTH"] = stu_birth;
                newRow["STU_ADMISSION_DATE"] = stu_admission_date;
                newRow["STU_PASSWORD"] = "1q2w3e4r"; //비밀번호 기본값

                RefTable.Rows.Add(newRow);
                DBAdapter.Update(DS, "Student");
                DS.AcceptChanges();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        public void DB_Delete_At_StudentTBL()
        {
            try
            {
                DataColumn[] PrimaryKey = new DataColumn[1];
                PrimaryKey[0] = RefTable.Columns["STU_NUM"];
                RefTable.PrimaryKey = PrimaryKey;
                DataRow currRow = RefTable.Rows.Find(SelectedKeyValue);
                currRow.Delete();
                DBAdapter.Update(DS.GetChanges(DataRowState.Deleted), "Student");
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        public void DB_Update_At_StudentTBL(string stu_addr, string stu_tel, string stu_condition)
        {
            try
            {
                DataColumn[] PrimaryKey = new DataColumn[1];
                PrimaryKey[0] = RefTable.Columns["STU_NUM"];
                RefTable.PrimaryKey = PrimaryKey;

                DataRow currRow = RefTable.Rows.Find(SelectedKeyValue);

                currRow.BeginEdit();
                currRow["STU_ADDR"] = stu_addr;
                currRow["STU_TEL"] = stu_tel;
                currRow["STU_CONDITION"] = stu_condition;
                currRow.EndEdit();

                DataSet UpdatedSet = DS.GetChanges(DataRowState.Modified);

                if (UpdatedSet.HasErrors)
                {
                    MessageBox.Show("변경된 데이터에 문제가 있습니다.");
                }
                else
                {
                    DBAdapter.Update(UpdatedSet, "Student");
                    DS.AcceptChanges();
                }
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        public void DB_ObjCreate()
        {
            RefTable = new DataTable();
        }
    }
}