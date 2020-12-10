using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum_App.Containers;
using Forum_App.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentation_Layer.ViewModelConverters;
using Presentation_Layer.ViewModels;

namespace Presentation_Layer.Controllers
{
    public class MessageController : Controller
    {
        private readonly AccountVMConverter accountVMConverter = new AccountVMConverter();
        private readonly AccountContainer accountContainer;
        private readonly MessageVMConverter messageVMConverter = new MessageVMConverter();
        private readonly MessageContainer messageContainer;
        public MessageController(AccountContainer aContainer, MessageContainer mContainer)
        {
            this.accountContainer = aContainer;
            this.messageContainer = mContainer;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("User") != null)
            {
                AccountDetailVM account = new AccountDetailVM();
                account = JsonConvert.DeserializeObject<AccountDetailVM>(HttpContext.Session.GetString("User"));

            }
            return View();
        }
        [HttpPost]
        public IActionResult SentMessages()
        {
            if (HttpContext.Session.GetInt32("User") != null)
            {
                AccountDetailVM account = new AccountDetailVM();
                account = JsonConvert.DeserializeObject<AccountDetailVM>(HttpContext.Session.GetString("User"));
                MessageViewModel vm = new MessageViewModel();
                List<Message> messages = new List<Message>();
                messages = messageContainer.GetAllBySender(account.Id);
                vm.Messages = messageVMConverter.ModelsToViewModels(messages);
                return View(vm);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public IActionResult ReceivedMessages()
        {
            if (HttpContext.Session.GetInt32("User") != null)
            {
                AccountDetailVM account = new AccountDetailVM();
                account = JsonConvert.DeserializeObject<AccountDetailVM>(HttpContext.Session.GetString("User"));
                MessageViewModel vm = new MessageViewModel();
                List<Message> messages = new List<Message>();
                messages = messageContainer.GetAllByReceiver(account.Id);
                vm.Messages = messageVMConverter.ModelsToViewModels(messages);
                return View(vm);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            MessageDetailVM vm = new MessageDetailVM();
            List<AccountDetailVM> accounts = new List<AccountDetailVM>();
            foreach(Account account in accountContainer.GetAll())
            {
                accounts.Add(accountVMConverter.ModelToViewModel(account));
            }
            Tuple<MessageDetailVM, List<AccountDetailVM>> tupleData = new Tuple<MessageDetailVM, List<AccountDetailVM>>(vm, accounts);
            return View(tupleData);
        }
        [HttpPost]
        public IActionResult SendMessage(MessageDetailVM vm)
        {
            if(HttpContext.Session.GetInt32("User") != null)
            {
                Account account = new Account();
                account = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("User"));
                Message message = messageVMConverter.ViewModelToModel(vm);
                message.SenderId = account.Id;
                messageContainer.Insert(message);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Login");
        }

    }
}
