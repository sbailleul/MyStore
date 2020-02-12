using Microsoft.AspNetCore.Mvc;

namespace MyStore.Web.Framework
{
    public abstract class StoreMvcController : Controller
    {
        // Fake user Id for now, there are so many ways to do this, and it's out of scope for this demo
        protected int UserId => 1;
    }
}
