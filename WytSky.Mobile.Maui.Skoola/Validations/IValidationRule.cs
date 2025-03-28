﻿namespace WytSky.Mobile.Maui.Skoola.Validations;

public interface IValidationRule<T>
{
    string ValidationMessage { get; set; }
    bool Check(T value);
}
