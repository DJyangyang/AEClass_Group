using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frminsert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtInputFile.Clear();
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.CheckPathExists = true;
            openDlg.Filter = "Shapefile (*.shp)|*.shp";
            openDlg.Title = "open input Layer";
            openDlg.RestoreDirectory = true;

            DialogResult dr = openDlg.ShowDialog();
            if (dr == DialogResult.OK)
                TxtInputFile.Text = openDlg.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            list1.Items.Add(TxtInputFile.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.CheckPathExists = true;
            saveDlg.Filter = "Shapefile (*.shp)|*.shp";
            saveDlg.OverwritePrompt = true;
            saveDlg.Title = "Output Layer";
            saveDlg.RestoreDirectory = true;
            saveDlg.FileName = (string)TxtInputFile.Text+"_insert.shp";

            DialogResult dr = saveDlg.ShowDialog();
            if (dr == DialogResult.OK)
                txtOutputPath.Text = saveDlg.FileName;
        }
      
        private void button4_Click(object sender, EventArgs e)
        {
           
          //  IGeoProcessor2 gp = new GeoProcessorClass();
           // gp.OverwriteOutput = true;
            //IGeoProcessorResult result = new GeoProcessorResultClass();
            IVariantArray par = new VarArrayClass();
            for (int i = 0; i < list1.Items.Count; i++)
            {
                par.Add(list1.Items);
            }
            object sev = null;
            
        }
       

    }
}
