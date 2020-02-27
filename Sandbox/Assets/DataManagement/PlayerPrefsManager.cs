using UnityEngine;

namespace DataManagement
{
    public class PlayerPrefsManager : MonoBehaviour
    {
        private void Awake()
        {
            FilePersister.Save(new FilePersister.AppData("data_header", 1));
        }
        
        private void Start()
        {
            PlayerPrefs.SetFloat("float_key", 5.0f);
            PlayerPrefs.SetInt("int_key", 2);
            PlayerPrefs.SetString("string_key", "string");
            PlayerPrefs.Save();

            if (FilePersister.Load(out var result))
            {
                Debug.Log($"{result.header} {result.version}");
            }
        }
    }
}
