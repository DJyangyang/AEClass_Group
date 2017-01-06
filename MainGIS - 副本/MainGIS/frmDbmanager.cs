using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MainGIS
{
    public partial class frmDbmanager : Form
    {

        #region 私有变量
        private string _mdbFileFullName;  //mdb文件完整路径名
        private DBOperate _dbOperate; //数据库操作类
        private DataTable resultDt;

        #endregion
        public frmDbmanager()
        {
            InitializeComponent();
        }

        private void frmDbmanager_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();//打开data文件夹下的mdb文件
            openDialog.InitialDirectory = Application.StartupPath + @"\data";
            openDialog.Filter = "mdb文件|*.mdb";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                tb_path.Text = openDialog.InitialDirectory;
                _mdbFileFullName = openDialog.FileName;

                //读取数据库的表名，并默认加载第一个表
                _dbOperate = new DBOperate(_mdbFileFullName, "");
                List<string> tableNames = _dbOperate.GetTableNameList();
                cmbxTableNames4.DataSource = tableNames;
                cmbxTableNames4.SelectedIndex = 0;
            }
        }
        private void cmbxTableNames4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        private void cmbxTableNames4_TextChanged(object sender, EventArgs e)
        {          
            if (cmbxTableNames4.DataSource == null || _dbOperate == null)
            {
                return;
            }
            DataTable dt = _dbOperate.GetDataTableByName(cmbxTableNames4.Text);
            dataGridView1.DataSource = dt;

        }
        //private void cmbxTableNames4_TextChanged_1(object sender, EventArgs e)
        //{
        //    if (cmbxTableNames4.DataSource == null || _dbOperate == null)
        //    {
        //        return;
        //    }
        //    DataTable dt = _dbOperate.GetDataTableByName(cmbxTableNames4.Text);
        //    dataGridView1.DataSource = dt;
        ////}

       

       

        
     
        
       
      
    }
}
