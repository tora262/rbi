using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace RBI.PRE.subForm
{
    public partial class UCRiskSummary : UserControl
    {
        public UCRiskSummary()
        {
            InitializeComponent();
        }
        RiskSummary risk = new RiskSummary();
        public List<RiskSummary> loadData()
        {
            List<RiskSummary> listrisk = new List<RiskSummary>();
            string sql = "select"
                + "rbi.dbo.SITES.SiteName,"
                + "faci.FacilityName,"
                + "compMaster.ComponentName,"
                + "eqMaster.EquipmentTypeID,"
                + "pof.CoFCategory,"
                + "pof.PoFAP1Category,"
                + "pof.PoFAP2Category,"
                + "pof.ThinningType"
                + "from rbi.dbo.RW_FULL_POF pof"
                + "join rbi.dbo.RW_ASSESSMENT assess"
                + "on assess.ID = pof.ID"
                + "join rbi.dbo.EQUIPMENT_MASTER eqMaster"
                + "on eqMaster.EquipmentID = assess.EquipmentID"
                + "join rbi.dbo.COMPONENT_MASTER compMaster"
                + "on compMaster.ComponentID = assess.ComponentID"
                + "join rbi.dbo.FACILITY faci"
                + "on faci.FacilityID = eqMaster.FacilityID"
                + "join rbi.dbo.SITES"
                + "on SITES.SiteID = eqMaster.SiteID";
            MySqlConnection conn = DAL.DBUtils.getDBConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            using (System.Data.Common.DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        risk = new RiskSummary();
                        risk.SiteName = reader.GetString(0);
                        risk.FaciName = reader.GetString(1);
                        risk.ComName = reader.GetString(2);
                        risk.EqName = reader.GetString(3);
                        risk.EqDesc = reader.GetString(4);
                        risk.EqType = reader.GetString(5);
                        risk

                        listEq.Add(risk);
                    }
                }
            }
    }
}
