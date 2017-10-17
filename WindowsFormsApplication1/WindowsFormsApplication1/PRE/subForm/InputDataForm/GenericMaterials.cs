using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class GenericMaterials : DevExpress.XtraEditors.XtraForm
    {
        public GenericMaterials()
        {
            InitializeComponent();
        }
        private void formatGridView()
        {
            string[] fields = { "GenericMaterial", "DesignPressure", "Max.DesignTemoerature", "Min.DesignTemperature", "Corrosionllowance", "SulfurContent", "Chromium", "SigmaPhase", "HeatTreatment", "Ref.Temperature", "Austenitic", "Temper", "CarbonLowAlloy", "NickelBased", "CostFactor", "PTAMaterial", "HTHAMaterial" };
            string[] caption = { "Generic Material", "Design Pressure (psi)", "Max. Design Temoerature", "Min. Design Temperature", "Corrosion Allowance", "Sulfur Content %", "Chromium >= 12%", "Sigma Phase", "Heat Treatment", "Ref. Temperature", "Austenitic", "Temper", "Carbon Low Alloy", "Nickel Based", "Cost Factor", "PTA Material", "HTHA Material" };
            for (int i = 0; i < fields.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = fields[i];
                col.Caption = caption[i];
                gridView1.Columns.Add(col);
                gridView1.Columns[i].Visible = true;
                gridView1.Columns[i].Width = 100;
            }
            gridView1.BestFitColumns();
        }
    }
}