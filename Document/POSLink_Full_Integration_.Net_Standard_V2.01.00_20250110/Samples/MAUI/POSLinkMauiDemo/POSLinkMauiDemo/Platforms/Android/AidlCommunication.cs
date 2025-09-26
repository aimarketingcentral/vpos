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

using Android.Content;
using Android.OS;
using POSLinkCore.CommunicationSetting;
using Com.Pax.Us.Pay.Std.Ecr;
using Android.Content.PM;

namespace POSLinkMauiDemo
{
    public class AidlCommunication: AidlSetting
    {
        public AidlConnection AidlConnection { get; set; }

        public AidlCommunication()
        {
            if(AidlConnection == null)
            {
                AidlConnection = new AidlConnection();
            }
        }

        public override string DoTrans(string request)
        {
            string response = "";
            try
            {
                response = AidlConnection.POSLinkBridge.DoTrans(request);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return response;
        }

        public override void AbortTrans()
        {
            AidlConnection.POSLinkBridge.AbortTrans();
        }

        private Intent CreateExplicitFromImplicitIntent(Context context, Intent implicitIntent)
        {
            PackageManager pm = context.PackageManager;

            IList<ResolveInfo> resolveInfo = pm.QueryIntentServices(implicitIntent, 0);
            if (resolveInfo == null)
            {
                return null;
            }

            ResolveInfo serviceInfo = resolveInfo[0];
            string packageName = serviceInfo.ServiceInfo.PackageName;
            PackageName = packageName;
            string className = serviceInfo.ServiceInfo.Name;
            Intent explicitIntent = new Intent(implicitIntent);
            ComponentName component = new ComponentName(packageName, className);
            explicitIntent.SetComponent(component);

            return explicitIntent;
        }

        public void BindRemoteService(Context context)
        {
            Intent intent = new Intent();
            intent.SetAction(AidlSetting.ActionName);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                intent = CreateExplicitFromImplicitIntent(context, intent);
            }

            bool ret = context.BindService(intent, AidlConnection, Bind.AutoCreate);
        }
    }

    public class AidlConnection: Java.Lang.Object, IServiceConnection
    {
        public IPOSLinkBridge POSLinkBridge { get;  set; }

        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            POSLinkBridge = IPOSLinkBridgeStub.AsInterface(service);
        }

        public void OnServiceDisconnected(ComponentName name)
        {
        }
    }
}