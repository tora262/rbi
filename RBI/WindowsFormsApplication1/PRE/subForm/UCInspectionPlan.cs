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

namespace RBI.PRE.subForm
{
    public partial class UCInspectionPlan : UserControl
    {
        public UCInspectionPlan()
        {
            InitializeComponent();
            showData();
        }
        public void showData()
        {
            DAL.MSSQL.INSPECTION_PLAN_ConnectUtils insp = new DAL.MSSQL.INSPECTION_PLAN_ConnectUtils();
            dataGridView1.DataSource = insp.getDataSource();
        }
    }
}
