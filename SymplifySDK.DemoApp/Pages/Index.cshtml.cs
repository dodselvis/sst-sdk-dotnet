﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using SymplifySDK.Cookies;
using SymplifySDK.DemoApp.Services;

namespace SymplifySDK.DemoApp.Pages
{
    public class IndexModel : PageModel, ICookieJar
    {
        public readonly ISymplifyService _service;
        public SymplifyClient client;

        public IndexModel(ISymplifyService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            client = _service.GetClient();
        }

        // Needed because the index model is the cookieJar and have to  implement the GetCookie method 
        public string GetCookie(string name)
        {
            return Request.Cookies[name];
        }

        // Needed because the index model is the cookieJar and have to  implement the SetCookie method 
        public void SetCookie(string name, string value)
        {
            Response.Cookies.Append(name, value);
        }
    }
}
