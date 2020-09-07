using System;
using System.Web.Mvc;
using PersentationLayer.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System.Collections.Generic;

namespace PersentationLayer.Controllers
{
    public class MeetingController : Controller
    {
        private RestClient restClient = new RestClient();
        // GET: Employee
        public ActionResult MeetingDetails()
        {
            return this.View();
        }
        public async Task<ActionResult> MeetingInfoData()
        {
            try
            {

                return this.Json(await this.restClient.RunAsyncGetAll<Meetings, Meetings>("api/Meeting/MeetingDetails"), JsonRequestBehavior.AllowGet);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
        }

        public async Task<ActionResult> AttendeeData()
        {
            try
            {

                return this.Json(await this.restClient.RunAsyncGetAll<Attendees, Attendees>("api/Meeting/AttendeesDetails"), JsonRequestBehavior.AllowGet);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
        }


        public async Task<ActionResult> MeetingInsertData(Meetings objMeeting)
        {
            try
            {
                return this.Json(await this.restClient.RunAsyncPost<Meetings, string>("api/ConfigSetting/InsertConfigSetting", objMeeting));
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
        }

        public async Task<ActionResult> InsertMeetingInfo(Meetings objMeeting)
        {
            try
            {
               
                return this.Json(await this.restClient.RunAsyncPost<Meetings, string>("api/Meeting/InsertMeetingDetails", objMeeting));
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
        }
        public async Task<ActionResult> UpdateMeetingInfo(Meetings objMeeting)
        {
            try
            {
                return this.Json(await this.restClient.RunAsyncPut<Meetings, string>("api/Meeting/UpdateMeetingDetails", objMeeting));
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
        }


        public async Task<ActionResult> DeleteMeetingInfo(int id)
        {
            try
            {
                return this.Json(await this.restClient.RunAsyncDelete<int, string>("api/Meeting/DeleteMeetingData", id));
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
        }

    }
}