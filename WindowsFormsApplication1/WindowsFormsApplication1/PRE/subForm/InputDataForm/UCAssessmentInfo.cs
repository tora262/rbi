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

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCAssessmentInfo : UserControl
    {
        public UCAssessmentInfo()
        {
            InitializeComponent();
            addAssessmentMethod();
            addReportTemplate();
        }
        public RW_ASSESSMENT getData()
        {
            RW_ASSESSMENT ass = new RW_ASSESSMENT();
            ass.AssessmentDate = dateAssessmentDate.DateTime;
            ass.AssessmentMethod = cbAsssessmentMethod.SelectedIndex;
            ass.RiskAnalysisPeriod = int.Parse(txtRiskAnalysisPeriod.Text);
            ass.IsEquipmentLinked = chkRiskLinksEquipmentRisk.Checked ? 1 : 0;
            ass.RecordType = cbReportTemplate.Text;
            return ass;
        }
        private void addAssessmentMethod()
        {
            cbAsssessmentMethod.Properties.Items.Add("");
            cbAsssessmentMethod.Properties.Items.Add("Semi-Quantitative PoF and Semi-Quantitative CoF");
            cbAsssessmentMethod.Properties.Items.Add("Semi-Quantitative PoF and Fully-Quantitative CoF");
            cbAsssessmentMethod.Properties.Items.Add("Fully-Quantitative PoF and Semi-Quantitative CoF");
            cbAsssessmentMethod.Properties.Items.Add("Fully-Quantitative PoF and Fully-Quantitative CoF");
        }
        private void addReportTemplate()
        {
            cbReportTemplate.Properties.Items.Add("");
            cbReportTemplate.Properties.Items.Add("Standard Component");
        }
    }
}
