﻿using Microsoft.AspNetCore.Mvc;

namespace SpaceWar.Controllers
{
    public class EmailsController : Controller
    {
        private readonly IEmailsServices _emailsServices;

        public EmailsController(IEmailsServices emailServices)
        {
            _emailsServices = emailServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailViewModel viewModel)
        {
            var dto = new EmailDto()
            {
                To = viewModel.To,
                Subject = viewModel.Subject,
                Body = viewModel.Body,
            };
            _emailsServices.SendEmail(dto);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult SendTokenEmail(EmailViewModel viewModel, string token)
        {
            var dto = new EmailTokenDto()
            {
                To = viewModel.To,
                Subject = viewModel.Subject,
                Body = viewModel.Body,
                Token = token
            };
            _emailsServices.SendEmailToken(dto, token);
            return RedirectToAction(nameof(Index));
        }
    }
}