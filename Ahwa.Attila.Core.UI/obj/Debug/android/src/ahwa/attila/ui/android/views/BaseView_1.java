package ahwa.attila.ui.android.views;


public abstract class BaseView_1
	extends cirrious.mvvmcross.binding.android.views.MvxBindingActivityView_1
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onOptionsItemSelected:(Landroid/view/MenuItem;)Z:GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler\n" +
			"";
		mono.android.Runtime.register ("Ahwa.Attila.UI.Android.Views.BaseView`1, Blooor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BaseView_1.class, __md_methods);
	}


	public BaseView_1 ()
	{
		super ();
		if (getClass () == BaseView_1.class)
			mono.android.TypeManager.Activate ("Ahwa.Attila.UI.Android.Views.BaseView`1, Blooor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean onOptionsItemSelected (android.view.MenuItem p0)
	{
		return n_onOptionsItemSelected (p0);
	}

	private native boolean n_onOptionsItemSelected (android.view.MenuItem p0);

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
