/// <reference path="jqGrid/jquery.jqGrid.js" />

var MeetingDetails = {

	GetMeetingData: function () {
		$("#list").jqGrid({
			url: '/Meeting/MeetingInfoData',
			datatype: 'json',
			mtype: 'Get',
			colModel: [
				{
					key: true, hidden: true, name: 'MeetingID', index: 'MeetingID', editable: true
				},

				{ name: 'Subject', index: 'Subject', width: 245, editable: true, editrules: { required: true }, },

				{ name: 'Agenda', index: 'Agenda', width: 245, editable: true, editrules: { required: true }, },

				{ name: 'Attendees', index: 'Attendees', width: 245, editable: true, editrules: { required: true }, },

				{ name: 'DateTime', index: 'DateTime', width: 245, editable: true, datefmt: 'm/d/Y', "formatter": "date", "formatoptions": { "srcformat": "Y-m-d", "newformat": "m/d/Y" }, editrules: { required: true }, }
			],
			pager: jQuery('#pager'),
			rowNum: 10,
			loadonce: true,
			rowList: [10, 20, 30, 40],
			height: '100%',
			viewrecords: true,
			caption: 'Meeting Details',
			emptyrecords: 'No records to display',
			jsonReader: {
				repeatitems: false,
				root: function (obj) { return obj; },
				page: "page",
				total: "total",
				records: "records",
				repeatitems: false,
				EmployeeNo: "0"
			},
			autowidth: true,
			multiselect: false
		}).navGrid('#pager', { add: false, edit: true, del: true, search: false, refresh: true },
			{
				// edit options
				zIndex: 1000,
				url: '/Meeting/UpdateMeetingInfo',
				closeOnEscape: true,
				closeAfterEdit: true,
				recreateForm: true,
				loadonce: true,
				align: 'center',
				afterComplete: function (response) {
					GetMeetingData()
					if (response.responseText) {

						alert(response.responseText);
					}
				}
			}, {},
			{
				// delete options
				zIndex: 1000,
				url: '/Meeting/DeleteMeetingInfo',
				closeOnEscape: true,
				closeAfterdel: true,
				recreateForm: true,
				msg: "Are you sure you want to delete this task?",
				afterComplete: function (response) {
					if (response.responseText) {
						$("#alert-Grid").html("<b>" + response.responseText + "</b>");
						$("#alert-Grid").show();
						$("#alert-Grid").delay(3000).fadeOut("slow");
					}
				}
			});
	},
	insertMeetingDetails: function () {

		$("#btnSubmit").click(function () {
			//debugger;
			var msg = "";

			if ($('#txtSubject').val() == "") {
				msg = "Please Enter Subject";
				alert(msg);
				e.preventDefault();
				return false;
			}
			if ($('#txtDate').val() == "") {
				msg = "Please Enter Date";
				alert(msg);
				e.preventDefault();
				return false;
			}
			if ($('#txtAgenda').val() == "") {
				msg = "Please Enter Agenda";
				alert(msg);
				e.preventDefault();
				return false;
			}
			
			if ($('#cmbAttendees').val() == null) {
				msg = "Please Enter Attendees";
				alert(msg);
				e.preventDefault();
				return false;
			}
			if ($("select option:selected").length-1 > 3) {
				//your code here
				alert('You can select upto 3 options only');

				return false;
			}
			$.ajax(
				{
					type: "POST", //HTTP POST Method  
					url: "/Meeting/InsertMeetingInfo", // Controller/View   
					data: { //Passing data  

						SubJect: $("#txtSubject").val(), //Reading text box values using Jquery   
						Agenda: $("#txtAgenda").val(),
						Attendees: $("#txtAttendees").val(),
						DateTime: $("#txtDate").val()

					},
					success: function (data) {
						alert(data);
						$("##alert-danger").html("<b>" + data + "</b>");
						$("##alert-danger").show();
						$("##alert-danger").delay(10000).fadeOut("slow");
						$("tblgrid").show();
					},
					error: function (data) {
						GetMeetingData();
						//var r = data.responseText;
						//var errorMessage = r.Message;
						$("##alert-danger").html("<b>" + data + "</b>");
						$("##alert-danger").show();
						$("##alert-danger").delay(10000).fadeOut("slow");
					}
				});

		});
	}
}

