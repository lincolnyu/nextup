using NextUp.MultiScenario;
using NextUp.Helpers;

namespace NextUpConsoleTest
{
    public class SampleObject : ILazyUpdate
    {
        public static ScenarioManager ScenarioManager { get; set; }

        private int _sampleProperty;

        public int SampleProperty
        {
            get
            {
                UpdateIfNeeded();
                return _sampleProperty;
            }
            set
            {
                _sampleProperty = value;
                var xp = ScenarioManager.CurrentScenario as XpScenario;
                if (xp != null) xp.SetValue(ScenarioManager, this, "SampleProperty", value);
                else this.SetValue(ScenarioManager, "SampleProperty", value);
            }
        }

        public bool ScenarioDataOutdated
        {
            get; set;
        }

        private void UpdateIfNeeded()
        {
            if (!ScenarioDataOutdated) return;
            var xp = ScenarioManager.CurrentScenario as XpScenario;
            if (xp != null) xp.TryGetValue(ScenarioManager, this, "SampleProperty", out _sampleProperty);
            else this.TryGetValue(ScenarioManager, "SampleProperty", out _sampleProperty);
        }
    }
}
