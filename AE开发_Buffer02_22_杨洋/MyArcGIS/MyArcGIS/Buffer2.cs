using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyArcGIS
{
    public partial class Buffer2 : Form
    {
        public Buffer2()
        {
            InitializeComponent();
        }

        private void btn_EXIT_Click(object sender, EventArgs e)//关闭窗口
        {
            this.Close();
        }

        private void btn_BrowserI_Click(object sender, EventArgs e)//浏览输入文件
        {
            //新创建文件夹选择对话框对象，调用文件夹选择窗体，进行文件选择
            OpenFileDialog dlg = new OpenFileDialog();

            //过滤选择数据类型为.shp
            dlg.Filter = "(*.shp)|*.shp|(*.*)|*.*";

            //获取窗口对象中的文件路径，并将文件路径字符串赋值给文本框txt_InputShp
            //如果文件选择后点击确定，则赋值给文本框，否则不进行任何操作。
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.tb_intput.Text = dlg.FileName;
            }
        }

        private void btn_BrowserO_Click(object sender, EventArgs e)//浏览输出路径
        {
            //创建存储文件
            SaveFileDialog sfd = new SaveFileDialog();
            //设置存储文件类型为.shp
            sfd.Filter = "(*.shp)|*.shp";
            //选择文件路径，设定文件名
            //如果路径文件名确定后点击确定，则赋值给文本框，否则不进行任何操作。
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                this.tb_output.Text = sfd.FileName;
            }      
        }

        private void btn_Buffer_Click(object sender, EventArgs e)//缓冲
        {
            //接收界面的输入参数
            #region
            //接收输入数据的路径
            string sInputFile = this.tb_intput.Text;
            //判断输入路径是否为空，如果为空，提示用户输入，并返回，不执行后续代码
            if (sInputFile.Equals(""))
            {
                MessageBox.Show("请选择输入数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //接收输出数据的路径
            string sOutputFile = this.tb_output.Text;
            //判断输出路径是否为空，如果为空，提示用户输入，并返回，不执行后续代码
            if (sOutputFile.Equals(""))
            {
                MessageBox.Show("请选择输出数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //接收输入的缓冲区半径
            string sRadius = this.tb_Buffer.Text;
            //判断输入半径是否为空，如果为空，提示用户输入，并返回，不执行后续代码
            if (sRadius.Equals(""))
            {
                MessageBox.Show("请输入缓冲区半径，只支持数字!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //半径是否为数字判断条件
            float f1 = 0.0f;
            if (float.TryParse(sRadius, out f1) == false)
            {
                MessageBox.Show("缓冲区半径只支持数字，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion
            //调用缓冲区分析接口，传递参数，实现缓冲区分析
            #region
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);



            // Create the geoprocessor.
            IGeoProcessor2 GP1 = new GeoProcessorClass();
            GP1.OverwriteOutput = true;
            // Create a variant array to hold the parameter values.
            IVariantArray parameters = new VarArrayClass();


            object sev = null;
            //新建输出结果对象
            IGeoProcessorResult result = new GeoProcessorResultClass();
            try
            {
                // Set parameter values.
                parameters.Add(sInputFile);
                parameters.Add(sOutputFile);
                parameters.Add(sRadius + " Meters");

                result = GP1.Execute("Buffer_analysis", parameters, null);
                // Wait until the execution completes.
                while (result.Status == esriJobStatus.esriJobExecuting)
                    Thread.Sleep(1000);
                // Wait for 1 second.
                // Print geoprocessring messages.
                MessageBox.Show(GP1.GetMessages(ref sev));
            }
            catch (Exception ex)
            {
                // Print geoprocessing execution error messages.
                MessageBox.Show(GP1.GetMessages(ref sev));
            }

            #endregion

        }

    }
}
