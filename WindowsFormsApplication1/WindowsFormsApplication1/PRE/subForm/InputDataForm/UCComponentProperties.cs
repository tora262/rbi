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
    public partial class UCComponentProperties : UserControl
    {
        public UCComponentProperties()
        {
            InitializeComponent();
        }
        public RW_COMPONENT getData()
        {
            RW_COMPONENT comp = new RW_COMPONENT();
            comp.NominalDiameter = float.Parse(txtNominalDiameter.Text);
            comp.NominalThickness = float.Parse(txtNominalThickness.Text);
            comp.CurrentThickness = float.Parse(txtCurrentThickness.Text);
            comp.MinReqThickness = float.Parse(txtMinRequiredThickness.Text);
            comp.CurrentCorrosionRate = float.Parse(txtCurrentCorrosionRate.Text);
            comp.BranchDiameter = cbBranchDiameter.Text;
            comp.BranchJointType = cbJointTypeBranch.Text;
            comp.BrinnelHardness = cbMaxBrillnessHardness.Text;
            return comp;
        }
       
    }
}
