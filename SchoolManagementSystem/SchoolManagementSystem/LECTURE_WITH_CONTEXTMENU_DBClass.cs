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
     *  클래스 정보 : 강의 테이블을 다루는 사용자 정의 클래스
     *  주요 구현 정보 : 생성, 수정, 삭제(컨텍스트 메뉴 사용)
     */

    class LECTURE_WITH_CONTEXTMENU_DBClass
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

        OracleCommand myCommand;


        DataTable refTable;
        // DataTable 객체입니다. 

        DataRowCollection rows;

        public int SelectedRowIndex { get { return selectedRowIndex; } set { selectedRowIndex = value; } }
        public string SelectedKeyValue { get { return selectedKeyValue; } set { selectedKeyValue = value; } }

        public string CommandString { get { return commandString; } set { commandString = value; } }
        public string ConnectionString { get { return connectionString; } set { connectionString = value; } }

        public OracleConnection MyConnection { get { return myConnection; } set { myConnection = value; } }
        public OracleDataAdapter DBAdapter { get { return dBAdapter; } set { dBAdapter = value; } }
        public OracleCommand MyCommand { get { return myCommand; } set { myCommand = value; } }
        public OracleDataReader DataReader { get { return dataReader; } set { dataReader = value; } }
        public DataRowCollection Rows { get { return rows; } set { rows = value; } }


        public DataSet DS { get { return dS; } set { dS = value; } }
        public DataTable RefTable { get { return refTable; } set { refTable = value; } }


        public void DB_CRUD_Mode_Open()
        {
            try
            {
                MyConnection = new OracleConnection();
                MyConnection.ConnectionString = "User Id=test; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                MyConnection.Open(); //데이터베이스 연결

                DBAdapter = new OracleDataAdapter();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
                MyConnection.Close();
            }
        }

        public int DB_Create_Lecture_With_ConetextMenu(int inLectureCode, String inLectureName, int inLectureCredit, String inLectureRoom, String inLectureClassify, int ProfessorCode)
        { 
            CommandString = "INSERT INTO Lecture VALUES(" + inLectureCode + ", '" + inLectureName + "', " + inLectureCredit + ", '" + inLectureRoom + "', '" + inLectureClassify + "')";
            MyCommand = new OracleCommand(CommandString, MyConnection);
            //1차적으로 강의를 생성하는 부분
            // 다대다 관계를 교수 - 교수강의 - 강의 테이블로 정규화를 시켜주었으므로
            // 2차적으로 교수강의 테이블에 인스턴스를 추가하여 교수와 강의를 연결시켜주어야한다.

            if (MyCommand.ExecuteNonQuery() > 0)  // 강의가 성공적으로 생성되었으면
            {
                CommandString = "INSERT INTO Lecture_teach VALUES('" + ProfessorCode + "', '" + inLectureCode + "')";
                MyCommand = new OracleCommand(CommandString, MyConnection);
                //2차적으로 교수와 강의를 테이블을  부분

                return MyCommand.ExecuteNonQuery();
                //등록하는 강의는, 이를 생성하는 교수가 관리하는 강의이므로
                // 교수강의 테이블에 강의코드와 교수 코드에 대한 인스턴스를 삽입해주고
                // 적용되는 행의 값을 리턴해준다.
            }

            return MyCommand.ExecuteNonQuery();
            // 강의가 성공적으로 생성되지 않았을 때의 리턴문이므로 0이하의 값을 반환하게 된다.
        }

        public int DB_Update_Lecture_With_ConetextMenu(int inLectureCode, int inLectureCredit, String inLectureClassify)
        {
            CommandString = "UPDATE Lecture SET lec_credit = " + inLectureCredit + ",  lec_classify = '" + inLectureClassify + "' WHERE lec_code =" + inLectureCode;

            MyCommand = new OracleCommand(CommandString, MyConnection);
            return MyCommand.ExecuteNonQuery();
        }

        public int DB_Delete_Lecture_With_ConetextMenu(int lec_code) //사용자 함수 정의
        {
            CommandString = "DELETE FROM Lecture WHERE lec_code = " + lec_code + "";

            MyCommand = new OracleCommand(CommandString, MyConnection);
            return MyCommand.ExecuteNonQuery();
        }

        public void DB_ObjCreate()
        {
            RefTable = new DataTable();
        }
    }
}