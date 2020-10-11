package crc64fa28fabcd1b32771;


public class RecyclerViewDataHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MagicApp.Helper.RecyclerViewDataHolder, MagicApp", RecyclerViewDataHolder.class, __md_methods);
	}


	public RecyclerViewDataHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == RecyclerViewDataHolder.class)
			mono.android.TypeManager.Activate ("MagicApp.Helper.RecyclerViewDataHolder, MagicApp", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
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
