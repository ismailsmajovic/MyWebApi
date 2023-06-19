
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApi.Models
{
    public class Document
    {
        private static int DocumentIdCount = 0;
        private static List<Document> documents = new List<Document>();

        public int DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
        public string FilePath { get; set; }
        public DateTime CreationDate { get; set; }

        public static Document CreateDocument(string documentType, string documentName, string filePath)
        {
            int documentId = GenerateDocumentId();

            Document document = new Document
            {
                DocumentId = documentId,
                DocumentType = documentType,
                DocumentName = documentName,
                FilePath = filePath,
                CreationDate = DateTime.Now
            };

            AddDocument(document);

            return document;
        }

        public static void DeleteDocument(int documentId)
        {
            RemoveDocument(documentId);
        }

        private static int GenerateDocumentId()
        {
            DocumentIdCount++;
            return DocumentIdCount;
        }

        private static void AddDocument(Document document)
        {
            documents.Add(document);
        }

        private static void RemoveDocument(int documentId)
        {
            var document = documents.FirstOrDefault(d => d.DocumentId == documentId);
            if (document != null)
            {
                documents.Remove(document);
            }
        }
    }
}
