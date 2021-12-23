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
     *  클래스 정보 : 면담 테이블을 다루는 클래스
     *  주요 구현 정보 : 생성 (면담 기록을 생성하는데 사용)
     */

    class CONSULT_LIST_CREATE_DBClass
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

        public void DB_CONSULT_CREATE_Mode_Open()
        {
            try
            {
                ConnectionString = "User Id=test; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                CommandString = "select * from consulting";

                DBAdapter = new OracleDataAdapter(CommandString, ConnectionString);
                MyCommandBuilder = new OracleCommandBuilder(DBAdapter);
                
                DS = new DataSet();
                DB_ObjCreate();

                DBAdapter.Fill(DS, "ConsultStudent");
                RefTable = DS.Tables["ConsultStudent"];
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        public void DB_Create_At_ConsultTBL(int consult_num, string stu_num, string consult_date, string consult_content)
        {
            try
            {
                DataRow newRow = RefTable.NewRow();

                newRow["CONSULT_NO"] = consult_num;
                newRow["STU_NUM"] = stu_num;
                newRow["CONSULT_DATE"] = consult_date;
                newRow["CONSULT_CONTENT"] = consult_content;

                RefTable.Rows.Add(newRow);
                DBAdapter.Update(DS, "ConsultStudent");
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

 
        public void DB_ObjCreate()
        {
            RefTable = new DataTable();
        }
    }
}