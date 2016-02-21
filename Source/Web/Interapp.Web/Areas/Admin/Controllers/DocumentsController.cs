namespace Interapp.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts;
    using ViewModels.Documents;

    public class DocumentsController : Controller
    {
        private IDocumentsService documents;

        public DocumentsController(IDocumentsService documents)
        {
            this.documents = documents;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult DocumentsRead([DataSourceRequest]DataSourceRequest request)
        {
            var model = this.documents.All().To<DocumentViewModel>();
            DataSourceResult result = model.ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DocumentsUpdate([DataSourceRequest]DataSourceRequest request, DocumentViewModel document)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Document
                {
                    Id = document.Id,
                    Name = document.Name,
                    Content = document.Content
                };

                this.documents.Update(entity);
            }

            return this.Json(new[] { document }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DocumentsDestroy([DataSourceRequest]DataSourceRequest request, DocumentViewModel document)
        {
            this.documents.Delete(document.Id);

            return this.Json(new[] { document }.ToDataSourceResult(request, this.ModelState));
        }
    }
}