package cirrious.mvvmcross.binding.android.simple;


public class MvxSimpleBindingActivity_1
	extends cirrious.mvvmcross.binding.android.views.MvxBindingActivityView_1
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Cirrious.MvvmCross.Binding.Android.Simple.MvxSimpleBindingActivity`1, Cirrious.MvvmCross.Binding.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MvxSimpleBindingActivity_1.class, __md_methods);
	}


	public MvxSimpleBindingActivity_1 ()
	{
		super ();
		if (getClass () == MvxSimpleBindingActivity_1.class)
			mono.android.TypeManager.Activate ("Cirrious.MvvmCross.Binding.Android.Simple.MvxSimpleBindingActivity`1, Cirrious.MvvmCross.Binding.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
