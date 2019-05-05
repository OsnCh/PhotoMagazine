using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PhotoMagazine.Client.Core.Models.Base;

namespace PhotoMagazine.Client.Core
{
    public class ConfigurationManager
    {
        public static AppConfiguration GetBase(string configName)
        {
            var type = typeof(App);
            var resource = $"{type.Namespace}.app.{configName}.config";

            var typeConfig = typeof(AppConfiguration);

            using (var stream = type.Assembly.GetManifestResourceStream(resource))
            using (var reader = new StreamReader(stream))
            {
                var doc = XDocument.Parse(reader.ReadToEnd());
                var elemConfig = doc.Element("config");

                var config = new AppConfiguration();

                foreach (var property in typeConfig.GetProperties())
                {
                    var name = property.Name;
                    property.SetValue(config, elemConfig.Element(name).Value);
                }

                return config;
            }
        }
    }
}
