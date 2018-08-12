using App.Models.Contracts;
using App.Models.Enums;
using Terminal.Gui;

namespace App.Core.Views
{
    public class SupplementsChoiceView : View
    {
        private CheckBox firstSupplement;
        private CheckBox secondSupplement;
        private CheckBox thirdSupplement;

        private SupplementCategoryType firstSupllType;
        private SupplementCategoryType secondSupllType;
        private SupplementCategoryType thirdSupplType;

        public SupplementsChoiceView(ISupplement firstChoice, ISupplement secondChoice, ISupplement thirdChoice)
            : base()
        {
            this.InitializeViewElements();
        }

        public CheckBox FirstChoice => this.firstSupplement;
        public CheckBox SecondChoice => this.secondSupplement;
        public CheckBox Third => this.thirdSupplement;

        private void InitializeViewElements()
        {

        }
    }
}
