using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Telerik.XamarinForms.Primitives;

namespace Examples.BusyIndicator.Gallery
{
    public class ViewModel : ViewModelBase
    {
        private ObservableCollection<AnimationType> animationTypes;
        private ObservableCollection<object> selectedItems;
        private AnimationType selectedAnimationType;

        public ViewModel()
        {
            ObservableCollection<AnimationType> animationTypes = new ObservableCollection<AnimationType>();

            IEnumerable<AnimationType> enumValues = Enum.GetValues(typeof(AnimationType)).Cast<AnimationType>();
            IEnumerable<AnimationType> animationTypesExceptCustom = enumValues.Except(new AnimationType[] { AnimationType.Custom });

            foreach (AnimationType animationType in animationTypesExceptCustom)
            {
                animationTypes.Add(animationType);
            }

            this.AnimationTypes = animationTypes;

            this.SelectedAnimationType = AnimationType.Animation1;
        }

        public ObservableCollection<AnimationType> AnimationTypes
        {
            get
            {
                return this.animationTypes;
            }
            private set
            {
                if (this.animationTypes != value)
                {
                    this.animationTypes = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<object> SelectedItems
        {
            get
            {
                return this.selectedItems;
            }
            set
            {
                if (this.selectedItems != value)
                {
                    this.DetachFromSelectionItemsEvents();

                    this.selectedItems = value;

                    this.AttachToSelectionItemsEvents();
                    this.OnSelectedItemsCollectionChanged();

                    this.OnPropertyChanged();
                }
            }
        }

        public AnimationType SelectedAnimationType
        {
            get
            {
                return this.selectedAnimationType;
            }
            set
            {
                if (this.selectedAnimationType != value)
                {
                    this.selectedAnimationType = value;
                    this.OnPropertyChanged();
                }
            }
        }

        private void AttachToSelectionItemsEvents()
        {
            if (this.SelectedItems != null)
            {
                this.SelectedItems.CollectionChanged += this.SelectedItems_CollectionChanged;
            }
        }

        private void DetachFromSelectionItemsEvents()
        {
            if (this.SelectedItems != null)
            {
                this.SelectedItems.CollectionChanged -= this.SelectedItems_CollectionChanged;
            }
        }

        private void SelectedItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this.SelectedItems.Count > 0)
            {
                this.SelectedAnimationType = (AnimationType)this.SelectedItems.First();
            }
        }

        private void OnSelectedItemsCollectionChanged()
        {
            if (this.SelectedItems != null && this.SelectedItems.Count == 0)
            {
                this.SelectedItems.Add(this.AnimationTypes.First());
            }
        }
    }
}
