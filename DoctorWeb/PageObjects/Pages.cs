using DoctorWeb.PageObjects;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace DoctorWeb
{
    public static class Pages
    {
        // private static IWebDriver webDriver = new ChromeDriver();

        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browser.Driver, page);
            return page;
        }

        public static Login_Page Login_Page
        {
            get { return GetPage<Login_Page>();}
        }

        public static Home_Page Home_Page
        {
            get { return GetPage<Home_Page>(); }
        }

        public static Patient_Page Patient_Page
        {
            get { return GetPage<Patient_Page>(); }
        }

        public static PatientMedical_Page PatientMedical_Page
        {
            get { return GetPage<PatientMedical_Page>(); }
        }

        public static PatientFamily_Page PatientFamily_Page
        {
            get { return GetPage<PatientFamily_Page>(); }
        }

        public static PatientDoc_Page PatientDoc_Page
        {
            get { return GetPage<PatientDoc_Page>(); }
        }

        public static Business_Page Business_Page
        {
            get { return GetPage<Business_Page>(); }
        }

        public static PriceList_Page PriceList_Page
        {
            get { return GetPage<PriceList_Page>(); }
        }

        public static Reports_Page Reports_Page
        {
            get { return GetPage<Reports_Page>(); }
        }

        public static Supplier_Page Supplier_Page
        {
            get { return GetPage<Supplier_Page>(); }
        }

        public static UserProfile_Page UserProfile_Page
        {
            get { return GetPage<UserProfile_Page>(); }
        }

        public static AdditinalFields_Page AdditinalFields_Page
        {
            get { return GetPage<AdditinalFields_Page>(); }
        }

        public static Authorization_Page Authorization_Page
        {
            get { return GetPage<Authorization_Page>(); }
        }

        public static UsersManagement_Page UsersManagement_Page
        {
            get { return GetPage<UsersManagement_Page>(); }
        }

        public static CancelledMeeting_Page CancelledMeeting_Page
        {
            get { return GetPage<CancelledMeeting_Page>(); }
        }

        public static BlockOpen_Page BlockOpen_Page
        {
            get { return GetPage<BlockOpen_Page>(); }
        }

        public static StandbyList_Page StandbyList_Page
        {
            get { return GetPage<StandbyList_Page>(); }
        }

        public static Scheduler_Page Scheduler_Page
        {
            get { return GetPage<Scheduler_Page>(); }
        }

        public static Document_Page Document_Page
        {
            get { return GetPage<Document_Page>(); }
        }

        public static Visits_Page Visits_Page
        {
            get { return GetPage<Visits_Page>(); }
        }

        public static Messages_Page Messages_Page
        {
            get { return GetPage<Messages_Page>(); }
        }

        public static Contact_Page Contact_Page
        {
            get { return GetPage<Contact_Page>(); }
        }

        public static Meeting_Page Meeting_Page
        {
            get { return GetPage<Meeting_Page>(); }
        }

        public static Standby_Page Standby_Page
        {
            get { return GetPage<Standby_Page>(); }
        }

        public static AvailbleTime_Page AvailbleTime_Page
        {
            get { return GetPage<AvailbleTime_Page>(); }
        }

        public static CancelReason_Page CancelReason_Page
        {
            get { return GetPage<CancelReason_Page>(); }
        }

        public static DevPriceList_Page DevPriceList_Page
        {
            get { return GetPage<DevPriceList_Page>(); }
        }

        public static PriceListTax_Page PriceListTax_Page
        {
            get { return GetPage<PriceListTax_Page>(); }
        }

        public static PriceListType_Page PriceListType_Page
        {
            get { return GetPage<PriceListType_Page>(); }
        }

        public static PriceListUpdate_Page PriceListUpdate_Page
        {
            get { return GetPage<PriceListUpdate_Page>(); }
        }

        public static Treatment_Page Treatment_Page
        {
            get { return GetPage<Treatment_Page>(); }
        }

    }
}
