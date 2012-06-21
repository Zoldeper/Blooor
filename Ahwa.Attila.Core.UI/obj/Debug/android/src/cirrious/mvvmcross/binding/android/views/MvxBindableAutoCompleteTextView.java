package cirrious.mvvmcross.binding.android.views;


public class MvxBindableAutoCompleteTextView
	extends android.widget.AutoCompleteTextView
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Cirrious.MvvmCross.Binding.Android.Views.MvxBindableAutoCompleteTextView, Cirrious.MvvmCross.Binding.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MvxBindableAutoCompleteTextView.class, __md_methods);
	}


	public MvxBindableAutoCompleteTextView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MvxBindableAutoCompleteTextView.class)
			mono.android.TypeManager.Activate ("Cirrious.MvvmCross.Binding.Android.Views.MvxBindableAutoCompleteTextView, Cirrious.MvvmCross.Binding.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=c4c4237547e4b6cd", this, new java.lang.Object[] { p0 });
	}


	public MvxBindableAutoCompleteTextView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MvxBindableAutoCompleteTextView.class)
			mono.android.TypeManager.Activate ("Cirrious.MvvmCross.Binding.Android.Views.MvxBindableAutoCompleteTextView, Cirrious.MvvmCross.Binding.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=c4c4237547e4b6cd:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=c4c4237547e4b6cd", this, new java.lang.Object[] { p0, p1 });
	}


	public MvxBindableAutoCompleteTextView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MvxBindableAutoCompleteTextView.class)
			mono.android.TypeManager.Activate ("Cirrious.MvvmCross.Binding.Android.Views.MvxBindableAutoCompleteTextView, Cirrious.MvvmCross.Binding.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=c4c4237547e4b6cd:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=c4c4237547e4b6cd:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
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
