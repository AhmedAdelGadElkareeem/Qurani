﻿using System.Collections.ObjectModel;
using WytSky.Mobile.Maui.Skoola.Helpers;
using WytSky.Mobile.Maui.Skoola.Models;

namespace WytSky.Mobile.Maui.Skoola.APIs
{
    public class StudentService
    {
        private const string BASE = "appservices";
        private const string CONTROLR = "students";

        //https://qr.saskw.net/appservices/studygroupstudentlist?_datatype=json&_jsonarray=1
        #region Get Students
        public static async Task<ObservableCollection<StudentModel>> GetStudents()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };

                if (!string.IsNullOrEmpty(Settings.StudyGroupId))
                    dictionary.Add("GroupID", Settings.StudyGroupId);

                //else  dictionary.Add("GroupID", Settings.CenterId);

                var result = await Services.RequestProvider.Current.GetData<TempletData<StudentModel>>(BASE, "students", dictionary, Enums.AuthorizationType.UserNamePassword);
                if (result != null && result.IsPassed)
                {
                    return result.Data.itemData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "StudentService", "GetStudents");
                return null;
            }
        }
        #endregion

        //public static async Task<ObservableCollection<StudentModel>> GetStudentById( string studentId)
        //{
        //    try
        //    {
        //        var dictionary = new Dictionary<string, string>()
        //        {
        //              {"_datatype", "json"},
        //              {"_jsonarray", "1"},
        //        };

        //        if (!string.IsNullOrEmpty(studentId))
        //            dictionary.Add("StudentD", studentId);

        //        else  dictionary.Add("StudentID", Settings.CenterId);

        //        var result = await Services.RequestProvider.Current.GetData<TempletData<StudentModel>>(BASE, "students", dictionary, Enums.AuthorizationType.UserNamePassword);
        //        if (result != null && result.IsPassed)
        //        {
        //            return result.Data.itemData;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
        //        System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
        //        ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "StudentService", "GetStudents");
        //        return null;
        //    }
        //}

        #region Get All Students
        public static async Task<ObservableCollection<StudentModel>> GetAllStudents()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };

                //if (!string.IsNullOrEmpty(Settings.StudyGroupId))
                //    dictionary.Add("GroupID", Settings.StudyGroupId);

                //else  dictionary.Add("GroupID", Settings.CenterId);

                var result = await Services.RequestProvider.Current.GetData<TempletData<StudentModel>>(BASE, "students", dictionary, Enums.AuthorizationType.UserNamePassword);
                if (result != null && result.IsPassed)
                {
                    return result.Data.itemData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "StudentService", "GetStudents");
                return null;
            }
        }

        public static async Task<ObservableCollection<StudyGroupStudentList>> GetStudyGroupStudentList()
        {
            try
            {
                var dictionary = new Dictionary<string, string>()
                {
                      {"_datatype", "json"},
                      {"_jsonarray", "1"},
                };

  
                dictionary.Add("GroupID", Settings.StudyGroupId);

                var result = await Services.RequestProvider.Current.GetData<TempletData<StudyGroupStudentList>>(BASE, "studygroupstudentlist", dictionary, Enums.AuthorizationType.UserNamePassword);
                if (result != null && result.IsPassed)
                {
                    return result.Data.itemData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
                ExtensionLogMethods.LogExtension(ExceptionMseeage, "", "StudentService", "GetStudyGroupStudentList");
                return null;
            }
        }
        #endregion

        #region Add Student
        public static async Task<Dtos.ReturnData> AddStudent(Dictionary<string, object> formData)
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>()
                {
                    {"_datatype","json"},
                    {"_jsonarray","1"},
                };

                var result = await Services.RequestProvider.Current.PostDataMultipart<Dtos.ReturnData>(BASE, CONTROLR, dictionary, formData, Enums.AuthorizationType.UserNamePassword);
                if (result != null && result.IsPassed)
                {
                    return result.Data;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string ExceptionMseeage = string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : "");
                System.Diagnostics.Debug.WriteLine(ExceptionMseeage);
                ExtensionLogMethods.LogExtension(ExceptionMseeage, System.Text.Json.JsonSerializer.Serialize(formData), "ServiceItem", "SaveNew()");
                return null;
            }
        }
        #endregion
    }
}
