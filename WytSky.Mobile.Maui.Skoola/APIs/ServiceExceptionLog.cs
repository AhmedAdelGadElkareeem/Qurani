using System;
using System.Collections.Generic;
using System.Text;

namespace WytSky.Mobile.Maui.Skoola.APIs
{
    public class ServiceExceptionLog
    {
        public const string CONTROLR = "api/ExceptionLog";
        
        #region Update(Dtos.ExceptionLogDto model)
        public async static System.Threading.Tasks.Task<Dtos.ExceptionLogDto> Update(Dtos.ExceptionLogDto model)
        {
            try
            {
                var result = await Services.RequestProvider.Current.PutData<Dtos.ExceptionLogDto, Dtos.ExceptionLogDto>(model, CONTROLR, "Update", null);
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
                System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
                return null;
            }
        }
        #endregion

        #region SaveNew(Dtos.ExceptionLogDto model)
        public async static System.Threading.Tasks.Task<Dtos.ExceptionLogDto> SaveNew(Dtos.ExceptionLogDto model)
        {
            try
            {
                var result = await Services.RequestProvider.Current.PostDataIgnoreException<Dtos.ExceptionLogDto, Dtos.ExceptionLogDto>(model, CONTROLR, "SaveNew", null);
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
                System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
                return null;
            }
        }
        #endregion

        #region GetAll()
        public async static System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Dtos.ExceptionLogDto>> GetAll()
        {
            try
            {
                var result = await Services.RequestProvider.Current.GetData<Models.TempletData<Dtos.ExceptionLogDto>>(CONTROLR, "GetAll", null);
                if (result != null && result.IsPassed)
                {
                    return result.Data.ItemData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
                return null;
            }
        }
        #endregion

        #region GetAvailable()
        public async static System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Dtos.ExceptionLogDto>> GetAvailable()
        {
            try
            {
                var result = await Services.RequestProvider.Current.GetData<Models.TempletData<Dtos.ExceptionLogDto>>(CONTROLR, "GetAvailable", null);
                if (result != null && result.IsPassed)
                {
                    return result.Data.ItemData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
                return null;
            }
        }
        #endregion

        #region GetById(Guid id)
        public async static System.Threading.Tasks.Task<Dtos.ExceptionLogDto> GetById(Guid id)
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>()
                {
                    {"id", id + ""},
                };
                var result = await Services.RequestProvider.Current.GetData<Dtos.ExceptionLogDto>(CONTROLR, "GetById", dictionary);
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
                System.Diagnostics.Debug.WriteLine(string.Format(" Error : {0} - {1} ", ex.Message, ex.InnerException != null ? ex.InnerException.FullMessage() : ""));
                return null;
            }
        }
        #endregion
    }
}
