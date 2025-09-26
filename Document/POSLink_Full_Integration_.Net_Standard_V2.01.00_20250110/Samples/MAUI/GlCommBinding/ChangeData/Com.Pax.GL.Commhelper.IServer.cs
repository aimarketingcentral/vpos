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

using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Com.Pax.GL.Commhelper {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer']"
	[Register ("com/pax/gl/commhelper/IServer", "", "Com.Pax.GL.Commhelper.IServerInvoker")]
	public partial interface IServer : IJavaObject, IJavaPeerable {
		// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer']/method[@name='start' and count(parameter)=0]"
		[Register ("start", "()V", "GetStartHandler:Com.Pax.GL.Commhelper.IServerInvoker, GlCommBinding")]
		void Start ();

		// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer']/method[@name='stop' and count(parameter)=0]"
		[Register ("stop", "()V", "GetStopHandler:Com.Pax.GL.Commhelper.IServerInvoker, GlCommBinding")]
		void Stop ();

		// Metadata.xml XPath class reference: path="/api/package[@name='com.pax.gl.commhelper']/class[@name='IServer.EServerError']"
		[global::Android.Runtime.Register ("com/pax/gl/commhelper/IServer$EServerError", DoNotGenerateAcw=true)]
		public sealed partial class EServerError : global::Java.Lang.Enum {

			// Metadata.xml XPath field reference: path="/api/package[@name='com.pax.gl.commhelper']/class[@name='IServer.EServerError']/field[@name='ERROR_COMMON']"
			[Register ("ERROR_COMMON")]
			public static global::Com.Pax.GL.Commhelper.IServer.EServerError? ErrorCommon {
				get {
					const string __id = "ERROR_COMMON.Lcom/pax/gl/commhelper/IServer$EServerError;";

					var __v = _members.StaticFields.GetObjectValue (__id);
					return global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.EServerError> (__v.Handle, JniHandleOwnership.TransferLocalRef);
				}
			}


			// Metadata.xml XPath field reference: path="/api/package[@name='com.pax.gl.commhelper']/class[@name='IServer.EServerError']/field[@name='ERROR_IS_RUNNING']"
			[Register ("ERROR_IS_RUNNING")]
			public static global::Com.Pax.GL.Commhelper.IServer.EServerError? ErrorIsRunning {
				get {
					const string __id = "ERROR_IS_RUNNING.Lcom/pax/gl/commhelper/IServer$EServerError;";

					var __v = _members.StaticFields.GetObjectValue (__id);
					return global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.EServerError> (__v.Handle, JniHandleOwnership.TransferLocalRef);
				}
			}


			// Metadata.xml XPath field reference: path="/api/package[@name='com.pax.gl.commhelper']/class[@name='IServer.EServerError']/field[@name='ERROR_IS_SHUTTING_DOWN']"
			[Register ("ERROR_IS_SHUTTING_DOWN")]
			public static global::Com.Pax.GL.Commhelper.IServer.EServerError? ErrorIsShuttingDown {
				get {
					const string __id = "ERROR_IS_SHUTTING_DOWN.Lcom/pax/gl/commhelper/IServer$EServerError;";

					var __v = _members.StaticFields.GetObjectValue (__id);
					return global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.EServerError> (__v.Handle, JniHandleOwnership.TransferLocalRef);
				}
			}


			// Metadata.xml XPath field reference: path="/api/package[@name='com.pax.gl.commhelper']/class[@name='IServer.EServerError']/field[@name='ERROR_LISTENING']"
			[Register ("ERROR_LISTENING")]
			public static global::Com.Pax.GL.Commhelper.IServer.EServerError? ErrorListening {
				get {
					const string __id = "ERROR_LISTENING.Lcom/pax/gl/commhelper/IServer$EServerError;";

					var __v = _members.StaticFields.GetObjectValue (__id);
					return global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.EServerError> (__v.Handle, JniHandleOwnership.TransferLocalRef);
				}
			}


			// Metadata.xml XPath field reference: path="/api/package[@name='com.pax.gl.commhelper']/class[@name='IServer.EServerError']/field[@name='ERROR_MAX_CONNECTION']"
			[Register ("ERROR_MAX_CONNECTION")]
			public static global::Com.Pax.GL.Commhelper.IServer.EServerError? ErrorMaxConnection {
				get {
					const string __id = "ERROR_MAX_CONNECTION.Lcom/pax/gl/commhelper/IServer$EServerError;";

					var __v = _members.StaticFields.GetObjectValue (__id);
					return global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.EServerError> (__v.Handle, JniHandleOwnership.TransferLocalRef);
				}
			}


			// Metadata.xml XPath field reference: path="/api/package[@name='com.pax.gl.commhelper']/class[@name='IServer.EServerError']/field[@name='ERROR_PARAM']"
			[Register ("ERROR_PARAM")]
			public static global::Com.Pax.GL.Commhelper.IServer.EServerError? ErrorParam {
				get {
					const string __id = "ERROR_PARAM.Lcom/pax/gl/commhelper/IServer$EServerError;";

					var __v = _members.StaticFields.GetObjectValue (__id);
					return global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.EServerError> (__v.Handle, JniHandleOwnership.TransferLocalRef);
				}
			}


			// Metadata.xml XPath field reference: path="/api/package[@name='com.pax.gl.commhelper']/class[@name='IServer.EServerError']/field[@name='ERR_START']"
			[Register ("ERR_START")]
			public static global::Com.Pax.GL.Commhelper.IServer.EServerError? ErrStart {
				get {
					const string __id = "ERR_START.Lcom/pax/gl/commhelper/IServer$EServerError;";

					var __v = _members.StaticFields.GetObjectValue (__id);
					return global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.EServerError> (__v.Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			static readonly JniPeerMembers _members = new XAPeerMembers ("com/pax/gl/commhelper/IServer$EServerError", typeof (EServerError));

			internal static IntPtr class_ref {
				get { return _members.JniPeerType.PeerReference.Handle; }
			}

			[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
			[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
			public override global::Java.Interop.JniPeerMembers JniPeerMembers {
				get { return _members; }
			}

			[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
			[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass {
				get { return _members.JniPeerType.PeerReference.Handle; }
			}

			[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
			[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
			protected override global::System.Type ThresholdType {
				get { return _members.ManagedPeerType; }
			}

			internal EServerError (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer)
			{
			}

			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/class[@name='IServer.EServerError']/method[@name='valueOf' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("valueOf", "(Ljava/lang/String;)Lcom/pax/gl/commhelper/IServer$EServerError;", "")]
			public static unsafe global::Com.Pax.GL.Commhelper.IServer.EServerError? ValueOf (string? name)
			{
				const string __id = "valueOf.(Ljava/lang/String;)Lcom/pax/gl/commhelper/IServer$EServerError;";
				IntPtr native_name = JNIEnv.NewString ((string?)name);
				try {
					JniArgumentValue* __args = stackalloc JniArgumentValue [1];
					__args [0] = new JniArgumentValue (native_name);
					var __rm = _members.StaticMethods.InvokeObjectMethod (__id, __args);
					return global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.EServerError> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
				} finally {
					JNIEnv.DeleteLocalRef (native_name);
				}
			}

			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/class[@name='IServer.EServerError']/method[@name='values' and count(parameter)=0]"
			[Register ("values", "()[Lcom/pax/gl/commhelper/IServer$EServerError;", "")]
			public static unsafe global::Com.Pax.GL.Commhelper.IServer.EServerError[]? Values ()
			{
				const string __id = "values.()[Lcom/pax/gl/commhelper/IServer$EServerError;";
				try {
					var __rm = _members.StaticMethods.InvokeObjectMethod (__id, null);
					return (global::Com.Pax.GL.Commhelper.IServer.EServerError[]?) JNIEnv.GetArray (__rm.Handle, JniHandleOwnership.TransferLocalRef, typeof (global::Com.Pax.GL.Commhelper.IServer.EServerError));
				} finally {
				}
			}

		}

		// Metadata.xml XPath interface reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.IBleServerListener']"
		[Register ("com/pax/gl/commhelper/IServer$IBleServerListener", "", "Com.Pax.GL.Commhelper.IServer/IBleServerListenerInvoker")]
		public partial interface IBleServerListener : IJavaObject, IJavaPeerable {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.IBleServerListener']/method[@name='onError' and count(parameter)=1 and parameter[1][@type='com.pax.gl.commhelper.IServer.EServerError']]"
			[Register ("onError", "(Lcom/pax/gl/commhelper/IServer$EServerError;)V", "GetOnError_Lcom_pax_gl_commhelper_IServer_EServerError_Handler:Com.Pax.GL.Commhelper.IServer/IBleServerListenerInvoker, GlCommBinding")]
			void OnError (global::Com.Pax.GL.Commhelper.IServer.EServerError? p0);

			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.IBleServerListener']/method[@name='onPeerConnected' and count(parameter)=3 and parameter[1][@type='com.pax.gl.commhelper.IComm'] and parameter[2][@type='android.bluetooth.BluetoothGattServer'] and parameter[3][@type='android.bluetooth.BluetoothDevice']]"
			[Register ("onPeerConnected", "(Lcom/pax/gl/commhelper/IComm;Landroid/bluetooth/BluetoothGattServer;Landroid/bluetooth/BluetoothDevice;)V", "GetOnPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_Handler:Com.Pax.GL.Commhelper.IServer/IBleServerListenerInvoker, GlCommBinding")]
			void OnPeerConnected (global::Com.Pax.GL.Commhelper.IComm? p0, global::Android.Bluetooth.BluetoothGattServer? p1, global::Android.Bluetooth.BluetoothDevice? p2);

			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.IBleServerListener']/method[@name='onPeerDisconnected' and count(parameter)=3 and parameter[1][@type='com.pax.gl.commhelper.IComm'] and parameter[2][@type='android.bluetooth.BluetoothGattServer'] and parameter[3][@type='android.bluetooth.BluetoothDevice']]"
			[Register ("onPeerDisconnected", "(Lcom/pax/gl/commhelper/IComm;Landroid/bluetooth/BluetoothGattServer;Landroid/bluetooth/BluetoothDevice;)V", "GetOnPeerDisconnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_Handler:Com.Pax.GL.Commhelper.IServer/IBleServerListenerInvoker, GlCommBinding")]
			void OnPeerDisconnected (global::Com.Pax.GL.Commhelper.IComm? p0, global::Android.Bluetooth.BluetoothGattServer? p1, global::Android.Bluetooth.BluetoothDevice? p2);

			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.IBleServerListener']/method[@name='onShuttingDown' and count(parameter)=0]"
			[Register ("onShuttingDown", "()V", "GetOnShuttingDownHandler:Com.Pax.GL.Commhelper.IServer/IBleServerListenerInvoker, GlCommBinding")]
			void OnShuttingDown ();

			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.IBleServerListener']/method[@name='onStarted' and count(parameter)=0]"
			[Register ("onStarted", "()V", "GetOnStartedHandler:Com.Pax.GL.Commhelper.IServer/IBleServerListenerInvoker, GlCommBinding")]
			void OnStarted ();

			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.IBleServerListener']/method[@name='onStopped' and count(parameter)=0]"
			[Register ("onStopped", "()V", "GetOnStoppedHandler:Com.Pax.GL.Commhelper.IServer/IBleServerListenerInvoker, GlCommBinding")]
			void OnStopped ();

		}

		[global::Android.Runtime.Register ("com/pax/gl/commhelper/IServer$IBleServerListener", DoNotGenerateAcw=true)]
		internal partial class IBleServerListenerInvoker : global::Java.Lang.Object, IBleServerListener {
			static readonly JniPeerMembers _members = new XAPeerMembers ("com/pax/gl/commhelper/IServer$IBleServerListener", typeof (IBleServerListenerInvoker));

			static IntPtr java_class_ref {
				get { return _members.JniPeerType.PeerReference.Handle; }
			}

			[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
			[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
			public override global::Java.Interop.JniPeerMembers JniPeerMembers {
				get { return _members; }
			}

			[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
			[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
			[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
			protected override global::System.Type ThresholdType {
				get { return _members.ManagedPeerType; }
			}

			IntPtr class_ref;

			public static IBleServerListener? GetObject (IntPtr handle, JniHandleOwnership transfer)
			{
				return global::Java.Lang.Object.GetObject<IBleServerListener> (handle, transfer);
			}

			static IntPtr Validate (IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
					throw new InvalidCastException ($"Unable to convert instance of type '{JNIEnv.GetClassNameFromInstance (handle)}' to type 'com.pax.gl.commhelper.IServer.IBleServerListener'.");
				return handle;
			}

			protected override void Dispose (bool disposing)
			{
				if (this.class_ref != IntPtr.Zero)
					JNIEnv.DeleteGlobalRef (this.class_ref);
				this.class_ref = IntPtr.Zero;
				base.Dispose (disposing);
			}

			public IBleServerListenerInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
			{
				IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
				this.class_ref = JNIEnv.NewGlobalRef (local_ref);
				JNIEnv.DeleteLocalRef (local_ref);
			}

			static Delegate? cb_onError_Lcom_pax_gl_commhelper_IServer_EServerError_;
#pragma warning disable 0169
			static Delegate GetOnError_Lcom_pax_gl_commhelper_IServer_EServerError_Handler ()
			{
				if (cb_onError_Lcom_pax_gl_commhelper_IServer_EServerError_ == null)
					cb_onError_Lcom_pax_gl_commhelper_IServer_EServerError_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_OnError_Lcom_pax_gl_commhelper_IServer_EServerError_);
				return cb_onError_Lcom_pax_gl_commhelper_IServer_EServerError_;
			}

			static void n_OnError_Lcom_pax_gl_commhelper_IServer_EServerError_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.IBleServerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
				var p0 = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.EServerError> (native_p0, JniHandleOwnership.DoNotTransfer);
				__this.OnError (p0);
			}
#pragma warning restore 0169

			IntPtr id_onError_Lcom_pax_gl_commhelper_IServer_EServerError_;
			public unsafe void OnError (global::Com.Pax.GL.Commhelper.IServer.EServerError? p0)
			{
				if (id_onError_Lcom_pax_gl_commhelper_IServer_EServerError_ == IntPtr.Zero)
					id_onError_Lcom_pax_gl_commhelper_IServer_EServerError_ = JNIEnv.GetMethodID (class_ref, "onError", "(Lcom/pax/gl/commhelper/IServer$EServerError;)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onError_Lcom_pax_gl_commhelper_IServer_EServerError_, __args);
			}

			static Delegate? cb_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_;
#pragma warning disable 0169
			static Delegate GetOnPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_Handler ()
			{
				if (cb_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_ == null)
					cb_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPLLL_V) n_OnPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_);
				return cb_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_;
			}

			static void n_OnPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.IBleServerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
				var p0 = (global::Com.Pax.GL.Commhelper.IComm?)global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IComm> (native_p0, JniHandleOwnership.DoNotTransfer);
				var p1 = global::Java.Lang.Object.GetObject<global::Android.Bluetooth.BluetoothGattServer> (native_p1, JniHandleOwnership.DoNotTransfer);
				var p2 = global::Java.Lang.Object.GetObject<global::Android.Bluetooth.BluetoothDevice> (native_p2, JniHandleOwnership.DoNotTransfer);
				__this.OnPeerConnected (p0, p1, p2);
			}
#pragma warning restore 0169

			IntPtr id_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_;
			public unsafe void OnPeerConnected (global::Com.Pax.GL.Commhelper.IComm? p0, global::Android.Bluetooth.BluetoothGattServer? p1, global::Android.Bluetooth.BluetoothDevice? p2)
			{
				if (id_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_ == IntPtr.Zero)
					id_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_ = JNIEnv.GetMethodID (class_ref, "onPeerConnected", "(Lcom/pax/gl/commhelper/IComm;Landroid/bluetooth/BluetoothGattServer;Landroid/bluetooth/BluetoothDevice;)V");
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
				__args [1] = new JValue ((p1 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p1).Handle);
				__args [2] = new JValue ((p2 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p2).Handle);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_, __args);
			}

			static Delegate? cb_onPeerDisconnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_;
#pragma warning disable 0169
			static Delegate GetOnPeerDisconnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_Handler ()
			{
				if (cb_onPeerDisconnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_ == null)
					cb_onPeerDisconnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPLLL_V) n_OnPeerDisconnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_);
				return cb_onPeerDisconnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_;
			}

			static void n_OnPeerDisconnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.IBleServerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
				var p0 = (global::Com.Pax.GL.Commhelper.IComm?)global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IComm> (native_p0, JniHandleOwnership.DoNotTransfer);
				var p1 = global::Java.Lang.Object.GetObject<global::Android.Bluetooth.BluetoothGattServer> (native_p1, JniHandleOwnership.DoNotTransfer);
				var p2 = global::Java.Lang.Object.GetObject<global::Android.Bluetooth.BluetoothDevice> (native_p2, JniHandleOwnership.DoNotTransfer);
				__this.OnPeerDisconnected (p0, p1, p2);
			}
#pragma warning restore 0169

			IntPtr id_onPeerDisconnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_;
			public unsafe void OnPeerDisconnected (global::Com.Pax.GL.Commhelper.IComm? p0, global::Android.Bluetooth.BluetoothGattServer? p1, global::Android.Bluetooth.BluetoothDevice? p2)
			{
				if (id_onPeerDisconnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_ == IntPtr.Zero)
					id_onPeerDisconnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_ = JNIEnv.GetMethodID (class_ref, "onPeerDisconnected", "(Lcom/pax/gl/commhelper/IComm;Landroid/bluetooth/BluetoothGattServer;Landroid/bluetooth/BluetoothDevice;)V");
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
				__args [1] = new JValue ((p1 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p1).Handle);
				__args [2] = new JValue ((p2 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p2).Handle);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onPeerDisconnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothGattServer_Landroid_bluetooth_BluetoothDevice_, __args);
			}

			static Delegate? cb_onShuttingDown;
#pragma warning disable 0169
			static Delegate GetOnShuttingDownHandler ()
			{
				if (cb_onShuttingDown == null)
					cb_onShuttingDown = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_OnShuttingDown);
				return cb_onShuttingDown;
			}

			static void n_OnShuttingDown (IntPtr jnienv, IntPtr native__this)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.IBleServerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
				__this.OnShuttingDown ();
			}
#pragma warning restore 0169

			IntPtr id_onShuttingDown;
			public unsafe void OnShuttingDown ()
			{
				if (id_onShuttingDown == IntPtr.Zero)
					id_onShuttingDown = JNIEnv.GetMethodID (class_ref, "onShuttingDown", "()V");
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onShuttingDown);
			}

			static Delegate? cb_onStarted;
#pragma warning disable 0169
			static Delegate GetOnStartedHandler ()
			{
				if (cb_onStarted == null)
					cb_onStarted = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_OnStarted);
				return cb_onStarted;
			}

			static void n_OnStarted (IntPtr jnienv, IntPtr native__this)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.IBleServerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
				__this.OnStarted ();
			}
#pragma warning restore 0169

			IntPtr id_onStarted;
			public unsafe void OnStarted ()
			{
				if (id_onStarted == IntPtr.Zero)
					id_onStarted = JNIEnv.GetMethodID (class_ref, "onStarted", "()V");
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onStarted);
			}

			static Delegate? cb_onStopped;
#pragma warning disable 0169
			static Delegate GetOnStoppedHandler ()
			{
				if (cb_onStopped == null)
					cb_onStopped = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_OnStopped);
				return cb_onStopped;
			}

			static void n_OnStopped (IntPtr jnienv, IntPtr native__this)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.IBleServerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
				__this.OnStopped ();
			}
