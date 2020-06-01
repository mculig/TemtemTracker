using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemtemTracker.Data
{
    public class Paths
    {
        public static readonly string SAVE_FOLDER_PATH = @"savedData";
        public static readonly string SPECIES_PATH = @"config\temtemSpecies.json";
        public static readonly string CONFIG_PATH = @"config\config.json";
        public static readonly string USER_SETTINGS_PATH = @"config\userSettings.json";
        public static readonly string STYLES_PATH = @"styles";
        public static readonly string TABLE_FILE = SAVE_FOLDER_PATH + @"\table.json";
        public static readonly string DATABASE_PATH = SAVE_FOLDER_PATH + @"\history.db";
    }
}
