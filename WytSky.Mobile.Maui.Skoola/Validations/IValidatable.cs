﻿using System.ComponentModel;

namespace WytSky.Mobile.Maui.Skoola.Validations;

public interface IValidatable<T> : INotifyPropertyChanged
{
    List<IValidationRule<T>> Validations { get; }
    List<string> Errors { get; set; }
    bool Validate();
    bool IsValid { get; set; }

}
