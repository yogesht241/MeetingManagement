using System.Collections.Generic;
using CRUD.DataLayer.Entities;

namespace CRUD.BusinessLayer.Interfaces
{
  public  interface IMeeting
    {
        IEnumerable<MeetingInfo> MeetingGet();
        string MeetingInsert(MeetingInfo meeting);
        string MeetingUpdate(MeetingInfo meeting);
        string MeetingDelete(int id);
    }
}
