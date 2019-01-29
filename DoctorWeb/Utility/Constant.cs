using System;

namespace DoctorWeb.Utility
{
    public static class Constant
    {
        public static string drWebUrl = "http://drweb-sys.com/Account/Login";
        public static string drWebTestUrl = "http://test.drweb-sys.com/Account/Login";


        public static string comment = "+++++++New Test++++++" + Environment.NewLine + Environment.NewLine;

        public static string groupUser = "reut@doctorwin.co.il";
        public static string adminUser = "test@doctorwin.co.il";
        public static string loginPassword = "zxcv1234";

        public static string therapistUser = "therapist@doctorwin.co.il";

        public static string clerkUser = "clerk@doctorwin.co.il";

        public static string unauthorizedUserName = "test02@test02.co.il";

        public static string patientName = "selenium" + RandomNumber.smallNumber();
        public static string patientLastname = "test";

        public static string supplierName = "supplier" + RandomNumber.smallNumber();
        public static string suppContactName = "test" + RandomNumber.smallNumber();
        public static string suppContactLast = "one";
        public static string suppContactPhone = RandomNumber.smallNumber();

        public static string contactName = "contact" + RandomNumber.smallNumber();
        public static string contactLast = "Test";
        public static string contactPhone = RandomNumber.smallNumber();

        public static string businessName = "Clinic" + RandomNumber.smallNumber();
        public static string businessNum = RandomNumber.smallNumber();
        public static string businessAddress = "Addres 101";
        public static string businessEmail = "Sanity" + RandomNumber.smallNumber() + "@test.com";

        public static string branchAddress = "Adress" + RandomNumber.smallNumber();

        public static string departmentName = "depart";

        public static string userName = "Doctor" + RandomNumber.smallNumber();
        public static string userLastName = RandomNumber.smallNumber();
        public static string userEmail = "doctor" + RandomNumber.smallNumber() + "@doctorwin.co.il";
        public static string userPhone = RandomNumber.smallNumber();

        public static string groupName = "group";

        public static string medicineName = "Medicine" + RandomNumber.smallNumber();
        public static string anamnezaName = "Anamneza" + RandomNumber.smallNumber();
        public static string noteName = "Note" + RandomNumber.smallNumber();

        public static string fieldName = "field" + RandomNumber.smallNumber();

        public static string relationPatiant = "Relation101";

        public static string downloadPath = "D:\\seleniumdownloads";

        public static string UserNameEdit = "NameEdit";
        public static string UserLastnameEdit = "Edit";

        public static string CategoryName = "Category";

        public static string priceListName = "Name" + RandomNumber.smallNumber();
        public static string priceListCode = "K" + RandomNumber.smallNumber();

        public static string priceListTax = RandomNumber.taxNumber();

        public static string practiceName = "Expertise" + RandomNumber.smallNumber();
        public static string practiceNameEdit = "Edit" + RandomNumber.smallNumber();

        public static string dateMinusMonth = DateTime.Today.AddMonths(-1).ToString();
        public static string datePlusMonth = DateTime.Today.AddMonths(+1).ToString();

        public static string stackTraceFalse = "Test Failed for True statement";
        public static string stackTraceTrue = "Test Failed for False statement";
        public static string stackTraceNotNull = "Test Failed for Startment was null";
        public static string stackTraceNull = "Test Failed for Startment was Not null";

        public static string WarningMsg = "Test failed due to step invalid";

        public static string uploadDocument = "importtest01.csv";

        public static string ICDData = "A01";

        public static string CancelReason = "Reason" + RandomNumber.smallNumber();

        public static string closeTabBeforeSave = "לא שמרת את נתוני המטופל החדש והנך עומד לסגור את טאב המטופל, האם לסגור את הטאב?";

        public static string CloseTable = "CloseTable";
        public static string OpenTable = "OpenTable";
        public static string Save = "Save";
        public static string Edit = "Edit";
        public static string PopupSave = "PopupSave";
        public static string PopupCancel = "PopupCancel";
        public static string Delete = "Delete";
        public static string Approve = "Approve";
        public static string Create = "CreateNew";
        public static string Checkbox = "Mark Checkbox";
        public static string Dropdown = "Select Dropdown";
        public static string Click = "Button";
        public static string CloseWindow = "CloseWindow";
        public static string Select = "Selected From List";


    }
}
