using NextUp.CoreStorage;
using System.Linq;

namespace NextUp.MultiScenario
{
    public class ScenarioManager : Repository
    {
        private object _currentScenario;

        public ScenarioManager(object baseScenario)
        {
            CurrentScenario = baseScenario;
        }

        public object CurrentScenario
        {
            get
            {
                return _currentScenario;
            }
            set
            {
                if (_currentScenario != value)
                {
                    _currentScenario = value;
                    foreach (var o in AffectedObjects.Cast<ILazyUpdate>())
                    {
                        o.ScenarioDataOutdated = true;
                    }
                }
            }
        }
    }
}
