using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private List<Document> documents;

        public DocumentController()
        {
            documents = new List<Document>();
        }

        [HttpGet]
        public ActionResult GetAllDocuments()
        {
            return Ok(documents);
        }

        [HttpGet("{documentId}")]
        public ActionResult GetDocumentById(int documentId)
        {
            var document = documents.FirstOrDefault(d => d.DocumentId == documentId);
            if (document != null)
            {
                return Ok(document);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult CreateDocument([FromBody] Document document)
        {
            documents.Add(document);
            return Ok();
        }

        [HttpDelete("{documentId}")]
        public ActionResult DeleteDocument(int documentId)
        {
            var document = documents.FirstOrDefault(d => d.DocumentId == documentId);
            if (document != null)
            {
                documents.Remove(document);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
