package crc64fa28fabcd1b32771;


public class AlbumHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MagicApp.Helper.AlbumHolder, MagicApp", AlbumHolder.class, __md_methods);
	}


	public AlbumHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == AlbumHolder.class)
			mono.android.TypeManager.Activate ("MagicApp.Helper.AlbumHolder, MagicApp", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
