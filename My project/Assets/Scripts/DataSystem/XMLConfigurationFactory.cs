public class XMLConfigurationFactory : ConfigurationFactory
{
    public override GameConfiguration CreateConfiguration()
    {
        return new XMLGameConfiguration();
    }
}
