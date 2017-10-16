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
    public partial class UCOperatingCondition : UserControl
    {
        public UCOperatingCondition()
        {
            InitializeComponent();
        }

        RW_STREAM str = new RW_STREAM();
        public RW_STREAM getData()
        {
            str.FlowRate = float.Parse(txtFlowRate.Text);
            str.MaxOperatingPressure = float.Parse(txtMaxOperatingPressure.Text);
            str.MinOperatingPressure = float.Parse(txtMinOperatingPressure.Text);
            str.MaxOperatingTemperature = float.Parse(txtMaximumOperatingTemp.Text);
            str.MinOperatingTemperature = float.Parse(txtMinimumOperatingTemp.Text);
            str.CriticalExposureTemperature = float.Parse(txtCriticalExposure.Text);

            //if(tankbottom) -> hide Operating Hydrogen Partial Pressure
            return str;
        }
    }
}
