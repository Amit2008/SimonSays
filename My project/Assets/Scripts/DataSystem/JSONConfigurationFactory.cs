// Factory for creating JSON configurations
public class JSONConfigurationFactory : ConfigurationFactory
{
    public override GameConfiguration CreateConfiguration()
    {
        return new JSONGameConfiguration();
    }
}