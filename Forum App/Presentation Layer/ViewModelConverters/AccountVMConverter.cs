using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Layer;
using Presentation_Layer.ViewModels;
using Forum_App.Models.Data;

namespace Presentation_Layer.ViewModelConverters
{
    public class AccountVMConverter : IViewModelConverter<Account, AccountDetailVM>
    {
        public List<AccountDetailVM> ModelsToViewModels(List<Account> models)
        {
            throw new NotImplementedException();
        }

        public AccountDetailVM ModelToViewModel(Account model)
        {
            AccountDetailVM vm = new AccountDetailVM()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                Username = model.Username
            };
            return vm;
        }

        public List<Account> ViewModelsToModels(List<AccountDetailVM> viewmodels)
        {
            throw new NotImplementedException();
        }

        public Account ViewModelToModel(AccountDetailVM viewmodel)
        {
            Account account = new Account()
            {
                FirstName = viewmodel.FirstName,
                LastName = viewmodel.LastName,
                Email = viewmodel.Email,
                Password = viewmodel.Password,
                Username = viewmodel.Username
            };
            return account;
        }
    }
}
