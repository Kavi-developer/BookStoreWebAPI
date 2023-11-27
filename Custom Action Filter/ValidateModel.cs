using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BooksStoreWebAPI.Custom_Action_Filter
{
    public class ValidateModel : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           
            if(context.ModelState.IsValid == false) {
                context.Result = new BadRequestResult();
            }
        }
    }
}
