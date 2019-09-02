using DoctorWeb.Utility;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DoctorWeb.PageObjects
{
    public class Forms_Page
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();
   

        [FindsBy(How = How.XPath, Using = "//[contains(text(), 'מועד שליחה)]")]
        [CacheLookup]
        public IWebElement PatientValidation { get; set; }

        [FindsBy(How = How.Id, Using = "txtFilterForms")]
        [CacheLookup]
        public IWebElement FormsSearchField { get; set; }

        [FindsBy(How = How.Id, Using = "btnFormCategories")]
        [CacheLookup]
        public IWebElement FormsCategoryBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnFormCategoryManagerCreateNew")]
        [CacheLookup]
        public IWebElement CreateNewCategory { get; set; }
        
        [FindsBy(How = How.Id, Using = "Name")]
        [CacheLookup]
        public IWebElement CategoryName { get; set; }

        [FindsBy(How = How.Id, Using = "Name_validationMessage")]
        [CacheLookup]
        public IWebElement NameValidation { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='FormCategoryManagmentGrid']/div[2]/table/tbody/tr[1]/td[3]/a[1]")]
        [CacheLookup]
        public IWebElement SaveCategory { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='FormCategoryManagmentGrid']/div[2]/table/tbody/tr[1]/td[3]/a[2]")]
        [CacheLookup]
        public IWebElement CancelSaveCategory { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='FormCategoryManagmentGrid']/div[2]/table/tbody/tr[1]/td[3]/a[1]")]
        [CacheLookup]
        public IWebElement EditCategory { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='FormCategoryManagmentGrid']/div[2]/table/tbody/tr[1]/td[3]/a[2]")]
        [CacheLookup]
        public IWebElement DeleteCategory { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-OK")]
        [CacheLookup]
        public IWebElement PopupApprove { get; set; }

        public string formsCategoryTableCount = "//*[@id='FormCategoryManagmentGrid']/div[2]/table/tbody";


        public void GoTo() {
            Pages.Home_Page.FormsScreen.ClickWait();
            softAssert.VerifyElementIsPresent(FormsSearchField);
        }

        public void OpenFormsCategory() {
            FormsCategoryBtn.ClickOn();
            softAssert.VerifyElementIsPresent(CreateNewCategory);
            Constant.tmpTableCount = utility.TableCount(formsCategoryTableCount);
        }

        public void CreateFormsCategoryApplication() {
            CreateNewCategory.ClickOn();
            //CreateNewCategory.ClickOn();
            CategoryName.SendKeys(Constant.CategoryName);
            SaveCategory.ClickOn();
            softAssert.VerifyElementHasEqual(utility.TableCount(formsCategoryTableCount), Constant.tmpTableCount+1);
        }

        public void EditFormsCategoryApplication() {
            EditCategory.ClickOn();
            CategoryName.Clear();
            SaveCategory.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(NameValidation, Pages.Home_Page.PopupCloseClass);
            CategoryName.SendKeys(Constant.Edit + RandomNumber.smallNumber());
            SaveCategory.ClickOn();
            softAssert.VerifyElementPresentInsideWindow(DeleteCategory, Pages.Home_Page.PopupCloseClass);
        }

        public void DeleteFormsCategoryApplication() {
            DeleteCategory.ClickOn();
            PopupApprove.ClickWait();
            softAssert.VerifyElementHasEqualInsideWindow(utility.TableCount(formsCategoryTableCount), Constant.tmpTableCount, Pages.Home_Page.PopupCloseClass);
            Pages.Home_Page.PopupCloseClass.ClickOn() ;
        }

    }
}
