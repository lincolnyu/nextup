using NextUp.MultiScenario;
using NextUp.Helpers;

namespace NextUpConsoleTest
{
    public class SampleObject
    {
        public static ScenarioManager ScenarioManager { get; set; }

        private int _sampleProperty;

        public int SampleProperty
        {
            get { return _sampleProperty; }
            set
            {
                ScenarioManager.SetValue(this, "SampleProperty", value);
                _sampleProperty = value;
            }
        }
    }
}
