using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainGIS
{
    public partial class frmattribute : Form
    {
        private ILayer layer;
        public frmattribute(ILayer lyr)
        {
            InitializeComponent();
            layer = lyr;
            this.Text = "\"" + layer.Name + "\"属性表";
        }

        private void frmattribute_Load(object sender, EventArgs e)
        {
            try
            {
                ITable lyrtable = (ITable)layer;
                DataTable table = new DataTable();
                IField field;
                for (int i = 0; i < lyrtable.Fields.FieldCount; i++)
                {
                    field = lyrtable.Fields.get_Field(i);
                    table.Columns.Add(field.Name);

                }
                object[] values = new object[lyrtable.Fields.FieldCount];
                IQueryFilter queryfilter = new QueryFilterClass();
                ICursor cursor = lyrtable.Search(queryfilter, true);
                IRow row;
                while ((row = cursor.NextRow()) != null)
                {
                    for (int j = 0; j < lyrtable.Fields.FieldCount; j++)
                    {
                        object ob = row.get_Value(j);
                        values[j] = ob;
                    }
                    table.Rows.Add(values);
                }
                this.dataGridView1.DataSource = table;

            }
            catch (Exception aee)
            {
                MessageBox.Show("无法显示属性表");
                this.Close();
            }

        }
    }
}
