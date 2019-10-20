using DoctorWeb.Utility;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System.Linq;
using System.Threading;

namespace DoctorWeb.PageObjects
{
    public class Forms_Page
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AssertionExtent softAssert = new AssertionExtent();
        UtilityFunction utility = new UtilityFunction();
   

        [FindsBy(How = How.XPath, Using = "//[contains(text(), 'מועד שליחה)]")]
        
        public IWebElement PatientValidation { get; set; }

        [FindsBy(How = How.Id, Using = "txtFilterForms")]
        
        public IWebElement FormsSearchField { get; set; }

        [FindsBy(How = How.Id, Using = "btnFormCategories")]
        
        public IWebElement FormsCategoryBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnFormCategoryManagerCreateNew")]
        
        public IWebElement CreateNewCategory { get; set; }
        
        [FindsBy(How = How.Id, Using = "Name")]
        
        public IWebElement CategoryName { get; set; }

        [FindsBy(How = How.Id, Using = "Name_validationMessage")]
        
        public IWebElement NameValidation { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='FormCategoryManagmentGrid']/div[2]/table/tbody/tr[1]/td[3]/a[1]")]
        
        public IWebElement SaveCategory { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='FormCategoryManagmentGrid']/div[2]/table/tbody/tr[1]/td[3]/a[2]")]
        
        public IWebElement CancelSaveCategory { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='FormCategoryManagmentGrid']/div[2]/table/tbody/tr[1]/td[3]/a[1]")]
        
        public IWebElement EditCategory { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='FormCategoryManagmentGrid']/div[2]/table/tbody/tr[1]/td[3]/a[2]")]
        
        public IWebElement DeleteCategory { get; set; }

        [FindsBy(How = How.Id, Using = "popup-btn-OK")]
        
        public IWebElement PopupApprove { get; set; }

        [FindsBy(How = How.Id, Using = "btnCreateNewForm")]
        
        public IWebElement CreateNewForm { get; set; }

        [FindsBy(How = How.Id, Using = "FormName")]
        
        public IWebElement FormName { get; set; }

        [FindsBy(How = How.Id, Using = "FormTitle")]
        
        public IWebElement FormTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='create-form-header-box']/div[2]/div/div[2]/span")]
        
        public IWebElement FormSelectDepartment { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='create-form-header-box']/div[2]/div/div[3]/span")]
        
        public IWebElement FormSelectCategory { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveForm")]
        
        public IWebElement SaveForm { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='pages-container']/div")]
        
        public IWebElement FormComponentAreaDrop { get; set; }

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
            softAssert.VerifySuccessMsg();
        }

        public void DeleteFormsCategoryApplication() {
            DeleteCategory.ClickOn();
            PopupApprove.ClickWait();
            softAssert.VerifyElementHasEqualInsideWindow(utility.TableCount(formsCategoryTableCount), Constant.tmpTableCount, Pages.Home_Page.PopupCloseClass);
            Pages.Home_Page.PopupCloseClass.ClickOn() ;
        }

        public void EnterNewPatientForm() {
            CreateNewForm.ClickOn();
            IWebElement formList = Browser.Driver.FindElement(By.Id("nmuCreateNewForm"));
            formList.FindElements(By.TagName("li")).ElementAt(0).ClickOn();
            softAssert.VerifyElementIsPresent(FormName);
        }
        public void CreateNewInteractiveForm()
        {
            CreateNewForm.ClickOn();
            IWebElement formList = Browser.Driver.FindElement(By.Id("nmuCreateNewForm"));
            formList.FindElements(By.TagName("li")).ElementAt(1).SendKeys(Constant.fileForTest);
            Thread.Sleep(500);
            softAssert.VerifyElementIsPresent(FormName);
        }

        public void CreateNewPatientForm() {
            FormName.SendKeys(Constant.fieldName);
            utility.ClickDropdownAndEnter(FormSelectDepartment);
            utility.ClickDropdownAndEnter(FormSelectCategory);
            FormTitle.SendKeys(Constant.fieldName);
            FillFormWithComponents();
            SaveForm.ClickOn();
            softAssert.VerifySuccessMsg();
        }

        public void FillFormWithComponents() {
            int totalComponent = 5;
        
            for (int i = 1; i <= totalComponent; i++)
            {
                IWebElement FormComponentDrag = Browser.Driver.FindElement(By.XPath("//*[@id='form-builder-toolbox']/div[" + i + "]/div"));

                (new Actions(Browser.chromebDriver)).ClickAndHold(FormComponentDrag).MoveToElement(FormComponentAreaDrop)
                    .DragAndDrop(FormComponentDrag, FormComponentAreaDrop).Perform();
                Thread.Sleep(500);
            }
        }
    }
}
