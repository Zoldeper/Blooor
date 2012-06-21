package cirrious.mvvmcross.binding.android.views;


public class MvxFilteringBindableListAdapter
	extends cirrious.mvvmcross.binding.android.views.MvxBindableListAdapter
	implements
		mono.android.IGCUserPeer,
		android.widget.Filterable
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_notifyDataSetChanged:()V:GetNotifyDataSetChangedHandler\n" +
			"n_getFilter:()Landroid/widget/Filter;:GetGetFilterHandler:Android.Widget.IFilterableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Cirrious.MvvmCross.Binding.Android.Views.MvxFilteringBindableListAdapter, Cirrious.MvvmCross.Binding.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MvxFilteringBindableListAdapter.class, __md_methods);
	}


	public MvxFilteringBindableListAdapter ()
	{
		super ();
		if (getClass () == MvxFilteringBindableListAdapter.class)
			mono.android.TypeManager.Activate ("Cirrious.MvvmCross.Binding.Android.Views.MvxFilteringBindableListAdapter, Cirrious.MvvmCross.Binding.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public MvxFilteringBindableListAdapter (android.content.Context p0)
	{
		super ();
		if (getClass () == MvxFilteringBindableListAdapter.class)
			mono.android.TypeManager.Activate ("Cirrious.MvvmCross.Binding.Android.Views.MvxFilteringBindableListAdapter, Cirrious.MvvmCross.Binding.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=c4c4237547e4b6cd", this, new java.lang.Object[] { p0 });
	}


	public void notifyDataSetChanged ()
	{
		n_notifyDataSetChanged ();
	}

	private native void n_notifyDataSetChanged ();


	public android.widget.Filter getFilter ()
	{
		return n_getFilter ();
	}

	private native android.widget.Filter n_getFilter ();

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
