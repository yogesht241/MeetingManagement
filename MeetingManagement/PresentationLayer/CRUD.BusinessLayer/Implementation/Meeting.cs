using CRUD.BusinessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using CRUD.DataLayer.Entities;
using CRUD.DataLayer.Implementation;

namespace CRUD.BusinessLayer.Implementation
{
    public  class Meeting:IMeeting
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        private List<MeetingInfo> lstMeeting = new List<MeetingInfo>();
        private MeetingInfo objMeeting = new MeetingInfo();
        public IEnumerable<MeetingInfo> MeetingGet()
        {
            lstMeeting = unitOfWork.GetMeetingRepository.Get().ToList();

            return lstMeeting;
        }

        public string MeetingUpdate(MeetingInfo meeting)
        {

            objMeeting = unitOfWork.GetMeetingRepository.GetByID(meeting.MeetingID);

            if (objMeeting != null)
            {
                objMeeting.Subject = meeting.Subject;
                objMeeting.Agenda = meeting.Agenda;
                objMeeting.Attendees = meeting.Attendees;
                objMeeting.DateTime = meeting.DateTime;
                
            }
            this.unitOfWork.GetMeetingRepository.Attach(objMeeting);
            int result = this.unitOfWork.Save();

            if (result > 0)
            {
                return "Sucessfully updated of meeting records";
            }
            else
            {
                return "Updation faild";
            }
        }

        public string MeetingDelete(int id)
        {
            var objMeeting = this.unitOfWork.GetMeetingRepository.GetByID(id);
            this.unitOfWork.GetMeetingRepository.Delete(objMeeting);
            int deleteData = this.unitOfWork.Save();
            if (deleteData > 0)
            {
                return "Successfully deleted of meeting records";
            }
            else
            {
                return "Deletion faild";
            }
        }

        public string MeetingInsert(MeetingInfo meeting)
        {
            this.unitOfWork.GetMeetingRepository.Insert(meeting);
            int inserData = this.unitOfWork.Save();

            if (inserData > 0)
            {
                return "Successfully Inserted of meeting records";
            }
            else
            {
                return "Insertion faild";
            }
        }
    }
}

