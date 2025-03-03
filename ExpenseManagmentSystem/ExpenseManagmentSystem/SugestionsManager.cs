using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagmentSystem
{
    class SugestionsManager
    {
        #region Singleton
        private static SugestionsManager _instance = null;

        private SugestionsManager()
        {
        }
        public static SugestionsManager GetManager()
        {
            if (_instance == null)
            {
                _instance = new SugestionsManager();
            }
            return _instance;
        }
        #endregion

        public List<string> GetVendorSuggestions() 
        {
            List<string> vendorNames = new List<string>();
            List<Expense> expenses = DataBaseManager.GetManager().GetExpenses();
            foreach (var item in expenses) 
            {
                string vendor = item.Vendor;
                if (vendorNames.Contains(vendor) == false) 
                {
                    vendorNames.Add(vendor);
                }
            }

            return vendorNames;
        }

        public List<string> GetDescriptionSuggestions() 
        {
            List<string> descriptions = new List<string>();
            List<Expense> expenses = DataBaseManager.GetManager().GetExpenses();
            foreach (var item in expenses)
            {
                string descrition = item.Description;
                if (descriptions.Contains(descrition) == false)
                {
                    descriptions.Add(descrition);
                }
            }


            return descriptions;
        }
    }
}
