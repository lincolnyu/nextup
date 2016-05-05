namespace NextUp.MultiScenario
{
    public interface ILazyUpdate
    {
        bool ScenarioDataOutdated { get; set; }
    }
}
