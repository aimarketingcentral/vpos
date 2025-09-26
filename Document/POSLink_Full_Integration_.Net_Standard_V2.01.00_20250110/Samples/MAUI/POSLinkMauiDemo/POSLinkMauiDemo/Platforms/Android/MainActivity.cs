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

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Java.Security;
using Javax.Net.Ssl;
using Org.Apache.Http.Conn;
using Org.Apache.Http.Conn.Schemes;
using POSLinkMauiDemo.Platforms.Android;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace POSLinkMauiDemo;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public static AidlCommunication AidlCommunication { get; set; }
    public static UartSetting UartSetting { get; set; }
    private static MainActivity _mainActivity;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        _mainActivity = this;
    }

    public static bool CreateAidl()
    {
        AidlCommunication = new AidlCommunication();
        try
        {
            AidlCommunication.BindRemoteService(_mainActivity);
        }
        catch(Exception)
        {
            return false;
        }
        return true;
    }

    public static void CreateUart()
    {
        UartSetting = new UartSetting(_mainActivity);
    }
}
