using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Ahwa.Attila.UI.Android.Views.ShoppingItem
{
    public static class ShoppingItemHelper
    {
        public const string NEW_OBJECT_VIEW_TITLE = "New shopping item";
        public const string LIST_OBJECT_VIEW_TITLE = "Shopping item list";
        public const string EDIT_OBJECT_VIEW_TITLE = "Shopping item editor";
        public const string DETAIL_OBJECT_VIEW_TITLE = "Shopping item Info";

        public const int ADD_OBJECT_MENU = Resource.Menu.shoppingitem_add_menu;
        public const int VIEW_OBJECT_MENU = Resource.Menu.shoppingitem_list_menu;
        public const int EDIT_OBJECT_MENU = Resource.Menu.shoppingitem_edit_menu;
        public const int CHANGE_OBJECT_MENU = Resource.Id.change_shoppingitem;
        public const int DELETE_OBJECT_MENU = Resource.Id.delete_shoppingitem;
        public const int SAVE_OBJECT_MENU = Resource.Id.save_shoppingitem;
        public const int LIST_OBJECT_MENU = Resource.Menu.shoppingitem_menu;
        
        public const int LIST_CONTENT = Resource.Layout.ShoppingItemListView;
        public const int DETAIL_CONTENT = Resource.Layout.ShoppingItemDetailsView;
        public const int EDIT_CONTENT = Resource.Layout.ShoppingItemEditView;
    }
}