#pragma warning restore 0169

			IntPtr id_onStopped;
			public unsafe void OnStopped ()
			{
				if (id_onStopped == IntPtr.Zero)
					id_onStopped = JNIEnv.GetMethodID (class_ref, "onStopped", "()V");
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onStopped);
			}

		}

		// event args for com.pax.gl.commhelper.IServer.IBleServerListener.onError
		public partial class ErrorEventArgs : global::System.EventArgs {
			public ErrorEventArgs (global::Com.Pax.GL.Commhelper.IServer.EServerError? p0)
			{
				this.p0 = p0;
			}

			global::Com.Pax.GL.Commhelper.IServer.EServerError? p0;

			public global::Com.Pax.GL.Commhelper.IServer.EServerError? P0 {
				get { return p0; }
			}

		}

		// event args for com.pax.gl.commhelper.IServer.IBleServerListener.onPeerConnected
		public partial class PeerConnectedEventArgs : global::System.EventArgs {
			public PeerConnectedEventArgs (global::Com.Pax.GL.Commhelper.IComm? p0, global::Android.Bluetooth.BluetoothGattServer? p1, global::Android.Bluetooth.BluetoothDevice? p2)
			{
				this.p0 = p0;
				this.p1 = p1;
				this.p2 = p2;
			}

			global::Com.Pax.GL.Commhelper.IComm? p0;

			public global::Com.Pax.GL.Commhelper.IComm? P0 {
				get { return p0; }
			}

			global::Android.Bluetooth.BluetoothGattServer? p1;

			public global::Android.Bluetooth.BluetoothGattServer? P1 {
				get { return p1; }
			}

			global::Android.Bluetooth.BluetoothDevice? p2;

			public global::Android.Bluetooth.BluetoothDevice? P2 {
				get { return p2; }
			}

		}

		// event args for com.pax.gl.commhelper.IServer.IBleServerListener.onPeerDisconnected
		public partial class PeerDisconnectedEventArgs : global::System.EventArgs {
			public PeerDisconnectedEventArgs (global::Com.Pax.GL.Commhelper.IComm? p0, global::Android.Bluetooth.BluetoothGattServer? p1, global::Android.Bluetooth.BluetoothDevice? p2)
			{
				this.p0 = p0;
				this.p1 = p1;
				this.p2 = p2;
			}

			global::Com.Pax.GL.Commhelper.IComm? p0;

			public global::Com.Pax.GL.Commhelper.IComm? P0 {
				get { return p0; }
			}

			global::Android.Bluetooth.BluetoothGattServer? p1;

			public global::Android.Bluetooth.BluetoothGattServer? P1 {
				get { return p1; }
			}

			global::Android.Bluetooth.BluetoothDevice? p2;

			public global::Android.Bluetooth.BluetoothDevice? P2 {
				get { return p2; }
			}

		}

		[global::Android.Runtime.Register ("mono/com/pax/gl/commhelper/IServer_IBleServerListenerImplementor")]
		internal sealed partial class IBleServerListenerImplementor : global::Java.Lang.Object, IBleServerListener {

			object sender;

			public IBleServerListenerImplementor (object sender) : base (global::Android.Runtime.JNIEnv.StartCreateInstance ("mono/com/pax/gl/commhelper/IServer_IBleServerListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "()V");
				this.sender = sender;
			}

			#pragma warning disable 0649
			public EventHandler<ErrorEventArgs>? OnErrorHandler;
			#pragma warning restore 0649

			public void OnError (global::Com.Pax.GL.Commhelper.IServer.EServerError? p0)
			{
				var __h = OnErrorHandler;
				if (__h != null)
					__h (sender, new ErrorEventArgs (p0));
			}

			#pragma warning disable 0649
			public EventHandler<PeerConnectedEventArgs>? OnPeerConnectedHandler;
			#pragma warning restore 0649

			public void OnPeerConnected (global::Com.Pax.GL.Commhelper.IComm? p0, global::Android.Bluetooth.BluetoothGattServer? p1, global::Android.Bluetooth.BluetoothDevice? p2)
			{
				var __h = OnPeerConnectedHandler;
				if (__h != null)
					__h (sender, new PeerConnectedEventArgs (p0, p1, p2));
			}

			#pragma warning disable 0649
			public EventHandler<PeerDisconnectedEventArgs>? OnPeerDisconnectedHandler;
			#pragma warning restore 0649

			public void OnPeerDisconnected (global::Com.Pax.GL.Commhelper.IComm? p0, global::Android.Bluetooth.BluetoothGattServer? p1, global::Android.Bluetooth.BluetoothDevice? p2)
			{
				var __h = OnPeerDisconnectedHandler;
				if (__h != null)
					__h (sender, new PeerDisconnectedEventArgs (p0, p1, p2));
			}

			#pragma warning disable 0649
			public EventHandler? OnShuttingDownHandler;
			#pragma warning restore 0649

			public void OnShuttingDown ()
			{
				var __h = OnShuttingDownHandler;
				if (__h != null)
					__h (sender, new EventArgs ());
			}

			#pragma warning disable 0649
			public EventHandler? OnStartedHandler;
			#pragma warning restore 0649

			public void OnStarted ()
			{
				var __h = OnStartedHandler;
				if (__h != null)
					__h (sender, new EventArgs ());
			}

			#pragma warning disable 0649
			public EventHandler? OnStoppedHandler;
			#pragma warning restore 0649

			public void OnStopped ()
			{
				var __h = OnStoppedHandler;
				if (__h != null)
					__h (sender, new EventArgs ());
			}

			internal static bool __IsEmpty (IBleServerListenerImplementor value)
			{
				return value.OnErrorHandler == null && value.OnPeerConnectedHandler == null && value.OnPeerDisconnectedHandler == null && value.OnShuttingDownHandler == null && value.OnStartedHandler == null && value.OnStoppedHandler == null;
			}

		}

		// Metadata.xml XPath interface reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.IBtServerListener']"
		[Register ("com/pax/gl/commhelper/IServer$IBtServerListener", "", "Com.Pax.GL.Commhelper.IServer/IBtServerListenerInvoker")]
		public partial interface IBtServerListener : IJavaObject, IJavaPeerable {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.IBtServerListener']/method[@name='onError' and count(parameter)=1 and parameter[1][@type='com.pax.gl.commhelper.IServer.EServerError']]"
			[Register ("onError", "(Lcom/pax/gl/commhelper/IServer$EServerError;)V", "GetOnError_Lcom_pax_gl_commhelper_IServer_EServerError_Handler:Com.Pax.GL.Commhelper.IServer/IBtServerListenerInvoker, GlCommBinding")]
			void OnError (global::Com.Pax.GL.Commhelper.IServer.EServerError? p0);

			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.IBtServerListener']/method[@name='onPeerConnected' and count(parameter)=2 and parameter[1][@type='com.pax.gl.commhelper.IComm'] and parameter[2][@type='android.bluetooth.BluetoothSocket']]"
			[Register ("onPeerConnected", "(Lcom/pax/gl/commhelper/IComm;Landroid/bluetooth/BluetoothSocket;)V", "GetOnPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothSocket_Handler:Com.Pax.GL.Commhelper.IServer/IBtServerListenerInvoker, GlCommBinding")]
			void OnPeerConnected (global::Com.Pax.GL.Commhelper.IComm? p0, global::Android.Bluetooth.BluetoothSocket? p1);

			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.IBtServerListener']/method[@name='onShuttingDown' and count(parameter)=0]"
			[Register ("onShuttingDown", "()V", "GetOnShuttingDownHandler:Com.Pax.GL.Commhelper.IServer/IBtServerListenerInvoker, GlCommBinding")]
			void OnShuttingDown ();

			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.IBtServerListener']/method[@name='onStarted' and count(parameter)=0]"
			[Register ("onStarted", "()V", "GetOnStartedHandler:Com.Pax.GL.Commhelper.IServer/IBtServerListenerInvoker, GlCommBinding")]
			void OnStarted ();

			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.IBtServerListener']/method[@name='onStopped' and count(parameter)=0]"
			[Register ("onStopped", "()V", "GetOnStoppedHandler:Com.Pax.GL.Commhelper.IServer/IBtServerListenerInvoker, GlCommBinding")]
			void OnStopped ();

		}

		[global::Android.Runtime.Register ("com/pax/gl/commhelper/IServer$IBtServerListener", DoNotGenerateAcw=true)]
		internal partial class IBtServerListenerInvoker : global::Java.Lang.Object, IBtServerListener {
			static readonly JniPeerMembers _members = new XAPeerMembers ("com/pax/gl/commhelper/IServer$IBtServerListener", typeof (IBtServerListenerInvoker));

			static IntPtr java_class_ref {
				get { return _members.JniPeerType.PeerReference.Handle; }
			}

			[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
			[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
			public override global::Java.Interop.JniPeerMembers JniPeerMembers {
				get { return _members; }
			}

			[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
			[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
			[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
			protected override global::System.Type ThresholdType {
				get { return _members.ManagedPeerType; }
			}

			IntPtr class_ref;

			public static IBtServerListener? GetObject (IntPtr handle, JniHandleOwnership transfer)
			{
				return global::Java.Lang.Object.GetObject<IBtServerListener> (handle, transfer);
			}

			static IntPtr Validate (IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
					throw new InvalidCastException ($"Unable to convert instance of type '{JNIEnv.GetClassNameFromInstance (handle)}' to type 'com.pax.gl.commhelper.IServer.IBtServerListener'.");
				return handle;
			}

			protected override void Dispose (bool disposing)
			{
				if (this.class_ref != IntPtr.Zero)
					JNIEnv.DeleteGlobalRef (this.class_ref);
				this.class_ref = IntPtr.Zero;
				base.Dispose (disposing);
			}

			public IBtServerListenerInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
			{
				IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
				this.class_ref = JNIEnv.NewGlobalRef (local_ref);
				JNIEnv.DeleteLocalRef (local_ref);
			}

			static Delegate? cb_onError_Lcom_pax_gl_commhelper_IServer_EServerError_;
#pragma warning disable 0169
			static Delegate GetOnError_Lcom_pax_gl_commhelper_IServer_EServerError_Handler ()
			{
				if (cb_onError_Lcom_pax_gl_commhelper_IServer_EServerError_ == null)
					cb_onError_Lcom_pax_gl_commhelper_IServer_EServerError_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_OnError_Lcom_pax_gl_commhelper_IServer_EServerError_);
				return cb_onError_Lcom_pax_gl_commhelper_IServer_EServerError_;
			}

			static void n_OnError_Lcom_pax_gl_commhelper_IServer_EServerError_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.IBtServerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
				var p0 = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.EServerError> (native_p0, JniHandleOwnership.DoNotTransfer);
				__this.OnError (p0);
			}
#pragma warning restore 0169

			IntPtr id_onError_Lcom_pax_gl_commhelper_IServer_EServerError_;
			public unsafe void OnError (global::Com.Pax.GL.Commhelper.IServer.EServerError? p0)
			{
				if (id_onError_Lcom_pax_gl_commhelper_IServer_EServerError_ == IntPtr.Zero)
					id_onError_Lcom_pax_gl_commhelper_IServer_EServerError_ = JNIEnv.GetMethodID (class_ref, "onError", "(Lcom/pax/gl/commhelper/IServer$EServerError;)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onError_Lcom_pax_gl_commhelper_IServer_EServerError_, __args);
			}

			static Delegate? cb_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothSocket_;
#pragma warning disable 0169
			static Delegate GetOnPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothSocket_Handler ()
			{
				if (cb_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothSocket_ == null)
					cb_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothSocket_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPLL_V) n_OnPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothSocket_);
				return cb_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothSocket_;
			}

			static void n_OnPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothSocket_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.IBtServerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
				var p0 = (global::Com.Pax.GL.Commhelper.IComm?)global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IComm> (native_p0, JniHandleOwnership.DoNotTransfer);
				var p1 = global::Java.Lang.Object.GetObject<global::Android.Bluetooth.BluetoothSocket> (native_p1, JniHandleOwnership.DoNotTransfer);
				__this.OnPeerConnected (p0, p1);
			}
#pragma warning restore 0169

			IntPtr id_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothSocket_;
			public unsafe void OnPeerConnected (global::Com.Pax.GL.Commhelper.IComm? p0, global::Android.Bluetooth.BluetoothSocket? p1)
			{
				if (id_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothSocket_ == IntPtr.Zero)
					id_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothSocket_ = JNIEnv.GetMethodID (class_ref, "onPeerConnected", "(Lcom/pax/gl/commhelper/IComm;Landroid/bluetooth/BluetoothSocket;)V");
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
				__args [1] = new JValue ((p1 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p1).Handle);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Landroid_bluetooth_BluetoothSocket_, __args);
			}

			static Delegate? cb_onShuttingDown;
#pragma warning disable 0169
			static Delegate GetOnShuttingDownHandler ()
			{
				if (cb_onShuttingDown == null)
					cb_onShuttingDown = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_OnShuttingDown);
				return cb_onShuttingDown;
			}

			static void n_OnShuttingDown (IntPtr jnienv, IntPtr native__this)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.IBtServerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
				__this.OnShuttingDown ();
			}
