package ahwa.attila.ui.android.views.category;


public class CategoryEditView
	extends ahwa.attila.ui.android.views.category.BaseCategoryEditView_1
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Ahwa.Attila.UI.Android.Views.Category.CategoryEditView, Blooor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CategoryEditView.class, __md_methods);
	}


	public CategoryEditView ()
	{
		super ();
		if (getClass () == CategoryEditView.class)
			mono.android.TypeManager.Activate ("Ahwa.Attila.UI.Android.Views.Category.CategoryEditView, Blooor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
