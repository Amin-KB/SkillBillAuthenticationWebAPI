using System.Text.RegularExpressions;

namespace SkillBilAuth.Services
{
    public static class ConfigurationService
    {
        public static string connectionString=GetConfig().GetSection("ConnectionStrings")["DefaultConnection"];
        public static string GetRootPath(string rootFilename)
        {
            string _root;
            var rootDir = System.IO.Path.GetDirectoryName(
                      System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex matchThepath = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = matchThepath.Match(rootDir).Value;
            _root = Path.Combine(appRoot, rootFilename);

            return _root;
        }
        public static IConfiguration GetConfig()
        {

            var config = (IConfiguration)new ConfigurationBuilder().AddJsonFile(GetRootPath("connectionsettings.json")).Build();

            return config;


        }
    }
}
