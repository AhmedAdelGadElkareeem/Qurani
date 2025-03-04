namespace WytSky.Mobile.Maui.Skoola.Validations;

public class IsEmptyValidation<T> : IValidationRule<string>
{
    public string ValidationMessage { get; set; }
    public bool Check(string value)
    {
        bool isValid = !string.IsNullOrWhiteSpace(value);
        return isValid;
    }
    public void UpdateMessage(string msg)
    {
        ValidationMessage = msg;
    }
}
