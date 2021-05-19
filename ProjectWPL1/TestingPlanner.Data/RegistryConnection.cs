using Microsoft.Win32;

namespace TestingPlanner.Data
{
    /// <summary>
    /// Gets all values from a registry key and stores them in an object
    /// Kaat
    /// </summary>
    public class RegistryConnection
    {
        // String that stores the program subkey with subkeys containing our values
        private readonly string _mainSubkeyPath;

        /// <summary>
        /// Constructor for the RegistryConnection class
        /// </summary>
        /// <param name="mainSubkeyPath">Relative subkey path within the Current User Key</param>
        public RegistryConnection(string mainSubkeyPath)
        {
            _mainSubkeyPath = mainSubkeyPath;
        }

        /// <summary>
        /// Gets all values from a subkey and stores them in an object
        /// </summary>
        /// <typeparam name="T">Type that is capable of storing the requested values</typeparam>
        /// <param name="subkeyName">Name of the subkey storing the requested values</param>
        /// <returns></returns>
        public T GetValueObject<T>(string subkeyName) where T : new()
        {
            var storage = new T();

            using (RegistryKey mainKey = Registry.CurrentUser.OpenSubKey(_mainSubkeyPath))
            {
                using (RegistryKey valueKey = mainKey.OpenSubKey(subkeyName))
                {
                    foreach (var property in typeof(T).GetProperties())
                    {
                        property.SetValue(storage, valueKey.GetValue(property.Name));
                    }
                }
            }

            return storage;
        }

    }
}
