package md59a598f6ea2090a9b5fdc4bef55fc42f7;


public class CustomMasterDetailPageRenderer
	extends md58432a647068b097f9637064b8985a5e0.MasterDetailPageRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ComposTux.Droid.Controls.CustomMasterDetailPageRenderer, ComposTux.Android", CustomMasterDetailPageRenderer.class, __md_methods);
	}


	public CustomMasterDetailPageRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CustomMasterDetailPageRenderer.class)
			mono.android.TypeManager.Activate ("ComposTux.Droid.Controls.CustomMasterDetailPageRenderer, ComposTux.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CustomMasterDetailPageRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CustomMasterDetailPageRenderer.class)
			mono.android.TypeManager.Activate ("ComposTux.Droid.Controls.CustomMasterDetailPageRenderer, ComposTux.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CustomMasterDetailPageRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CustomMasterDetailPageRenderer.class)
			mono.android.TypeManager.Activate ("ComposTux.Droid.Controls.CustomMasterDetailPageRenderer, ComposTux.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
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
