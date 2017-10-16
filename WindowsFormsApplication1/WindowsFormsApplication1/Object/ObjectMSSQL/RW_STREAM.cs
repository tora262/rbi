using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class RW_STREAM
    {
        public int ID { set; get; }
        public String AmineSolution { set; get; }
        public int AqueousOperation { set; get; }
        public int AqueousShutdown { set; get; }
        public int ToxicConstituent { set; get; }
        public int Caustic { set; get; }
        public float Chloride { set; get; }
        public float CO3Concentration { set; get; }
        public int Cyanide { set; get; }
        public int ExposedToGasAmine { set; get; }
        public int ExposedToSulphur { set; get; }
        public String ExposureToAmine { set; get; }
        public int FlammableFluidID { set; get; }
        public float FlowRate { set; get; } //nằm ở file Operating
        public int H2S { set; get; }
        public float H2SInWater { set; get; }
        public int Hydrogen { set; get; } //??
        public float H2SPartialPressure { set; get; }//??
        public int Hydrofluoric { set; get; }
        public int MaterialExposedToClInt { set; get; }
        public float MaxOperatingPressure { set; get; }
        public float MaxOperatingTemperature { set; get; }
        public float MinOperatingPressure { set; get; }
        public float MinOperatingTemperature { set; get; }
        public float CriticalExposureTemperature { set; get; } //ben file Operating
        public int ModelFluidID { set; get; }
        public float NaOHConcentration { set; get; }
        public int NonFlameToxicFluidID { set; get; }
        public float ReleaseFluidPercentToxic { set; get; }
        public String StoragePhase { set; get; } //??
        public int ToxicFluidID { set; get; }
        public float WaterpH { set; get; }
        public String TankFluidName { set; get; }//??
        public float FluidHeight { set; get; }
        public float FluidLeaveDikePercent { set; get; }
        public float FluidLeaveDikeRemainOnSitePercent { set; get; }
        public float FluidGoOffSitePercent { set; get; }
    }
}
