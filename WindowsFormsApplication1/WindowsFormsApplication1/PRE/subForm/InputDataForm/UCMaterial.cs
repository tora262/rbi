﻿using System;
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
    public partial class UCMaterial : UserControl
    {
        public UCMaterial()
        {
            InitializeComponent();
            cbHTHAMaterial.Enabled = false;
            cbPTAMaterial.Enabled = false;
            addSulfurContent();
            addMaterialGradeHTHA();
            addHeatTreatment();
            addMaterialGradeHTHA();
        }

        private void addSulfurContent()
        {
            cbSulfurContent.Properties.Items.Add("");
            cbSulfurContent.Properties.Items.Add("Ultra Low < 0.002%");
            cbSulfurContent.Properties.Items.Add("Low 0.002 - 0.01%");
            cbSulfurContent.Properties.Items.Add("High > 0.01%");
        }
        private void addHeatTreatment()
        {
            cbHeatTreatment.Properties.Items.Add("");
            cbHeatTreatment.Properties.Items.Add("None");
            cbHeatTreatment.Properties.Items.Add("Annealed");
            cbHeatTreatment.Properties.Items.Add("Normalised Temper");
            cbHeatTreatment.Properties.Items.Add("Quench Temper");
            cbHeatTreatment.Properties.Items.Add("Stress Relieved");
            cbHeatTreatment.Properties.Items.Add("Sub Critical PWHT");
        }
        private void addMaterialGradeHTHA()
        {
            cbHTHAMaterial.Properties.Items.Add("");
            cbHTHAMaterial.Properties.Items.Add("Carbon Steel");
            cbHTHAMaterial.Properties.Items.Add("C-0.5Mo (Annealed)");
            cbHTHAMaterial.Properties.Items.Add("C-0.5Mo (Normalised)");
            cbHTHAMaterial.Properties.Items.Add("1Cr-0.5Mo");
            cbHTHAMaterial.Properties.Items.Add("1.25Cr-0.5Mo");
            cbHTHAMaterial.Properties.Items.Add("2.25Cr-1Mo");
            cbHTHAMaterial.Properties.Items.Add("Not Applicable");
        }
        private void addPTAMterial()
        {
            cbPTAMaterialGrade.Properties.Items.Add("");
            cbPTAMaterialGrade.Properties.Items.Add("Regular 300 series Stainless Steel and Alloys 600 and 800");
            cbPTAMaterialGrade.Properties.Items.Add("L Grade 300 series Stainless Steel");
            cbPTAMaterialGrade.Properties.Items.Add("H Grade 300 series Stainless Steel");
            cbPTAMaterialGrade.Properties.Items.Add("321 Stainless Steel");
            cbPTAMaterialGrade.Properties.Items.Add("347 Stainless Steel, Alloy 20, Alloy 625, All  austenitic weld overlay");
            cbPTAMaterialGrade.Properties.Items.Add("Not Applicable");
        }

        public RW_MATERIAL getData()
        {
            RW_MATERIAL ma = new RW_MATERIAL();
            ma.MaterialName = cbPTAMaterial.Text;
            ma.DesignPressure = float.Parse(txtDesignPressure.Text);
            ma.DesignTemperature = float.Parse(txtMaxDesignTemperature.Text);
            ma.MinDesignTemperature = float.Parse(txtMinDesignTemperature.Text);
            ma.BrittleFractureThickness = float.Parse(txtBrittleFracture.Text);
            ma.CorrosionAllowance = float.Parse(txtCorrosionAllowance.Text);
            //if(tankBottom) -> hide txtSigmaPhase
            ma.SigmaPhase = float.Parse(txtSigmaPhase.Text);
            ma.SulfurContent = cbSulfurContent.Text;
            ma.HeatTreatment = cbHeatTreatment.Text;
            ma.ReferenceTemperature = float.Parse(txtReferenceTemperature.Text);
            ma.PTAMaterialCode = cbPTAMaterial.Text;
            ma.HTHAMaterialCode = cbHTHAMaterial.Text;
            ma.IsPTA = chkIsPTA.Checked ? 1 : 0;
            ma.IsHTHA = chkIsHTHA.Checked ? 1 : 0;
            ma.Austenitic = chkAusteniticSteel.Checked ? 1 : 0;
            ma.Temper = chkSusceptibleTemper.Checked ? 1 : 0;
            ma.CarbonLowAlloy = chkCarbonLowAlloySteel.Checked ? 1 : 0;
            ma.NickelBased = chkNickelAlloy.Checked ? 1 : 0;
            ma.ChromeMoreEqual12 = chkChromium.Checked ? 1 : 0;
            ma.AllowableStress = float.Parse(txtAllowableStress.Text);
            ma.CostFactor = float.Parse(txtMaterialCostFactor.Text);
            return ma;
        }

        private void chkIsHTHA_CheckedChanged(object sender, EventArgs e)
        {
            cbHTHAMaterial.Enabled = chkIsHTHA.Checked ? true : false;
        }

        private void chkIsPTA_CheckedChanged(object sender, EventArgs e)
        {
            cbPTAMaterialGrade.Enabled = chkIsPTA.Checked ? true : false;
        }
    }
}
