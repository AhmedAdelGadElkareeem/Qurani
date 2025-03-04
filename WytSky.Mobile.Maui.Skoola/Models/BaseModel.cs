using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.Models
{
    public class BaseModel :  System.ComponentModel.INotifyPropertyChanged 
    {
        #region SetProperty
        protected bool SetProperty<T>(ref T backingStore, T value,
            [System.Runtime.CompilerServices.CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

        #region INotifyPropertyChanged
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(sender, e);
        }
        protected void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (!string.IsNullOrWhiteSpace(propertyName))
            {
                OnPropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
            else
            {
                foreach (System.Reflection.PropertyInfo pi in this.GetType().GetProperties())
                    OnPropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(pi.Name));
            }
        }
        #endregion
    }
}
