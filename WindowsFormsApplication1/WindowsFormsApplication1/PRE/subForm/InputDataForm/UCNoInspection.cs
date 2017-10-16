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
    public partial class UCNoInspection : UserControl
    {
        public UCNoInspection()
        {
            InitializeComponent();
        }
        public NO_INSPECTION getData()
        {
            NO_INSPECTION no = new NO_INSPECTION();
            //number inspection
            no.numThinning = int.Parse(txtThinning.Text);
            no.numCaustic = int.Parse(txtCaustic.Text);
            no.numAmine = int.Parse(txtAmine.Text);
            no.numSulphide = int.Parse(txtSulphide.Text);
            no.numHICSOHIC_H2S = int.Parse(txtH2S.Text);
            no.numCarbonate = int.Parse(txtCarbonate.Text);
            no.numExternal_CLSCC = int.Parse(txtExternalCLSCC.Text);
            no.numPTA = int.Parse(txtPTA.Text);
            no.numCLSCC = int.Parse(txtCLSCC.Text);
            no.numHSC_HF = int.Parse(txtHSCHF.Text);
            no.numHICSOHIC_HF = int.Parse(txtHF.Text);
            no.numExternalCorrosion = int.Parse(txtExternalCorrosion.Text);
            no.numCUI = int.Parse(txtCUI.Text);
            no.numExternalCUI = int.Parse(txtExternalCUI.Text);
            //catalog
            no.inspThinning = cbThinning.Text;
            no.inspCaustic = cbCaustic.Text;
            no.inspAmine = cbAmine.Text;
            no.inspSulphide = cbSulphide.Text;
            no.inspHICSOHIC_H2S = cbH2S.Text;
            no.inspCarbonate = cbCarbonate.Text;
            no.inspExternal_CLSCC = cbExternalCLSCC.Text;
            no.inspPTA = cbPTA.Text;
            no.inspCLSCC = cbCLSCC.Text;
            no.inspHSC_HF = cbHSC_HF.Text;
            no.inspHICSOHIC_HF = cbHICSOHICHF.Text;
            no.inspExternalCorrosion = cbExternalCorrosion.Text;
            no.inspCUI = cbCUI.Text;
            no.inspExternalCUI = cbExternalCUI.Text;
            return no;
        }
    }
}
