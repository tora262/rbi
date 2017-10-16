using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class NO_INSPECTION
    {
        public int numThinning { set; get; }
        public int numCaustic { set; get; }
        public int numAmine { set; get; }
        public int numSulphide { set; get; }
        public int numHICSOHIC_H2S { set; get; }
        public int numCarbonate { set; get; }
        public int numExternal_CLSCC { set; get; }
        public int numPTA { set; get; }
        public int numCLSCC { set; get; }
        public int numHSC_HF { set; get; }
        public int numHICSOHIC_HF { set; get; }
        public int numExternalCorrosion { set; get; }
        public int numCUI { set; get; }
        public int numExternalCUI { set; get; }


        public string inspThinning { set; get; }
        public string inspCaustic { set; get; }
        public string inspAmine { set; get; }
        public string inspSulphide { set; get; }
        public string inspHICSOHIC_H2S { set; get; }
        public string inspCarbonate { set; get; }
        public string inspExternal_CLSCC { set; get; }
        public string inspPTA { set; get; }
        public string inspCLSCC { set; get; }
        public string inspHSC_HF { set; get; }
        public string inspHICSOHIC_HF { set; get; }
        public string inspExternalCorrosion { set; get; }
        public string inspCUI { set; get; }
        public string inspExternalCUI { set; get; }

    }
}
