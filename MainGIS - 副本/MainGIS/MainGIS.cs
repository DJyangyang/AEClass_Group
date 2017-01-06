using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
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

namespace MainGIS
{
    public partial class MainGIS : Form
    {
        #region
        private ITOCControl2 m_toc = null;
        private IToolbarMenu m_menu = null;
        private IToolbarMenu m_menulayer = null;
     

        #endregion
        public MainGIS()
        {
            InitializeComponent();
        }
        //保存
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand pMxd = new ControlsOpenDocCommandClass();
            pMxd.OnCreate(axMapControl1.Object);
            pMxd.OnClick();
        }
        //添加数据
        private void addDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand cmd = null;
            cmd = new ControlsAddDataCommandClass();
            cmd.OnCreate(axMapControl1.Object);
            cmd.OnClick();
        }
        //保存
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand save = new ControlsSaveAsDocCommandClass();
            save.OnCreate(axMapControl1.Object);
            save.OnClick();
        }
        //关闭
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bufferToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IHookHelper map_hookHelper = new HookHelper();

            //参数赋值  
            //Hook定义  
            map_hookHelper.Hook = this.axMapControl1.Object;
            MBuffer bfm = new MBuffer(map_hookHelper);
            bfm.ShowDialog();
        }
        //图例
        private void legendToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            #region
            UID uid;
            IEnvelope envelope;
            IGraphicsContainer graphicsContainer;
            IMapFrame mapFrame;
            IMapSurroundFrame mapSurroundFrame;//mapSurroundFrame对象是MapSurround的容器，MapSurround的框架元素包括比例尺，指北针，图例等
            IElement element;
            ITrackCancel trackCancel;
            #endregion//定义参数
            uid = new UIDClass();//创建一个UID对象，并把值付给图例类的ID
            uid.Value = "esriCarto.legend";
            envelope = new EnvelopeClass();
            envelope.PutCoords(1, 1, 3, 4);//图例位置
            graphicsContainer = axPageLayoutControl1.PageLayout as IGraphicsContainer;//定义并获取一个PageLayout容器
            mapFrame = graphicsContainer.FindFrame(axPageLayoutControl1.ActiveView.FocusMap) as IMapFrame;//查找与FocusMap相关联的MapFrame对象
            mapSurroundFrame = mapFrame.CreateSurroundFrame(uid, null);//根据UID来创建
            mapSurroundFrame.MapSurround.Name = "图例";
            element = mapSurroundFrame as IElement;//将MapSurroundFram对象引用付给IElement接口的对象变量，得到element对象
            element.Geometry = envelope;//得到主地图的MapFrame相关联的几何体，几何体控制图例位置
            element.Activate(axPageLayoutControl1.ActiveView.ScreenDisplay);
            trackCancel = new CancelTrackerClass();
            element.Draw(axPageLayoutControl1.ActiveView.ScreenDisplay, trackCancel);
            graphicsContainer.AddElement(element, 0);//将地图要素element(t图例)添加到地图布局
            axPageLayoutControl1.Refresh();//刷新
        }

        private void scaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region
            UID uid;
            IEnvelope envelope;
            IGraphicsContainer graphicsContainer;
            IMapFrame mapFrame;
            IMapSurroundFrame mapSurroundFrame;
            IElement element;
            ITrackCancel trackCancel;
            #endregion//定义参数
            uid = new UIDClass();
            uid.Value = "esriCarto.ScaleLine";
            envelope = new EnvelopeClass();
            envelope.PutCoords(4, 4, 20, 24);//图例位置
            graphicsContainer = axPageLayoutControl1.PageLayout as IGraphicsContainer;
            mapFrame = graphicsContainer.FindFrame(axPageLayoutControl1.ActiveView.FocusMap) as IMapFrame;
            mapSurroundFrame = mapFrame.CreateSurroundFrame(uid, null);
            mapSurroundFrame.MapSurround.Name = "比例尺";

            element = mapSurroundFrame as IElement;
            element.Geometry = envelope;
            element.Activate(axPageLayoutControl1.ActiveView.ScreenDisplay);
            trackCancel = new CancelTrackerClass();
            element.Draw(axPageLayoutControl1.ActiveView.ScreenDisplay, trackCancel);
            graphicsContainer.AddElement(element, 0);
            axPageLayoutControl1.Refresh();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            this.axToolbarControl1.SetBuddyControl(axPageLayoutControl1);
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            //显示比例尺
            ScaleLabel.Text = "Scale1：" + ((long)this.axMapControl1.MapScale).ToString();
            //显示坐标
            coordinateLable.Text = " NowCoord X = " + e.mapX.ToString() + " Y = " + e.mapY.ToString();//根据鼠标位置显示坐标
        }

        private void axToolbarControl1_OnMouseMove(object sender, IToolbarControlEvents_OnMouseMoveEvent e)
        {
            // 取得鼠标所在工具的索引号 
            int index = axToolbarControl1.HitTest(e.x, e.y, false);
            if (index != -1)
            {
                // 取得鼠标所在工具的 ToolbarItem 
                IToolbarItem toolbarItem = axToolbarControl1.GetItem(index);
                // 设置状态栏信息 
                Messagelabel.Text = toolbarItem.Command.Message;
            }
            else
            {
                Messagelabel.Text = " 就绪 ";
            }
        }

        private void axTOCControl1_OnDoubleClick(object sender, ITOCControlEvents_OnDoubleClickEvent e)
        {
            esriTOCControlItem toccItem = esriTOCControlItem.esriTOCControlItemNone;
            ILayer iLayer = null;
            IBasicMap iBasicMap = null;
            object unk = null;
            object data = null;
            if (e.button == 1)
            {
                axTOCControl1.HitTest(e.x, e.y, ref toccItem, ref iBasicMap, ref iLayer, ref unk,
                    ref data);
                System.Drawing.Point pos = new System.Drawing.Point(e.x, e.y);
                if (toccItem == esriTOCControlItem.esriTOCControlItemLegendClass)
                {
                    ESRI.ArcGIS.Carto.ILegendClass pLC = new LegendClassClass();
                    ESRI.ArcGIS.Carto.ILegendGroup pLG = new LegendGroupClass();
                    if (unk is ILegendGroup)
                    {
                        pLG = (ILegendGroup)unk;
                    }
                    pLC = pLG.get_Class((int)data);
                    ISymbol pSym;
                    pSym = pLC.Symbol;
                    ESRI.ArcGIS.DisplayUI.ISymbolSelector pSS = new
                        ESRI.ArcGIS.DisplayUI.SymbolSelectorClass();
                    bool bOK = false;
                    pSS.AddSymbol(pSym);
                    bOK = pSS.SelectSymbol(0);
                    if (bOK)
                    {
                        pLC.Symbol = pSS.GetSymbolAt(0);
                    }
                    this.axMapControl1.ActiveView.Refresh();
                    this.axTOCControl1.Refresh();
                }


            }
        }

        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            CopyToPageLayout();
        }

        private void CopyToPageLayout()
        {
            IObjectCopy objectCopy = new ObjectCopyClass();
            object copyFromMap = axMapControl1.Map;
            object copyMap = objectCopy.Copy(copyFromMap);
            object copyToMap = axPageLayoutControl1.ActiveView.FocusMap;
            objectCopy.Overwrite(copyMap, ref copyToMap);
        }

        private void axMapControl1_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            IActiveView activeView = (IActiveView)axPageLayoutControl1.ActiveView.FocusMap;
            IDisplayTransformation dispalyTransformation = activeView.ScreenDisplay.DisplayTransformation;
            dispalyTransformation.VisibleBounds = axMapControl1.Extent;
            axPageLayoutControl1.ActiveView.Refresh();
            CopyToPageLayout();
        }

        private void MainGIS_Load(object sender, EventArgs e)
        {
            m_menu = new ToolbarMenuClass();
            m_menulayer = new ToolbarMenuClass();
            this.axMapControl1.Map.Name = "Map";
            this.axTOCControl1.Update();
            IHookHelper map_hookHelper = new HookHelper();

            //参数赋值  
            //Hook定义  
            map_hookHelper.Hook = this.axMapControl1.Object;

        }

        private void removeLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.axMapControl1.Map.LayerCount; i++)
            {
                if (this.axMapControl1.Map.get_Layer(i) == layer)
                { }
            }
        }

        //private void openAttributeToolStripMenuItem_Click(object sender, EventArgs e)
        //{
           
        //}
        ILayer layer = new FeatureLayerClass();
        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            this.axTOCControl1.ContextMenuStrip = null;
            IBasicMap map = new MapClass();
            System.Object other = null;
            System.Object index = null;
            esriTOCControlItem  item= esriTOCControlItem.esriTOCControlItemNone;
            this.axTOCControl1.HitTest(e.x,e.y, ref item, ref map,ref layer,ref other,ref index);
            if (item == esriTOCControlItem.esriTOCControlItemLayer && e.button == 2)
            {
                System.Drawing.Point pt = new System.Drawing.Point();
                pt.X = e.x;
                pt.Y = e.y;
                pt = this.axTOCControl1.PointToScreen(pt);
                this.contextMenuStrip1.Show(pt);
            }

        }
        //打开属性表
        private void attributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmattribute frmatt = new frmattribute(layer);
            frmatt.ShowDialog();
        }
        //移除图层
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.axMapControl1.Map.LayerCount; i++)
            {
                if (this.axMapControl1.Map.get_Layer(i) == layer)
                { this.axMapControl1.DeleteLayer(i); }
            }
        }
        //移动图层
        private void zooMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.axMapControl1.Map.LayerCount; i++)
            {
                if (this.axMapControl1.Map.get_Layer(i) == layer)
                { this.axMapControl1.Pan(); }
            }
        }
        //全图显示
        private void fullExtentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.axMapControl1.Map.LayerCount; i++)
            {
                if (this.axMapControl1.Map.get_Layer(i) == layer)
                { this.axMapControl1.Extent=axMapControl1.FullExtent; }
            }
        }
        //缩小图层
        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnvelope penve;
            penve = axMapControl1.Extent;
            penve.Expand(2, 2, true);
            axMapControl1.Extent = penve;

        }
        //放大图层
        private void zoomInToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IEnvelope penve;
            penve = axMapControl1.Extent;
            penve.Expand(0.5, 0.5, true);
            axMapControl1.Extent = penve;
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDbmanager frmDB = new frmDbmanager();
            frmDB.ShowDialog();
        }

      

      
    }
}
