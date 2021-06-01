using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;


namespace TestingPlanner.ResgistryAccess
{
    class RegistryConnection
    {
        /// <summary>
        /// Constructor for the registryConnection Class
        /// </summary>
        public RegistryConnection()
        {

        }

        public void DoEverything()
        {
            // The name of the key is null.
            // The key name exceeds the 255 - character limit.
            // The key is closed.
            // The registry key is read - only.

            // The user does not have permissions to create registry keys.


            // Get software subkey
            RegistryKey softwareRegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);

            // Add new subkey
            RegistryKey barcoKey = softwareRegistryKey.CreateSubKey("VivesBarco");
            barcoKey.SetValue("Test", "Test");
            barcoKey.Close();
            softwareRegistryKey.Close();

        }

        public void SetKey()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Names");
            key.SetValue("Name", "Isabella");
            key.Close();
        }

        public void FindKey()
        {

        }

        private RegistryKey FindSubKey()
        {
            return null;
        }

    }
}
