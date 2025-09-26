POSLinkMauiDemo：
1. This demo is a net7.0 MAUI demo. The MainPage is in MainPage.xaml.cs.
2. This demo contain Android TCP, SSL, AIDL and UART. And contain Windows TCP, SSL. Not contains iOS now.
3. POSLinkBridge.aidl: It is used to define the AIDL interface. Build Action: AndroidInterfaceDescription.
4. GlCommBinding.aar and GlCommBinding.dll: The dependence of Android UART.
5. Add permission in AndroidManifest.xml for communication and write log file:
<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
<uses-permission android:name="android.permission.INTERNET" />
<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
6. This demo write log file to Storage path, so it also need to dynamically apply for permissions when running the program:

    PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
    if (status == PermissionStatus.Denied)
    {
        status = await Permissions.RequestAsync<Permissions.StorageWrite>();
    }

7. When encounter SSL Authentication failed exception, you need to disable server certificate validation on Android:
Create DangerousTrustProvider.cs like demo and add this to MauiProgram.cs:

    #if ANDROID && DEBUG
        Platforms.Android.DangerousTrustProvider.Register();
    #endif
-------------------------------------------------------------------------------------------------------------------------------------------------------------

GlCommBinding：
1. This projcet is used to build GlCommBinding.aar and GlCommBinding.dll for Android UART communication.
2. It depends on GLComm_V1.11.00_20221102.jar. When add GLComm_V1.11.00_20221102.jar, it's Build Action should be AndroidLibrary. Other dependencies's Build Action should be AndroidNativeLibrary.
3. When build it will prompt some errors because the Android code structure has some different with .NET. Such as:

error CS0111: Type 'IServer.ErrorEventArgs' already defines a member called 'ErrorEventArgs' with the same parameter types
error CS0111: Type 'IServer.ErrorEventArgs' already defines a member called 'ErrorEventArgs' with the same parameter types
error CS0102: The type 'IServer.ErrorEventArgs' already contains a definition for 'p0'
error CS0102: The type 'IServer.ErrorEventArgs' already contains a definition for 'p0'
error CS0102: The type 'IServer.ErrorEventArgs' already contains a definition for 'P0'
error CS0102: The type 'IServer.ErrorEventArgs' already contains a definition for 'P0'
error CS0102: The type 'IServer.PeerConnectedEventArgs' already contains a definition for 'p0'
error CS0102: The type 'IServer.PeerConnectedEventArgs' already contains a definition for 'p0'
error CS0102: The type 'IServer.PeerConnectedEventArgs' already contains a definition for 'P0'
error CS0102: The type 'IServer.PeerConnectedEventArgs' already contains a definition for 'P0'
error CS0102: The type 'IServer.PeerConnectedEventArgs' already contains a definition for 'p1'
error CS0102: The type 'IServer.PeerConnectedEventArgs' already contains a definition for 'p1'
error CS0102: The type 'IServer.PeerConnectedEventArgs' already contains a definition for 'P1'
error CS0102: The type 'IServer.PeerConnectedEventArgs' already contains a definition for 'P1'

Please copy the Com.Pax.GL.Commhelper.IServer.cs which in ChangeData folder to replace GlCommBinding\obj\Release\net7.0-android\generated\src\Com.Pax.GL.Commhelper.IServer.cs. 
If you want use other version GLComm.jar, you can remove the definitions or change other's names just like ChangeData\Com.Pax.GL.Commhelper.IServer.cs do.
-------------------------------------------------------------------------------------------------------------------------------------------------------------