#pragma warning restore 0169

			IntPtr id_onShuttingDown;
			public unsafe void OnShuttingDown ()
			{
				if (id_onShuttingDown == IntPtr.Zero)
					id_onShuttingDown = JNIEnv.GetMethodID (class_ref, "onShuttingDown", "()V");
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onShuttingDown);
			}

			static Delegate? cb_onStarted;
#pragma warning disable 0169
			static Delegate GetOnStartedHandler ()
			{
				if (cb_onStarted == null)
					cb_onStarted = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_OnStarted);
				return cb_onStarted;
			}

			static void n_OnStarted (IntPtr jnienv, IntPtr native__this)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.IBtServerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
				__this.OnStarted ();
			}
#pragma warning restore 0169

			IntPtr id_onStarted;
			public unsafe void OnStarted ()
			{
				if (id_onStarted == IntPtr.Zero)
					id_onStarted = JNIEnv.GetMethodID (class_ref, "onStarted", "()V");
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onStarted);
			}

			static Delegate? cb_onStopped;
#pragma warning disable 0169
			static Delegate GetOnStoppedHandler ()
			{
				if (cb_onStopped == null)
					cb_onStopped = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_OnStopped);
				return cb_onStopped;
			}

			static void n_OnStopped (IntPtr jnienv, IntPtr native__this)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.IBtServerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
				__this.OnStopped ();
			}
