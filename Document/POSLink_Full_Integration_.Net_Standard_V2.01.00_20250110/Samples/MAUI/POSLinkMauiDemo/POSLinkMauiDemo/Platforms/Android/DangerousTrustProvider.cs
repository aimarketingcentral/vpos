/*		
 * ===========================================================================================
 * = COPYRIGHT		                  	
 *          PAX Computer Technology (Shenzhen) Co., Ltd. PROPRIETARY INFORMATION	
 *   This software is supplied under the terms of a license agreement or nondisclosure 	
 *   agreement with PAX Computer Technology (Shenzhen) Co., Ltd. and may not be copied or 
 *   disclosed except in accordance with the terms in that agreement.   		
 *     Copyright (C) 2023 PAX Computer Technology (Shenzhen) Co., Ltd. All rights reserved.
 * ===========================================================================================
 */

using Java.Security;
using Java.Net;
using Javax.Net.Ssl;
using Java.Security.Cert;

namespace POSLinkMauiDemo.Platforms.Android
{
    internal class DangerousTrustProvider : Provider
    {
        private const string TRUST_PROVIDER_ALG = "DangerousTrustAlgorithm";
        private const string TRUST_PROVIDER_ID = "DangerousTrustProvider";

        public DangerousTrustProvider() : base(TRUST_PROVIDER_ID, 1, string.Empty)
        {
            var key = "TrustManagerFactory." + DangerousTrustManagerFactory.GetAlgorithm();
            var val = Java.Lang.Class.FromType(typeof(DangerousTrustManagerFactory)).Name;
            Put(key, val);
        }

        public static void Register()
        {
            Provider registered = Security.GetProvider(TRUST_PROVIDER_ID);
            if (null == registered)
            {
                Security.InsertProviderAt(new DangerousTrustProvider(), 1);
                Security.SetProperty("ssl.TrustManagerFactory.algorithm", TRUST_PROVIDER_ALG);
            }
        }

        public class DangerousTrustManager : X509ExtendedTrustManager
        {
            public override void CheckClientTrusted(X509Certificate[] chain, string authType, Socket socket) { }
            public override void CheckClientTrusted(X509Certificate[] chain, string authType, SSLEngine engine) { }
            public override void CheckClientTrusted(X509Certificate[] chain, string authType) { }
            public override void CheckServerTrusted(X509Certificate[] chain, string authType, Socket socket) { }
            public override void CheckServerTrusted(X509Certificate[] chain, string authType, SSLEngine engine) { }
            public override void CheckServerTrusted(X509Certificate[] chain, string authType) { }
            public override X509Certificate[] GetAcceptedIssuers() => Array.Empty<X509Certificate>();
        }

        public class DangerousTrustManagerFactory : TrustManagerFactorySpi
        {
            protected override void EngineInit(IManagerFactoryParameters mgrparams) { }
            protected override void EngineInit(KeyStore keystore) { }
            protected override ITrustManager[] EngineGetTrustManagers() => new ITrustManager[] { new DangerousTrustManager() };
            public static string GetAlgorithm() => TRUST_PROVIDER_ALG;
        }
    }
}
