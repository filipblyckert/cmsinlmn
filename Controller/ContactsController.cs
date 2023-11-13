using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Wesite.ActionResults;
using Umbraco.Cms.Web.Website.Controllers;

public class ContactsController : SurfaceController
{
	public ContactsController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appcaches, IProfilingLogger, profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appcaches, profilingLogger, publishedUrlProvider)
	{
	}

	[HttpPost]
	public async Task<IActionResult> Index(ContactForm contactForm)
	{
		if (!ModelState.IsValid)
			return CurrentUmbracoPage();

		using var mail = new MailService();

		await mail.SendAsync(contactForm.Email, "Your request was received" "Hi, your request was received");


		await mail.SendAsync("");

        return LocalRedirect(contactForm.RedirectUrl ?? "/");
	}
}
