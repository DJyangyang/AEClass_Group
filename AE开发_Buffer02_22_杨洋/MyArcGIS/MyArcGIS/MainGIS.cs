using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyArcGIS
{
    public partial class MainGIS : DevComponents.DotNetBar.OfficeForm
    {
        private ESRI.ArcGIS.Controls.ITOCControlDefault _tocControl = null;
        public MapControl m_MapControl = null;
        

        bufferEX bf;
        

        public MainGIS()
        {
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            InitializeComponent();
            //禁用Glass主题
            this.EnableGlass = false;
            //不显示最大化最小化按钮
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            //去除图标
            this.ShowIcon = false;
        }

        private void MainGIS_Load(object sender, EventArgs e)
        {
            this.axMapControl1.Map.Name = "Map";
            this.axTOCControl1.Update();
            IHookHelper map_hookHelper = new HookHelper();

            //参数赋值  
            //Hook定义  
            map_hookHelper.Hook = this.axMapControl1.Object; 

        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)//关闭
        {
            this.Close();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)//打开Mxd文件
        {
            ICommand pMxd = new ControlsOpenDocCommandClass();
            pMxd.OnCreate(axMapControl1.Object);
            pMxd.OnClick();
        }
        
        private void 添加数据ToolStripMenuItem_Click(object sender, EventArgs e)//添加数据
        { 
            ICommand cmd = null;
            cmd = new ControlsAddDataCommandClass();
            cmd.OnCreate(axMapControl1.Object);
            cmd.OnClick();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)//保存
        {
            ICommand save = new ControlsSaveAsDocCommandClass();
            save.OnCreate(axMapControl1.Object);
            save.OnClick();
        }

        private void 缓冲ToolStripMenuItem_Click(object sender, EventArgs e)//缓冲
        {
            IHookHelper map_hookHelper = new HookHelper();

            //参数赋值  
            //Hook定义  
            map_hookHelper.Hook = this.axMapControl1.Object;
            bufferEX bfm = new bufferEX(map_hookHelper);
            bfm.ShowDialog();

        }

        private void 缓冲ToolStripMenuItem1_Click(object sender, EventArgs e)//缓冲
        {
            Buffer2 bform = new Buffer2();
            bform.ShowDialog();
        }

        //public bufferEX()
        //{

          
        //}


    }
}
