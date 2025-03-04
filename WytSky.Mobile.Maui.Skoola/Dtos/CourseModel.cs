
using System.ComponentModel;

namespace WytSky.Mobile.Maui.Skoola.Dtos;

public class CourseModel : INotifyPropertyChanged
{
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
    public int RecordStatus { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string NameAr { get; set; }
    public object DescriptionAr { get; set; }
    public int CategoryID { get; set; }
    public string CategoryMainCategoryName { get; set; }
    public string CategoryMainCategoryParentCategoryName { get; set; }
    public object PackageID { get; set; }
    public string Goals { get; set; }
    public string GoalsAr { get; set; }
    public string Skills { get; set; }
    public string SkillsAr { get; set; }
    public string Duration { get; set; }
    public string DurationAr { get; set; }
    public int? Episodes { get; set; }
    public string InstructorName { get; set; }
    public string InstructorCv { get; set; }
    public string OverviewVideoUrl { get; set; }
    public string OverviewImageUrl { get; set; }
    public string OverviewImageUrlContent
    {
        get
        {
            return
                string.IsNullOrEmpty(OverviewImageUrl) ? "" : Services.ApiServices.BaseImage + OverviewImageUrl;
        }
    }
    public bool HasOverviewImageUrlContent { get { return string.IsNullOrEmpty(OverviewImageUrlContent); } }

    public bool HasExam { get; set; }
    public bool HasCertificate { get; set; }
    public int? ExamTimeInMinutes { get; set; }
    public int? QuestionsNumber { get; set; }
    public int? PassQuestionsNumber { get; set; }
    public int? AttemptsNumber { get; set; }
    public bool HasSecondExam { get; set; }
    public bool HasSecondCertificate { get; set; }
    public int? ExamTimeInMinutesSecond { get; set; }
    public int? QuestionsNumberSecond { get; set; }
    public int? PassQuestionsNumberSecond { get; set; }
    public int? AttemptsNumberSecond { get; set; }
    public string Price { get; set; }
    public string OldPrice { get; set; }
    public bool IsFree { get; set; }
    public bool ComingSoon { get; set; }
    public int ID { get; set; }
    public string CategoryName { get; set; }
    public object PackageName { get; set; }

    // used in caourse content
    public int? CourseID { get; set; }
    public string CourseCategoryName { get; set; }
    public string CourseCategoryMainCategoryName { get; set; }
    public object CoursePackageName { get; set; }
    public string CourseName { get; set; }

    // used in course material
    public int? CourseContentID { get; set; }
    public string CourseContentCourseName { get; set; }
    public string CourseContentCourseCategoryName { get; set; }
    public object CourseContentCoursePackageName { get; set; }
    public string MaterialLink { get; set; }
    public string MaterialLinkContent
    {
        get
        {
            return
                string.IsNullOrEmpty(MaterialLink) ? "" :
                (MaterialLink.Contains("https://www.youtube.com/") ? MaterialLink : Services.ApiServices.BaseImage + MaterialLink);
        }
    }

    public object MaterialUrl { get; set; }
    public int? FileType { get; set; }
    public int? PartNumber { get; set; }
    public int? DurationInMinutes { get; set; }
    public string CourseContentName { get; set; }


    private Color textColor = Colors.DimGray;
    public Color TextColor
    {
        get => textColor;
        set => SetProperty(ref textColor, value);
    }

    private Color backgroundColor = Colors.White;
    public Color BackgroundColor
    {
        get => backgroundColor;
        set => SetProperty(ref backgroundColor, value);
    }

    private bool _IsSelected = false;
    public bool IsSelected
    {
        get => _IsSelected;
        set => SetProperty(ref _IsSelected, value);
    }

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
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
    {
        var changed = PropertyChanged;
        if (changed == null)
            return;

        changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}
