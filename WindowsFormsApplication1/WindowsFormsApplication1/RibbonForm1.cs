using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Menu;
using DevExpress.Utils.Menu;

using RBI.PRE.TabPlant;
using RBI.BUS.Calculator;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using RBI.DAL;
using RBI.BUS;
using RBI.Object;
using RBI.BUS.BUSExcel;
using RBI.PRE.subForm;
using RBI.Object.ObjectMSSQL;

using RBI.PRE.subForm.InputDataForm;
using RBI.BUS.BUSMSSQL_CAL;

namespace RBI
{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonForm1()
        {
            InitializeComponent();
            treeListProject.OptionsBehavior.Editable = false;
            //DevExpress.XtraTreeList.Design.XViews xv = new DevExpress.XtraTreeList.Design.XViews(treeList1);
        }

        
        TreeListNode siteNode = null;
        TreeListNode facilityNode = null;
        TreeListNode equipmentNode = null;
        TreeListNode componentNode = null;
        TreeListNode recordNode = null;
        public static string k = "hoang";
        #region Button Event
        private void btnPlant_ItemClick(object sender, ItemClickEventArgs e)
        {
            treeListProject.BeginUpdate();
            TreeListColumn col1 = treeListProject.Columns.Add();
            col1.Caption = "List";
            col1.VisibleIndex = 0;
            treeListProject.EndUpdate();
            //treeListProject.BeginUnboundLoad();
            //// Create a root node .
            //TreeListNode parentForRootNodes = null;
            //TreeListNode rootNode = treeListProject.AppendNode(
            //    new object[] { "Alfreds Futterkiste" },
            //    parentForRootNodes);
            //// Create a child of the rootNode
            //treeListProject.AppendNode(new object[] { "Suyama, Michael" }, rootNode);
            //// Creating more nodes
            //// ...
            //treeListProject.EndUnboundLoad();
            RBI.PRE.subForm.InputDataForm.NewSite site = new PRE.subForm.InputDataForm.NewSite();
            site.ShowDialog();
            treeListProject.BeginUnboundLoad();
            siteNode = treeListProject.AppendNode(
                new object[] { k }, siteNode);
            treeListProject.EndUnboundLoad();
            
            site.Close();
        }
        private void btnFacility_ItemClick(object sender, ItemClickEventArgs e)
        {
            FacilityInput faci = new FacilityInput();
            faci.ShowDialog();
            treeListProject.BeginUnboundLoad();
            siteNode = treeListProject.AppendNode(
                new object[] { faci.getFacilityName() }, siteNode);
            treeListProject.EndUnboundLoad();
        }
        private void btnEquipment_ItemClick(object sender, ItemClickEventArgs e)
        {
            treeListProject.BeginUnboundLoad();
            equipmentNode = treeListProject.AppendNode(
                new object[] { "Equipment Name" }, facilityNode);
            treeListProject.EndUnboundLoad();
            RBI.PRE.subForm.InputDataForm.Equipment eq = new PRE.subForm.InputDataForm.Equipment();
            eq.ShowDialog();
        }

        private void btnComponent_ItemClick(object sender, ItemClickEventArgs e)
        {
            treeListProject.BeginUnboundLoad();
            componentNode = treeListProject.AppendNode(
                new object[] { "Component Name" }, equipmentNode);
            imageCollection1.Images.IndexOf(1);
            treeListProject.EndUnboundLoad();
        }

