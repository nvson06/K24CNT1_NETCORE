using Microsoft.AspNetCore.Mvc;

namespace NvsLessson06.ViewComponnent
{
    public class CategaryViewController : ViewComponent
    {
        public iviewComponetResult Invoke()
        {
            return View();
        }
    }
}
