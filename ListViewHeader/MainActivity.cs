using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using Android.Views;
using System;

namespace ListViewHeader
{
	[Activity(Label = "ListViewHeader", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		public static int TYPE_ITEM = 0;
		public static int TYPE_SEPORATOR=1;

		List<IMenuItemsType> item = new List<IMenuItemsType>();

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			item.Add(new MenuHeaderItem("GENERAL SETTINGS"));
			item.Add(new MenuContentItem("Display Settings", "Settings about screen display",Resource.Drawable.Delete15));
			item.Add(new MenuContentItem("Display Settings", "Settings about screen display", Resource.Drawable.DoubleTap15));
			item.Add(new MenuContentItem("Display Settings", "Settings about screen display", Resource.Drawable.Settings15));
			item.Add(new MenuContentItem("Display Settings", "Settings about screen display", Resource.Drawable.ShowProperty15));
			item.Add(new MenuHeaderItem("NOTIFICATIONS"));
			item.Add(new MenuContentItem("Display Settings", "Settings about screen display", Resource.Drawable.Settings15));
			item.Add(new MenuContentItem("Display Settings", "Settings about screen display", Resource.Drawable.Phone15));
			item.Add(new MenuContentItem("Display Settings", "Settings about screen display", Resource.Drawable.EditUserMale15));
			item.Add(new MenuContentItem("Display Settings", "Settings about screen display", Resource.Drawable.DoubleTap15));
			item.Add(new MenuHeaderItem("GENERAL SETTINGS"));
			item.Add(new MenuContentItem("Display Settings", "Settings about screen display", Resource.Drawable.Delete15));
			item.Add(new MenuContentItem("Display Settings", "Settings about screen display", Resource.Drawable.DoubleTap15));
			item.Add(new MenuContentItem("Display Settings", "Settings about screen display", Resource.Drawable.Settings15));
			item.Add(new MenuContentItem("Display Settings", "Settings about screen display", Resource.Drawable.ShowProperty15));
			item.Add(new MenuHeaderItem("NOTIFICATIONS"));
			item.Add(new MenuContentItem("Display Settings", "Settings about screen display", Resource.Drawable.Settings15));
			item.Add(new MenuContentItem("Display Settings", "Settings about screen display", Resource.Drawable.Phone15));
			item.Add(new MenuContentItem("Display Settings", "Settings about screen display", Resource.Drawable.EditUserMale15));
			item.Add(new MenuContentItem("Display Settings", "Settings about screen display", Resource.Drawable.DoubleTap15));

			ListView lst = FindViewById<ListView>(Resource.Id.lstview);
			lst.Adapter = new ListViewAdapter(this, item);
			         
		}

		public interface IMenuItemsType
		{
			int GetMenuItemsType();
		}

		public class MenuHeaderItem : IMenuItemsType
		{
			public string HeaderText { get; set; }

			public int GetMenuItemsType()
			{
				return TYPE_ITEM;
			}

			public MenuHeaderItem(string _headerText)
			{
				HeaderText = _headerText;
			}
		}

		public class MenuContentItem : IMenuItemsType
		{
			public string Title { get; set; }
			public string SubTitle { get; set; }
			public int IconImage { get; set; }

			public int GetMenuItemsType()
			{
				return TYPE_SEPORATOR;
			}

			public MenuContentItem(string _title, string _subtitle, int _iconImage)
			{
				Title = _title;
				SubTitle = _subtitle;
				IconImage = _iconImage;
			}
		}



		public class ListViewAdapter : ArrayAdapter<IMenuItemsType>
		{
			private Context context;
			private List<IMenuItemsType> items;
			private LayoutInflater inflater;

			public ListViewAdapter(Context context, List<IMenuItemsType> items) : base(context,0,items)
			{
				this.context = context;
				this.items = items;
				this.inflater = (LayoutInflater)this.context.GetSystemService(Context.LayoutInflaterService);
			}


			public override int Count
			{
				get
				{
					//throw new System.NotImplementedException();
					return items.Count;
				}
			}

			public override long GetItemId(int position)
			{
				//throw new System.NotImplementedException();
				return position;
			}

			public override View GetView(int position, View convertView, ViewGroup parent)
			{
				//throw new System.NotImplementedException();
				View view = convertView;
				try
				{
					IMenuItemsType item = items[position];
					if (item.GetMenuItemsType() == TYPE_ITEM)
					{
						MenuHeaderItem _headerItem = (MenuHeaderItem)item;
						view = inflater.Inflate(Resource.Layout.ListViewHeaderItem, null);
						// user dont click header item
						view.Clickable = false;

						var headerName = view.FindViewById<TextView>(Resource.Id.txtHeader);
						headerName.Text = _headerItem.HeaderText;

					}
					else if (item.GetMenuItemsType() == TYPE_SEPORATOR)
					{
						MenuContentItem _contentItem = (MenuContentItem)item;
						view = inflater.Inflate(Resource.Layout.ListViewContentItem, null);

						var _title = view.FindViewById<TextView>(Resource.Id.txtTitle);
						var _imgIcon = view.FindViewById<ImageView>(Resource.Id.imgIcon);
						var _subTitle = view.FindViewById<TextView>(Resource.Id.txtSubTitle);

						_title.Text = _contentItem.Title;
						_imgIcon.SetBackgroundResource(_contentItem.IconImage);
						_subTitle.Text = _contentItem.SubTitle;
					}
				}
				catch (Exception ex)
				{
					Toast.MakeText(context, ex.Message, ToastLength.Long);
				}
				return view;
			}
		}
	}
}


