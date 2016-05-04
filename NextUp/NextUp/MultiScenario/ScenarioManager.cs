using NextUp.CoreStorage;

namespace NextUp.MultiScenario
{
    public class ScenarioManager : Repository
    {
        private object _currentScenario;

        public ScenarioManager(object baseScenario)
        {
            CurrentScenario = baseScenario;
        }

        public bool IsChangingScenario { get; private set; }

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
                    IsChangingScenario = true;
                    _currentScenario = value;
                    Execute(_currentScenario);
                    IsChangingScenario = false;
                }
            }
        }
    }
}
