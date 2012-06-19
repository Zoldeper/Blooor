
using System.Collections;
using Android.Content;
using Android.Util;
using Android.Widget;
using Cirrious.MvvmCross.Interfaces.Commands;

namespace Cirrious.MvvmCross.Binding.Android.Views
{
    public class MvxBindableSpinner : Spinner
    {
        public MvxBindableSpinner(Context context, IAttributeSet attrs)
            : this(context, attrs, new MvxBindableSpinnerAdapter(context))
        {
        }

        public MvxBindableSpinner(Context context, IAttributeSet attrs, MvxBindableSpinnerAdapter adapter)
            : base(context, attrs)
        {
            var itemTemplateId = MvxBindableSpinnerHelpers.ReadTemplatePath(context, attrs);
            adapter.ItemTemplateId = itemTemplateId;
            Adapter = adapter;
            SetupHandleItemSelected();
        }

        public new MvxBindableSpinnerAdapter Adapter
        {
            get { return base.Adapter as MvxBindableSpinnerAdapter; }
            set
            {
                var existing = Adapter;
                if (existing == value)
                    return;

                if (existing != null && value != null)
                {
                    value.ItemsSource = existing.ItemsSource;
                    value.ItemTemplateId = existing.ItemTemplateId;
                }

                base.Adapter = value;
            }
        }

        public IList ItemsSource
        {
            get { return Adapter.ItemsSource; }
            set { Adapter.ItemsSource = value; }
        }

        public int ItemTemplateId
        {
            get { return Adapter.ItemTemplateId; }
            set { Adapter.ItemTemplateId = value; }
        }

        public IMvxCommand HandleItemSelected { get; set; }

        private void SetupHandleItemSelected()
        {
            base.ItemSelected += (sender, args) =>
            {
                var item = Adapter.GetItem(args.Position) as MvxJavaContainer;
                if (this.HandleItemSelected == null || item == null || !this.HandleItemSelected.CanExecute(item.Object) || item.Object == null)
                    return;

                this.HandleItemSelected.Execute(item.Object);
            };
        }
    }
}