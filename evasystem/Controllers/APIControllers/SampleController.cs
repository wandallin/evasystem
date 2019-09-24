using evasystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static evasystem.Models.Enums.EnumClass;
using evasystem.BAL;

namespace evasystem.Controllers.APIControllers
{
    public class SampleController : ApiBaseController
    {
        SampleService oSampleService = new SampleService();

        [HttpGet]
        [Route("api/v1/Sample/GetSampleInfo")]
        public ApiResponse<SampleResultViewModel> GetSampleInfo()
        {
            ApiResponse<SampleResultViewModel> apiResponse = new ApiResponse<SampleResultViewModel>();
            try
            {
                apiResponse.Result.Obj = oSampleService.GetSampleInfo();
            }
            catch (Exception ex)
            {

            }
            return apiResponse;
        }

        [HttpGet]
        [Route("api/v1/Sample/Get")]
        public ApiResponse<SampleResultViewModel> Get(string id)
        {
            ApiResponse<SampleResultViewModel> apiResponse = new ApiResponse<SampleResultViewModel>();
            try
            {
                //判斷輸入參數有無問題
                if (string.IsNullOrWhiteSpace(id))
                {
                    return new ApiResponse<SampleResultViewModel>(EnumApiStatus.API_ParameterError);
                }
                apiResponse.Result.Obj = new List<SampleObjViewModel>()
                {
                     new SampleObjViewModel {
                          Id =id,
                           Name = id+"_Name",
                     }
                };
            }
            catch (Exception)
            {
                apiResponse.ErrorSetting();
            }
            return apiResponse;
        }
        [HttpGet]
        [Route("api/v1/Sample/Get2/{id}")]
        public ApiResponse<SampleResultViewModel> Get2(string id)
        {
            ApiResponse<SampleResultViewModel> apiResponse = new ApiResponse<SampleResultViewModel>();
            try
            {
                //判斷輸入參數有無問題
                if (string.IsNullOrWhiteSpace(id))
                {
                    return new ApiResponse<SampleResultViewModel>(EnumApiStatus.API_ParameterError);
                }
                apiResponse.Result.Obj = new List<SampleObjViewModel>()
                {
                     new SampleObjViewModel {
                          Id =id,
                           Name = id+"_Name",
                     }
                };
            }
            catch (Exception)
            {
                apiResponse.ErrorSetting();
            }
            return apiResponse;
        }
    }
}