        private void btnRecord_ItemClick(object sender, ItemClickEventArgs e)
        {
            treeListProject.BeginUnboundLoad();
            recordNode = treeListProject.AppendNode(new object[] { "Record Name" }, componentNode);
            treeListProject.EndUnboundLoad();
        }
        private void btnRecalculate_ItemClick(object sender, ItemClickEventArgs e)
        {
            //closeAllTab();
            //Thread cal = new Thread(Calculator);
            //cal.Start();
            //while (cal.IsAlive)
            //{
            //    WatingForm wait = new WatingForm();
            //    wait.process = cal.IsAlive;
            //    wait.ShowDialog();
            //}
            //UCDevexpress risk = new UCDevexpress();
            //addNewTab("Risk Summary", risk);
        }
        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult da = MessageBox.Show("Do you want to close program?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (da == DialogResult.Yes)
                System.Windows.Forms.Application.Exit();
            else return;
        }
        private void btnRiskSummary_Click(object sender, EventArgs e)
        {
            //Thread cal = new Thread(Calculator);
            //cal.Start();
            //while (cal.IsAlive)
            //{
            //    WatingForm wait = new WatingForm();
            //    wait.process = cal.IsAlive;
            //    wait.ShowDialog();
            //}
            
            UCAssessmentInfo assessmentInfo = new UCAssessmentInfo();
            //addNewTab("Risk Summary", risk);
            DevExpress.XtraTab.XtraTabPage tabPage = new DevExpress.XtraTab.XtraTabPage();
            
            tabPage.Name = "tabAssessment";
            tabPage.Text = "Assessment Information";
            tabPage.Controls.Add(assessmentInfo);
            assessmentInfo.Dock = DockStyle.Fill;
            xtraTabData.TabPages.Add(tabPage);
            tabPage.Show();
        }
        #endregion
        private void xtraTabData_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.XtraTabControl tabControl = sender as DevExpress.XtraTab.XtraTabControl;
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            (arg.Page as DevExpress.XtraTab.XtraTabPage).Dispose();
        }
        private void treeList1_GetSelectImage(object sender, GetSelectImageEventArgs e)
        {
            
        }

        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            //TreeListHitInfo hitInfo = (sender as TreeList).CalcHitInfo(e.Location);
            //TreeListNode node = null;
            //if (hitInfo.HitInfoType == HitInfoType.RowIndicator)
            //{
            //    node = hitInfo.Node;
            //}
            //if (node == null) return;
            //// Create a menu with a 'Delete Node' item.
            //TreeListMenu menu = new TreeListMenu(sender as TreeList);
            //DXMenuItem menuItem = new DXMenuItem("Delete Node", new EventHandler(deleteNodeMenuItemClick));
            //menuItem.Tag = node;
            //menu.Items.Add(menuItem);
            //// Show the menu.
            //menu.Show(e.Location);
        }
        private void deleteNodeMenuItemClick(object sender, EventArgs e)
        {
            //DXMenuItem item = sender as DXMenuItem;
            //if (item == null) return;
            //TreeListNode node = item.Tag as TreeListNode;
            //if (node == null) return;
            //DialogResult da = MessageBox.Show("Do you want delete?","Warning", MessageBoxButtons.YesNo);
            //if (da == DialogResult.Yes)
            //    node.TreeList.DeleteNode(node);
            //else MessageBox.Show("Xóa đi còn đợi chờ chi?");
            
        }

        private void treeList1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            TreeList tL = sender as TreeList;
            TreeListHitInfo hitInfo = tL.CalcHitInfo(e.Point);
            if (hitInfo.HitInfoType == HitInfoType.SummaryFooter)
            {
                DXMenuItem menuItem = new DXMenuItem("Clear All", new EventHandler(this.clearAllMenuItemClick));
                menuItem.Tag = hitInfo.Column;
                e.Menu.Items.Add(menuItem);
            }
        }
        private void clearAllMenuItemClick(object sender, EventArgs e)
        {
            TreeListColumn clickedColumn = (sender as DXMenuItem).Tag as TreeListColumn;
            if (clickedColumn == null) return;
            TreeList tl = clickedColumn.TreeList;
            foreach (TreeListColumn column in tl.Columns)
                column.SummaryFooter = SummaryItemType.None;
        }

        private void treeList1_MouseClick(object sender, MouseEventArgs e)
        {
            //ContextMenu ct = new ContextMenu();
            //ct.MenuItems.Add("Add Plan");
            //ct.MenuItems.Add("Add Equipment");
            //ct.MenuItems.Add("Add Component");
            //ct.MenuItems.Add("Add Report5");
            //treeList1.ContextMenu = ct;
            
        }
        
        private void shows()
        {
            MessageBox.Show("Hoang");
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }
        //<Calculation>
        private String checkCatalog(String a)
        {
            if (a == "Highly Effective")
                return "A";
            else if (a == "Usually Effective")
                return "B";
            else if (a == "Fairly Effective")
                return "C";
            else if (a == "Poorly Effective")
                return "D";
            else
                return "E";
        }
        private int convertType(String a)
        {
            if (a == "C")
                return 3;
            if (a == "B")
                return 2;
            else
                return 1;
        }
        private void Calculator()
        {
            RiskBaseCalculate riskBase = new RiskBaseCalculate();

            // BUS
            BusRiskSummary bus = new BusRiskSummary();
            BusEquipmentTemp busTemp = new BusEquipmentTemp();
            List<EquipmentTemp> list = busTemp.loads();

            List<RiskSummary> listRisk = new List<RiskSummary>();
            RiskSummary risk = new RiskSummary();
            BusComponents busCOm = new BusComponents();
            //Component com;
            RBICalculatorConn rbicon = new RBICalculatorConn();
            consequenceAnalysisLvl1 financial = new consequenceAnalysisLvl1();
            //list.Count
            // Tinh toan
            BusFullPlant busFull = new BusFullPlant();
            List<FullPlantObject> listFull = busFull.load();

            BusRiskDemo riskDemo = new BusRiskDemo();
            for (int i = 0; i < listFull.Count; i++)
            {
                riskBase.equipmentType = listFull[i].EquipType;
                riskBase.componentType = listFull[i].ComponentType;
                riskBase.Fms = listFull[i].Fms;
                riskBase.crackPresent = listFull[i].CrackPresent;
                riskBase.internalLiner = listFull[i].InternalLiner;
                riskBase.thinning = listFull[i].CheckThin;
                riskBase.noInsp = listFull[i].NoInsp;
                riskBase.catalog_thin = checkCatalog(listFull[i].CatalogThin);
                riskBase.age = DateTime.Now.Year - int.Parse(listFull[i].LastIsnpDate.Substring(6, 4));
                riskBase.Trd = listFull[i].NominalThick / 25.4;
                riskBase.haveCladding = listFull[i].Cladding;
                riskBase.Crbm = listFull[i].CorrosionRateMetal * 39.4 / 1000;
                riskBase.Crcm = listFull[i].CorrosionRateCladding * 39.4 / 1000;
                riskBase.T = listFull[i].ThickBaseMetal / 25.4;
                riskBase.Tmin = listFull[i].MinimumThick / 25.4;
                riskBase.CA = listFull[i].CA / 25.4;
                riskBase.Fom_thin = listFull[i].Fom;
                riskBase.Fip = listFull[i].Fip;
                riskBase.Fdl = listFull[i].Fdl;
                riskBase.Fwd = listFull[i].Fwd;
                riskBase.Fam = listFull[i].Fam;
                riskBase.linningType = listFull[i].LinningType;
                riskBase.yearInService = listFull[i].YearInservice;
                riskBase.Fom_lin = listFull[i].Fom;
                riskBase.Flc = listFull[i].Flc;
                riskBase.catalog_caustic = checkCatalog(listFull[i].CatalogCaustic);
                riskBase.level_caust = listFull[i].LevelCaustic;
                riskBase.level_amine = listFull[i].LevelAmine;
                riskBase.catalog_amine = checkCatalog(listFull[i].CatalogAmine);
                riskBase.catalog_sulf = checkCatalog(listFull[i].CatalogSulfide);
                riskBase.pH = listFull[i].pH;
                riskBase.PWHT = listFull[i].NoPWHT;
                riskBase.isPWHT = listFull[i].PWHT;
                riskBase.catalog_hicH2S = checkCatalog(listFull[i].HIC_H2S_Catalog);
                riskBase.ppm_H2S = listFull[i].H2S_ppm;
                riskBase.Risk_target = 100000;
                financial.componentType = riskBase.componentType;
                financial.releasePhase = listFull[i].ReleaseFluid;
                financial.material = listFull[i].MaterialsCA;
                financial.fluid = listFull[i].Fluid;
                financial.fluidPhase = listFull[i].FluidPhase;
                financial.idealGasConstant = "B";
                financial.fluidType = listFull[i].FluidType;
                financial.detectionType = convertType(listFull[i].DetectionType);
                //financial.detectionType = 3;
                //financial.isolationType = 3;
                financial.isolationType = convertType(listFull[i].IsolationType);
                financial.p_s = listFull[i].StoredPressure * 145.0377;
                //financial.p_s = 102;
                financial.p_atm = listFull[i].AtmosphericPressure * 145.0377;
                financial.t_s = listFull[i].StoredTemp * 1.8 + 491.67;
                //financial.t_s = 1764;
                financial.t_atm = listFull[i].AtmosphericTemp * 1.8 + 491.67;
                //financial.t_atm = 540;
                //financial.r_e = 100000;
                financial.r_e = listFull[i].Reynol;
                financial.mass_inv = listFull[i].InventoryTotal;
                //financial.mass_inv = 420000;//15000;// lb
                financial.mass_comp = (listFull[i].Vapor + listFull[i].Liquid) * 2.2;
                //financial.mass_comp = 10000;
                //financial.mitigationSystem = 3;
                financial.mitigationSystem = listFull[i].MitigationSystem;
                //financial.mfrac_tox = 0.3;
                financial.mfrac_tox = listFull[i].ToxicPercent;
                financial.materialType = listFull[i].MaterialsCA;
                //financial.materialType = "Carbon Steel";// "Carbon Steel";
                financial.releaseDuration = listFull[i].ReleaseDuration;
                //financial.releaseDuration = "40";
                //financial.nfntReleaseFluid = "Steam";
                financial.nfntReleaseFluid = listFull[i].NonToxic_NonFlammable;
                financial.outage_mult = listFull[i].OutageMultiplier;
                //financial.outage_mult = 2;
                financial.prodcost = listFull[i].ProductionCost;
                //financial.prodcost = 50000;
                financial.injcost = listFull[i].InjuryCost;
                //financial.injcost = 5000000;
                financial.envcost = listFull[i].EnvCost;
                //financial.envcost = 0;
                //financial.popdens = 0.00006;
                financial.popdens = listFull[i].PersonDensity / 10763910;
                financial.equipcost = listFull[i].EquipmentCost / 10.76;
                riskBase.CoF = financial.fc();

                ///<summary>
                /// xuat ket qua
                ///</summary>
                risk.ComName = listFull[i].SubComponent;
                risk.ItemNo = listFull[i].EquipNum;
                risk.EqDesc = listFull[i].EquipDescrip;
                risk.EqType = listFull[i].EquipType;
                risk.RepresentFluid = listFull[i].RepresentFluid;
                risk.FluidPhase = listFull[i].FluidPhase;
                risk.CotcatFlammable = "" + financial.ca_cmd();
                risk.CurrentRisk = "N/A";
                risk.CotcatPeople = "" + financial.fc_inj();
                risk.CotcatAsset = "" + financial.fc_prod();
                risk.CotcatEnv = "" + financial.fc_environ();
                risk.CotcatReputation = "N/A";
                risk.CotcatCombinled = "" + financial.fc();
                risk.ComponentMaterialGrade = "N/A";
                risk.InitThinningCategory = "" + riskBase.PoF_thin(riskBase.age);
                risk.InitEnvCracking = "" + riskBase.PoF_scc(riskBase.age);
                risk.InitOtherCategory = "" + riskBase.PoF_brit();
                risk.InitCategory = "" + (riskBase.PoF_thin(riskBase.age) + riskBase.PoF_scc(riskBase.age));
                risk.ExtThinningCategory = "N/A";
                risk.ExtEnvCracking = "N/A";
                risk.ExtOtherCategory = "N/A";

                risk.ExtCategory = "" + riskBase.PoF_ext(riskBase.age);
                risk.POFCategory = "" + riskBase.PoF_total(riskBase.age);

                risk.CurrentRiskCal = "" + (riskBase.PoF_total(riskBase.age) * financial.fc());
                risk.FutureRisk = "" + (riskBase.PoF_total(riskBase.age + 1) * financial.fc());

                riskDemo.add(risk);
            }
        }

        private void btnImportExcelData_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImportExcel import = new ImportExcel();
            import.ShowDialog();
        }

        private void barBtnNewEquipment_ItemClick(object sender, ItemClickEventArgs e)
        {
            newEquipment eq = new newEquipment();
            eq.ShowDialog();
        }

        private void barBtnImportEquipment_ItemClick(object sender, ItemClickEventArgs e)
        {

        }




        
        UCCoatLiningIsulationCladding coat = new UCCoatLiningIsulationCladding();
        
        UCAssessmentInfo ass = new UCAssessmentInfo();
        UCComponentProperties comp = new UCComponentProperties();
        UCEquipmentProperties eq = new UCEquipmentProperties();
        UCMaterial ma = new UCMaterial();
        UCOperatingCondition op = new UCOperatingCondition();
        UCStream st = new UCStream();
        UCNoInspection No = new UCNoInspection();
        MSSQL_DM_CAL cal = new MSSQL_DM_CAL();
        UCNoInspection NoInsp = new UCNoInspection();

        private void Calculation()
        {
            RW_EQUIPMENT rweq = eq.getData();
            RW_COMPONENT rwcom = comp.getData();
            RW_MATERIAL rwma = ma.getData();
            RW_STREAM rwstream1 = st.getData1();
            RW_STREAM rwstream2 = st.getData2();
            RW_COATING rwcoat = coat.getData();
            NO_INSPECTION noInsp = NoInsp.getData();
            //<input thinning>
            cal.Diametter = rwcom.NominalDiameter;
            cal.NomalThick = rwcom.NominalThickness;
            cal.CurrentThick = rwcom.CurrentThickness;
            cal.MinThickReq = rwcom.MinReqThickness;
            cal.CorrosionRate = rwcom.CurrentCorrosionRate;

            cal.ProtectedBarrier = rweq.DowntimeProtectionUsed == 1 ? true : false; //xem lai
            cal.CladdingCorrosionRate = rwcoat.CladdingCorrosionRate;
            cal.InternalCladding = rwcoat.InternalCladding == 1 ? true : false;
            cal.NoINSP_THINNING = noInsp.numThinning;
            //cal.EFF_THIN = chua biet
            cal.OnlineMonitoring = rweq.OnlineMonitoring;
            cal.HighlyEffectDeadleg = rweq.HighlyDeadlegInsp == 1 ? true : false;
            cal.ContainsDeadlegs = rweq.ContainsDeadlegs == 1 ? true : false;
            //tank maintain653 trong Tank Bottom
            cal.AdjustmentSettle = rweq.AdjustmentSettle;
            cal.ComponentIsWeld = rweq.ComponentIsWelded == 1 ? true : false;
            //</input thinning>

            //<input linning>
            //cal.LinningType = r
            cal.LINNER_ONLINE = rweq.LinerOnlineMonitoring == 1 ? true : false;
            //cal.LINNER_CONDITION = 
            //</input linning>
        }


        private void btnImportInspection_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmImportInspection insp = new frmImportInspection();
            insp.ShowDialog();
        }
        private void addNewTab(string tabname, UserControl uc)
        {
            foreach (DevExpress.XtraTab.XtraTabPage tabpage in xtraTabData.TabPages)
            {
                if (tabpage.Text == tabname)
                    return;
            }
            DevExpress.XtraTab.XtraTabPage tabPage = new DevExpress.XtraTab.XtraTabPage();
            tabPage.Name = "tab" + tabname.Split(' ');
            tabPage.Text = tabname;
            tabPage.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            if (xtraTabData.TabPages.Contains(tabPage)) return;
            xtraTabData.TabPages.Add(tabPage);
            tabPage.Show();
            
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            
        }

        private void navAssessmentInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            addNewTab("Assessment Information", ass);
        }

        private void navEquipment_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            addNewTab("Equipment", eq);
        }

        private void navComponent_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            addNewTab("Component", comp);
        }

        private void navOperating_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            addNewTab("Operating Conditions", op);
        }

        private void navMaterial_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            addNewTab("Material", ma);
        }

        private void navCoating_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            addNewTab("Coating Cladding", coat);
        }

        private void navNoInspection_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            addNewTab("Number of Inspection", No);
        }

        private void navStream_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            addNewTab("Stream", st);
        }
    }
}