#pragma warning restore 0169

			IntPtr id_onStopped;
			public unsafe void OnStopped ()
			{
				if (id_onStopped == IntPtr.Zero)
					id_onStopped = JNIEnv.GetMethodID (class_ref, "onStopped", "()V");
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onStopped);
			}

		}

		// event args for com.pax.gl.commhelper.IServer.IBtServerListener.onError
		/*
		public partial class ErrorEventArgs : global::System.EventArgs {
			public ErrorEventArgs (global::Com.Pax.GL.Commhelper.IServer.EServerError? p0)
			{
				this.p0 = p0;
			}

			global::Com.Pax.GL.Commhelper.IServer.EServerError? p0;

			public global::Com.Pax.GL.Commhelper.IServer.EServerError? P0 {
				get { return p0; }
			}

		}
		*/
		// event args for com.pax.gl.commhelper.IServer.IBtServerListener.onPeerConnected
		public partial class PeerConnectedEventArgs : global::System.EventArgs {
			public PeerConnectedEventArgs (global::Com.Pax.GL.Commhelper.IComm? p0, global::Android.Bluetooth.BluetoothSocket? p4)
			{
				this.p0 = p0;
				this.p4 = p4;
			}
			/*
			global::Com.Pax.GL.Commhelper.IComm? p0;

			public global::Com.Pax.GL.Commhelper.IComm? P0 {
				get { return p0; }
			}
			*/
			global::Android.Bluetooth.BluetoothSocket? p4;

			public global::Android.Bluetooth.BluetoothSocket? P4 {
				get { return p4; }
			}

		}

		[global::Android.Runtime.Register ("mono/com/pax/gl/commhelper/IServer_IBtServerListenerImplementor")]
		internal sealed partial class IBtServerListenerImplementor : global::Java.Lang.Object, IBtServerListener {

			object sender;

			public IBtServerListenerImplementor (object sender) : base (global::Android.Runtime.JNIEnv.StartCreateInstance ("mono/com/pax/gl/commhelper/IServer_IBtServerListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "()V");
				this.sender = sender;
			}

			#pragma warning disable 0649
			public EventHandler<ErrorEventArgs>? OnErrorHandler;
			#pragma warning restore 0649

			public void OnError (global::Com.Pax.GL.Commhelper.IServer.EServerError? p0)
			{
				var __h = OnErrorHandler;
				if (__h != null)
					__h (sender, new ErrorEventArgs (p0));
			}

			#pragma warning disable 0649
			public EventHandler<PeerConnectedEventArgs>? OnPeerConnectedHandler;
			#pragma warning restore 0649

			public void OnPeerConnected (global::Com.Pax.GL.Commhelper.IComm? p0, global::Android.Bluetooth.BluetoothSocket? p1)
			{
				var __h = OnPeerConnectedHandler;
				if (__h != null)
					__h (sender, new PeerConnectedEventArgs (p0, p1));
			}

			#pragma warning disable 0649
			public EventHandler? OnShuttingDownHandler;
			#pragma warning restore 0649

			public void OnShuttingDown ()
			{
				var __h = OnShuttingDownHandler;
				if (__h != null)
					__h (sender, new EventArgs ());
			}

			#pragma warning disable 0649
			public EventHandler? OnStartedHandler;
			#pragma warning restore 0649

			public void OnStarted ()
			{
				var __h = OnStartedHandler;
				if (__h != null)
					__h (sender, new EventArgs ());
			}

			#pragma warning disable 0649
			public EventHandler? OnStoppedHandler;
			#pragma warning restore 0649

			public void OnStopped ()
			{
				var __h = OnStoppedHandler;
				if (__h != null)
					__h (sender, new EventArgs ());
			}

			internal static bool __IsEmpty (IBtServerListenerImplementor value)
			{
				return value.OnErrorHandler == null && value.OnPeerConnectedHandler == null && value.OnShuttingDownHandler == null && value.OnStartedHandler == null && value.OnStoppedHandler == null;
			}

		}

		// Metadata.xml XPath interface reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.ITcpServerListener']"
		[Register ("com/pax/gl/commhelper/IServer$ITcpServerListener", "", "Com.Pax.GL.Commhelper.IServer/ITcpServerListenerInvoker")]
		public partial interface ITcpServerListener : IJavaObject, IJavaPeerable {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.ITcpServerListener']/method[@name='onError' and count(parameter)=1 and parameter[1][@type='com.pax.gl.commhelper.IServer.EServerError']]"
			[Register ("onError", "(Lcom/pax/gl/commhelper/IServer$EServerError;)V", "GetOnError_Lcom_pax_gl_commhelper_IServer_EServerError_Handler:Com.Pax.GL.Commhelper.IServer/ITcpServerListenerInvoker, GlCommBinding")]
			void OnError (global::Com.Pax.GL.Commhelper.IServer.EServerError? p0);

			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.ITcpServerListener']/method[@name='onPeerConnected' and count(parameter)=2 and parameter[1][@type='com.pax.gl.commhelper.IComm'] and parameter[2][@type='java.net.Socket']]"
			[Register ("onPeerConnected", "(Lcom/pax/gl/commhelper/IComm;Ljava/net/Socket;)V", "GetOnPeerConnected_Lcom_pax_gl_commhelper_IComm_Ljava_net_Socket_Handler:Com.Pax.GL.Commhelper.IServer/ITcpServerListenerInvoker, GlCommBinding")]
			void OnPeerConnected (global::Com.Pax.GL.Commhelper.IComm? p0, global::Java.Net.Socket? p1);

			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.ITcpServerListener']/method[@name='onShuttingDown' and count(parameter)=0]"
			[Register ("onShuttingDown", "()V", "GetOnShuttingDownHandler:Com.Pax.GL.Commhelper.IServer/ITcpServerListenerInvoker, GlCommBinding")]
			void OnShuttingDown ();

			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.ITcpServerListener']/method[@name='onStarted' and count(parameter)=2 and parameter[1][@type='java.util.List&lt;java.lang.String&gt;'] and parameter[2][@type='int']]"
			[Register ("onStarted", "(Ljava/util/List;I)V", "GetOnStarted_Ljava_util_List_IHandler:Com.Pax.GL.Commhelper.IServer/ITcpServerListenerInvoker, GlCommBinding")]
			void OnStarted (global::System.Collections.Generic.IList<string>? p0, int p1);

			// Metadata.xml XPath method reference: path="/api/package[@name='com.pax.gl.commhelper']/interface[@name='IServer.ITcpServerListener']/method[@name='onStopped' and count(parameter)=0]"
			[Register ("onStopped", "()V", "GetOnStoppedHandler:Com.Pax.GL.Commhelper.IServer/ITcpServerListenerInvoker, GlCommBinding")]
			void OnStopped ();

		}

		[global::Android.Runtime.Register ("com/pax/gl/commhelper/IServer$ITcpServerListener", DoNotGenerateAcw=true)]
		internal partial class ITcpServerListenerInvoker : global::Java.Lang.Object, ITcpServerListener {
			static readonly JniPeerMembers _members = new XAPeerMembers ("com/pax/gl/commhelper/IServer$ITcpServerListener", typeof (ITcpServerListenerInvoker));

			static IntPtr java_class_ref {
				get { return _members.JniPeerType.PeerReference.Handle; }
			}

			[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
			[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
			public override global::Java.Interop.JniPeerMembers JniPeerMembers {
				get { return _members; }
			}

			[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
			[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
			[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
			protected override global::System.Type ThresholdType {
				get { return _members.ManagedPeerType; }
			}

			IntPtr class_ref;

			public static ITcpServerListener? GetObject (IntPtr handle, JniHandleOwnership transfer)
			{
				return global::Java.Lang.Object.GetObject<ITcpServerListener> (handle, transfer);
			}

			static IntPtr Validate (IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
					throw new InvalidCastException ($"Unable to convert instance of type '{JNIEnv.GetClassNameFromInstance (handle)}' to type 'com.pax.gl.commhelper.IServer.ITcpServerListener'.");
				return handle;
			}

			protected override void Dispose (bool disposing)
			{
				if (this.class_ref != IntPtr.Zero)
					JNIEnv.DeleteGlobalRef (this.class_ref);
				this.class_ref = IntPtr.Zero;
				base.Dispose (disposing);
			}

			public ITcpServerListenerInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
			{
				IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
				this.class_ref = JNIEnv.NewGlobalRef (local_ref);
				JNIEnv.DeleteLocalRef (local_ref);
			}

			static Delegate? cb_onError_Lcom_pax_gl_commhelper_IServer_EServerError_;
#pragma warning disable 0169
			static Delegate GetOnError_Lcom_pax_gl_commhelper_IServer_EServerError_Handler ()
			{
				if (cb_onError_Lcom_pax_gl_commhelper_IServer_EServerError_ == null)
					cb_onError_Lcom_pax_gl_commhelper_IServer_EServerError_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_OnError_Lcom_pax_gl_commhelper_IServer_EServerError_);
				return cb_onError_Lcom_pax_gl_commhelper_IServer_EServerError_;
			}

			static void n_OnError_Lcom_pax_gl_commhelper_IServer_EServerError_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.ITcpServerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
				var p0 = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.EServerError> (native_p0, JniHandleOwnership.DoNotTransfer);
				__this.OnError (p0);
			}
#pragma warning restore 0169

			IntPtr id_onError_Lcom_pax_gl_commhelper_IServer_EServerError_;
			public unsafe void OnError (global::Com.Pax.GL.Commhelper.IServer.EServerError? p0)
			{
				if (id_onError_Lcom_pax_gl_commhelper_IServer_EServerError_ == IntPtr.Zero)
					id_onError_Lcom_pax_gl_commhelper_IServer_EServerError_ = JNIEnv.GetMethodID (class_ref, "onError", "(Lcom/pax/gl/commhelper/IServer$EServerError;)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onError_Lcom_pax_gl_commhelper_IServer_EServerError_, __args);
			}

			static Delegate? cb_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Ljava_net_Socket_;
#pragma warning disable 0169
			static Delegate GetOnPeerConnected_Lcom_pax_gl_commhelper_IComm_Ljava_net_Socket_Handler ()
			{
				if (cb_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Ljava_net_Socket_ == null)
					cb_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Ljava_net_Socket_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPLL_V) n_OnPeerConnected_Lcom_pax_gl_commhelper_IComm_Ljava_net_Socket_);
				return cb_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Ljava_net_Socket_;
			}

			static void n_OnPeerConnected_Lcom_pax_gl_commhelper_IComm_Ljava_net_Socket_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.ITcpServerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
				var p0 = (global::Com.Pax.GL.Commhelper.IComm?)global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IComm> (native_p0, JniHandleOwnership.DoNotTransfer);
				var p1 = global::Java.Lang.Object.GetObject<global::Java.Net.Socket> (native_p1, JniHandleOwnership.DoNotTransfer);
				__this.OnPeerConnected (p0, p1);
			}
#pragma warning restore 0169

			IntPtr id_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Ljava_net_Socket_;
			public unsafe void OnPeerConnected (global::Com.Pax.GL.Commhelper.IComm? p0, global::Java.Net.Socket? p1)
			{
				if (id_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Ljava_net_Socket_ == IntPtr.Zero)
					id_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Ljava_net_Socket_ = JNIEnv.GetMethodID (class_ref, "onPeerConnected", "(Lcom/pax/gl/commhelper/IComm;Ljava/net/Socket;)V");
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
				__args [1] = new JValue ((p1 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p1).Handle);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onPeerConnected_Lcom_pax_gl_commhelper_IComm_Ljava_net_Socket_, __args);
			}

			static Delegate? cb_onShuttingDown;
#pragma warning disable 0169
			static Delegate GetOnShuttingDownHandler ()
			{
				if (cb_onShuttingDown == null)
					cb_onShuttingDown = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_OnShuttingDown);
				return cb_onShuttingDown;
			}

			static void n_OnShuttingDown (IntPtr jnienv, IntPtr native__this)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.ITcpServerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
				__this.OnShuttingDown ();
			}
