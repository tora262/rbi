using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RBI.Object.ObjectMSSQL;
using RBI.BUS.BUSMSSQL;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCAssessmentInfo : UserControl
    {
        List<COMPONENT_TYPE> listComponentType = new List<COMPONENT_TYPE>();
        COMPONENT_TYPE__BUS componentTypeBus = new COMPONENT_TYPE__BUS();
        
        
        public UCAssessmentInfo()
        {
            InitializeComponent();
            listComponentType = componentTypeBus.getDataSource();
            showDatatoControl();
        }
        public UCAssessmentInfo(int AssessmentID)
        {
            InitializeComponent();
            listComponentType = componentTypeBus.getDataSource();
            showDatatoControl();
        }
        public RW_ASSESSMENT getData()
        {
            RW_ASSESSMENT ass = new RW_ASSESSMENT();
            ass.AssessmentDate = dateAssessmentDate.DateTime;
            ass.AssessmentMethod = cbAsssessmentMethod.SelectedIndex;
            ass.RiskAnalysisPeriod = txtRiskAnalysisPeriod.Text != "" ? int.Parse(txtRiskAnalysisPeriod.Text) : 0;
            ass.IsEquipmentLinked = chkRiskLinksEquipmentRisk.Checked ? 1 : 0;
            ass.RecordType = cbReportTemplate.Text;
            ass.ProposalName = txtAssessmentName.Text;
            ass.AdoptedDate = DateTime.Now;
            ass.RecommendedDate = DateTime.Now;
            ass.ComponentID = 1;
            ass.EquipmentID = 1;
            return ass;
        }
        public EQUIPMENT_MASTER getEquipmentMaster()
        {
            EQUIPMENT_MASTER eq = new EQUIPMENT_MASTER();
            eq.EquipmentNumber = txtEquipmentNumber.Text;
            //eq.EquipmentDesc = txt
            return eq;
        }
        public RW_EQUIPMENT getData1()
        {
            RW_EQUIPMENT eq = new RW_EQUIPMENT();
            eq.CommissionDate = dateComissionDate.DateTime;
            return eq;
        }
        private void showDatatoControl()
        {
            //EQUIPMENT_TYPE_BUS eqTypeBus = new EQUIPMENT_TYPE_BUS();
            //List<EQUIPMENT_TYPE> listEquipmentType = eqTypeBus.getDataSource();
            //EQUIPMENT_MASTER_BUS equipmentMasterBus = new EQUIPMENT_MASTER_BUS();
            //List<EQUIPMENT_MASTER> listEquipmentMaster = equipmentMasterBus.getDataSource();
            //DESIGN_CODE_BUS designCodeBus = new DESIGN_CODE_BUS();
            //List<DESIGN_CODE> listDesignCode = designCodeBus.getDataSource();
            //SITES_BUS siteBus = new SITES_BUS();
            //List<SITES> listSite = siteBus.getData();
            //foreach(EQUIPMENT_MASTER e in listEquipmentMaster)
            //{
            //    try
            //    {
            //        txtEquipmentNumber.Text = e.EquipmentNumber;
            //        txtEquipmentName.Text = e.EquipmentName;
            //        txtProcessDesciption.Text = e.ProcessDescription;
            //        foreach(DESIGN_CODE d in listDesignCode)
            //        {
            //            if (d.DesignCodeID == e.DesignCodeID)
            //                txtDesignCode.Text = d.DesignCode;
            //        }
            //        foreach(EQUIPMENT_TYPE t in listEquipmentType)
            //        {
            //            if (t.EquipmentTypeID == e.EquipmentTypeID)
            //                txtEquipmentType.Text = t.EquipmentTypeName;
            //        }
            //    }
            //    catch(Exception ex)
            //    {
            //        MessageBox.Show("khong add duoc data vao UCAssessment--->" + ex.ToString(), "Cortek RBI");
            //    }
            //}
        }
        public void showData(int ID)
        {
            RW_ASSESSMENT_BUS BUS = new RW_ASSESSMENT_BUS();
            RW_ASSESSMENT obj = BUS.getData(ID);
            EQUIPMENT_MASTER_BUS EQBUS = new EQUIPMENT_MASTER_BUS();
            EQUIPMENT_MASTER EQobj = EQBUS.getData(obj.EquipmentID);
            txtAssessmentName.Text = obj.ProposalName;
            dateAssessmentDate.DateTime = obj.AssessmentDate;
            int method = obj.AssessmentMethod;
            cbAsssessmentMethod.SelectedIndex = method;
            txtRiskAnalysisPeriod.Text = obj.RiskAnalysisPeriod.ToString() ;

        }
    }
}
