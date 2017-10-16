using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class NewComponent : Form
    {
        public NewComponent()
        {
            InitializeComponent();
            addComponentType();
        }
        private void addComponentType()
        {
            cbComponentType.Properties.Items.Add("Fixed Roof");
            cbComponentType.Properties.Items.Add("Floating Roof");
            cbComponentType.Properties.Items.Add("Shell");
            cbComponentType.Properties.Items.Add("Tank Bottom");
        }
        private void add()
        {
            for(int i = 1; i < 10; i++)
            {
                cbAPIComponentType.Properties.Items.Add("COURSE-" + i);
            }
            cbAPIComponentType.Properties.Items.Add("TANKBOTTOM");
        }
        //public COMPONENT_MASTER getData()
        //{
        //    //cac so ID chua gan
        //    COMPONENT_MASTER compMaster = new COMPONENT_MASTER();
            
        //    compMaster.ComponentName = txtComponentName.Text;
        //    compMaster.ComponentNumber = txtComponentNumber.Text;
        //    compMaster.ComponentDesc = txtDescription.Text;
        //    compMaster.IsEquipmentLinked = Convert.ToInt32(chkLinks.Checked);
        //    return compMaster;
        //}
    }
}
