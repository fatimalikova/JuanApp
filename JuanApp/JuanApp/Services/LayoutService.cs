using JuanApp.Data;

namespace JuanApp.Services
{
    public class LayoutService(JuanDbContext context)
    {
        public Dictionary<string, string> GetSettings()
        {
            return context.Settings.ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
