using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainGIS
{
    public partial class MBuffer : Form
    {
        //添加定义的全局变量
        [DllImport("user32.dll")]
        private static extern int PostMessage(IntPtr wnd,
        uint Msg, IntPtr wParam, IntPtr Iparam);
        private IMapControl4 MapControl;
        private IHookHelper m_hookhelper = null;
        private const uint WM_VSCPOLL = 0x0115;
        private const uint SB_BOTTOM = 7;
        public MBuffer(IHookHelper hookHelper)
        {
            InitializeComponent();
            m_hookhelper = hookHelper;
        }

        private void btnBuffer_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //所有参数都是正确的？？  
            double bufferDistance;
            double.TryParse(tbBuDis.Text, out bufferDistance);
            if (0.0 == bufferDistance)
            {
                MessageBox.Show("无效的缓冲距离！");
                return;
            }

            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtSave1.Text)) ||
              ".shp" != System.IO.Path.GetExtension(txtSave1.Text))
            {
                MessageBox.Show("无效的文件名！");
                return;
            }

            if (m_hookhelper.FocusMap.LayerCount == 0)
                return;


            IFeatureLayer layer = GetFeatureLayer((string)cmbFeature.SelectedItem);
            if (null == layer)
            {
                tbMessage.Text += "图层 " + (string)cmbFeature.SelectedItem + "未被找到！\r\n";
                return;
            }


            ScrollToBottom();

            tbMessage.Text += "进行缓冲区的图层: " + layer.Name + "\r\n";
            tbMessage.Text += DateTime.Now.ToString();
            tbMessage.Text += "\r\n正在获取空间数据。这可能需要几秒钟时间...\r\n";
            tbMessage.Update();

            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            tbMessage.Text += "正在进行缓冲区分析...\r\n";
            tbMessage.Update();


            ESRI.ArcGIS.AnalysisTools.Buffer buffer = new ESRI.ArcGIS.AnalysisTools.Buffer(layer, txtSave1.Text, Convert.ToString(bufferDistance) + " " + (string)cmbScale1.SelectedItem);



            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(buffer, null);
            if (results.Status != esriJobStatus.esriJobSucceeded)
            {
                tbMessage.Text += "缓冲区失败的图层: " + layer.Name + "\r\n";
            }
            tbMessage.Text += ReturnMessage(gp);

            ScrollToBottom();

            tbMessage.Text += "\r\n完成！\r\n";
            tbMessage.Text += "------------------------------------------------------\r\n";

            ScrollToBottom();

            //修改当前指针样式  
            this.Cursor = Cursors.Default;  

        }

        private string ReturnMessage(Geoprocessor gp)
        {
            StringBuilder sb = new StringBuilder();
            if (gp.MessageCount > 0)
            {
                for (int Count = 0; Count <= gp.MessageCount - 1; Count++)
                {
                    System.Diagnostics.Trace.WriteLine(gp.GetMessage(Count));
                    sb.AppendFormat("{0}\n", gp.GetMessage(Count));
                }
            }
            return sb.ToString();
        }

        private void ScrollToBottom()
        {
            PostMessage((IntPtr)tbMessage.Handle, WM_VSCPOLL, (IntPtr)SB_BOTTOM,
          (IntPtr)IntPtr.Zero);
        }

        private IFeatureLayer GetFeatureLayer(string layerName)
        {
            IEnumLayer layers = GetLayers();
            layers.Reset();
            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                if (layer.Name == layerName)
                    return layer as IFeatureLayer;
            }
            return null;
        }

        private void MBuffer_Load(object sender, EventArgs e)
        {
            if (null == m_hookhelper || null == m_hookhelper.Hook || 0 == m_hookhelper.FocusMap.LayerCount)
                return;
            //加载地图到cmbFeature
            IEnumLayer layers = GetLayers();
            layers.Reset();
            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                cmbFeature.Items.Add(layer.Name);

            }
            //默认选择第一个图层
            if (cmbFeature.Items.Count > 0)
            {
                cmbFeature.SelectedIndex = 0;
            }
            string tempDir = System.IO.Path.GetTempPath();
            txtSave1.Text = Path.Combine(tempDir, ((string)cmbFeature.SelectedItem + "_buffer.shp"));
            //设置缓冲单位
            int units = Convert.ToInt32(m_hookhelper.FocusMap.MapUnits);
            cmbScale1.SelectedIndex = units;

        }

        private IEnumLayer GetLayers()
        {
            UID uid = new UIDClass();
            uid.Value = "{40A9E885-5533-11d0-98BE-00805F7CED21}";
            IEnumLayer layers = m_hookhelper.FocusMap.get_Layers(uid, true);
            return layers;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.CheckPathExists = true;
            saveDlg.Filter = "Shapefile(*.shp)|*.shp";
            saveDlg.Title = "输出图层";
            saveDlg.RestoreDirectory = true;
            saveDlg.FileName = (string)cmbFeature.SelectedItem + "_buffer.shp";
            DialogResult dr = saveDlg.ShowDialog();
            if (dr == DialogResult.OK)
                txtSave1.Text = saveDlg.FileName;
        }
    }
}
