﻿using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using WytSky.Mobile.Maui.Skoola.AppResources;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.APIs;
using WytSky.Mobile.Maui.Skoola.Models;
using WytSky.Mobile.Maui.Skoola.Views.Students;
using WytSky.Mobile.Maui.Skoola.Validations;
using WytSky.Mobile.Maui.Skoola.ViewModels.StudyGroups;

namespace WytSky.Mobile.Maui.Skoola.ViewModels.Students
{
    public partial class StudentsVM : CenterVM
    {
        [ObservableProperty] private ObservableCollection<StudentModel> students;
        [ObservableProperty] private ObservableCollection<StudentModel> filteredStudents = new ObservableCollection<StudentModel>();

        [ObservableProperty] private ObservableCollection<StudentModel> lastAddedStudent;
        [ObservableProperty] private string searchText;
        // add student popup
        [ObservableProperty] private string  studentName;
        #region Register Values
        [ObservableProperty]
        public ValidatableObject<string> userName = new ValidatableObject<string>();
        [ObservableProperty]
        public ValidatableObject<string> email = new ValidatableObject<string>();
        [ObservableProperty]
        public ValidatableObject<string> phone = new ValidatableObject<string>();
        [ObservableProperty]
        public ValidatableObject<string> password = new ValidatableObject<string>();
        [ObservableProperty]
        public ValidatableObject<string> confirmPassword = new ValidatableObject<string>();
        [ObservableProperty]
        public string regVerficationCode;
        #endregion
        //public StudentsVM()
        //{
        //     GetStudentsByCenterId();
        //}
        public async Task GetStudentsByStudyGroupId()
        {
            IsRunning = true;
            try
            {
                Students = await StudentService.GetStudents();
                FilteredStudents = new ObservableCollection<StudentModel>(Students);
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "StudentsVM", "GetStudentsByStudyGroupId");
            }
            finally
            {
                IsRunning = false;
            }
        }
        public async Task GetStudentsByCenterId()
        {
            IsRunning = true;
            try
            {
                Students = await StudentService.GetStudentsByCenterId();
                FilteredStudents = new ObservableCollection<StudentModel>(Students);
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "StudentsVM", "GetStudentsByCenterId");

            }
            finally 
            { 
                IsRunning = false; 
            }
            
        }
        partial void OnSearchTextChanging(string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    FilteredStudents =
                        new ObservableCollection<StudentModel>(Students.Where(x => x.FullName.ToLower().Contains(value)).ToList());
                }
                else
                {
                    FilteredStudents = Students;
                }
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "StudentsVM", "OnSearchTextChanging");
            }
        }

        [RelayCommand]
        public void OpenAddStudent()
        {
            try
            {
                var popup = new AddStudentPopup();
                popup.BindingContext = this;
                ShowPopup(popup);
            }
            catch (Exception ex)
            {
                ExtensionLogMethods.LogExtension(ex, "", "StaffVM", "OpenAddStudent");
            }

        }

        [RelayCommand]
        public async Task AddStudent(string fromStudyGroup)
        {
            try
            {
                var userName = UserName.Value.Replace(" ", "");
                if (ChekRegisterData())
                {
                    Dictionary<string, string> keys = new Dictionary<string, string>()
                    {
                        { "Email", Email.Value}
                    };
                    var clinte = await APIs.ServiceClient.GetAll(filter: keys);
                    if (clinte != null && clinte.Count > 0)
                    {
                        Toast.ShowToastError(SharedResources.Msg_EmailAlreadyUse);
                        Settings.Password = "";
                        Settings.UserName = "";
                        return;
                    }
                    Dictionary<string, string> keys2 = new Dictionary<string, string>()
                    {
                        { "UserName", userName}
                    };
                    var user = await APIs.ServiceAspNetUser.GetAll(filter: keys2);
                    if (user != null && user.Count > 0)
                    {
                        Toast.ShowToastError(SharedResources.Msg_EmailAlreadyUse);
                        Settings.Password = "";
                        Settings.UserName = "";
                        return;
                    }
                    Random _random = new Random();
                    var NewClient = await APIs.ServiceClient.SaveNew(new Dictionary<string, object>()
                    {
                            {"ClientTypeID","2" },
                            {"FullName", userName},
                            {"Phone", Phone.Value },
                            {"Email", Email.Value  },
                            {"PasswordHash",SecurityHelper.EncodePasswordmosso(Password.Value) },
                        });
                    var NewUser = await APIs.ServiceAspNetUser.SaveNew(new Dictionary<string, object>()
                    {
                        {"Email", Email.Value },
                        {"UserName", userName  },
                        {"PhoneNumber", Phone.Value  },
                        {"PasswordHash",SecurityHelper.EncodePasswordmosso(Password.Value) },
                        {"UserTypeID","4" },
                        {"Confirmed","false" },
                        {"EmailConfirmed","false" },
                        {"IsApproved","true" },
                        {"PhoneNumberConfirmed","false" },
                        {"LastLoginDate",DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") },
                        {"LastActivityDate",DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") },
                        {"LastPasswordChangedDate",DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") },
                        {"LastLockedOutDate",DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") },
                        {"LastLockoutDate",DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") },
                    });
                    var addedStudent = await StudentService.AddStudent(new Dictionary<string, object>()
                    {
                        { "GroupID", Settings.StudyGroupId },
                        { "FullName", userName },
                        { "Status", "1" },
                        { "Email", Email.Value },
                        { "PhoneNumber", Phone.Value  },
                        { "CenterID", Settings.CenterId  },
                        { "ComplexID", Settings.ComplexId  },
          
                    });

                    if (addedStudent != null && addedStudent.rowsAffected > 0)
                    {

                        await GetStudentsByStudyGroupId();
                        LastAddedStudent =  await StudentService.GetStudents();
                        if (fromStudyGroup == "fromS")
                        {
                            await AddNewStudentStudyGroupList(LastAddedStudent.Select(s=> s.StudentID.ToString()).First());
                        }
                        Toast.ShowToastError(SharedResources.AddedSuccessfully);
                        
                    }
                }
            }

            catch (Exception e)
            {
                ExtensionLogMethods.LogExtension(e, "", "StudentsVM", "AddStudent");
            }
            finally
            {
                HidePopup();
            }
        }
        private bool ChekRegisterData()
        {
            try
            {
                if (string.IsNullOrEmpty(UserName.Value) || UserName.Value.Length < 5)
                {
                    Toast.ShowToastError(SharedResources.Msg_NotValidName);
                    return false;
                }
                else if (string.IsNullOrEmpty(Email.Value) || !Behaviors.EmailValidBehavior.RegexIsMatch(Email.Value))
                {
                    Toast.ShowToastError(SharedResources.Msg_NotValidEmail);
                    return false;
                }
                else if (string.IsNullOrEmpty(Password.Value) || !Behaviors.PasswordValidBehavior.RegexIsMatch(Password.Value))
                {
                    Toast.ShowToastError(SharedResources.Msg_PasswordValdation);
                    return false;
                }
                else if (string.IsNullOrEmpty(ConfirmPassword.Value) || Password.Value != ConfirmPassword.Value)
                {
                    Toast.ShowToastError(SharedResources.Msg_PasswordNotMatch);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "SignInSignUpVM", "update");
                return false;
            }
        }
    }
}
