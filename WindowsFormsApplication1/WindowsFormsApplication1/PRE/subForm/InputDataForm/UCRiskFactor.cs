using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCRiskFactor : UserControl
    {
        public UCRiskFactor()
        {
            InitializeComponent();
            readOnlyAllTextbox();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
        private void readOnlyAllTextbox()
        {
            txt00.ReadOnly = true;
            txt01.ReadOnly = true;
            txt02.ReadOnly = true;
            txt10.ReadOnly = true;
            txt11.ReadOnly = true;
            txt12.ReadOnly = true;
            txt20.ReadOnly = true;
            txt21.ReadOnly = true;
            txt22.ReadOnly = true;
            txt30.ReadOnly = true;
            txt31.ReadOnly = true;
            txt32.ReadOnly = true;
            txt40.ReadOnly = true;
            txt41.ReadOnly = true;
            txt42.ReadOnly = true;
            txt50.ReadOnly = true;
            txt51.ReadOnly = true;
            txt52.ReadOnly = true;
            txt60.ReadOnly = true;
            txt61.ReadOnly = true;
            txt62.ReadOnly = true;
            txt70.ReadOnly = true;
            txt71.ReadOnly = true;
            txt72.ReadOnly = true;
            txt80.ReadOnly = true;
            txt81.ReadOnly = true;
            txt82.ReadOnly = true;
            txt90.ReadOnly = true;
            txt91.ReadOnly = true;
            txt92.ReadOnly = true;
            txtA0.ReadOnly = true;
            txtA1.ReadOnly = true;
            txtA2.ReadOnly = true;
            txtB0.ReadOnly = true;
            txtB1.ReadOnly = true;
            txtB2.ReadOnly = true;
            txtC0.ReadOnly = true;
        }
    }
}
