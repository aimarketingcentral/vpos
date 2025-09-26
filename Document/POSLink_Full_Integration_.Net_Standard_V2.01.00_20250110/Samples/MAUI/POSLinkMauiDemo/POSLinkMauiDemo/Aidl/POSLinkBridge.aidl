// IMyAidlInterface.aidl
package com.pax.us.pay.std.ecr;

// Declare any non-default types here with import statements

interface POSLinkBridge {
    String init();
	String doTrans(String jsonStr);
	void abortTrans();
}