#pragma warning restore 0169

			IntPtr id_onShuttingDown;
			public unsafe void OnShuttingDown ()
			{
				if (id_onShuttingDown == IntPtr.Zero)
					id_onShuttingDown = JNIEnv.GetMethodID (class_ref, "onShuttingDown", "()V");
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onShuttingDown);
			}

			static Delegate? cb_onStarted_Ljava_util_List_I;
#pragma warning disable 0169
			static Delegate GetOnStarted_Ljava_util_List_IHandler ()
			{
				if (cb_onStarted_Ljava_util_List_I == null)
					cb_onStarted_Ljava_util_List_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPLI_V) n_OnStarted_Ljava_util_List_I);
				return cb_onStarted_Ljava_util_List_I;
			}

			static void n_OnStarted_Ljava_util_List_I (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.ITcpServerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
				var p0 = global::Android.Runtime.JavaList<string>.FromJniHandle (native_p0, JniHandleOwnership.DoNotTransfer);
				__this.OnStarted (p0, p1);
			}
#pragma warning restore 0169

			IntPtr id_onStarted_Ljava_util_List_I;
			public unsafe void OnStarted (global::System.Collections.Generic.IList<string>? p0, int p1)
			{
				if (id_onStarted_Ljava_util_List_I == IntPtr.Zero)
					id_onStarted_Ljava_util_List_I = JNIEnv.GetMethodID (class_ref, "onStarted", "(Ljava/util/List;I)V");
				IntPtr native_p0 = global::Android.Runtime.JavaList<string>.ToLocalJniHandle (p0);
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onStarted_Ljava_util_List_I, __args);
				JNIEnv.DeleteLocalRef (native_p0);
			}

			static Delegate? cb_onStopped;
