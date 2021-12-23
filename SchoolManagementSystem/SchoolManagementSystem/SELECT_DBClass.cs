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
     *  클래스 정보 : 모든 테이블에서 공통적으로 사용되는 조회 기능을 구현한 클래스
     *  주요 구현 정보 : 조회
     */

    class SELECT_DBClass
    {
        private string commandString;
        private string connectionString;

        private int selectedRowIndex;
        //수정하거나 삭제하기 위해 선택된 행의 인덱스를 저장한다. 

        private string selectedKeyValue;
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

        DataRow[] resultRows;

        public int SelectedRowIndex { get { return selectedRowIndex; } set { selectedRowIndex = value; } }
        public string SelectedKeyValue { get { return selectedKeyValue; } set { selectedKeyValue = value; } }

        public string CommandString { get { return commandString; } set { commandString = value; } }
        public string ConnectionString { get { return connectionString; } set { connectionString = value; } }

        public OracleConnection MyConnection { get { return myConnection; } set { myConnection = value; } }
        public OracleDataAdapter DBAdapter { get { return dBAdapter; } set { dBAdapter = value; } }
        public OracleCommand MyCommand { get { return myCommand; } set { myCommand = value; } }
        public OracleDataReader DataReader { get { return dataReader; } set { dataReader = value; } }
        public DataRowCollection Rows { get { return rows; } set { rows = value; } }
        public DataRow[] ResultRows { get { return resultRows; } set { resultRows = value; } }


        public DataSet DS { get { return dS; } set { dS = value; } }
        public DataTable RefTable { get { return refTable; } set { refTable = value; } }

        public void DB_Select_Mode_Open()
        {
            try
            {
                ConnectionString = "User Id=test; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";

                MyConnection = new OracleConnection(ConnectionString);

                MyCommand = new OracleCommand();
                DBAdapter = new OracleDataAdapter();

                MyCommand.Connection = MyConnection;
                DB_ObjCreate();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        public void DB_Select_By_DataReader()
        {
            MyConnection.Open();
            DS = new DataSet();
            MyCommand.CommandText = CommandString;
            DataReader = MyCommand.ExecuteReader();
        }

        public void DB_Select_By_DBAdaper(string tableName)
        {
            DS = new DataSet();
            MyCommand.CommandText = CommandString;
            DBAdapter.SelectCommand = MyCommand;

            DBAdapter.Fill(DS, tableName);
            RefTable = DS.Tables[tableName];
        }

        public void DB_ObjCreate()
        {
            RefTable = new DataTable();
        }
    }
}