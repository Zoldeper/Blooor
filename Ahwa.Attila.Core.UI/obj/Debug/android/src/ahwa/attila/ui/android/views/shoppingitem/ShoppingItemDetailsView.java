package ahwa.attila.ui.android.views.shoppingitem;


public class ShoppingItemDetailsView
	extends ahwa.attila.ui.android.views.BaseView_1
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateOptionsMenu:(Landroid/view/Menu;)Z:GetOnCreateOptionsMenu_Landroid_view_Menu_Handler\n" +
			"n_onOptionsItemSelected:(Landroid/view/MenuItem;)Z:GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler\n" +
			"";
		mono.android.Runtime.register ("Ahwa.Attila.UI.Android.Views.ShoppingItem.ShoppingItemDetailsView, Blooor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ShoppingItemDetailsView.class, __md_methods);
	}


	public ShoppingItemDetailsView ()
	{
		super ();
		if (getClass () == ShoppingItemDetailsView.class)
			mono.android.TypeManager.Activate ("Ahwa.Attila.UI.Android.Views.ShoppingItem.ShoppingItemDetailsView, Blooor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean onCreateOptionsMenu (android.view.Menu p0)
	{
		return n_onCreateOptionsMenu (p0);
	}

	private native boolean n_onCreateOptionsMenu (android.view.Menu p0);


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
