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
            addAPI();
            //addComponentTypeforTankBottom();
            //addAPIComponentforTankBottom();
        }
        private void addComponentType()
        {
            cbComponentType.Properties.Items.Add("Bend / Elbow");
            cbComponentType.Properties.Items.Add("Cylindrical Section");
            cbComponentType.Properties.Items.Add("Cylindrical Shell");
            cbComponentType.Properties.Items.Add("Elliptical Head");
            cbComponentType.Properties.Items.Add("Fixed Roof");
            cbComponentType.Properties.Items.Add("Float Roof");
            cbComponentType.Properties.Items.Add("Hemispherical Head");
            cbComponentType.Properties.Items.Add("Nozzle");
            cbComponentType.Properties.Items.Add("Reducer");
            cbComponentType.Properties.Items.Add("Shell");
            cbComponentType.Properties.Items.Add("Spherical Shell");
            cbComponentType.Properties.Items.Add("Torispherical Head");
        }
        private void addAPI()
        {
            cbAPIComponentType.Properties.Items.Add("COLBTM");
            cbAPIComponentType.Properties.Items.Add("COLMID");
            cbAPIComponentType.Properties.Items.Add("COLTOP");
            cbAPIComponentType.Properties.Items.Add("COMPC");
            cbAPIComponentType.Properties.Items.Add("COMPR");
            for (int i = 1; i < 10; i++)
            {
                cbAPIComponentType.Properties.Items.Add("COURSE-" + i);
            }
            cbAPIComponentType.Properties.Items.Add("DRUM");
            cbAPIComponentType.Properties.Items.Add("FILTER");
            cbAPIComponentType.Properties.Items.Add("FINFAN");
            cbAPIComponentType.Properties.Items.Add("HEXSS");
            cbAPIComponentType.Properties.Items.Add("HEXTUBE");
            cbAPIComponentType.Properties.Items.Add("KODRUM");
            cbAPIComponentType.Properties.Items.Add("PIPE-1");
            cbAPIComponentType.Properties.Items.Add("PIPE-2");
            cbAPIComponentType.Properties.Items.Add("PIPE-4");
            cbAPIComponentType.Properties.Items.Add("PIPE-6");
            cbAPIComponentType.Properties.Items.Add("PIPE-8");
            cbAPIComponentType.Properties.Items.Add("PIPE-10");
            cbAPIComponentType.Properties.Items.Add("PIPE-12");
            cbAPIComponentType.Properties.Items.Add("PIPE-16");
            cbAPIComponentType.Properties.Items.Add("PIPEGT16");
            cbAPIComponentType.Properties.Items.Add("PUMP1S");
            cbAPIComponentType.Properties.Items.Add("PUMP2S");
            cbAPIComponentType.Properties.Items.Add("PUMPR");
            cbAPIComponentType.Properties.Items.Add("REACTOR");
            cbAPIComponentType.Properties.Items.Add("TANKBOTTOM");
            cbAPIComponentType.Properties.Items.Add("OTHER");
        }
        private  void addComponentTypeforTankBottom()
        {
            cbComponentType.Properties.Items.Add("Fixed Roof");
            cbComponentType.Properties.Items.Add("Float Roof");
            cbComponentType.Properties.Items.Add("Shell");
            cbComponentType.Properties.Items.Add("Tank bottom");
        }
        private void addAPIComponentforTankBottom()
        {
            for (int i = 1; i < 10; i++)
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
