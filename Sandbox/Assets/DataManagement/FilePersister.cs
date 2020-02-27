using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace DataManagement
{
    public static class FilePersister
    {
        [Serializable]
        public class AppData
        {
           public string header;
           public int version;

           public AppData(string header, int version)
           {
               this.header = header;
               this.version = version;
           }
        }
        
        private static readonly string FilePath = $"{Application.persistentDataPath}/data.save";

        private static BinaryFormatter _binaryFormatter;
        private static BinaryFormatter BinaryFormatter
        {
            get
            {
                if (_binaryFormatter == null)
                {
                    _binaryFormatter = new BinaryFormatter();
                }

                return _binaryFormatter;
            }
        }

        public static bool Load(out AppData result)
        {
            var success = false;
            result = null;
            
            if (File.Exists(FilePath))
            {
                var loadStream = File.Open(FilePath, FileMode.Open, FileAccess.Read);
                result = BinaryFormatter.Deserialize(loadStream) as AppData;
                success = result != null;
                loadStream.Close();
            }

            return success;
        }

        public static void Save(AppData data)
        {
            var saveStream = File.Create(FilePath);
            BinaryFormatter.Serialize(saveStream, data);
            saveStream.Close();
        }
    }
}
