using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace MDrop
{
    public abstract class JsonSettings<T> where T : class, new()
    {
        #region save\load
        private const string configFileName = "user.dat";
        private static byte[] s_additionalEntropy = { 14, 18, 72, 63, 57 };

        private static readonly JsonSerializerOptions jsonOpts = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true,

        };
        public void Save()
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes<object>(this,jsonOpts);
            //bytes = ProtectedData.Protect(bytes,s_additionalEntropy,DataProtectionScope.CurrentUser);
            File.WriteAllBytes(configFileName, bytes);
        }

        public static T Load()
        {
            try
            {
                var bytes = File.ReadAllBytes(configFileName);
                // bytes = ProtectedData.Unprotect(bytes, s_additionalEntropy, DataProtectionScope.CurrentUser);
                return JsonSerializer.Deserialize<T>(bytes, jsonOpts);
            }
            catch { return new T(); }
        }
        #endregion
    }
}