#pragma warning disable 0169
			static Delegate GetOnStoppedHandler ()
			{
				if (cb_onStopped == null)
					cb_onStopped = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_OnStopped);
				return cb_onStopped;
			}

			static void n_OnStopped (IntPtr jnienv, IntPtr native__this)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer.ITcpServerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
				__this.OnStopped ();
			}
#pragma warning restore 0169

			IntPtr id_onStopped;
			public unsafe void OnStopped ()
			{
				if (id_onStopped == IntPtr.Zero)
					id_onStopped = JNIEnv.GetMethodID (class_ref, "onStopped", "()V");
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onStopped);
			}

		}

		// event args for com.pax.gl.commhelper.IServer.ITcpServerListener.onError
		/*
		public partial class ErrorEventArgs : global::System.EventArgs {
			public ErrorEventArgs (global::Com.Pax.GL.Commhelper.IServer.EServerError? p0)
			{
				this.p0 = p0;
			}

			global::Com.Pax.GL.Commhelper.IServer.EServerError? p0;

			public global::Com.Pax.GL.Commhelper.IServer.EServerError? P0 {
				get { return p0; }
			}

		}
		*/
		// event args for com.pax.gl.commhelper.IServer.ITcpServerListener.onPeerConnected
		public partial class PeerConnectedEventArgs : global::System.EventArgs {
			public PeerConnectedEventArgs (global::Com.Pax.GL.Commhelper.IComm? p0, global::Java.Net.Socket? p5)
			{
				this.p0 = p0;
				this.p5 = p5;
			}
			/*
			global::Com.Pax.GL.Commhelper.IComm? p0;

			public global::Com.Pax.GL.Commhelper.IComm? P0 {
				get { return p0; }
			}
			*/
			global::Java.Net.Socket? p5;

			public global::Java.Net.Socket? P5 {
				get { return p5; }
			}

		}

		// event args for com.pax.gl.commhelper.IServer.ITcpServerListener.onStarted
		public partial class StartedEventArgs : global::System.EventArgs {
			public StartedEventArgs (global::System.Collections.Generic.IList<string>? p0, int p1)
			{
				this.p0 = p0;
				this.p1 = p1;
			}

			global::System.Collections.Generic.IList<string>? p0;

			public global::System.Collections.Generic.IList<string>? P0 {
				get { return p0; }
			}

			int p1;

			public int P1 {
				get { return p1; }
			}

		}

		[global::Android.Runtime.Register ("mono/com/pax/gl/commhelper/IServer_ITcpServerListenerImplementor")]
		internal sealed partial class ITcpServerListenerImplementor : global::Java.Lang.Object, ITcpServerListener {

			object sender;

			public ITcpServerListenerImplementor (object sender) : base (global::Android.Runtime.JNIEnv.StartCreateInstance ("mono/com/pax/gl/commhelper/IServer_ITcpServerListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
			{
				global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "()V");
				this.sender = sender;
			}

			#pragma warning disable 0649
			public EventHandler<ErrorEventArgs>? OnErrorHandler;
			#pragma warning restore 0649

			public void OnError (global::Com.Pax.GL.Commhelper.IServer.EServerError? p0)
			{
				var __h = OnErrorHandler;
				if (__h != null)
					__h (sender, new ErrorEventArgs (p0));
			}

			#pragma warning disable 0649
			public EventHandler<PeerConnectedEventArgs>? OnPeerConnectedHandler;
			#pragma warning restore 0649

			public void OnPeerConnected (global::Com.Pax.GL.Commhelper.IComm? p0, global::Java.Net.Socket? p1)
			{
				var __h = OnPeerConnectedHandler;
				if (__h != null)
					__h (sender, new PeerConnectedEventArgs (p0, p1));
			}

			#pragma warning disable 0649
			public EventHandler? OnShuttingDownHandler;
			#pragma warning restore 0649

			public void OnShuttingDown ()
			{
				var __h = OnShuttingDownHandler;
				if (__h != null)
					__h (sender, new EventArgs ());
			}

			#pragma warning disable 0649
			public EventHandler<StartedEventArgs>? OnStartedHandler;
			#pragma warning restore 0649

			public void OnStarted (global::System.Collections.Generic.IList<string>? p0, int p1)
			{
				var __h = OnStartedHandler;
				if (__h != null)
					__h (sender, new StartedEventArgs (p0, p1));
			}

			#pragma warning disable 0649
			public EventHandler? OnStoppedHandler;
			#pragma warning restore 0649

			public void OnStopped ()
			{
				var __h = OnStoppedHandler;
				if (__h != null)
					__h (sender, new EventArgs ());
			}

			internal static bool __IsEmpty (ITcpServerListenerImplementor value)
			{
				return value.OnErrorHandler == null && value.OnPeerConnectedHandler == null && value.OnShuttingDownHandler == null && value.OnStartedHandler == null && value.OnStoppedHandler == null;
			}

		}

	}

	[global::Android.Runtime.Register ("com/pax/gl/commhelper/IServer", DoNotGenerateAcw=true)]
	internal partial class IServerInvoker : global::Java.Lang.Object, IServer {
		static readonly JniPeerMembers _members = new XAPeerMembers ("com/pax/gl/commhelper/IServer", typeof (IServerInvoker));

		static IntPtr java_class_ref {
			get { return _members.JniPeerType.PeerReference.Handle; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		public override global::Java.Interop.JniPeerMembers JniPeerMembers {
			get { return _members; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override global::System.Type ThresholdType {
			get { return _members.ManagedPeerType; }
		}

		IntPtr class_ref;

		public static IServer? GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IServer> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException ($"Unable to convert instance of type '{JNIEnv.GetClassNameFromInstance (handle)}' to type 'com.pax.gl.commhelper.IServer'.");
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IServerInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate? cb_start;
#pragma warning disable 0169
		static Delegate GetStartHandler ()
		{
			if (cb_start == null)
				cb_start = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_Start);
			return cb_start;
		}

		static void n_Start (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.Start ();
		}
#pragma warning restore 0169

		IntPtr id_start;
		public unsafe void Start ()
		{
			if (id_start == IntPtr.Zero)
				id_start = JNIEnv.GetMethodID (class_ref, "start", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_start);
		}

		static Delegate? cb_stop;
#pragma warning disable 0169
		static Delegate GetStopHandler ()
		{
			if (cb_stop == null)
				cb_stop = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_Stop);
			return cb_stop;
		}

		static void n_Stop (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::Com.Pax.GL.Commhelper.IServer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.Stop ();
		}
#pragma warning restore 0169

		IntPtr id_stop;
		public unsafe void Stop ()
		{
			if (id_stop == IntPtr.Zero)
				id_stop = JNIEnv.GetMethodID (class_ref, "stop", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_stop);
		}

	}
}
