package cirrious.mvvmcross.platform.location;


public abstract class MvxBaseGeoLocationWatcher
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Cirrious.MvvmCross.Platform.Location.MvxBaseGeoLocationWatcher, Cirrious.MvvmCross.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MvxBaseGeoLocationWatcher.class, __md_methods);
	}


	public MvxBaseGeoLocationWatcher ()
	{
		super ();
		if (getClass () == MvxBaseGeoLocationWatcher.class)
			mono.android.TypeManager.Activate ("Cirrious.MvvmCross.Platform.Location.MvxBaseGeoLocationWatcher, Cirrious.MvvmCross.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
