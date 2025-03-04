using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WytSky.Mobile.Maui.Skoola.Validations;

public class ValidatableObject<T> : IValidatable<T>
{

    public List<IValidationRule<T>> Validations { get; } = new List<IValidationRule<T>>();

    private List<string> errors = new List<string>();
    public List<string> Errors
    {
        get { return errors; }
        set { errors = value; OnPropertyChanged(); }
    }


    public bool CleanOnChange { get; set; } = true;

    T _value;
    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            OnPropertyChanged();
            if (CleanOnChange)
                IsValid = true;
        }
    }

    private bool isValid = true;
    public bool IsValid
    {
        get { return isValid; }
        set { isValid = value; OnPropertyChanged(); }
    }

    //public bool IsValid { get; set; } = true;

    public virtual bool Validate()
    {
        Errors.Clear();

        IEnumerable<string> errors = Validations.Where(v => !v.Check(Value))
            .Select(v => v.ValidationMessage);

        Errors = errors.ToList();
        IsValid = !Errors.Any();

        return this.IsValid;
    }
    public override string ToString()
    {
        return $"{Value}";
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        var handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
    }
}
