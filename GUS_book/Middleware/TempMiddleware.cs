using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GUS_book.Middleware
{
    public class TempMiddleware
    {
        private readonly RequestDelegate Next;
        private string Action;
        public TempMiddleware(RequestDelegate next, string ActionName)
        {
            this.Next = next;
            this.Action = ActionName;           
        }

        public async Task InvokeAsync(HttpContext context)
        {
            ITempDataDictionaryFactory factory = context.RequestServices.GetService(typeof(ITempDataDictionaryFactory)) as ITempDataDictionaryFactory;
            TempDataDictionary TempData = factory.GetTempData(context) as TempDataDictionary;

            if (TempData != null && TempData.Remove(Action + "_Errors" + "_old") == true)
            {
                TempData.Remove(Action + "_Errors");
            }
            await Next.Invoke(context);
            
        }
    }
}
