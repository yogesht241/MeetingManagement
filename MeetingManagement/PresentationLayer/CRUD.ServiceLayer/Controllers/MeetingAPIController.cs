using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUD.DataLayer.Entities;
using CRUD.BusinessLayer.Implementation;
using CRUD.BusinessLayer.Interfaces;

namespace CRUD.ServiceLayer.Controllers
{
    [System.Web.Http.RoutePrefix("api/Meeting")]
    public class MeetingAPIController : ApiController
    {
        // IEmployee objEmp = new Employee();

        IMeeting objMeeting = new Meeting();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("MeetingDetails")]
        public IEnumerable<MeetingInfo> GetEmployeeData()
        {


            IEnumerable<MeetingInfo> meetingDetail = new List<MeetingInfo>();
            try
            {
                meetingDetail = objMeeting.MeetingGet();
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return meetingDetail;
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("InsertMeetingDetails")]
        public string InserMeeting(MeetingInfo objMeetingDetails)
        {
            string objMeeting;
            try
            {
                objMeeting = this.objMeeting.MeetingInsert(objMeetingDetails);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return objMeeting;
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("UpdateMeetingDetails")]
        public string UpdateMeeting(MeetingInfo objMeetingDetails)
        {
            string objEmployee;
            try
            {
                objEmployee = this.objMeeting.MeetingUpdate(objMeetingDetails);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return objEmployee;
        }
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("DeleteMeetingData/{id}")]
        public string DeleteMeetingData(int id)
        {
            string objMeetingDetails;
            try
            {
                objMeetingDetails = this.objMeeting.MeetingDelete(id);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return objMeetingDetails;
        }
    }
}

