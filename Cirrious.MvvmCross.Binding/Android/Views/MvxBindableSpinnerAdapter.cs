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
using Cirrious.MvvmCross.Binding.Android.Interfaces.Views;
using System.Collections;
using System.Collections.Specialized;
using Android;
using Cirrious.MvvmCross.Exceptions;
using Cirrious.MvvmCross.Interfaces.Platform.Diagnostics;

namespace Cirrious.MvvmCross.Binding.Android.Views
{
    public class MvxBindableSpinnerAdapter: BaseAdapter
    {
        private readonly IMvxBindingActivity _bindingActivity;
        private readonly Context _context;
        private int _itemTemplateId;
        private IList _itemsSource;

        public MvxBindableSpinnerAdapter(Context context)
        {
            _context = context;
            _bindingActivity = context as IMvxBindingActivity;
            if (_bindingActivity == null)
                throw new MvxException("MvxBindableSpinnerView can only be used within a Context which supports IMvxBindingActivity");
        }

        protected Context Context { get { return _context; } }
        protected IMvxBindingActivity BindingActivity { get { return _bindingActivity; } }

        public IList ItemsSource
        {
            get { return _itemsSource; }
            set {
                SetItemsSource(value);
            }
        }

        public int ItemTemplateId
        {
            get { return _itemTemplateId; }
            set
            {
                if (_itemTemplateId == value)
                    return;
                _itemTemplateId = value;

                // since the template has changed then let's force the list to redisplay by firing NotifyDataSetChanged()
                if (_itemsSource != null)
                    NotifyDataSetChanged();
            }
        }

        public override int Count
        {
            get
            {
                if (_itemsSource == null)
                    return 0;

                return _itemsSource.Count;
            }
        }

        protected virtual void SetItemsSource(IList value)
        {
            if (_itemsSource == value)
                return;
            var existingObservable = _itemsSource as INotifyCollectionChanged;
            if (existingObservable != null)
                existingObservable.CollectionChanged -= OnItemsSourceCollectionChanged;
            _itemsSource = value;
            var newObservable = _itemsSource as INotifyCollectionChanged;
            if (newObservable != null)
                newObservable.CollectionChanged += OnItemsSourceCollectionChanged;
            NotifyDataSetChanged();
        }

        private void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyDataSetChanged();
        }

        public int GetPosition(object item)
        {
            if (_itemsSource == null)
                return -1;
            return _itemsSource.IndexOf(item);
        }

        public override Java.Lang.Object GetItem(int position)
        {
            if (_itemsSource == null)
                return null;
            return new MvxJavaContainer<object>(_itemsSource[position]);
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (_itemsSource == null)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error, "GetView called when ItemsSource is null");
                return null;
            }

            if (position < 0 || position >= _itemsSource.Count)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error, "GetView called with invalid Position - zero indexed {0} out of {1}", position, _itemsSource.Count);
                return null;
            }

            var source = _itemsSource[position];

            return GetBindableView(convertView, source);
        }

        protected virtual View GetSimpleView(View convertView, object source)
        {
            if (convertView == null)
            {
                convertView = CreateSimpleView(source);
            }
            else
            {
                BindSimpleView(convertView, source);
            }

            return convertView;
        }

        protected virtual void BindSimpleView(View convertView, object source)
        {
            var textView = convertView as TextView;
            if (textView != null)
            {
                textView.Text = (source ?? string.Empty).ToString();
            }
        }

        protected virtual View CreateSimpleView(object source)
        {
            var view = _bindingActivity.NonBindingInflate(Resource.Layout.SimpleDropDownItem1Line, null);
            BindSimpleView(view, source);
            return view;
        }

        protected virtual View GetBindableView(View convertView, object source)
        {
            return GetBindableView(convertView, source, ItemTemplateId);
        }

        protected virtual View GetBindableView(View convertView, object source, int templateId)
        {
            if (templateId == 0)
            {
                // no template seen - so use a standard string view from Android and use ToString()
                return GetSimpleView(convertView, source);
            }

            // we have a templateid so lets use bind and inflate on it :)
            var viewToUse = convertView as IMvxBindableSpinnerItemView;
            if (viewToUse != null)
            {
                if (viewToUse.TemplateId != templateId)
                {
                    viewToUse = null;
                }
            }

            if (viewToUse == null)
            {
                viewToUse = CreateBindableView(source, templateId);
            }
            else
            {
                BindBindableView(source, viewToUse);
            }

            return viewToUse as View;
        }

        protected virtual void BindBindableView(object source, IMvxBindableSpinnerItemView viewToUse)
        {
            viewToUse.BindTo(source);
        }

        protected virtual MvxBindableSpinnerItemView CreateBindableView(object source, int templateId)
        {
            return new MvxBindableSpinnerItemView(_context, _bindingActivity, templateId, source);
        }
    }
}