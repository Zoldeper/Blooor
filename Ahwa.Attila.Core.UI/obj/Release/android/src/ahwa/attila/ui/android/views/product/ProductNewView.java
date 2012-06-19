package ahwa.attila.ui.android.views.product;


public class ProductNewView
	extends ahwa.attila.ui.android.views.product.BaseProductEditView_1
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Ahwa.Attila.UI.Android.Views.Product.ProductNewView, Blooor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ProductNewView.class, __md_methods);
	}


	public ProductNewView ()
	{
		super ();
		if (getClass () == ProductNewView.class)
			mono.android.TypeManager.Activate ("Ahwa.Attila.UI.Android.Views.Product.ProductNewView, Blooor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
